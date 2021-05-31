using Newtonsoft.Json;
using System;

namespace ConsoleApp8
{
    public static class StringExtension
    {
        public static T As<T>(this string text)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(text);
            }
            catch (JsonException innerException)
            {
                throw new Exception("Incorrect JSON", innerException);
            }
        }
    }
}
