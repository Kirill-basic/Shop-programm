using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Workers
{
    public abstract class Worker
    {
                
        protected virtual void ShowAction()
        {
            Console.WriteLine("Select action:\n" +
                "1. Sell\n" +
                "2. Get products info\n" +
                "3. Exit");
        }

        protected int GetActionId()
        {
            ShowAction();
            if (!int.TryParse(Console.ReadLine(), out int actionNum))
                throw new Exception("incorrect value");
            return actionNum;
        }

        public virtual void SelectAction()
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
                        Exit();
                        break;
                    default:
                        Console.WriteLine("input value is out of range");
                        break;
                }
            }
        }
        protected void ShowItems()
        {
            Console.Clear();
            Console.WriteLine("ID \tName \t Amount \t Value");
            foreach (var item in ShopDBProvider.GetInstance().GetItemsList())
            {
                Console.WriteLine("{0}. {1}\t{2}\t{3}", item.ID, item.Name, item.Amount, item.Value);
            }
            Console.WriteLine("Press enter");
            Console.ReadLine();
        }

        protected void Sell()
        {
            ShowItems();
            Console.WriteLine("Select item ID to sell");
            if (!int.TryParse(Console.ReadLine(), out int itemID))
                throw new Exception("incorrect value");
            Console.WriteLine("Select amount to sell");
            if (!int.TryParse(Console.ReadLine(), out int itemAmount))
                throw new Exception("incorrect value");
            ShopDBProvider.GetInstance().SellItem(itemID, itemAmount);
        }

        protected void Exit()
        {
            WorkSelector.SelectWork();
        }
    }
}
