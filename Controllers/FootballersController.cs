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
    public class FootballersController : ControllerBase
    {
        private readonly FootballerContext _context;
        private readonly IRequest _request;

        public FootballersController(FootballerContext context, IRequest request)
        {
            _context = context;
            _request = request;
        }

        // GET: api/Footballers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Footballer>>> GetFootballers()
        {
            var footballers = _request.SelectTeam(_context.Footballers.ToList(), _context.Teams.ToList());
            if (footballers.Count == 0)
                return CreatedAtAction(nameof(GetFootballersWithTeam), new
                {
                    result = "Не найдено футболистов"
                });
            else
            {
                return CreatedAtAction(nameof(GetFootballersWithTeam), new
                { footballers });
            }
            //var footballer = _context.Footballers.Include(x => x.Team);
            //return await footballer.ToListAsync();
        }


        // GET: api/Footballers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Footballer>> GetFootballer(int id)
        {
            var footballer = _context.Footballers.FirstOrDefault(i => i.ID == id);
            
            if (footballer == null)
            {
                return NotFound();
            }

            return footballer;
        }


        // GET: api/Footballers/Age
        [HttpGet("Age")]
        public CreatedAtActionResult GetFootballersAge()
        {
            var footballers = _request.SelectFootballers(_context.Footballers.ToList());
            if (footballers.Count() == 0)
                return CreatedAtAction(nameof(GetFootballersAge), new
                { result = "Не найдено молодых футболистов моложе 21 лет" });
            else
            {
                return CreatedAtAction(nameof(GetFootballersAge), new
                { footballers });
            }
        }


        // GET: api/Footballers/FootballersWithTeam
        [HttpGet("FootballersWithTeam")]
        public CreatedAtActionResult GetFootballersWithTeam()
        {
            var footballers = _request.SelectTeam(_context.Footballers.ToList(), _context.Teams.ToList());
            if (footballers.Count() == 0)
                return CreatedAtAction(nameof(GetFootballersWithTeam), new
                { 
                    result = "Не найдено футболистов" 
                });
            else
            {
                return CreatedAtAction(nameof(GetFootballersWithTeam), new
                { footballers });
            }
        }

        [HttpGet("FootballersOneTeam/{id}")]
        public CreatedAtActionResult GetFootballersOneTeam(int id)
        {
            var footballers = _request.ShowAllFootballersInTeam(_context.Footballers.ToList(), _context.Teams.Find(id));
            if (footballers.Count() == 0)
                return CreatedAtAction(nameof(GetFootballersOneTeam), new
                {
                    result = "Не найдено футболистов этой команды"
                });
            else
            {
                return CreatedAtAction(nameof(GetFootballersOneTeam), new
                { footballers });
            }
        }


        [HttpGet("FootballersOnePosition/{position}")]
        public CreatedAtActionResult GetFootballersOnePosition(string position)
        {
            var footballers = _request.ShowAllFootballersOnePosition(_context.Footballers.ToList(), _context.Teams.ToList(), position);
            if (footballers.Count() == 0)
                return CreatedAtAction(nameof(GetFootballersOnePosition), new
                {
                    result = "Не найдено футболистов, играющих на этой позиции"
                });
            else
            {
                return CreatedAtAction(nameof(GetFootballersOnePosition), new
                { footballers });
            }
        }

        //public Team GetTeamAboutFootballer(int TeamID) => FootballerContext.;

        /*[HttpGet("FootballersInTeam")]
        public Dictionary<string, List<string>> GetFootballersInTeam()
        {
            return _context.GetFootballersInTeam();
        }*/


        // PUT: api/Footballers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFootballer(int id, Footballer footballer)
        {
            if (id != footballer.ID)
            {
                return BadRequest();
            }

            _context.Entry(footballer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FootballerExists(id))
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

        // POST: api/Footballers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Footballer>> PostFootballer([FromBody] Footballer footballer)
        {
            _context.Footballers.Add(footballer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFootballer), new { id = footballer.ID }, footballer);
        }

        // DELETE: api/Footballers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Footballer>> DeleteFootballer(int id)
        {
            var footballer = await _context.Footballers.FindAsync(id);
            if (footballer == null)
            {
                return NotFound();
            }

            _context.Footballers.Remove(footballer);
            await _context.SaveChangesAsync();

            return footballer;
        }

        private bool FootballerExists(int id)
        {
            return _context.Footballers.Any(e => e.ID == id);
        }
    }
}
