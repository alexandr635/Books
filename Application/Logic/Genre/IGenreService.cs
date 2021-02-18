using Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public interface IGenreService
    {
        Task<List<GenreDTO>> GetGenre();
        Task AddGenre(GenreDTO genreDTO);
        Task ChangeGenre(GenreDTO genreDTO);
        Task<GenreDTO> GetGenre(int? id);
        Task DeleteGenre(GenreDTO genreDTO);
    }
}
