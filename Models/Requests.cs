using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KamashevApplication1.Interfaces;

namespace KamashevApplication1.Models
{
    public class Requests: IRequest
    {
        public List <Footballer> SelectFootballers(List<Footballer> footballers) 
            //вывести всех футболистов возраст которых не больше 21
        {
            List<Footballer> selected = footballers.Where(footballers => footballers.Age <= 21)
               .ToList();
            return selected;
        }

        public List<Footballer> SelectTeam(List<Footballer> footballers, List<Team> teams)
        {
            //List<string> result = new List<string>();
            /*foreach (var i in footballers)
            {*/
                /*int TeamID = i.TeamID;//выбираем id команды у футболиста
                for (int j = 0; j < teams.Count(); j++)
                {
                    int teamid = teams[j].ID;
                    IEnumerable<Team> selected = teams.Where(x => TeamID == teamid);
                    result.Add($"Имя футболиста: {i.FullName} \n Возраст: {i.Age} \n Национальность: {i.Nationality} \n Команда: {selected} \n");
                }*/

                return footballers.Select(a => new Footballer
                {
                    ID = a.ID,
                    FullName = a.FullName,
                    Age = a.Age,
                    Img = a.Img,
                    Position = a.Position,
                    TeamID = a.TeamID,
                    Team = teams[a.TeamID - 1],
                    Nationality = a.Nationality
                }).ToList();
            //}
            //return result;
        }

        public List<Footballer> ShowAllFootballersInTeam(List<Footballer> footballers, Team team)
        {
            var selected = footballers.Where(footballers => footballers.TeamID == team.ID).ToList();
            return selected;
        }

        public List<Footballer> ShowAllFootballersOnePosition(List<Footballer> footballers, List<Team> teams, string position)
        {
            var selected = footballers.Where(footballers => footballers.Position == position).ToList();
            return selected;
        }

        public List<Team> SortingByScores(List<Team> teams)
        {
            for (int i = 1; i < teams.Count(); i++)
            {
                for (int j = 0; j < teams.Count() - 1; j++)
                {
                    if (teams[j].Score <= teams[j + 1].Score)
                    {
                        Team sort = teams[j];
                        teams[j] = teams[j + 1];
                        teams[j + 1] = sort;
                    }

                }
            }
            return teams;
        }
    }

}
