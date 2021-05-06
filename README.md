# HitBtc.Net 

[![build](https://github.com/ridicoulous/HitBtc.Net/actions/workflows/main.yml/badge.svg)](https://github.com/ridicoulous/HitBtc.Net/actions/workflows/main.yml)

HitBtc.Net.Client is a .Net wrapper for the HitBtc API as described on [HitBtc](https://api.hitbtc.com/). It includes all features the API provides using clear and readable C# objects including 
* Reading market info
* Placing and managing orders
* Reading balances and funds
* Live updates using the websocket

Additionally it adds some convenience features like:
* Configurable rate limiting
* Autmatic logging
## Installation
![Nuget version](https://img.shields.io/nuget/v/HitBtc.Net.Client.svg) ![Nuget downloads](https://img.shields.io/nuget/dt/HitBtc.Net.Client.svg)

Available on [NuGet](https://www.nuget.org/packages/HitBtc.Net.Client/):
```
PM> Install-Package HitBtc.Net.Client
```
To get started with HitBtc.Net.Client first you will need to get the library itself. The easiest way to do this is to install the package into your project using [NuGet](https://www.nuget.org/packages/HitBtc.Net.Client/).

## Getting started
To get started we have to add the HitBtc.Net.Client namespace:  `using HitBtc.Net;`.

HitBtc.Net.Client provides three clients to interact with the HitBtc API:

The `HitBtcClient` provides all rest API calls.

The `HitBtcSocketClient` provides functions to interact with the websocket provided by the HitBtc API.

See [examples here](https://github.com/ridicoulous/HitBtc.Net/blob/master/Example/HitBtc.Net.Example/Program.cs). 

**If you think something is broken, something is missing or have any questions, please open an [Issue](https://github.com/ridicoulous/HitBtc.Net.Client/issues)**

## CryptoExchange.Net
Implementation is build upon the CryptoExchange.Net library, make sure to also check out the documentation on that: [docs](https://github.com/JKorf/CryptoExchange.Net)

Other CryptoExchange.Net implementations:
<table>
<tr>
<td><a href="https://github.com/JKorf/Bitfinex.Net"><img src="https://github.com/JKorf/Bitfinex.Net/blob/master/Bitfinex.Net/Icon/icon.png?raw=true"></a>
<br />
<a href="https://github.com/JKorf/Bitfinex.Net">Bitfinex</a>
</td>
<td><a href="https://github.com/JKorf/Bittrex.Net"><img src="https://github.com/JKorf/Bittrex.Net/blob/master/Bittrex.Net/Icon/icon.png?raw=true"></a>
<br />
<a href="https://github.com/JKorf/Bittrex.Net">Bittrex</a>
</td>
<td><a href="https://github.com/JKorf/Binance.Net"><img src="https://github.com/JKorf/Binance.Net/blob/master/Binance.Net/Icon/icon.png?raw=true"></a>
<br />
<a href="https://github.com/JKorf/Binance.Net">Binance</a>
</td>
<td><a href="https://github.com/JKorf/CoinEx.Net"><img src="https://github.com/JKorf/CoinEx.Net/blob/master/CoinEx.Net/Icon/icon.png?raw=true"></a>
<br />
<a href="https://github.com/JKorf/CoinEx.Net">CoinEx</a>
</td>
<td><a href="https://github.com/JKorf/Huobi.Net"><img src="https://github.com/JKorf/Huobi.Net/blob/master/Huobi.Net/Icon/icon.png?raw=true"></a>
<br />
<a href="https://github.com/JKorf/Huobi.Net">Huobi</a>
</td>
<td><a href="https://github.com/JKorf/Kucoin.Net"><img src="https://github.com/JKorf/Kucoin.Net/blob/master/Kucoin.Net/Icon/icon.png?raw=true"></a>
<br />
<a href="https://github.com/JKorf/Kucoin.Net">Kucoin</a>
</td>
<td><a href="https://github.com/JKorf/Kraken.Net"><img src="https://github.com/JKorf/Kraken.Net/blob/master/Kraken.Net/Icon/icon.png?raw=true"></a>
<br />
<a href="https://github.com/JKorf/Kraken.Net">Kraken</a>
</td>
<td><a href="https://github.com/Zaliro/Switcheo.Net"><img src="https://github.com/Zaliro/Switcheo.Net/blob/master/Resources/switcheo-coin.png?raw=true"></a>
<br />
<a href="https://github.com/Zaliro/Switcheo.Net">Switcheo</a>
</td>
<td><a href="https://github.com/ridicoulous/LiquidQuoine.Net"><img src="https://github.com/ridicoulous/LiquidQuoine.Net/blob/master/Resources/icon.png?raw=true"></a>
<br />
<a href="https://github.com/ridicoulous/LiquidQuoine.Net">Liquid</a>
</td>
<td><a href="https://github.com/burakoner/OKEx.Net"><img src="https://raw.githubusercontent.com/burakoner/OKEx.Net/master/Okex.Net/Icon/icon.png"></a>
<br />
<a href="https://github.com/burakoner/OKEx.Net">OKEx</a>
</td>
<td><a href="https://github.com/d-ugarov/Exante.Net"><img src="https://github.com/d-ugarov/Exante.Net/blob/master/Exante.Net/Icon/icon.png?raw=true"></a>
<br />
<a href="https://github.com/d-ugarov/Exante.Net">Exante</a>
</td>
</tr>
</table>

## Changelog
* 05/06/2021 - IExchangeClient recent trades changed to public
* 03/18/2021 - IExchangeClient common interface implementation
* 03/09/2021 - socket, more api methods implemented
* 02/27/2021 - Initial release

## Donations
Donations are greatly appreciated and a motivation to keep improving.

**Btc**:  14nuXrFEKTrvyhHWYW7RgRt4zVxBfwff5V  
**Eth**:  0x7CD82F45b173891e36d68ea4311B8b13A11a3B4b
