using DrinkAndGoMVC.Data.Models;

namespace DrinkAndGoMVC.Data.Interfaces
{
    public interface IDrinkRepository
    {
        IEnumerable<Drink> Drinks { get; }

        IEnumerable<Drink> PreferredDrinks { get;  }
        Drink GetDrinksById(int drinkId);

    }
}
