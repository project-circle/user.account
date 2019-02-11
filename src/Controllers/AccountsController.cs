using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserAccount.Accounts;
using UserAccount.Models;

namespace UserAccount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IRepository<Account> _repository;

        public AccountsController(IRepository<Account> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}", Name = "GetAccount")]
        public async Task<ActionResult<Account>> Get(string id)
        {
            var account = await _repository.GetAsync(id);

            if (account == null)
                return NotFound();

            return Ok(account);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Account account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var id = await _repository.AddAsync(account);
            
            var uri = Url.Link("GetAccount", new { id = id });
            
            return Created(uri, account);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Account account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.UpdateAsync(id, account);

            var uri = Url.Link("GetAccount", new { id = id });

            return Accepted(uri, account);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
