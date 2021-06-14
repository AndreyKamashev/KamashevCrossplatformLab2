using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KamashevApplication1.Models;

namespace KamashevApplication1.Models
{
    public class FootballerContext : DbContext
    {
        public FootballerContext(DbContextOptions<FootballerContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet <Footballer> Footballers { get; set; }
        public DbSet <Team> Teams { get; set; }
        public DbSet <User> User { get; set; }

        /*public void TeamsInclude()
        {
            Teams.Include(c => c.Footballers).ToList();
        }

        public void FootballersInclude()
        {
            Footballers.Include(c => c.Team);
        }

        public List <Footballer> ShowAllFootballers(List <Footballer> Footballers, List <Team> Teams)
        {
            return Footballers.Select(a => new Footballer 
            {
                ID = a.ID,
                FullName = a.FullName,
                Age = a.Age,
                Img = a.Img,
                Position = a.Position,
                Team = Teams[a.TeamID]
            }).ToList();
        }
        */
        /*public Dictionary<int, List<int>> GetTeam()
        {
            return new Dictionary<int, List<int>>
                (Footballers.Include(c => c.Team).ToList()
                .Select(b => new KeyValuePair<int, List<int>>
                    (b.TeamID,
                    b.Team.Select(c => c.Team.Id)
                    .ToList()))
                );
        }*/

            /*protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Footballer>()
                    .HasOne(sc => sc.Team)
                    .WithMany(s => s.Footballers)
                    .HasForeignKey(sc => sc.TeamID);
            }

            public void FootballersInclude()
            {
               Footballers.Include(c => c.Team);
            }

            public void TeamInclude()
            {
                Teams.Include(c => c.Footballers).ToList();
            }

            public string SetFootballersInTeam(int FootballerID, int TeamId)
            {

                foreach (var u in Footballers)
                {

                    if (u.ID == FootballerID)
                    {
                        try
                        {

                            u.Team.Add(new Footballer { TeamID = TeamId, ID = u.ID });
                            SaveChanges();
                            return "Okey";
                        }
                        catch
                        {
                            return "Error";
                        }

                    }

                }

                return "Error. Not Found this";
            }
            */
            /*public Dictionary<string, List<string>> GetFootballersInTeam()
            {
                return new Dictionary<string, List<string>>
                (Teams.Include(c => c.Footballers).ThenInclude(sc => sc.Footballer).ToList()
                .Select(b => new KeyValuePair<string, List<string>>
                    (b.Name,
                    b.Footballers.Select(c => c.Footballer.name)
                    .ToList()))
                );

            }*/
        }
}
