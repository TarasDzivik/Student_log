using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Back.Data.Models;
using Back.Data.Models.Entities;
using Back.DTOs;
using Back.Data;
using Back.Services.Validation;
using FluentValidation.AspNetCore;

namespace HoneycombTT.Controller
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        AppDbContext db;
        public UserController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserCreateDto>> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut]
        // DTO створити щоб не передавати усього USER з усыма полями.
        public async Task<ActionResult<User>> Put(User user)
        {
            if (!db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(string id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}