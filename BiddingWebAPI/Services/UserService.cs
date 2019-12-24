using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BiddingWebAPI.ApiModels.Users;
using BiddingWebAPI.EFCore.DAL;
using BiddingWebAPI.EFCore.Enum;
using BiddingWebAPI.EFCore.Helper;
using BiddingWebAPI.EFCore.Model;
using BiddingWebAPI.Exceptions;
using BiddingWebAPI.Helpers;
using BiddingWebAPI.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BiddingWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        
        private readonly AppSettings _appSettings;
        //private readonly IAutoMapper _mapper;

        public UserService(IUnitOfWork uow,  IOptions<AppSettings> appSettings)
        {
            _uow = uow;
            _appSettings = appSettings.Value;
            //  _mapper = mapper;
        }

        public async Task<User> Create(CreateUserModel model)
        {
            var username = model.Email.Trim();

            if (GetQuery().Any(u => u.Email == username))
            {
                throw new BadRequestException("The email is already in use");
            }

            var user = new User
            {
                Name = model.Name.Trim(),
                Email = model.Email.Trim(),
                Password = model.Password.Trim().WithBCrypt(),
                RoleID = model.UserType ,
                IsActive = false,
                ActivationCode = Guid.NewGuid().ToString()

            };

            _uow.Add(user);
            await _uow.CommitAsync();
            
            return user;
        }

        public IQueryable<User> Get()
        {
            var query = GetQuery();

            return query;
        }
        private IQueryable<User> GetQuery()
        {
            return _uow.Query<User>()
               .Include(x => x.Role);
        }

        public User Get(int id)
        {
            var user = GetQuery().FirstOrDefault(x => x.ID == id);

            if (user == null)
            {
                throw new NotFoundException("User is not found");
            }

            return user;
        }

        public async Task<User> ActivateUser(string code)
        {
            var user = GetQuery().FirstOrDefault(x => x.ActivationCode == code);

            if (user == null)
            {
                throw new NotFoundException("Wrong Activation Code");
            }

            user.IsActive = true;
            
            await _uow.CommitAsync();
            return user;
        }

        public User Authenticate(AuthenticateModel model)
        {
            var user = GetQuery().FirstOrDefault(x => x.Email == model.Email);

            // return null if user not found
            if (user == null)
                throw new BadRequestException("Wrong email or password");

            if (!user.IsActive)
            {
                throw new ForbiddenException("User is not activated");
            }
            if (!user.Password.VerifyWithBCrypt(model.Password))
            {
                throw new BadRequestException("Wrong email or password");
            }
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.ID.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            
            return user;
        }

    }
}
