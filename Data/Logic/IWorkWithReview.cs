using Data.Entities;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IWorkWithReview
    {
        Task AddReview(Review review);
    }
}
