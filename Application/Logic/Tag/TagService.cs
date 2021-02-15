using Application.DTO;
using AutoMapper;
using Data.Entities;
using Data.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class TagService : ITagService
    {
        ITagRepository TagRepository { get; set; }
        IMapper Mapper { get; set; }

        public TagService(ITagRepository TagRepository, IMapper mapper)
        {
            this.TagRepository = TagRepository;
            this.Mapper = mapper;
        }

        public async Task<HashSet<TagDTO>> GetTag()
        {
            var listTag = await TagRepository.GetTag();
            HashSet<TagDTO> listTagDTO = new HashSet<TagDTO>();

            foreach (Tag tag in listTag)
                listTagDTO.Add(Mapper.Map<TagDTO>(tag));

            return listTagDTO;
        }

        public async Task<TagDTO> GetTag(int? id)
        {
            var tag = await TagRepository.GetTag(id);
            TagDTO tagDTO = Mapper.Map<TagDTO>(tag);

            return tagDTO;
        }

        public async Task AddTag(TagDTO tagDTO)
        {
            Tag tag = Mapper.Map<Tag>(tagDTO);
            await TagRepository.AddTag(tag);
        }

        public async Task ChangeTag(TagDTO tagDTO)
        {
            Tag tag = Mapper.Map<Tag>(tagDTO);
            await TagRepository.ChangeTag(tag);
        }

        public async Task DeleteTag(TagDTO tagDTO)
        {
            Tag tag = Mapper.Map<Tag>(tagDTO);
            await TagRepository.DeleteTag(tag);
        }
    }
}
