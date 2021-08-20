using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FactInterventionApi.Models;

namespace FactIntervention.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FactInterventionContext _context;

        public UsersController(FactInterventionContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.users.ToListAsync();
        }


        [HttpGet("Email/{email}")]
        public async Task<ActionResult<Users>> GetUserEmail(string email)
        {
            IEnumerable<Users> usersAll = await _context.users.ToListAsync();

            foreach (Users user in usersAll)
            {
                if (user.email == email)
                {
                    return user;
                }
            }
            return NotFound();
        }


        private bool UsersExists(long id)
        {
            return _context.users.Any(e => e.Id == id);
        }
    }
}
