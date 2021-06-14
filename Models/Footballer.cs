using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using KamashevApplication1.Models;

namespace KamashevApplication1.Models
{
    public class Footballer
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Img { get; set; }
        public string Position { get; set; }
        public int TeamID { get; set; }     
        public string Nationality { get; set; }

        //[JsonIgnore]
        public Team Team { get; set; }

        /*public Footballer()
        {
            Team = new Team()
            {
                ID = TeamID
            };
        }*/

        /*public FootballerInfo GetFootballerInfo()
        {
            FootballerInfo FootbInf = new FootballerInfo();
            FootbInf.ID = ID;
            FootbInf.FullName = FullName;
            FootbInf.Age = Age;
            FootbInf.Img = Img;
            FootbInf.Position = Position;
            FootbInf.TeamID = TeamID;
            FootbInf.Team = Team.Name;
            return FootbInf;
        }
    }
    public class FootballerInfo
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Img { get; set; }
        public string Position { get; set; }
        public int TeamID { get; set; }
        public string Team { get; set; }*/

    }

}
