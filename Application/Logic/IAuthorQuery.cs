using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic
{
    public interface IAuthorQuery
    {
        Task<List<AuthorDTO>> GetAuthor();
        Task<AuthorDTO> GetAuthor(int? id);
        Task AddAuthor(AuthorDTO authorDTO);
        Task ChangeAuthor(AuthorDTO authorDTO);
    }
}
