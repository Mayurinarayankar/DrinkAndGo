using DrinkAndGoMVC.Data;
using DrinkAndGoMVC.Data.Interfaces;
using DrinkAndGoMVC.Data.Models;
using System.Data.Entity;

namespace DrinkAndGoMVC.Data.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly AppDbContext _appDbContext;
        public DrinkRepository(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;
        }
        
        public IEnumerable<Drink> Drinks => _appDbContext.Drinks.Include(c => c.Category);
        public IEnumerable<Drink> PreferredDrinks => _appDbContext.Drinks.Where(p => p.IsPreferredDrink).Include(c => c.Category);

      
        public Drink GetDrinksById(int drinkId) => _appDbContext.Drinks.FirstOrDefault(p => p.DrinkId == drinkId);
        
    }
}

    

