using DrinkAndGoMVC.Data.Interfaces;
using DrinkAndGoMVC.Data.Models;

namespace DrinkAndGoMVC.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories { 
            get
                
            {
                return new List<Category>
                {
                    new Category {CategoryName= "Alcholic", Description="All Alcholic Drinks"},
                    new Category{CategoryName="Non Alcholic", Description="Non Alcholic Drinks"}
                };
            }
            set => throw new NotImplementedException();
        }
    }
}
