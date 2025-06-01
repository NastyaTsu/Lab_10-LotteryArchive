using LotteryArchive.Model.Core;
using Model.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Model.Data
{
    public class JsonSerializer : Serializer
    {
        public string Filename { get; set; }
        public override List<dynamic> DeserializeLottery()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "Статистика");

            if (!Directory.Exists(folderPath))
            {
                return null;
            }

            var jsonFiles = Directory.GetFiles(folderPath, Filename);
            if (jsonFiles.Length == 0)
            {
                return null;
            }

            var allResults = new List<dynamic>();

            foreach (var file in jsonFiles)
            {
                string json = File.ReadAllText(file);
                var result = JsonConvert.DeserializeObject<dynamic>(json);
                if (result != null)
                    allResults.Add(result);
            }
            return allResults;
        }

        public override LotteryParticipant DeserializeParticipant(string fileName)
        {
            throw new NotImplementedException();
        }

        public override void SerializeLottery(Lottery loter, WinningTicket TicetWin)
        {
            if (loter == null) return;

            // Указываем путь к рабочему столу
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "Статистика");

            // Создаем папку если не существует
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Уникальное имя файла
            Filename = $"{loter.Name}_{DateTime.Now:yyyyMMddHHmmss}";

            if (TicetWin == null) return;

            LotteryParticipant person = TicetWin.Owner;

            var result = new
            {
                Название_лотереи = loter.Name,
                Количество_участников = loter.Colparticipants,
                Количество_билетов = loter.Totaltickets,
                Призовой_фонд = loter.Prizefond,
                Цена_билета = loter.Price,
                Победитель = person.Fullname,
                ID_победителя = TicetWin.Id,
                Дата_проведения = DateTime.Now
            };

            string json = JsonConvert.SerializeObject(result, (Newtonsoft.Json.Formatting)System.Xml.Formatting.Indented);
            string fullPath = Path.Combine(folderPath, Filename + ".json");

            File.WriteAllText(fullPath, json);
        }

        public override void SerializeParticipant(LotteryParticipant participant)
        {
            throw new NotImplementedException();
        }
    }
}
