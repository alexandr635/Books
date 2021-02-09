using Application.DTO;
using AutoMapper;
using Data.Entities;

namespace Application.Mapping
{
    public class TagMap
    {
        public static Tag Tag(TagDTO tagDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TagDTO, Tag>());
            var mapper = new Mapper(config);
            Tag tag = mapper.Map<TagDTO, Tag>(tagDTO);

            return tag;
        }

        public static TagDTO TagDTO(Tag tag)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Tag, TagDTO>());
            var mapper = new Mapper(config);
            TagDTO tagDTO = mapper.Map<Tag, TagDTO>(tag);

            return tagDTO;
        }
    }
}
