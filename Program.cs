using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab11;
using Plants;

namespace lab12
{
    public class Program
    {
        public static void Main()
        {
            //DoublyLinkedList list = new DoublyLinkedList();
            //bool exit = false;

            //Console.WriteLine("Работа с двунаправленным списком:");
            //Console.WriteLine();

            //while (!exit)
            //{
            //    Console.WriteLine("Меню:");
            //    Console.WriteLine("1. Добавить элемент в конец списка");
            //    Console.WriteLine("2. Удалить элементы по имени");
            //    Console.WriteLine("3. Добавить K случайных элементов в начало списка");
            //    Console.WriteLine("4. Печать списка");
            //    Console.WriteLine("5. Глубокое клонирование списка");
            //    Console.WriteLine("6. Выход");
            //    Console.Write("Выберите действие: ");

            //    int choice = Convert.ToInt32(Console.ReadLine());

            //    switch (choice)
            //    {
            //        case 1:
            //            Console.Write("Введите имя элемента: ");
            //            string name = Console.ReadLine();
            //            list.AddLast(new Plant(name, "Color", 0));
            //            Console.WriteLine("Элемент успешно добавлен в список.");
            //            list.PrintList();
            //            break;
            //        case 2:
            //            Console.Write("Введите имя для удаления: ");
            //            string deleteName = Console.ReadLine();
            //            list.RemoveByName(deleteName);
            //            Console.WriteLine("Элементы с указанным именем были удалены из списка.");
            //            list.PrintList();
            //            break;
            //        case 3:
            //            Console.Write("Введите количество элементов для добавления: ");
            //            int count = Convert.ToInt32(Console.ReadLine());
            //            list.AddRandomElements(count);
            //            Console.WriteLine($"{count} случайных элементов успешно добавлены в начало списка.");
            //            list.PrintList();
            //            break;
            //        case 4:
            //            list.PrintList();
            //            Console.WriteLine("Список успешно выведен.");
            //            break;
            //        case 5:
            //            DoublyLinkedList clonedList = list.DeepClone();
            //            Console.WriteLine("Список был успешно клонирован.");
            //            clonedList.PrintList();
            //            break;
            //        case 6:
            //            exit = true;
            //            Console.WriteLine("Выход из программы.");
            //            break;
            //        default:
            //            Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
            //            break;
            //    }

            //    Console.WriteLine("Работа с хеш-таблицей:");

            //    var hashTable = new HashTable();
            //    var plant1 = new Plant("Rose", "Red", 933); //остаток 3 = индекс 3
            //    var plant2 = new Plant("Tree", "Green", 914); //остаток 2 = индекс 2
            //    var plant3 = new Plant("Rose", "Yellow", 900); //остаток 0 = индекс 0
            //    var plant4 = new Plant("Тюльпан", "Yellow", 930); //остаток 0 = индекс 1
            //    var plant5 = new Plant("Лилия", "Красный", 34); //остаток 4 = индекс 4
            //    var plant6 = new Plant("Гипсофила", "Синий", 35); //остаток 4 = индекс 4
            //    hashTable.Add(plant1);
            //    hashTable.Add(plant2);
            //    hashTable.Add(plant3);
            //    hashTable.Add(plant4);
            //    hashTable.Add(plant5);
            //    hashTable.Add(plant6);
            //    bool exit = false;

            //    Console.WriteLine("В таблице изначально есть все элементы для отображения корректной работы открытой адресации, но вы можете их удалить!)");
            //    Console.WriteLine();

            //while (!exit)
            //    {
            //        Console.WriteLine("Меню:");
            //        Console.WriteLine("1. Добавить элемент в хеш-таблицу");
            //        Console.WriteLine("2. Найти элемент по ключу");
            //        Console.WriteLine("3. Удалить элемент по ключу");
            //        Console.WriteLine("4. Вывести все элементы хеш-таблицы");
            //        Console.WriteLine("5. Выход");
            //        Console.Write("Выберите действие: ");

            //        int choice = Convert.ToInt32(Console.ReadLine());

            //    switch (choice)
            //        {
            //            case 1:
            //                Console.Write("Введите имя элемента: ");
            //                string name = Console.ReadLine();
            //                Console.Write("Введите цвет элемента: ");
            //                string color = Console.ReadLine();
            //                Console.Write("Введите номер элемента: ");
            //                int number = Convert.ToInt32(Console.ReadLine());
            //                hashTable.Add(new Plant(name, color, number));
            //                break;
            //            case 2:
            //                Console.Write("Введите номер элемента для поиска: ");
            //                int searchKey = Convert.ToInt32(Console.ReadLine());
            //                var foundPlant = hashTable.Find(searchKey);
            //                if (foundPlant != null)
            //                {
            //                    Console.WriteLine($"Найдено: {foundPlant.Name}");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("Элемент не найден.");
            //                }
            //                break;
            //            case 3:
            //                Console.Write("Введите номер элемента для удаления: ");
            //                int removeKey = Convert.ToInt32(Console.ReadLine());
            //                bool isRemoved = hashTable.Remove(removeKey);
            //                if (isRemoved)
            //                {
            //                    Console.WriteLine("Элемент успешно удален.");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("Элемент не найден для удаления.");
            //                }
            //                break;
            //            case 4:
            //                Console.WriteLine("Вывод всех элементов хеш-таблицы:");
            //                hashTable.PrintAll();
            //                break;
            //            case 5:
            //                exit = true;
            //                Console.WriteLine("Выход из программы.");
            //                break;
            //            default:
            //                Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
            //                break;
            //        }
            //}


            BinaryTree<Plant> tree = new BinaryTree<Plant>(); // Создаем дерево для демонстрации
                                                          // Здесь могут быть дополнительные инициализации

            while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Добавить растение");
            Console.WriteLine("2 - Печать дерева по уровням");
            Console.WriteLine("3 - Удалить растение по имени");
            Console.WriteLine("4 - Очистить дерево");
            Console.WriteLine("5 - Выход");
            string choice = Console.ReadLine();

            switch (choice)
            {
                    case "1":
                        // Добавить растение в дерево
                        Console.WriteLine("Введите имя растения:");
                        string plantName = Console.ReadLine();
                        Console.WriteLine("Введите цвет растения:");
                        string plantColor = Console.ReadLine();
                        Console.WriteLine("Введите номер растения:");
                        int plantId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите высоту растения:");
                        double plantHeiht = Convert.ToDouble(Console.ReadLine());
                        tree.Add(new Plant(plantName, plantColor, plantId, plantHeiht));
                        break;
                    case "2":
                    // Печать дерева по уровням
                    tree.PrintLevelByLevel();
                    break;
                case "3":
                    // Удалить растение по имени
                    Console.WriteLine("Введите название растения для удаления:");
                    string DeleteplantName = Console.ReadLine();
                    tree.DeleteByKey(DeleteplantName);
                    break;
                case "4":
                    // Очистить дерево
                    tree.Clear();
                    Console.WriteLine("Дерево очищено.");
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
        }
        }
        }


