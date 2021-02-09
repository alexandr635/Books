using Application.DTO;
using Application.Mapping;
using Data.Entities;
using Data.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class GenreService : IGenreService
    {
        IGenreRepository GenreRepository { get; set; }

        public GenreService(IGenreRepository GenreRepository)
        {
            this.GenreRepository = GenreRepository;
        }

        public async Task<HashSet<GenreDTO>> GetGenre()
        {
            HashSet<Genre> listGenre = await GenreRepository.GetGenre();
            HashSet<GenreDTO> listGenreDTO = new HashSet<GenreDTO>();

            foreach (Genre genre in listGenre)
                listGenreDTO.Add(GenreMap.GenreDTO(genre));

            return listGenreDTO;
        }

        public async Task<GenreDTO> GetGenre(int? id)
        {
            Genre genre = await GenreRepository.GetGenre(id);
            GenreDTO genreDTO = GenreMap.GenreDTO(genre);

            return genreDTO;
        }

        public async Task AddGenre(GenreDTO genreDTO)
        {
            Genre genre = GenreMap.Genre(genreDTO);
            await GenreRepository.AddGenre(genre);
        }

        public async Task ChangeGenre(GenreDTO genreDTO)
        {
            Genre genre = GenreMap.Genre(genreDTO);
            await GenreRepository.ChangeGenre(genre);
        }

        public async Task DeleteGenre(GenreDTO genreDTO)
        {
            Genre genre = GenreMap.Genre(genreDTO);
            await GenreRepository.DeleteGenre(genre);
        }
    }
}
