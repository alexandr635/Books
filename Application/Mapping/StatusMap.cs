using Application.DTO;
using Data.Entities;
using AutoMapper;

namespace Application.Mapping
{
    public class StatusMap
    {
        public static BookStatus BookStatus(BookStatusDTO bookStatusDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookStatusDTO, BookStatus>());
            var mapper = new Mapper(config);
            BookStatus bookStatus = mapper.Map<BookStatusDTO, BookStatus>(bookStatusDTO);

            return bookStatus;
        }

        public static BookStatusDTO BookStatusDTO(BookStatus bookStatus)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookStatus, BookStatusDTO>());
            var mapper = new Mapper(config);
            BookStatusDTO bookStatusDTO = mapper.Map<BookStatus, BookStatusDTO>(bookStatus);

            return bookStatusDTO;
        }
    }
}
