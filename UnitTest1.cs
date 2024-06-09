using lab12;
using Plants;
using System.Text;

namespace Testlab12
{
    //[TestClass]
    //public class DoublyLinkedListTests
    //{
    //    private DoublyLinkedList _list;
    //    private StringBuilder _output;
    //    private StringWriter _stringWriter;

    //    [TestInitialize]
    //    public void TestInitialize()
    //    {
    //        _list = new DoublyLinkedList();
    //        _output = new StringBuilder();
    //        _stringWriter = new StringWriter(_output);
    //        Console.SetOut(_stringWriter);
    //    }

    //    [TestCleanup]
    //    public void TestCleanup()
    //    {
    //        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    //    }

    //    [TestMethod]
    //    public void AddLast_AddsElementToEndOfList()
    //    {
    //        // Arrange
    //        var plant = new Plant("Rose", "Red", 0);

    //        // Act
    //        _list.AddLast(plant);

    //        // Assert
    //        Assert.AreEqual(plant, _list.head.Data);
    //    }

    //    [TestMethod]
    //    public void PrintList_PrintsListToConsole()
    //    {
    //        // Arrange
    //        var plant1 = new Plant("Rose", "Red", 0);
    //        var plant2 = new Plant("Tulip", "Yellow", 0);
    //        _list.AddLast(plant1);
    //        _list.AddLast(plant2);

    //        // Act
    //        _list.PrintList();

    //        // Assert
    //        var expectedOutput = $"{plant1}{Environment.NewLine}{plant2}{Environment.NewLine}";
    //        Assert.AreEqual(expectedOutput, _output.ToString());
    //    }


    //    [TestMethod]
    //    public void RemoveByName_RemovesElementsByName()
    //    {
    //        // Arrange
    //        var plant1 = new Plant("Rose", "Red", 0);
    //        var plant2 = new Plant("Tulip", "Yellow", 0);
    //        _list.AddLast(plant1);
    //        _list.AddLast(plant2);

    //        // Act
    //        _list.RemoveByName("Rose");

    //        // Assert
    //        Assert.IsNull(_list.head.Data);
    //    }

    //    [TestMethod]
    //    public void AddRandomElements_AddsCorrectNumberOfElements()
    //    {
    //        // Arrange
    //        int count = 10; // Количество элементов для добавления

    //        // Act
    //        _list.AddRandomElements(count);

    //        // Assert
    //        int actualCount = 0;
    //        Node current = _list.head;
    //        while (current != null)
    //        {
    //            actualCount++;
    //            current = current.Next;
    //        }
    //        Assert.AreEqual(count, actualCount);
    //    }

    //    [TestMethod]
    //    public void DeepClone_CreatesDeepCopyOfList()
    //    {
    //        // Arrange
    //        var plant1 = new Plant("Rose", "Red", 0);
    //        var plant2 = new Plant("Tulip", "Yellow", 0);
    //        _list.AddLast(plant1);
    //        _list.AddLast(plant2);

    //        // Act
    //        var clonedList = _list.DeepClone();

    //        // Assert
    //        Assert.AreNotSame(_list, clonedList);
    //        Assert.AreEqual(_list.head.Data, clonedList.head.Data);
    //        Assert.AreEqual(_list.head.Next.Data, clonedList.head.Next.Data);
    //    }
    //}

    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void AddAndFindTest()
        {
            // Arrange
            var hashTable = new HashTable();
            var plant = new Plant("Rose", "Red", 1, 2);

            // Act
            hashTable.Add(plant);
            var foundPlant = hashTable.Find(1);

            // Assert
            Assert.IsNotNull(foundPlant);
            Assert.AreEqual("Rose", foundPlant.Name);
            Assert.AreEqual("Red", foundPlant.Color);
            Assert.AreEqual(1, foundPlant.Id.Number);
        }

        [TestMethod]
        public void RemoveTest()
        {
            // Arrange
            var hashTable = new HashTable();
            var plant = new Plant("Rose", "Red", 1, 2);
            hashTable.Add(plant);

            // Act
            bool isRemoved = hashTable.Remove(1);

            // Assert
            Assert.IsTrue(isRemoved);
            Assert.IsNull(hashTable.Find(1));
        }

        [TestMethod]
        public void PrintAllTest()
        {
            // Arrange
            var hashTable = new HashTable();
            var plant1 = new Plant("Rose", "Red", 1, 2 );
            var plant2 = new Plant("Tree", "Green", 2, 2);
            hashTable.Add(plant1);
            hashTable.Add(plant2);

            try
            {
                hashTable.PrintAll();
            }
            catch (Exception)
            {
                Assert.Fail("PrintAll вызвал исключение.");
            }
        }
    }
}