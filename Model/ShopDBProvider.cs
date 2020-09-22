using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    class ShopDBProvider
    {
        ShopDB shopDB = new ShopDB();

        private static ShopDBProvider handler;
        private ShopDBProvider()
        {

        }
        public static ShopDBProvider GetInstance()
        {
            if (handler == null)
                handler = new ShopDBProvider();
            return handler;
        }
        public void AddItem(string itemName, int itemAmount, double itemPrice)
        {
            var newItem = new Product() { Name = itemName, Amount = itemAmount, Value = itemPrice };
            shopDB.products.Add(newItem);
            shopDB.SaveChanges();
        }

        public void SellItem(int itemId, int itemAmount)
        {
            var selectedItem = shopDB.products.Where(x => x.ID == itemId).First();
            if (selectedItem.Amount >= itemAmount)
            {
                selectedItem.Amount -= itemAmount;
                shopDB.SaveChanges();
            }
            else
                Console.WriteLine("unable to sell this amount");
        }

        public void Remove(int itemID)
        {
            shopDB.products.Remove(shopDB.products.Find(itemID));
            shopDB.SaveChanges();
        }

        public IEnumerable<Product> GetItemsList()
        {
            return shopDB.products.ToList();
        }

        public void ChangePrice(int ID, double Value)
        {
            var book = shopDB.products.Find(ID);
            book.Value = Value;
            shopDB.SaveChanges();
        }
    }
}
