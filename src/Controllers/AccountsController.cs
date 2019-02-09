using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserAccount.Models;

namespace UserAccount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> Get(string id)
        {
            return Ok(new Account() 
            {
                Id = id
            });

            // 200 - OK
            // 404 - Not Found
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Account account)
        {
            return Created("", account);

            // 201 - Created
            // 400 - Bad Request
            // 409 - Conflict
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Account account)
        {
            return Created("", account);

            // 201 - Created
            // 202 - Accepted
            // 400 - Bad Request
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            return NoContent();
            
            // 204 - No Content
        }
    }
}
