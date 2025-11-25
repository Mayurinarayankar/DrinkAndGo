using DrinkAndGoMVC.Data.Models;

namespace DrinkAndGoMVC.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Drink> PreferredDrinks { get;set; }
    }
}
