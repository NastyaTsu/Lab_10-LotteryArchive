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
        public override List<string> DeserializeLottery(string file)
        {
            List<string> lines = new List<string>();
            string json = File.ReadAllText(file);
            var obj = JObject.Parse(json);

            string lotteryName = (string)obj["Название_лотереи"] ?? "";
            string participants = (string)obj["Количество_участников"];
            string tickets = (string)obj["Количество_билетов"];
            string prizeFund = (string)obj["Призовой_фонд"];
            string ticketPrice = (string)obj["Цена_билета"];
            string winner = (string)obj["Победитель"] ?? "";
            string winnerId = (string)obj["ID_победителя"] ?? "";
            string date = (string)obj["Дата_проведения"];

            lines.Add(lotteryName);
            lines.Add(participants);
            lines.Add(tickets);
            lines.Add(prizeFund);
            lines.Add(ticketPrice);
            lines.Add(winner);
            lines.Add(winnerId);
            lines.Add(date);


            return lines;
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
    }
}
