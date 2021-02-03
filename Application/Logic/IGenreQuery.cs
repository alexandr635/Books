using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic
{
    public interface IGenreQuery
    {
        Task<List<GenreDTO>> GetGenre();
        Task AddGenre(GenreDTO genreDTO);
        Task ChangeGenre(GenreDTO genreDTO);
        Task<GenreDTO> GetGenre(int? id);
    }
}
