using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic
{
    public interface IAuthorService
    {
        Task<HashSet<AuthorDTO>> GetAuthor();
        Task<HashSet<AuthorDTO>> GetAuthor(string pattern);
        Task<AuthorDTO> GetAuthor(int? id);
        Task AddAuthor(AuthorDTO authorDTO);
        Task ChangeAuthor(AuthorDTO authorDTO);
        Task DeleteAuthor(AuthorDTO authorDTO);
    }
}
