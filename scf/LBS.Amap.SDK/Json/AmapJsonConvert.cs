using Newtonsoft.Json;
using System.Xml;

namespace LBS.Amap.SDK.Json
{
    internal static class AmapJsonConvert
    {
        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, new AmapStringConverter());
        }

        public static T DeserializeXmlObject<T>(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return default(T);

            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.LoadXml(xml);
            AddJsonNetRootAttribute(XmlDoc);
            AddJsonArrayAttributesForXPath(XmlDoc);
            var json = JsonConvert.SerializeXmlNode(XmlDoc);
            return JsonConvert.DeserializeObject<XmlResponse<T>>(json).Data;
        }

        class XmlResponse<T>
        {
            [JsonProperty("response")]
            public T Data { get; set; }
        }

        private static void AddJsonNetRootAttribute(XmlDocument xmlD)
        {
            XmlAttribute jsonNS = xmlD.CreateAttribute("xmlns", "json", "http://www.w3.org/2000/xmlns/");
            jsonNS.Value = "http://james.newtonking.com/projects/json";
            xmlD.DocumentElement.SetAttributeNode(jsonNS);
        }

        private static void AddJsonArrayAttributesForXPath(XmlDocument doc)
        {
            var elements = doc.SelectNodes("//*[@type='list']");
            foreach (var element in elements)
            {
                var el = element as XmlElement;
                if (el != null)
                {
                    var jsonArray = doc.CreateAttribute("json", "Array", "http://james.newtonking.com/projects/json");
                    jsonArray.Value = "true";
                    el.SetAttributeNode(jsonArray);
                }
            }
        }
    }
}
