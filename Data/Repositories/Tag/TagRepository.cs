using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Logic
{
    public class TagRepository : ITagRepository
    {
        BookContext Context { get; set; }

        public TagRepository(BookContext Context)
        {
            this.Context = Context;
        }

        public async Task<HashSet<Tag>> GetTag()
        {
            var result = await Task.Run( () => Context.Tags.ToHashSet());

            return result;
        }

        public async Task<Tag> GetTag(int? id)
        {
            var result = await Task.Run(() => Context.Tags.FirstOrDefault(t => t.Id == id));

            return result;
        }

        public async Task AddTag(Tag tag)
        {
            await Context.Tags.AddAsync(tag);
            await Context.SaveChangesAsync();
        }

        public async Task ChangeTag(Tag tag)
        {
            Context.Update(tag);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteTag(Tag tag)
        {
            Context.Tags.Remove(tag);
            await Context.SaveChangesAsync();
        }
    }
}
