using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KamashevApplication1.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public ushort Games { get; set; }
        public ushort Score { get; set; }

        //[JsonIgnore]
        //public List<Footballer> Footballers { get; set; }

        /*public Team()
        {
            Footballers = new List<Footballer>();
        }*/
    }
}
