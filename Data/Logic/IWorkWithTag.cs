using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IWorkWithTag
    {
        Task<HashSet<Tag>> GetTag();
        Task<Tag> GetTag(int? id);
        Task AddTag(Tag tag);
        Task ChangeTag(Tag tag);
    }
}
