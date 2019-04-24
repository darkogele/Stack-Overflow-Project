using System.Data.Entity;

namespace StackOverflowProjectServiceLayer.UoW
{
    public interface IUoW
    {
        DbContext Context { get; set; }
        bool SaveChanges();
    }
}
