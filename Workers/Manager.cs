using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Workers
{
    class Manager : Seller
    {
        protected override void ShowAction()
        {
            Console.WriteLine("Select action:\n" +
               "1. Sell\n" +
               "2. Get products info\n" +
               "3. Add item\n" +
               "4. Exit");
        }

        public override void SelectAction()
        {
            while (true)
            {
                Console.Clear();
                switch (GetActionId())
                {
                    case 1:
                        Sell();
                        break;
                    case 2:
                        ShowItems();
                        break;
                    case 3:
                        AddItem();
                        break;
                    case 4:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("input value is out of range");
                        break;
                }
            }
        }
        protected void AddItem()
        {
            ShowItems();
            Console.WriteLine("Input item name");
            string itemName = Console.ReadLine();
            Console.WriteLine("input item price");
            if (!int.TryParse(Console.ReadLine(), out int itemAmount))
                throw new Exception("incorrect value");
            if (!double.TryParse(Console.ReadLine(), out double itemPrice))
                throw new Exception("incorrect value");
            ShopDBProvider.GetInstance().AddItem(itemName, itemAmount, itemPrice);
        }
    }
}
