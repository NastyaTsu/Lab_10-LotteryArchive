using LotteryArchive.Model.Core;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Xml;

namespace Model.Data
{
    public class XmlSerializer : Serializer
    {

        public override List<string> DeserializeLottery(string file)
        {
            List<string> lines = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            XmlNode root = doc.SelectSingleNode("LotteryResult");
            if (root == null)
                return lines; // или выбросить исключение

            string GetNodeText(string nodeName)
            {
                var node = root.SelectSingleNode(nodeName);
                return node?.InnerText ?? "";
            }

            lines.Add(GetNodeText("Название_лотереи"));
            lines.Add(GetNodeText("Количество_участников"));
            lines.Add(GetNodeText("Количество_билетов"));
            lines.Add(GetNodeText("Призовой_фонд"));
            lines.Add(GetNodeText("Цена_билета"));
            lines.Add(GetNodeText("Победитель"));
            lines.Add(GetNodeText("ID_победителя"));
            lines.Add(GetNodeText("Дата_проведения"));

            return lines;
        }

        public override void SerializeLottery<T>(T loter, WinningTicket TicetWin)
        {
            if (loter == null || TicetWin == null) return;

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "Статистика");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileName = $"{loter.Name}_{DateTime.Now:yyyyMMddHHmmss}.xml";
            string fullPath = Path.Combine(folderPath, fileName);

            using (XmlWriter writer = XmlWriter.Create(fullPath, new XmlWriterSettings { Indent = true }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("LotteryResult");

                writer.WriteElementString("Название_лотереи", loter.Name);
                writer.WriteElementString("Количество_участников", loter.Colparticipants.ToString());
                writer.WriteElementString("Количество_билетов", loter.Totaltickets.ToString());
                writer.WriteElementString("Призовой_фонд", loter.Prizefond.ToString());
                writer.WriteElementString("Цена_билета", loter.Price.ToString());
                writer.WriteElementString("Победитель", TicetWin.Owner.Fullname);
                writer.WriteElementString("ID_победителя", TicetWin.Id.ToString());
                writer.WriteElementString("Дата_проведения", DateTime.Now.ToString("o")); // ISO 8601 формат

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
