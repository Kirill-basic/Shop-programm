using Shop.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop
{
    static class WorkSelector
    {
        static void ShowWorkers()
        {
            Console.WriteLine("Select your work:\n" +
                "1. Seller\n" +
                "2. Manager\n" +
                "3. director\n" +
                "4. Exit");
        }

        private static int GetPositionId()
        {
            ShowWorkers();
            if (!int.TryParse(Console.ReadLine(), out int workNum))
                throw new Exception("incorrect value");
            return workNum;
        }

        public static void SelectWork()
        {
            Worker worker;
            Console.Clear();
            switch (GetPositionId())
            {
                case 1:
                    worker = new Seller();
                    worker.SelectAction();
                    break;
                case 2:
                    worker = new Manager();
                    worker.SelectAction();
                    break;
                case 3:
                    worker = new Director();
                    worker.SelectAction();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("input value is out of range");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }
}
