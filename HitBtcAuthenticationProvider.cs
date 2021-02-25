using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace HitBtc.Net
{
    public class HitBtcAuthenticationProvider : AuthenticationProvider
    {
        private readonly HMACSHA256 encryptor;
        public HitBtcAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
            encryptor = new HMACSHA256(Encoding.ASCII.GetBytes(credentials.Secret.GetString()));
        }

        private static readonly object nonceLock = new object();
        private long lastNonce;
        public long TimeStamp
        {
            get
            {
                lock (nonceLock)
                {
                    var nonce = (long)Math.Round((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
                    if (nonce == lastNonce)
                        nonce += 1;

                    lastNonce = nonce;
                    return lastNonce;
                }
            }
        }
        //Create hmac signature with secretKey as a key and sign request "method+timestamp+url+body"
        //Like as basic authorization add header "Authorization: HS256 " + base64(publicKey+":"+timestamp+":"+signature hex encoded)
        public override Dictionary<string, string> AddAuthenticationToHeaders(string uri, HttpMethod method, Dictionary<string, object> parameters, bool signed, PostParameters postParameters, ArrayParametersSerialization arrayParametersSerialization)
        {
            var time = TimeStamp;

            if (!signed)
                return new Dictionary<string, string>();
            var result = new Dictionary<string, string>();          
            string additionalData = String.Empty;
            if (parameters != null && parameters.Any() && method != HttpMethod.Delete && method != HttpMethod.Get)
            {
                additionalData = JsonConvert.SerializeObject(parameters.ToDictionary(p => p.Key, p => p.Value));
            }
            var dataToSign = CreateAuthPayload(method, time, uri.Split(new[] { ".com" }, StringSplitOptions.None)[1],  additionalData);
            var signedData = Sign(dataToSign);
            var b64 = Base64Encode($"{Credentials.Key.GetString()}:{time}:{signedData}");
            result.Add("Authorization", $"HS256 {b64}");
            return result;
        }
        public string ByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);
            foreach (var b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        public override string Sign(string toSign)
        {
            return  ByteArrayToString(encryptor.ComputeHash(Encoding.UTF8.GetBytes(toSign)));
        }
      
        private string CreateAuthPayload(HttpMethod method, long time, string requestUrl,  string body = "")
        {
            return $"{method}{time}{requestUrl}{body}";
        }
        private  string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
