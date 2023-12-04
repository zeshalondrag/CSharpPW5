using System;
using System.IO;

namespace CSharpPW5
{
    internal class Submenu
    {
        public string name, submenuInput, orderHistoryInput, stringValue;
        public int price, intValue;
        public bool[] boolValue = new bool[4];

        private Submenu(string nameArg, string SubmenuInputArg, int priceArg)
        {
            name = nameArg;
            submenuInput = SubmenuInputArg;
            price = priceArg;
        }

        public static Submenu numberOfTiers = new Submenu("  Количество коржей", "->Один\n  Два\n  Три\n  Четыре", 1000);
        public static Submenu filling = new Submenu("  Вкус коржей", "->Ванильный\n  Шоколадный\n  Карамельный\n  Ягодный\n  Кокосовый", 0);
        public static Submenu shape = new Submenu("  Форма торта", "->Круг\n  Квадрат\n  Прямоугольная", 0);
        public static Submenu productWeight = new Submenu("  Вес изделия", "->1 кг (5 порций)\n  3 кг (15 порций)\n  6 кг (30 порций)\n  9 кг (45 порций)\n  12 кг (60 порций)\n  15 кг (75 порций)\n  18 кг (90 порций)", 1300);
        public static Submenu cakeDecoration = new Submenu("  Декор", "->Шоколадная\n  Ягодная\n  Кремовая", 0);

        public static void Calculations()
        {
            if (numberOfTiers.intValue != 0)
            {
                if (numberOfTiers.intValue == 1)
                {
                    if (productWeight.intValue < 1)
                    {
                        productWeight.intValue = 1;
                    }
                }

                else if (numberOfTiers.intValue == 2)
                {
                    if (productWeight.intValue < 3)
                    {
                        productWeight.intValue = 3;
                    }
                }

                else if (numberOfTiers.intValue == 3)
                {
                    if (productWeight.intValue < 4)
                    {
                        productWeight.intValue = 4;
                    }
                }

                else if (numberOfTiers.intValue == 4)
                {
                    if (productWeight.intValue < 6)
                    {
                        productWeight.intValue = 6;
                    }
                }
            }

            if (!string.IsNullOrEmpty(shape.stringValue))
            {
                shape.price = 100 * productWeight.intValue;
            }

            if (!string.IsNullOrEmpty(cakeDecoration.stringValue))
            {
                cakeDecoration.price = 500;
            }
        }

        public static void ZeroingOut()
        {
            numberOfTiers.intValue = 0;
            filling.stringValue = string.Empty;
            shape.stringValue = string.Empty;
            productWeight.intValue = 0;
            cakeDecoration.stringValue = string.Empty;
        }
    }
}
