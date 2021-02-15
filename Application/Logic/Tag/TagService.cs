using Application.DTO;
using Application.Mapping;
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
        IMapper mapper { get; set; }

        public TagService(ITagRepository TagRepository, IMapper mapper)
        {
            this.TagRepository = TagRepository;
            this.mapper = mapper;
        }

        public async Task<HashSet<TagDTO>> GetTag()
        {
            var listTag = await TagRepository.GetTag();
            HashSet<TagDTO> listTagDTO = new HashSet<TagDTO>();

            foreach (Tag tag in listTag)
                listTagDTO.Add(mapper.Map<TagDTO>(tag));

            return listTagDTO;
        }

        public async Task<TagDTO> GetTag(int? id)
        {
            var tag = await TagRepository.GetTag(id);
            TagDTO tagDTO = mapper.Map<TagDTO>(tag);

            return tagDTO;
        }

        public async Task AddTag(TagDTO tagDTO)
        {
            Tag tag = mapper.Map<Tag>(tagDTO);
            await TagRepository.AddTag(tag);
        }

        public async Task ChangeTag(TagDTO tagDTO)
        {
            Tag tag = mapper.Map<Tag>(tagDTO);
            await TagRepository.ChangeTag(tag);
        }

        public async Task DeleteTag(TagDTO tagDTO)
        {
            Tag tag = mapper.Map<Tag>(tagDTO);
            await TagRepository.DeleteTag(tag);
        }
    }
}
