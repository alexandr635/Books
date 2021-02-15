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
            this.Mapper = mapper;
        }

        public async Task<HashSet<GenreDTO>> GetGenre()
        {
            HashSet<Genre> listGenre = await GenreRepository.GetGenre();
            HashSet<GenreDTO> listGenreDTO = new HashSet<GenreDTO>();

            foreach (Genre genre in listGenre)
                listGenreDTO.Add(Mapper.Map<GenreDTO>(genre));

            return listGenreDTO;
        }

        public async Task<GenreDTO> GetGenre(int? id)
        {
            Genre genre = await GenreRepository.GetGenre(id);
            GenreDTO genreDTO = Mapper.Map<GenreDTO>(genre);

            return genreDTO;
        }

        public async Task AddGenre(GenreDTO genreDTO)
        {
            Genre genre = Mapper.Map<Genre>(genreDTO);
            await GenreRepository.AddGenre(genre);
        }

        public async Task ChangeGenre(GenreDTO genreDTO)
        {
            Genre genre = Mapper.Map<Genre>(genreDTO);
            await GenreRepository.ChangeGenre(genre);
        }

        public async Task DeleteGenre(GenreDTO genreDTO)
        {
            Genre genre = Mapper.Map<Genre>(genreDTO);
            await GenreRepository.DeleteGenre(genre);
        }
    }
}
