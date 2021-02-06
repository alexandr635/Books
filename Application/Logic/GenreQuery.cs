using Application.DTO;
using Data.Entities;
using Data.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class GenreQuery : IGenreQuery
    {
        IWorkWithGenre iWorkWithGenre { get; set; }

        public GenreQuery(IWorkWithGenre iWorkWithGenre)
        {
            this.iWorkWithGenre = iWorkWithGenre;
        }

        public async Task<HashSet<GenreDTO>> GetGenre()
        {
            HashSet<Genre> listGenre = await iWorkWithGenre.GetGenre();
            HashSet<GenreDTO> listGenreDTO = new HashSet<GenreDTO>();
            foreach (Genre genre in listGenre)
                listGenreDTO.Add(ConvertTo.GenreDTO(genre));

            return listGenreDTO;
        }

        public async Task<GenreDTO> GetGenre(int? id)
        {
            Genre genre = await iWorkWithGenre.GetGenre(id);
            GenreDTO genreDTO = ConvertTo.GenreDTO(genre);
            return genreDTO;
        }

        public async Task AddGenre(GenreDTO genreDTO)
        {
            Genre genre = ConvertTo.Genre(genreDTO);
            await iWorkWithGenre.AddGenre(genre);
        }

        public async Task ChangeGenre(GenreDTO genreDTO)
        {
            Genre genre = ConvertTo.Genre(genreDTO);
            await iWorkWithGenre.ChangeGenre(genre);
        }
    }
}
