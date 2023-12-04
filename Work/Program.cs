using System;
using System.IO;

namespace CSharpPW5
{
    internal class Program
    {
        public static int menuCheck = 0;
        public static int position;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            position = 3;

            do
            {
                if (menuCheck == 0)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine($"Заказ тортов \"МПТ\", любые виды тортов на ваш выбор!\nВыберете параметры торта\n------------------------\n{Submenu.numberOfTiers.name}\n{Submenu.filling.name}\n{Submenu.shape.name}\n{Submenu.productWeight.name}\n{Submenu.cakeDecoration.name}\n  Конец заказа\n\nЦена: {Order.price}\nВаш торт: {Order.yourCake}");
                    menuCheck = 1;
                }

                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");

                ConsoleKeyInfo key = Console.ReadKey(true);

                if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                {
                    position = Arrows(key, position, 3, 10);
                }

                else if (key.Key == ConsoleKey.Enter)
                {
                    Order.OrderMenu(position);
                }

            }
            while (true);

        }

        public static int Arrows(ConsoleKeyInfo key, int position, int upperBound, int lowerBound)
        {
            int prevPosition = 3;

            if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W))
            {
                if (position == upperBound)
                {
                    position = upperBound;
                    prevPosition = upperBound;
                }

                else
                {
                    prevPosition = position;
                    position--;
                }
            }

            else if ((key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
            {
                if (position == lowerBound)
                {
                    position = lowerBound;
                    prevPosition = lowerBound;
                }

                else
                {
                    prevPosition = position;
                    position++;
                }
            }

            Console.SetCursorPosition(0, prevPosition);
            Console.Write("  ");
            Console.SetCursorPosition(0, position);
            Console.Write("->");

            return position;
        }
    }
}
