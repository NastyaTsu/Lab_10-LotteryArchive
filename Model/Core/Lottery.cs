﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LotteryArchive.Model.Core
{
    public partial class Lottery
    {
        
        public string Name { get; set; }
        public int Totaltickets { get; set; }
        public int Prizefond { get; set; }
        public int Colparticipants { get; set; }
        private List<Ticket> _ticket;
        public List<Ticket> Massivticket
        {
            get
            {
                List<Ticket> list = new List<Ticket>();
                foreach (var ticket in _ticket)
                {
                    list.Add(ticket);
                }
                return list;
            }
        }

        public Lottery(string name, int totaltickets, int prizefond, int colparticipants, int price)
        {
            Name = name;
            Totaltickets = totaltickets;
            Prizefond = prizefond;
            Colparticipants = colparticipants;
            _ticket = new List<Ticket>(Totaltickets);
            Price = price;
        }
        public Lottery()
        {

        }
        public void DistributeTickets(List<LotteryParticipant> participants)
        {
            _ticket.Clear();
            Random random = new Random();

            // Равномерно распределяем билеты между участниками
            int ticketsPerParticipant = Totaltickets / participants.Count;
            int remainingTickets = Totaltickets % participants.Count;

            foreach (var participant in participants)
            {
                int ticketsToAssign = ticketsPerParticipant;
                if (remainingTickets > 0)
                {
                    ticketsToAssign++;
                    remainingTickets--;
                }

                for (int i = 0; i < ticketsToAssign; i++)
                {
                    _ticket.Add(new Ticket(this, participant));
                }
            }
        }
    }
}
