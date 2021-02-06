using Application.DTO;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public interface ITagQuery
    {
        Task<HashSet<TagDTO>> GetTag();
        Task<TagDTO> GetTag(int? id);
        Task AddTag(TagDTO tagDTO);
        Task ChangeTag(TagDTO tagDTO);
    }
}
