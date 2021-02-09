using Application.DTO;
using Application.Mapping;
using Data.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class StatusService : IStatusService
    {
        IStatusRepository StatusRepository { get; set; }

        public StatusService(IStatusRepository StatusRepository)
        {
            this.StatusRepository = StatusRepository;
        }

        public async Task<HashSet<BookStatusDTO>> GetStatus()
        {
            var result = await StatusRepository.GetStatus();
            HashSet<BookStatusDTO> list = new HashSet<BookStatusDTO>();

            foreach (var status in result)
                list.Add(StatusMap.BookStatusDTO(status));

            return list;
        }

        public async Task<BookStatusDTO> GetStatus(int? id)
        {
            var result = await StatusRepository.GetStatus(id);
            BookStatusDTO statusDTO = StatusMap.BookStatusDTO(result);

            return statusDTO;
        }
    }
}
