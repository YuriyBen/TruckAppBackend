using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TruckProject.Entities;
using TruckProject.Helpers;
using TruckProject.Models;
using TruckProject.ResourceParameters;
using TruckProject.Services;

namespace TruckProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AutomobileContext _context;

        //private readonly ITruckLogicRepository _logicRepository;
        private readonly IMapper _mapper;

        public UserController(/*ITruckLogicRepository logicRepository*/AutomobileContext context, IMapper mapper)
        {
            //_logicRepository = logicRepository ??
            //    throw new ArgumentNullException(nameof(logicRepository));
            _context = context ??
               throw new ArgumentNullException(nameof(AutomobileContext));
            _mapper = mapper;

        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GettAllUsers()
        {
            var usersList = _context.Users.Include(x => x.Truck).Where(u => u.Role != "admin").ToList();

            var listToReturn = _mapper.Map<IEnumerable<UserDTO>>(usersList);

            return Ok(listToReturn);
        }

        //[HttpGet()]
        [HttpPost("login")]
        public ActionResult<UserDTO> GetUserAfterLogIn(UserAuthorization user)
        {

            if (!_context.Users.Any(u => u.Email == user.Email && u.PasswordHash == user.Password.Encode()))
            {
                return NotFound();
            }
            var userToReturn = _context.Users.FirstOrDefault(u => u.Email == user.Email &&
                                                             u.PasswordHash == user.Password.Encode());
            if(userToReturn.IsActive==false)
            {
                throw new Exception("You are not an active user,you can't log in ..");
            }
            return Ok(_mapper.Map<UserDTO>(userToReturn));
        }

        [HttpPost("create")]
        public ActionResult<UserDTO> CreateAccount(UserAuthentication userFromBody)
        {

            if (_context.Users.Any(u => u.Email == userFromBody.Email))
            {
                throw new Exception("There are an account with the same e-mail..");
            }
            var userForCreation = _mapper.Map<Users>(userFromBody);
            userForCreation.Country = RegionInfo.CurrentRegion.EnglishName;
            _context.Users.Add(userForCreation);
            _context.SaveChanges();
            return Ok(_mapper.Map<UserDTO>(userForCreation));

        }

        
        [HttpPut("{UserId}")]
        public void UpdateUserStatus(long UserId,Status check)
        {
            if(!_context.Users.Any(u=>u.Id==UserId))
            {
                NotFound();
            }
            short status = 0;
            if (check.IsActive == true)
            {
                status = 1;
            }
            _context.Database.ExecuteSqlRaw($"UPDATE avto.Users " +
                                    $"SET IsActive = {status}" +
                                    $"WHERE Id = {UserId};");

        }
    }

    public class Status
    {
        public bool IsActive { get; set; }
    }
}