using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Promotion.Library
{
    public static class Utility
    {
        public static string Serialize<T>(T data) where T : class
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            return JsonConvert.SerializeObject(data,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }

        public static T Deserialize<T>(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new ArgumentNullException(nameof(data));
            try
            {
                return JsonConvert.DeserializeObject<T>(data,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
            }
            catch (Exception ex)
            {
                var exceptionMessage = string.Format(ErrorMessages.DeserializationError, data, typeof(T));
                throw new PromotionException(exceptionMessage, ex);
            }
        }

        public static string DecodeBase64(string data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            return Encoding.UTF8.GetString(Convert.FromBase64String(data));
        }

        public static string EncodeBase64(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new ArgumentNullException(nameof(data));
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        }

        public static async Task<bool> WaitUntilAsync(Func<Task<bool>> func, int timeoutInSecs = 300)
        {
            DateTime stopAt = DateTime.Now + TimeSpan.FromSeconds(timeoutInSecs);
            while (true)
            {
                var result = await func().ConfigureAwait(false);
                if (result)
                {
                    return true;
                }

                if (DateTime.Now >= stopAt)
                    return false;
            }
        }
    }
}
