using DrinkAndGoMVC.Data.Interfaces;
using DrinkAndGoMVC.Data.Models;
using DrinkAndGoMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DrinkAndGoMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IDrinkRepository drinkRepository, ShoppingCart shoppingCart)
        { drinkRepository = _drinkRepository;
            shoppingCart =_shoppingCart ;
        }
        public ViewResult index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };
            return View(sCVM);
        }
        public RedirectToActionResult AddToShoppingCart(int drinkId)
        {
            var SelectedDrink = _drinkRepository.Drinks.FirstOrDefault(p => p.DrinkId == drinkId);
            if(SelectedDrink!=null)
            {
                _shoppingCart.AddToCart(SelectedDrink, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int drinkId)
        {
            var SelectedDrink = _drinkRepository.Drinks.FirstOrDefault(p => p.DrinkId == drinkId);
            if (SelectedDrink != null)
            {
                _shoppingCart.RemoveFromCart(SelectedDrink);
            }
            return RedirectToAction("Index");
        }
    }
}
