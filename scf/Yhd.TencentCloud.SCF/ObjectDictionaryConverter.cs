
// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using Microsoft.Extensions.Configuration;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Yhd.TencentCloud.SCF
{
    internal static class ObjectDictionaryConverter
    {
        public static IDictionary<string, object> AsDictionary(object values)
        {
            if (values == null)
            {
                return null;
            }

            IDictionary<string, object> valuesAsDictionary = values as IDictionary<string, object>;

            if (valuesAsDictionary != null)
            {
                return valuesAsDictionary;
            }

            IDictionary valuesAsNonGenericDictionary = values as IDictionary;

            if (valuesAsNonGenericDictionary != null)
            {
                throw new InvalidOperationException("Argument dictionaries must implement IDictionary<string, object>.");
            }

            IDictionary<string, object> dictionary = new Dictionary<string, object>();

            foreach (PropertyHelper property in PropertyHelper.GetProperties(values))
            {
                // Extract the property values from the property helper
                // The advantage here is that the property helper caches fast accessors.
                dictionary.Add(property.Name, property.GetValue(values));
            }

            return dictionary;
        }

        public static string DictToString<T, V>(IEnumerable<KeyValuePair<T, V>> items, string format = "")
        {
            format = String.IsNullOrEmpty(format) ? "{0}='{1}' " : format;

            StringBuilder itemString = new StringBuilder();
            foreach (var item in items)
                itemString.AppendFormat(format, item.Key, item.Value);

            return itemString.ToString();
        }
    }
}
