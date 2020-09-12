using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace LBS.Amap.SDK
{
    internal static class DictionaryExtensions
    {
        public static string ToUriParam(this IDictionary<string, string> dict)
        {
            if (dict == null)
                throw new ArgumentNullException(nameof(dict));

            if (dict.Count <= 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in dict)
            {
                sb.Append(kv.Key);
                sb.Append("=");
                sb.Append(HttpUtility.UrlEncode(kv.Value));
                sb.Append("&");
            }

            return sb.Remove(sb.Length - 1, 1).ToString();
        }
    }
}
