using System.Text;
using MyLinkedListLibrary;

namespace MyLinkedListApp
{
    internal static class Program
    {
        private static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            MyLinkedList firstList = new MyLinkedList();
            MyLinkedList secondList = new MyLinkedList();

            firstList.Add(10);
            firstList.Add(25);
            firstList.Add(5);
            firstList.Add(40);
            firstList.Add(15);

            secondList.Add(3);
            secondList.Add(18);
            secondList.Add(7);
            secondList.Add(50);

            Console.WriteLine("Перший список:");
            PrintList(firstList);

            Console.WriteLine("\nДругий список:");
            PrintList(secondList);

            int value = ReadInt("\nВведіть число для виконання операцій: ");

            Console.WriteLine("\nОперації для першого списку:");

            Console.WriteLine("\n1. Перше входження елемента, більшого за задане значення:");
            TryPrintFirstGreaterThan(firstList, value);

            Console.WriteLine("\n2. Сума елементів, менших за задане значення:");
            Console.WriteLine(firstList.GetSumOfElementsLessThan(value));

            Console.WriteLine("\n3. Новий список зі значень елементів, більших за задане:");
            MyLinkedList newList = firstList.GetNewListWithElementsGreaterThan(value);
            PrintList(newList);

            Console.WriteLine("\n4. Список після видалення елементів, які розташовані після максимального:");
            MyLinkedList trimmedList = firstList.Clone();
            trimmedList.RemoveElementsAfterMaximum();
            PrintList(trimmedList);

            Console.WriteLine("\nДемонстрація foreach для першого списку:");
            foreach (int item in firstList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nДемонстрація індексації:");
            Console.WriteLine("Елемент з індексом 1: " + firstList[1]);

            Console.WriteLine("\nДемонстрація видалення за номером:");
            MyLinkedList listAfterRemoval = firstList.Clone();
            listAfterRemoval.RemoveAt(1);
            PrintList(listAfterRemoval);

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }

        private static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    return number;
                }

                Console.WriteLine("Помилка введення. Спробуйте ще раз.");
            }
        }

        private static void PrintList(MyLinkedList list)
        {
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        private static void TryPrintFirstGreaterThan(MyLinkedList list, int value)
        {
            try
            {
                Console.WriteLine(list.FindFirstGreaterThan(value));
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}