using Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public interface IStatusService
    {
        Task<List<BookStatusDTO>> GetStatus();
        Task<BookStatusDTO> GetStatus(int? id);
    }
}
