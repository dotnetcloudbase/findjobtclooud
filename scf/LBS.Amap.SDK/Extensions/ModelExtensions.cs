using LBS.Amap.SDK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LBS.Amap.SDK
{
    internal static class ModelExtensions
    {
        public static string ToUriParam(this BaseParameter obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            PropertyInfo[] propertis = obj.GetType().GetProperties();
            SortedDictionary<string, string> paramDict = new SortedDictionary<string, string>();
            foreach (var p in propertis)
            {
                var v = p.GetValue(obj, null);
                if (v == null)
                    continue;

                paramDict.Add(GetName(p), v.ToString());
            }

            return paramDict.ToUriParam();
        }

        private static string GetName(PropertyInfo p)
        {
            DisplayAttribute attribute = p.GetCustomAttribute<DisplayAttribute>();
            return attribute != null ? attribute.Name : p.Name;
        }
    }
}
