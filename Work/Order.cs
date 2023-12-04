using System;
using System.IO;

namespace CSharpPW5
{
    internal class Order
    {
        public static int price = 0;
        public static string yourCake = "";

        public static void OrderMenu(int position)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape\nВыберите пункт из меню:\n-----------------------");
            Console.SetCursorPosition(0, 3);

            OrderSubmenu(position);
            Submenu.Calculations();

            if (Submenu.numberOfTiers.intValue != 0)
            {
                price = Submenu.numberOfTiers.price + Submenu.shape.price + Submenu.productWeight.intValue * Submenu.productWeight.price + Submenu.cakeDecoration.price;
            }

            if (Submenu.numberOfTiers.intValue != 0)
            {
                yourCake = $"кол-во коржей: {Submenu.numberOfTiers.intValue};";

                if (!string.IsNullOrEmpty(Submenu.filling.stringValue))
                {
                    yourCake += $" вкус коржей: {Submenu.filling.stringValue};";
                }

                if (!string.IsNullOrEmpty(Submenu.shape.stringValue))
                {
                    yourCake += $" форма торта: {Submenu.shape.stringValue};";
                }

                if (Submenu.productWeight.intValue != 0)
                {
                    yourCake += $" вес: {Submenu.productWeight.intValue} кг;";
                }

                if (!string.IsNullOrEmpty(Submenu.cakeDecoration.stringValue))
                {
                    yourCake += $" декор: {Submenu.cakeDecoration.stringValue};";
                }
            }

            Console.SetCursorPosition(2, 3);
        }

        static void OrderSubmenu(int position)
        {
            if (position == 3)
            {
                position = 3;

                Console.WriteLine(Submenu.numberOfTiers.submenuInput);

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                    {
                        position = Program.Arrows(key, position, 3, 6);
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        Submenu.numberOfTiers.intValue = position - 2;
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }

                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }
                }
                while (true);
            }

            else if (position == 4)
            {
                position = 3;

                Console.WriteLine(Submenu.filling.submenuInput);

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                    {
                        position = Program.Arrows(key, position, 3, 7);
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (position == 3)
                        {
                            Submenu.filling.stringValue = "Ванильный";
                        }

                        else if (position == 4)
                        {
                            Submenu.filling.stringValue = "Шоколадный";
                        }

                        else if (position == 5)
                        {
                            Submenu.filling.stringValue = "Карамельный";
                        }

                        else if (position == 6)
                        {
                            Submenu.filling.stringValue = "Ягодный";
                        }

                        else if (position == 7)
                        {
                            Submenu.filling.stringValue = "Кокосовый";
                        }

                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }

                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }
                }
                while (true);
            }

            else if (position == 5)
            {
                position = 3;

                Console.WriteLine(Submenu.shape.submenuInput);

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                    {
                        position = Program.Arrows(key, position, 3, 6);
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (position == 3)
                        {
                            Submenu.shape.stringValue = "Круг";
                        }

                        else if (position == 4)
                        {
                            Submenu.shape.stringValue = "Квадрат";
                        }

                        else if (position == 5)
                        {
                            Submenu.shape.stringValue = "Прямоугольник";
                        }

                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }

                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }
                }
                while (true);
            }

            else if (position == 6)
            {
                position = 3;

                Console.WriteLine(Submenu.productWeight.submenuInput);

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                    {
                        position = Program.Arrows(key, position, 3, 9);
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (position - 2 == 1)
                        {
                            Submenu.productWeight.intValue = 1;
                        }

                        else
                        {
                            Submenu.productWeight.intValue = (position - 3) * 3;
                        }

                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }

                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }
                }
                while (true);
            }

            else if (position == 7)
            {
                position = 3;

                Console.WriteLine(Submenu.cakeDecoration.submenuInput);

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                    {
                        position = Program.Arrows(key, position, 3, 5);
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (position == 3)
                        {
                            Submenu.cakeDecoration.stringValue = "Шоколадная";
                        }

                        else if (position == 4)
                        {
                            Submenu.cakeDecoration.stringValue = "Ягодная";
                        }

                        else if (position == 5)
                        {
                            Submenu.cakeDecoration.stringValue = "Кремовая";
                        }

                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }

                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }
                }
                while (true);
            }

            else if (position == 8)
            {
                Console.Write("Заказ оформлен! Спасибо за покупку торта \"МПТ\", обращайтесь ещё!");

                Saving();

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        price = 0;
                        yourCake = "";
                        Submenu.ZeroingOut();
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }

                }
                while (true);
            }
        }

        static void Saving()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktopPath, "OrderHistory.txt");
            string newOrder = $"Заказ от {DateTime.Now}\n\tЗаказ: {yourCake}\n\tЦена: {price}\n\n";

            if (price != 0 || !string.IsNullOrEmpty(yourCake))
            {
                File.AppendAllText(path, newOrder);
            }

            Program.position = 3;
        }

    }
}
