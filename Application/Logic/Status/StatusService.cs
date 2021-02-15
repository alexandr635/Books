﻿using Application.DTO;
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

        public async Task<HashSet<BookStatusDTO>> GetStatus()
        {
            var result = await StatusRepository.GetStatus();
            HashSet<BookStatusDTO> list = new HashSet<BookStatusDTO>();

            foreach (var status in result)
                list.Add(Mapper.Map<BookStatusDTO>(status));

            return list;
        }

        public async Task<BookStatusDTO> GetStatus(int? id)
        {
            var result = await StatusRepository.GetStatus(id);
            BookStatusDTO statusDTO = Mapper.Map<BookStatusDTO>(result);

            return statusDTO;
        }
    }
}
