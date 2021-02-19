using Application.DTO;
using AutoMapper;
using Data.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class StatusService : IStatusService
    {
        IStatusRepository StatusRepository { get; set; }
        IMapper Mapper { get; set; }

        public StatusService(IStatusRepository StatusRepository, IMapper mapper)
        {
            this.StatusRepository = StatusRepository;
            this.Mapper = mapper;
        }

        public async Task<List<BookStatusDTO>> GetStatus()
        {
            return Mapper.Map<List<BookStatusDTO>>(await StatusRepository.GetStatus());
        }

        public async Task<BookStatusDTO> GetStatus(int? id)
        {
            return Mapper.Map<BookStatusDTO>(await StatusRepository.GetStatus(id));
        }
    }
}
