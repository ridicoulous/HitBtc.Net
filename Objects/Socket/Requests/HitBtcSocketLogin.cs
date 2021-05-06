using HitBtc.Net.Enums;
using Newtonsoft.Json;

namespace HitBtc.Net.Objects.Socket
{
    internal class HitBtcSocketLogin : HitBtcSocketSubscribeBaseRequest<LoginParams>
    {
        public HitBtcSocketLogin(LoginParams @params) : base(HitBtcSocketRequest.Login, @params)
        {
        }

        public override string EndpointSuffix => "account";
    }

    internal class LoginParams
    {
        /// <summary>
        /// Encryption algorithm
        /// Accepted values: BASIC or HS256
        /// </summary>
        [JsonProperty("algo")]
        public string Algorithm { get; set; }

        [JsonProperty("pKey")]
        public string Key { get; set; }

        /// <summary>
        /// Random string, required on HS256 algo
        /// </summary>
        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        /// <summary>
        /// API secret key, required on BASIC algo
        /// </summary>
        [JsonProperty("sKey")]
        public string SecretKey { get; set; }

        /// <summary>
        /// HMAC SHA256 sign nonce with API secret key, required on HS256 algo
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
}