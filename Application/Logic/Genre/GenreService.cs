using Application.DTO;
using AutoMapper;
using Data.Entities;
using Data.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class GenreService : IGenreService
    {
        IGenreRepository GenreRepository { get; set; }
        IMapper Mapper { get; set; }

        public GenreService(IGenreRepository GenreRepository, IMapper mapper)
        {
            this.GenreRepository = GenreRepository;
            Mapper = mapper;
        }

        public async Task<List<GenreDTO>> GetGenre()
        {
            return Mapper.Map<List<GenreDTO>>(await GenreRepository.GetGenre());
        }

        public async Task<GenreDTO> GetGenre(int? id)
        {
            return Mapper.Map<GenreDTO>(await GenreRepository.GetGenre(id));
        }

        public async Task AddGenre(GenreDTO genreDTO)
        {
            await GenreRepository.AddGenre(Mapper.Map<Genre>(genreDTO));
        }

        public async Task ChangeGenre(GenreDTO genreDTO)
        {
            await GenreRepository.ChangeGenre(Mapper.Map<Genre>(genreDTO));
        }

        public async Task DeleteGenre(GenreDTO genreDTO)
        {
            await GenreRepository.DeleteGenre(Mapper.Map<Genre>(genreDTO));
        }
    }
}
