using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Workers
{
    class Director : Manager
    {
        protected override void ShowAction()
        {
            Console.WriteLine("Select action:\n" +
               "1. Sell\n" +
               "2. Get products info\n" +
               "3. Add item\n" +
               "4. Change item value\n" +
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
                        ChangeItemValue();
                        break;
                    case 5:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("input value is out of range");
                        break;
                }
            }
        }
        protected void ChangeItemValue()
        {
            
            Console.WriteLine("Select item");
            if (!int.TryParse(Console.ReadLine(), out int itemID))
                throw new Exception("incorrect value");
            Console.WriteLine("Input item value");
            if (!double.TryParse(Console.ReadLine(), out double itemValue))
                throw new Exception("incorrect value");
            ShopDBProvider.GetInstance().ChangePrice(itemID, itemValue);
        }
    }
}
