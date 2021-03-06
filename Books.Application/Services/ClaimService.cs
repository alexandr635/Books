using Books.Domain.Entities;
using Books.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;

namespace Books.Application.Services
{
    public class ClaimService : IClaimService
    {
        public ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.RoleName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "BookCookie", ClaimsIdentity.DefaultNameClaimType,
                                                                         ClaimsIdentity.DefaultRoleClaimType);

            return id;
        }
    }
}
