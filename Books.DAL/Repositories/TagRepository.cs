using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.DAL.Repositories
{
    public class TagRepository : ITagRepository
    {
        ApplicationContext Context { get; set; }

        public TagRepository(ApplicationContext Context)
        {
            this.Context = Context;
        }

        public async Task<List<Tag>> GetTag()
        {
            return await Context.Tags
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Tag> GetTag(int? id)
        {
            return await Context.Tags
                .AsNoTracking()
                .Include(t => t.BookToTags)
                .FirstOrDefaultAsync(t => t.Id == id);
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
