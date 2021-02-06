using Application.DTO;
using Data.Entities;
using Data.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class TagQuery : ITagQuery
    {
        IWorkWithTag workWithTag { get; set; }

        public TagQuery(IWorkWithTag workWithTag)
        {
            this.workWithTag = workWithTag;
        }


        public async Task<HashSet<TagDTO>> GetTag()
        {
            var listTag = await workWithTag.GetTag();
            HashSet<TagDTO> listTagDTO = new HashSet<TagDTO>();
            foreach (Tag tag in listTag)
                listTagDTO.Add(ConvertTo.TagDTO(tag));

            return listTagDTO;
        }

        public async Task<TagDTO> GetTag(int? id)
        {
            var tag = await workWithTag.GetTag(id);
            TagDTO tagDTO = ConvertTo.TagDTO(tag);

            return tagDTO;
        }

        public async Task AddTag(TagDTO tagDTO)
        {
            Tag tag = ConvertTo.Tag(tagDTO);
            await workWithTag.AddTag(tag);
        }

        public async Task ChangeTag(TagDTO tagDTO)
        {
            Tag tag = ConvertTo.Tag(tagDTO);
            await workWithTag.ChangeTag(tag);
        }
    }
}
