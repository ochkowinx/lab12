using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plants;

namespace Plants
{
    public class HashTable
    {
        private const int TableSize = 6; // размер таблицы
        private List<Plant>[] table; // хеш таблица
        private int elementCount = 0; // счетчик элементов

        public HashTable() 
        {
            table = new List<Plant>[TableSize]; 
            for (int i = 0; i < TableSize; i++)
            {
                table[i] = new List<Plant>();
            }
        }

        //метод для добавления элемента в хеш-таблицу
        public void Add(Plant plant)
        {
            if (elementCount >= TableSize)
            {
                Console.WriteLine("Таблица полна. Невозможно добавить новый элемент.");
                return;
            }

            int index = GetHash(plant.Id.Number);
            // проверка есть ли свободное место в списке на текущем индексе
            while (table[index].Count >= TableSize)
            {
                // если список полон, переходим к следующему индексу
                index = (index + 1) % TableSize;
                // проверка не достигли ли мы конца массива
                if (index == GetHash(plant.Id.Number))
                {
                    Console.WriteLine("Таблица полна. Невозможно добавить новый элемент.");
                    return;
                }
            }

            table[index].Add(plant);
            elementCount++;

            Console.WriteLine($"Элемент успешно добавлен: {plant.Name}"); 
        }



        // метод для получения хеша по ключу
        private int GetHash(int key)
        {
            return key % TableSize;
        }

        // метод для поиска элемента в хеш-таблице по ключу
        public Plant Find(int key)
        {
            int index = GetHash(key);
            foreach (var plant in table[index])
            {
                if (plant.Id.Number == key)
                {
                    return plant;
                }
            }
            return null; // элемент не найден
        }

        // метод для удаления элемента из хеш-таблицы по ключу
        public bool Remove(int key)
        {
            int index = GetHash(key);
            foreach (var plant in table[index])
            {
                if (plant.Id.Number == key)
                {
                    table[index].Remove(plant);
                    elementCount--; 
                    return true;
                }
            }
            return false; // элемент не найден
        }

        public void PrintAll()
        {
            for (int i = 0; i < TableSize; i++)
            {
                int elementIndex = 0; // счетчик для отслеживания индекса элемента внутри списка
                foreach (var plant in table[i])
                {
                    Console.WriteLine($"Индекс: {i + elementIndex}, Имя: {plant.Name}, Цвет: {plant.Color}, Номер: {plant.Id.Number}");
                    elementIndex++; 
                }
            }
        }
    }
}
