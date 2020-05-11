using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruckProject.DTO;
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

        [HttpGet()]
        public ActionResult<UserDTO> GetCurrentUser(UserAuthorization user)
        {
            if(!_context.Users.Any(u=>u.Email==user.Email && u.PasswordHash==user.Password))
            {
                return NotFound();
            }
            var userToReturn = _context.Users.FirstOrDefault(u => u.Email == user.Email &&
                                                             u.PasswordHash == user.Password);
            return Ok(_mapper.Map<UserDTO>(userToReturn));
        }

    }
}