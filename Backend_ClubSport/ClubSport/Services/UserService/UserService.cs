using ClubSport.Domain.Member;
using Contracts.Member;
using Contracts.UserServices;
using Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClubSport.Services.UserService
{
    public class UserService : IUserService
    {

        private readonly List<User> _users = new List<User>();
        private readonly List<Member> _member = new List<Member>();

        private readonly ApplicationServices.Config.AppSettings _appSettings;
        private readonly IMemberRepository MemberRepository;

        public UserService(IOptions<ApplicationServices.Config.AppSettings> appSettings, IMemberRepository MemberRepository)
        {
            _appSettings = appSettings.Value;
            this.MemberRepository = MemberRepository;
        }

        public User Authenticate(string username, string password)
        {
          
            var user = MemberRepository.GetAll().ToList().SingleOrDefault(x => x.UserName == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = new ClaimsIdentity();
            claims.AddClaims(new[]
            {
                new Claim(ClaimTypes.Role, user.Role.ToString())
            });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;
            User UserRevers = new User
            {
                FirstName = user.UserName,
                Id = (int)user.Id,
                LastName = user.FullName,
                Password = user.Password,
                Role = user.Role,
                Token=user.Token,
                Username=user.UserName,
                Photo=user.Photo
            };

            return UserRevers;
        }

        public IEnumerable<User> GetAll()
        {
            var listmember = MemberRepository.GetAll().ToList();
            foreach (var item in listmember)
            {
                foreach (var itemmember in _users)
                {
                    itemmember.Username=  item.UserName;
                   
                    itemmember.LastName=  item.FullName;
                    itemmember.Id=  (int)item.Id ;

                     
                    itemmember.Password=  item.Password;
                    itemmember.Role=  item.Role;
                    itemmember.Token=  item.Token;
                    itemmember.Username=  item.UserName ;
                        
                }

            }
            return _users.ToList();
        }
    }
}
