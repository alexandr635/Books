using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Logic
{
    public class WorkWithTag : IWorkWithTag
    {
        BookContext context { get; set; }

        public WorkWithTag(BookContext context)
        {
            this.context = context;
        }

        public async Task<HashSet<Tag>> GetTag()
        {
            var result = await Task.Run( () => context.Tags.ToHashSet());
            return result;
        }

        public async Task<Tag> GetTag(int? id)
        {
            var result = await Task.Run(() => context.Tags.FirstOrDefault(t => t.Id == id));
            return result;
        }

        public async Task AddTag(Tag tag)
        {
            await context.Tags.AddAsync(tag);
            await context.SaveChangesAsync();
        }

        public async Task ChangeTag(Tag tag)
        {
            context.Update(tag);
            await context.SaveChangesAsync();
        }
    }
}
