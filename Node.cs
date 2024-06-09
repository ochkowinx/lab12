using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plants;

namespace lab12
{
    public class Node
    {
        public object Data { get; set; } // данные 
        public Node Next { get; set; } // следующий 
        public Node Previous { get; set; } // предыдущий 

        public Node(object data)
        {
            Data = data;
        }
    }

    // двунаправленный список
    public class DoublyLinkedList
    {
        public Node head; 
        public Node tail; 

        // добавляет элемент в конец списка
        public void AddLast(object data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }

        // печать всех элементов списка
        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        // удаляет все элементы с заданным именем
        public void RemoveByName(string name)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data is Plant plant && plant.Name == name)
                {
                    // удаление узла из списка
                    if (current.Previous != null)
                        current.Previous.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.Previous = current.Previous;
                    else
                        tail = current.Previous;
                }
                current = current.Next;
            }
        }

        public static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public void AddRandomElements(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int randomType = GetRandomNumber(1, 4); // случайное число от 1 до 4
                switch (randomType)
                {
                    case 1: // Plant
                        AddFirst(new Plant($"Plant{i}", $"Color{i}",0,0));
                        break;
                    case 2: // Tree
                        AddFirst(new Tree($"Tree{i}", $"Color{i}", GetRandomNumber(1, 20), 0));
                        break;
                    case 3: // Flower
                        AddFirst(new Flower($"Flower{i}", $"Color{i}", $"Smell{i}", 0));
                        break;
                    case 4: // Rose
                        AddFirst(new Rose($"Rose{i}", $"Color{i}", $"Smell{i}", GetRandomNumber(0, 2) == 1, 0  ));
                        break;
                }
            }
        }

        // добавляем элемент в начало списка
        public void AddFirst(object data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                head.Previous = newNode;
                newNode.Next = head;
                head = newNode;
            }
        }

        // глубокое клонирование списка
        public DoublyLinkedList DeepClone()
        {
            DoublyLinkedList clonedList = new DoublyLinkedList();
            Node current = head;
            while (current != null)
            {
                if (current.Data is ICloneable cloneable)
                {
                    clonedList.AddLast(cloneable.Clone());
                }
                else
                {
                    clonedList.AddLast(current.Data);
                }
                current = current.Next;
            }
            return clonedList;
        }
    }
}
