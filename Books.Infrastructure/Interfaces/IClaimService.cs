using Books.Domain.Entities;
using System.Security.Claims;

namespace Books.Infrastructure.Interfaces
{
    public interface IClaimService
    {
        ClaimsIdentity Authenticate(User user);
    }
}
