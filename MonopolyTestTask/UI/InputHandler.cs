using MonopolyTestTask.Extensions;
using MonopolyTestTask.Models;
using MonopolyTestTask.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTestTask.UI
{
    internal class InputHandler
    {
        private const string stringFormat = "{0, 4} | {1, 5} | {2,20} | {3,15} | {4,15}";
        public void Handle(string input)
        {
            var dbSrvice = new PalleteService();
            switch (int.Parse(input))
            {
                case 1:
                    var Sortedpallets = dbSrvice.GetAllpalletsGroupAndSort();
                    WriteList(Sortedpallets);
                    break;
                case 2:
                    var ExpirationPallets = dbSrvice.GetPalletesWithMaxExpirationDate();
                    WriteList(ExpirationPallets);
                    break;
                case 3:
                    RandomDataGenerator generator = new RandomDataGenerator();
                    generator.GenerateData();
                    Console.WriteLine("База данных заполнена случайными данными");
                    break;
                case 4:
                    DbExtensions.ClearDb();
                    Console.WriteLine("База очищена");
                    break;
                default:
                    Console.WriteLine("Неправильный ввод");
                    break;
            }
        }
        private static void WriteList(List<Pallete> palletes)
        {
            Console.WriteLine(stringFormat, "Id", "Weigh", "Size", "Volume", "ExpirationDate");
            foreach (Pallete pallete in palletes)
            {
                Console.WriteLine(stringFormat, pallete.PalleteId, pallete.Weight, pallete.GetStringSize(), pallete.Volume, pallete.ExpirationDate);
            }
        }
    }
}
