using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;

namespace DrinkAndGoMVC.Data.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;
        private ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public string ShoppingCartId{ get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = service.GetService<AppDbContext>();

            string CartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString(CartId, CartId);

            return new ShoppingCart(context) { ShoppingCartId = CartId };

        }

        public void AddToCart(Drink drink,int amount)
        {
            var ShoppingCartItem = _appDbContext.ShoppingCartItems.
                SingleOrDefault(s=>s.Drink.DrinkId == drink.DrinkId && s.ShoppingCartId== ShoppingCartId);

            if(ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Drink = drink,
                    Amount = 1
                };
                _appDbContext.ShoppingCartItems.Add(ShoppingCartItem);
            }
            else
            {
                ShoppingCartItem.Amount++;
            }
            _appDbContext.SaveChanges();
           
            
        }
        public int RemoveFromCart (Drink drink)
        {
            var ShoppingCartItem = _appDbContext.ShoppingCartItems.
               SingleOrDefault(s => s.Drink.DrinkId == drink.DrinkId && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;

            if(ShoppingCartItem != null)
            {
                if(ShoppingCartItem.Amount > 1)
                {
                    ShoppingCartItem.Amount--;
                    localAmount = ShoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(ShoppingCartItem);
                }
            }
            _appDbContext.SaveChanges ();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems??
                (ShoppingCartItems =_appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).
                Include(s => s.Drink).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Drink.Price* c.Amount).Sum();

            return total;
        }


    }
}
