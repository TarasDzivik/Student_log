using AutoMapper;
using AutoMapper.QueryableExtensions;
using Back.Data;
using Back.Data.Models.Entities;
using Back.DTOs;
using Back.Services.Validation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public AppDbContext db;
        private readonly IMapper mapper;
        public AdminController(AppDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            return await db.Users
                .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(string id)
        {
            UserDto user = await db.Users
                .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPost]
        public async Task<ActionResult<RegistrationDto>>
            CreateUser(RegistrationDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = mapper.Map<User>(userDto);
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPut]
        public async Task<ActionResult<UserDto>> UpdateUser(UserDto userDto)
        {
            // так як об'єкт User наслідує дуже багато прихованих
            // параметрів яких не має в UserDto в результаті і виникає
            // проблема з паралелізмом при збереженні БД, якщо
            // вхідні параметри брати з DTO файла
            
            if (!db.Users.Any(x => x.Id == userDto.Id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = mapper.Map<User>(userDto);
                
            try
            {
                user.Email = userDto.Email;
                user.Age = userDto.Age;
                user.Name = userDto.Name;
                user.LastName = userDto.LastName;
                db.Update(user);

                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(nameof(UpdateUser), "unable to save changes");
                return StatusCode(500, ModelState);
            }
            //db.Users.Update(user);
            //await db.SaveChangesAsync(); // !!! не зберігає зміни
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