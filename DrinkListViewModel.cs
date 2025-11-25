using DrinkAndGoMVC.Data.Models;

namespace DrinkAndGoMVC.ViewModel
{
    public class DrinkListViewModel
    {
        public IEnumerable<Drink> Drinks { get; set; }
        public string CurrentCategory { get; set; }
    }
}
