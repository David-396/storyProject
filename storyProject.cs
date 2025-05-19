using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story
{
    internal class EmergencyReport
    {
        private string IncidentType;
        private string City;
        private int HowSerious;
        private int HowMightLast;
        private string Description;

        public string GetIncidentType()
        {
            return this.IncidentType;
        }

        public string GetCity()
        {
            return this.City;
        }

        public int GetHowSerious()
        {
            return this.HowSerious;
        }

        public int GetHowMightLast()
        {
            return this.HowMightLast;
        }

        public string GetDescription()
        {
            return this.Description;
        }

    }


    internal abstract class EmergencyTeamsParent
    {
        protected string Name;
        protected string region;
        protected bool flag;

        public EmergencyTeamsParent(string Name, string region, bool flag)
        {
            this.Name = Name;
            this.region = region;
            this.flag = flag;
        }

        public string GetName()
        {
            return this.Name;
        }

        public string GetRegion()
        {
            return this.region;
        }
        
        public bool GetFlag()
        {
            return this.flag;
        }

        public virtual bool ifCanHelp()
        {
            return false;
        }

    }


    internal class Floods : EmergencyTeamsParent
    {
        public Floods(string Name, string region, bool flag) : base(Name, region, flag) { }

        public override bool ifCanHelp()
        {
            return this.flag;
        }
    }


    internal class Injuries : EmergencyTeamsParent
    {
        public Injuries(string Name, string region, bool flag) : base(Name, region, flag) { }

        public override bool ifCanHelp()
        {
            return this.flag;
        }
    }


    internal class Blockages : EmergencyTeamsParent
    {
        public Blockages(string Name, string region, bool flag) : base(Name, region, flag) { }

        public override bool ifCanHelp()
        {
            return this.flag;
        }
    }



    internal class DispatchCenter
    {
        private List<EmergencyReport> rprtLst;
        private List<EmergencyTeamsParent> tmsLst;

        public DispatchCenter() { }

        public bool AddRprt(EmergencyReport report)
        {
            this.rprtLst.Add(report);
            return true;
        }

        public bool AddTeam(EmergencyTeamsParent team)
        {
            this.tmsLst.Add(team);
            return true;
        }



        public void FindAvailableTeam(EmergencyReport report)
        {
            foreach(EmergencyTeamsParent team in tmsLst)
            {
                if (team.GetType().ToString() == report.GetIncidentType() && team.GetFlag() && team.GetRegion() == report.GetCity())
                {
                    Console.WriteLine($"{team.GetName()} team was sent");
                }
            }
            Console.WriteLine("no one available");
        }


    }
}
