using Plants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public class BinaryTree<T> where T : Plant, IComparable<T>, ICloneablePlant
    {
        public Node<T> Root { get; private set; }

        public BinaryTree()
        {
            Root = null;
        }

        public void Add(T item)
        {
            Root = AddRecursive(Root, item);
            Console.WriteLine($"Добавлен элемент: {item}");
        }

        private Node<T> AddRecursive(Node<T> node, T item)
        {
            if (node == null)
            {
                return new Node<T>(item);
            }

            if (item.CompareTo(node.Item) < 0)
            {
                node.LeftChild = AddRecursive(node.LeftChild, item);
            }
            else if (item.CompareTo(node.Item) > 0)
            {
                node.RightChild = AddRecursive(node.RightChild, item);
            }

            return node;
        }

        public void PrintLevelByLevel()
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();
                    Console.Write(currentNode.Item.ToString());
                    if (currentNode.LeftChild != null)
                    {
                        queue.Enqueue(currentNode.LeftChild);
                    }
                    if (currentNode.RightChild != null)
                    {
                        queue.Enqueue(currentNode.RightChild);
                    }
                }
                Console.WriteLine();
            }
        }

        public Node<T> _root;
        public double AverageHeight()
        {
            return AverageHeight(_root);
        }

        public double AverageHeight(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            double leftHeight = AverageHeight(node.LeftChild);
            double rightHeight = AverageHeight(node.RightChild);
            double currentHeight = node.Item.Height;

            Console.WriteLine($"Current height: {currentHeight}, Left height: {leftHeight}, Right height: {rightHeight}");

            return (leftHeight + rightHeight + currentHeight) / 3;
        }

        public Node<T> TransformToSearchTree()
        {
            return TransformToSearchTree(_root);
        }

        private Node<T> TransformToSearchTree(Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            Node<T> minRightNode = FindMinInSubtree(node.RightChild);
            node.RightChild = TransformToSearchTree(minRightNode.RightChild);
            minRightNode.RightChild = TransformToSearchTree(node.LeftChild);

            return minRightNode;
        }

        private Node<T> FindMinInSubtree(Node<T> node)
        {
            while (node.LeftChild != null)
            {
                node = node.LeftChild;
            }
            return node;
        }

        public bool DeleteByKey(string name)
        {
            _root = DeleteByKeyHelper(_root, name);
            return _root != null;
        }

        private Node<T> DeleteByKeyHelper(Node<T> node, string name)
        {
            if (node == null)
            {
                return null;
            }

            int comparisonResult = name.CompareTo(node.Item.Name);
            if (comparisonResult < 0)
            {
                node.LeftChild = DeleteByKeyHelper(node.LeftChild, name);
            }
            else if (comparisonResult > 0)
            {
                node.RightChild = DeleteByKeyHelper(node.RightChild, name);
            }
            else
            {
                if (node.LeftChild == null && node.RightChild == null)
                {
                    node = null;
                }
                else if (node.LeftChild == null || node.RightChild == null)
                {
                    Node<T> temp = null;
                    if (node.LeftChild != null)
                    {
                        temp = node.LeftChild;
                    }
                    else
                    {
                        temp = node.RightChild;
                    }
                    node = temp;
                }
                else
                {
                    Node<T> successor = FindMinInSubtree(node.RightChild);
                    node.Item = successor.Item;
                    node.RightChild = DeleteByKeyHelper(node.RightChild, successor.Item.Name);
                }
            }
            return node;
        }

        public void Clear()
        {
            Root = null;
        }
    }
}
