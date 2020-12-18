using MilitaryElite.Contracts;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICollection<ISoldier> soldiers;

        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string comand;
            while ((comand = this.reader.ReadLine()) != "End")
            {
                try
                {
                    var args = comand.Split();
                    var soldierType = args[0];
                    var iD = int.Parse(args[1]);
                    var firstName = args[2];
                    var lastName = args[3];
                    if (soldierType == "Private")
                    {
                        var salary = decimal.Parse(args[4]);
                        soldiers.Add(new Private(iD, firstName, lastName, salary));
                    }
                    else if (soldierType == "LieutenantGeneral")
                    {
                        var salary = decimal.Parse(args[4]);
                        var leitenant = new LieutenantGeneral(iD, firstName, lastName, salary);
                        for (int i = 5; i < args.Length; i++)
                        {
                            var currID = int.Parse(args[i]);
                            Private currPrivate = (Private)soldiers.FirstOrDefault(x => x.ID == currID);
                            leitenant.AddPrivate(currPrivate);
                        }
                        soldiers.Add(leitenant);
                    }
                    else if (soldierType == "Engineer")
                    {
                        var salry = decimal.Parse(args[4]);
                        var corps = args[5];
                        Engineer engineer = new Engineer(iD, firstName, lastName, salry, corps);
                        for (int i = 6; i < args.Length; i += 2)
                        {
                            var partName = args[i];
                            var hoursWork = int.Parse(args[i + 1]);
                            var currRepair = new Repair(partName, hoursWork);
                            engineer.AddRepair(currRepair);
                        }
                        soldiers.Add(engineer);
                    }
                    else if (soldierType == "Commando")
                    {
                        var salry = decimal.Parse(args[4]);
                        var corps = args[5];
                        var commando = new Commando(iD, firstName, lastName, salry, corps);
                        for (int i = 6; i < args.Length; i += 2)
                        {
                            var missionName = args[i];
                            var state = args[i + 1];
                            var mission = new Mission(missionName, state);
                            commando.CompleteMission(mission);
                        }
                        soldiers.Add(commando);
                    }
                    else if (soldierType == "Spy")
                    {
                        var codeNumber = int.Parse(args[4]);
                    }
                }
                catch (Exception ex)
                {

                    this.writer.WriteLine(ex.Message);
                }
                
            }
            foreach (var soldier in soldiers)
            {
                this.writer.WriteLine(soldier.ToString().TrimEnd());
            }
        }
    }
}
