﻿using System;
using System.IO;
public static class ArrowMenu
{
    public static int ShowMenu(string[] options)
    {
        int currentChoice = 0;

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + options.Length) % options.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % options.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                return currentChoice;
            }
        }
    }
}
public class CakeOrder
{
    private double totalPrice;
    private string selectedCake;
    private string orderInfo;

    public static int ShowSubMenu(string[] options)
    {
        return ArrowMenu.ShowMenu(options);
    }
    public CakeOrder()
    {
        totalPrice = 0;
        selectedCake = "";
        orderInfo = "";
    }
    public void PlaceOrder()
    {
        int currentChoice = 0;
        string[] options = { "Форма торта", "Размер торта", "Вкус коржей", "Количество коржей", "Глазурь", "Декор", "Завершить заказ" };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Заказ тортов в МПТ, торты на ваш выбор!");
            Console.WriteLine("Выберите параметр торта");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write("   ");
                }
                Console.WriteLine(options[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Цена: " + totalPrice);
            Console.Write("Ваш торт: ");
            Console.WriteLine(selectedCake);

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + options.Length) % options.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % options.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                if (currentChoice == 6)
                {
                    CompleteOrder();
                    break;
                }
                else
                {
                    if (!string.IsNullOrEmpty(selectedCake))
                    {
                        selectedCake += "; ";
                    }
                    if (currentChoice == 0)
                    {
                        selectedCake += ChooseCakeForm(out double formPrice);
                        totalPrice += formPrice;
                    }
                    else if (currentChoice == 1)
                    {
                        selectedCake += ChooseCakeSize(out double sizePrice);
                        totalPrice += sizePrice;
                    }
                    else if (currentChoice == 2)
                    {
                        selectedCake += ChooseCakeTaste(out double tastePrice);
                        totalPrice += tastePrice;
                    }
                    else if (currentChoice == 3)
                    {
                        selectedCake += ChooseCakeQuantity(out double quantityPrice);
                        totalPrice += quantityPrice;
                    }
                    else if (currentChoice == 4)
                    {
                        selectedCake += ChooseCakeGlaze(out double glazePrice);
                        totalPrice += glazePrice;
                    }
                    else if (currentChoice == 5)
                    {
                        selectedCake += ChooseCakeDecor(out double decorPrice);
                        totalPrice += decorPrice;
                    }
                }
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                currentChoice = 0;
            }
        }
    }
    private string ChooseCakeForm(out double formPrice)
    {
        string[] formOptions = { "Круг", "Квадрат", "Прямоугольник", "Сердечко" };
        double[] formPrices = { 500, 500, 500, 700 };

        int currentChoice = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите форму торта:");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < formOptions.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write("   ");
                }
                Console.WriteLine($"{formOptions[i]} - {formPrices[i]} монет");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + formOptions.Length) % formOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % formOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                formPrice = formPrices[currentChoice];
                return formOptions[currentChoice];
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                formPrice = 0;
                return "Не выбрано";
            }
        }
    }
    private string ChooseCakeSize(out double sizePrice)
    {
        string[] sizeOptions = { "Маленький (Диаметр - 16 см, 8 порций)", "Обычный (Диаметр - 18 см, 10 порций)", "Большой (Диаметр - 28 см, 24 порции)" };
        double[] sizePrices = { 1000, 1200, 2000 };

        int currentChoice = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите размер торта:");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < sizeOptions.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write("   ");
                }
                Console.WriteLine($"{sizeOptions[i]} - {sizePrices[i]} монет");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + sizeOptions.Length) % sizeOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % sizeOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                sizePrice = sizePrices[currentChoice];
                return sizeOptions[currentChoice];
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                sizePrice = 0;
                return "Не выбрано";
            }
        }
    }
    private string ChooseCakeTaste(out double tastePrice)
    {
        string[] tasteOptions = { "Ванильный", "Шоколадный", "Карамельный", "Ягодный", "Кокосовый" };
        double[] tastePrices = { 100, 100, 150, 200, 250 };

        int currentChoice = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите вкус коржей:");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < tasteOptions.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write("   ");
                }
                Console.WriteLine($"{tasteOptions[i]} - {tastePrices[i]} монет");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + tasteOptions.Length) % tasteOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % tasteOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                tastePrice = tastePrices[currentChoice];
                return tasteOptions[currentChoice];
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                tastePrice = 0;
                return "Не выбрано";
            }
        }
    }
    private string ChooseCakeQuantity(out double quantityPrice)
    {
        string[] quantityOptions = { "1 корж", "2 коржа", "3 коржа", "4 коржа" };
        double[] quantityPrices = { 200, 400, 600, 800 };

        int currentChoice = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите количество коржей:");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < quantityOptions.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write("   ");
                }
                Console.WriteLine($"{quantityOptions[i]} - {quantityPrices[i]} монет");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + quantityOptions.Length) % quantityOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % quantityOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                quantityPrice = quantityPrices[currentChoice];
                return quantityOptions[currentChoice];
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                quantityPrice = 0;
                return "Не выбрано";
            }
        }
    }
    private string ChooseCakeGlaze(out double glazePrice)
    {
        string[] glazeOptions = { "Шоколад", "Крем", "Бизе", "Драже", "Ягоды" };
        double[] glazePrices = { 100, 100, 150, 150, 200 };

        int currentChoice = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите глазурь:");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < glazeOptions.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write("   ");
                }
                Console.WriteLine($"{glazeOptions[i]} - {glazePrices[i]} монет");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + glazeOptions.Length) % glazeOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % glazeOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                glazePrice = glazePrices[currentChoice];
                return glazeOptions[currentChoice];
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                glazePrice = 0;
                return "Не выбрано";
            }
        }
    }
    private string ChooseCakeDecor(out double decorPrice)
    {
        string[] decorOptions = { "Шоколадная", "Ягодная", "Кремовая" };
        double[] decorPrices = { 150, 150, 150 };

        int currentChoice = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите декор:");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < decorOptions.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write("   ");
                }
                Console.WriteLine($"{decorOptions[i]} - {decorPrices[i]} монет");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + decorOptions.Length) % decorOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % decorOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                decorPrice = decorPrices[currentChoice];
                return decorOptions[currentChoice];
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                decorPrice = 0; 
                return "Не выбрано"; 
            }
        }
    }
    private void CompleteOrder()
    {
        Console.WriteLine("Заказ завершен. Цена: " + totalPrice);
        Console.WriteLine("Ваш торт: " + selectedCake);

        DateTime currentTime = DateTime.Now;
        string orderTime = currentTime.ToString("dd.MM.yyyy HH:mm:ss");

        orderInfo = "Время завершения заказа: " + orderTime + Environment.NewLine +
                    "Из чего сделан торт: " + selectedCake + Environment.NewLine +
                    "Окончательная цена: " + totalPrice.ToString("C");

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "История заказов.txt");

        try
        {
            File.AppendAllText(filePath, orderInfo + Environment.NewLine);
            Console.WriteLine("Информация о заказе сохранена в файле История заказов.txt на рабочем столе.");
        }
        catch (IOException e)
        {
            Console.WriteLine("Произошла ошибка при сохранении файла: " + e.Message);
        }
    }
    static void Main(string[] args)
    {
        while (true)
        {
            CakeOrder order = new CakeOrder();
            order.PlaceOrder();

            Console.WriteLine("Желаете оформить еще один заказ? (Да/Нет)");
            string response = Console.ReadLine();
            if (response.ToLower() != "да")
            {
                break;
            }
        }
    }

}