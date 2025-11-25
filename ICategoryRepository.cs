using DrinkAndGoMVC.Data.Models;

namespace DrinkAndGoMVC.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
