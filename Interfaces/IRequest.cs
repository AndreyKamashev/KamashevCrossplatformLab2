using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KamashevApplication1.Models;

namespace KamashevApplication1.Interfaces
{
    public interface IRequest
    {
        List<Footballer> SelectFootballers(List<Footballer> Footballers);
        List<Footballer> SelectTeam(List<Footballer> footballers, List<Team> teams);
        List<Footballer> ShowAllFootballersInTeam(List<Footballer> footballers, Team team);
        List<Footballer> ShowAllFootballersOnePosition(List<Footballer> footballers, List<Team> teams, string position);
        List<Team> SortingByScores(List<Team> teams);
    }
}
