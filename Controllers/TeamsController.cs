using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KamashevApplication1.Models;
using KamashevApplication1.Interfaces;

namespace KamashevApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly FootballerContext _context;
        private readonly IRequest _request;

        public TeamsController(FootballerContext context, IRequest request)
        {
            _context = context;
            _request = request;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            //return await _context.Teams.ToListAsync();
            var teams = _context.Teams;
            return await teams.ToListAsync();
        }

        [HttpGet("SortingTeamsByScore")]
        public CreatedAtActionResult GetSortingTeamsByScore()
        {
            var SortTeams = _request.SortingByScores(_context.Teams.ToList());
            if (SortTeams.Count() == 0)
                return CreatedAtAction(nameof(GetSortingTeamsByScore), new
                {
                    result = "Не найдено команд"
                });
            else
            {
                return CreatedAtAction(nameof(GetSortingTeamsByScore), new
                {
                    SortTeams
                });
            }
        }


        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = _context.Teams.FirstOrDefault(i => i.ID == id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.ID)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTeam), new { id = team.ID }, team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return team;
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.ID == id);
        }
    }
}
