using MonopolyTestTask;
using MonopolyTestTask.Extensions;
using MonopolyTestTask.Models;
using MonopolyTestTask.Service;
using MonopolyTestTask.UI;
using System.Xml.Linq;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите цифру пункта меню \n" +
            "1. Вывести отсортированные палеты\n" +
            "2. 3 паллеты, которые содержат коробки с наибольшим сроком годности\n" +
            "3. Заполнить бд случайными данными\n" +
            "4. Очистить все таблицы");
        while (true)
        {
            Console.Write("Введите пункт меню: ");
            string input = Console.ReadLine();
            var inputHandler = new InputHandler();
            try
            {
                inputHandler.Handle(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка:" + ex.Message);
                throw;
            }
        }

        
    }

}


