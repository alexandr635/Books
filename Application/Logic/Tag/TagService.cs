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
            Mapper = mapper;
        }

        public async Task<List<TagDTO>> GetTag()
        {
            return Mapper.Map<List<TagDTO>>(await TagRepository.GetTag());
        }

        public async Task<TagDTO> GetTag(int? id)
        {
            return Mapper.Map<TagDTO>(await TagRepository.GetTag(id));
        }

        public async Task AddTag(TagDTO tagDTO)
        {
            await TagRepository.AddTag(Mapper.Map<Tag>(tagDTO));
        }

        public async Task ChangeTag(TagDTO tagDTO)
        {
            await TagRepository.ChangeTag(Mapper.Map<Tag>(tagDTO));
        }

        public async Task DeleteTag(TagDTO tagDTO)
        {
            await TagRepository.DeleteTag(Mapper.Map<Tag>(tagDTO));
        }
    }
}
