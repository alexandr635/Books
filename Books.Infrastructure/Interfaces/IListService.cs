using Books.Infrastructure.Lists;
using System.Threading.Tasks;

namespace Books.Infrastructure.Interfaces
{
    public interface IListService
    {
        Task<ListEntities> GetListEntities();
        Task<ListEntities> GetFullListEntities(int id);
        Task<ListEntities> GetListBookAndStatus(string role, int id);
        Task<ListEntities> GetListAuthorAndTag();
        Task<UserToRoles> GetListUserAndRole(int id);
    }
}
