using Application.DTO;
using Data.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class StatusQuery : IStatusQuery
    {
        IWorkWithStatus workWithStatus { get; set; }

        public StatusQuery(IWorkWithStatus workWithStatus)
        {
            this.workWithStatus = workWithStatus;
        }

        public async Task<HashSet<BookStatusDTO>> GetStatus()
        {
            var result = await workWithStatus.GetStatus();
            HashSet<BookStatusDTO> list = new HashSet<BookStatusDTO>();
            foreach (var status in result)
                list.Add(ConvertTo.BookStatusDTO(status));

            return list;
        }

        public async Task<BookStatusDTO> GetStatus(int? id)
        {
            var result = await workWithStatus.GetStatus(id);
            BookStatusDTO statusDTO = ConvertTo.BookStatusDTO(result);

            return statusDTO;
        }
    }
}
