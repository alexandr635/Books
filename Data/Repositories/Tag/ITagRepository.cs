using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface ITagRepository
    {
        Task<HashSet<Tag>> GetTag();
        Task<Tag> GetTag(int? id);
        Task AddTag(Tag tag);
        Task ChangeTag(Tag tag);
        Task DeleteTag(Tag tag);
    }
}
