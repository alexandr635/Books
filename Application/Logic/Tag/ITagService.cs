using Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public interface ITagService
    {
        Task<HashSet<TagDTO>> GetTag();
        Task<TagDTO> GetTag(int? id);
        Task AddTag(TagDTO tagDTO);
        Task ChangeTag(TagDTO tagDTO);
        Task DeleteTag(TagDTO tagDTO);
    }
}
