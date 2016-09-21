using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace SoundOryc.Desktop.Services
{
    public class WyMusic
    {
        
        public static string WyNewCookie = "__remember_me=true; MUSIC_U=5f9d910d66cb2440037d1c68e6972ebb9f15308b56bfeaa4545d34fbabf71e0f36b9357ab7f474595690d369e01fbb9741049cea1c6bb9b6; __csrf=8ea789fbbf78b50e6b64b5ebbb786176; os=uwp; osver=10.0.10586.318; appver=1.2.1; deviceId=0e4f13d2d2ccbbf31806327bd4724043";

        private static string GetEncHtml(string url, string text)
        {
            //AES加密参数参考了 https://github.com/darknessomi/musicbox
            //该处使用固定密钥，简化操作，效果与随机密钥一致
            const string secKey = "a44e542eaac91dce";
            var pad = 16 - text.Length % 16;
            for (var i = 0; i < pad; i++)
            {
                text = text + Convert.ToChar(pad);
            }
            var encText = AesEncrypt(AesEncrypt(text, "0CoJUm6Qyw8W8jud"), secKey);
            const string encSecKey = "411571dca16717d9af5ef1ac97a8d21cb740329890560688b1b624de43f49fdd7702493835141b06ae45f1326e264c98c24ce87199c1a776315e5f25c11056b02dd92791fcc012bff8dd4fc86e37888d5ccc060f7837b836607dbb28bddc703308a0ba67c24c6420dd08eec2b8111067486c907b6e53c027ae1e56c188bc568e";
            var data = new Dictionary<string, string>
            {
                {"params", encText},
                {"encSecKey"    , encSecKey},
            };
            var html = CommonHelper.PostData(url, data, 0, 0, new Dictionary<string, string>
            {
                {"Cookie", WyNewCookie}
            });
            return html;
        }

        private static string AesEncrypt(string toEncrypt, string key, string iv = "0102030405060708")
        {
            var keyArray = Encoding.UTF8.GetBytes(key);
            var ivArr = Encoding.UTF8.GetBytes(iv);
            var toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            using (var aesDel = Aes.Create())
            {
                aesDel.IV = ivArr;
                aesDel.Key = keyArray;
                aesDel.Mode = CipherMode.CBC;
                aesDel.Padding = PaddingMode.PKCS7;
                var cTransform = aesDel.CreateEncryptor();
                var resultArr = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return Convert.ToBase64String(resultArr, 0, resultArr.Length);
            }
        }

    }

    public class CommonHelper
    {
        public static string IpAddr = "127.0.0.1";
        public static string SignKey = "$$itwusun.com$$";


        public static string GetHtmlContent(string url, int userAgent = 0, Dictionary<string, string> headers = null, bool isDecode = true)
        {
            try
            {
                var myHttpWebRequest = new HttpClient { Timeout = new TimeSpan(0, 0, 10) };
                myHttpWebRequest.DefaultRequestHeaders.Add("Method", "GET");
                myHttpWebRequest.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                switch (userAgent)
                {
                    case 1:
                        myHttpWebRequest.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 5_0 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko) Version/5.1 Mobile/9A334 Safari/7534.48.3");
                        break;
                    case 2:
                        myHttpWebRequest.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Linux; U; Android 2.2; en-gb; GT-P1000 Build/FROYO) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1");
                        break;
                    case 3:
                        myHttpWebRequest.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows Phone 10.0; Android 4.2.1; NOKIA; Lumia 930) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2486.0 Mobile Safari/537.36 Edge/13.10586");
                        break;
                    case 4:
                        myHttpWebRequest.DefaultRequestHeaders.Add("User-Agent", "NativeHost");
                        break;
                    default:
                        myHttpWebRequest.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36");
                        break;
                }
                if (headers != null)
                {
                    foreach (var k in headers)
                    {
                        myHttpWebRequest.DefaultRequestHeaders.Add(k.Key, k.Value);
                    }
                }
                var result = myHttpWebRequest.GetStringAsync(url).Result;
                return isDecode ? WebUtility.HtmlDecode(result) : result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string PostData(string url, Dictionary<string, string> data, int contentType = 0, int userAgent = 0, Dictionary<string, string> headers = null, bool isDecode = true)
        {
            try
            {
                var myHttpWebRequest = new HttpClient { Timeout = new TimeSpan(0, 0, 5) };
                myHttpWebRequest.DefaultRequestHeaders.Add("Method", "POST");
                myHttpWebRequest.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                myHttpWebRequest.DefaultRequestHeaders.Add("ContentType",
                    userAgent == 0 ? "application/x-www-form-urlencoded" : "application/json;charset=UTF-8");
                switch (userAgent)
                {
                    case 1:
                        myHttpWebRequest.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 5_0 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko) Version/5.1 Mobile/9A334 Safari/7534.48.3");
                        break;
                    case 2:
                        myHttpWebRequest.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Linux; Android 4.0.4; Galaxy Nexus Build/IMM76B) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.133 Mobile Safari/535.19");
                        break;
                    case 3:
                        myHttpWebRequest.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows Phone 8.0; Trident/6.0; IEMobile/10.0; ARM; Touch; NOKIA; Lumia 920)");
                        break;
                    case 4:
                        myHttpWebRequest.DefaultRequestHeaders.Add("User-Agent", "NativeHost");
                        break;
                    default:
                        myHttpWebRequest.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36");
                        break;
                }
                if (headers != null)
                {
                    foreach (var k in headers)
                    {
                        myHttpWebRequest.DefaultRequestHeaders.Add(k.Key, k.Value);
                    }
                }
                var response = contentType == 0
                    ? myHttpWebRequest.PostAsync(url, new FormUrlEncodedContent(data)).Result
                    : myHttpWebRequest.PostAsync(url, new StringContent(data[data.Keys.First()], Encoding.UTF8)).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return isDecode ? WebUtility.HtmlDecode(result) : result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}