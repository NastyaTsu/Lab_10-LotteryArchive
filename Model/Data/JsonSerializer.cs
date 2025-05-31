using LotteryArchive.Model.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace LotteryArchive.Model.Data
{
    public class JsonSerializer : Serializer
    {
        public override void Serialize<T>(T data, string filePath)
        {
            EnsureDirectoryExists(filePath);
            string json = JsonConvert.SerializeObject(data, (Newtonsoft.Json.Formatting)System.Xml.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public override T Deserialize<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
