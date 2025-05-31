using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LotteryArchive.Model.Data
{
    public class XmlSerializer : Serializer
    {
        private Type type;

        public XmlSerializer(Type type)
        {
            this.type = type;
        }

        public override void Serialize<T>(T data, string filePath)
        {
            EnsureDirectoryExists(filePath);
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, data);
            }
        }

        private void Serialize<T>(StreamWriter writer, T? data)
        {
            throw new NotImplementedException();
        }

        public override T Deserialize<T>(string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(filePath))
            {
                return (T)serializer.Deserialize<T>(reader);
            }
        }

        private T Deserialize<T>(StreamReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
