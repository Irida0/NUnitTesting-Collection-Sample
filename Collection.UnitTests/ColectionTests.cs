using Collections;
using System.Reflection.Metadata;

namespace Collection.UnitTests
{
    public class ColectionTests
    {

        [Test]
        public void Test_Collections_EmptyConstructor()
        {
            var coll = new Collection<int>();

            Assert.AreEqual(coll.ToString(), "[]");
        }

        [Test]
        public void Test_Collections_ConstructorSingleItem()
        {
            var coll = new Collection<int>(1);

            Assert.AreEqual(coll.ToString(), "[1]");
        }

        [Test]
        public void Test_Collections_ConstructorMultipleItems()
        {
            var coll = new Collection<int>(1, 2);

            Assert.AreEqual(coll.ToString(), "[1, 2]");
        }

        [Test]
        public void Test_Collections_CountAndCapacity()
        {
            var coll = new Collection<int>(1, 2, 3);

            Assert.AreEqual(coll.Count, 3);
            Assert.That(coll.Capacity, Is.GreaterThan(coll.Count));
        }

        [Test]
        public void Test_Collections_Add()
        {
            var coll = new Collection<string>("A", "B");

            coll.Add("C");
            Assert.AreEqual(coll.ToString(), "[A, B, C]");
        }

        [Test]
        public void Test_Collections_AddRange()
        {
            var coll = new Collection<int>(1, 2, 3);

            coll.AddRange(4, 5, 6);
            Assert.AreEqual(coll.ToString(), "[1, 2, 3, 4, 5, 6]");
        }

        [Test]
        public void Test_Collections_GetbyIndex()
        {
            var coll = new Collection<string>("A", "B");
            var item = coll[1];

            Assert.That(item, Is.EqualTo("B"));
        }

        [Test]
        public void Test_Collections_SetByIndex()
        {
            var coll = new Collection<int>(1, 2);
            coll[0] = 3;

            Assert.That(coll[0], Is.EqualTo(3));
        }

        [Test]
        public void Test_Collections_SetByInvalidIndex()
        {
            var coll = new Collection<int>(1, 2);

            Assert.That(() =>
            {
                var c = coll[50];
            },
            Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collections_GetByInvalidIndex()
        {
            var coll = new Collection<int>(1, 2);

            Assert.That(() =>
            {
                var c = coll[-1];
            }, 
            Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collections_InsertAtMiddle()
        {
            var coll = new Collection<string>("A", "B");

            coll.InsertAt(1, "C");
            Assert.AreEqual(coll.ToString(), "[A, C, B]");
        }

        [Test]
        public void Test_Collections_InsertAtEnd()
        {
            var coll = new Collection<string>("A", "B");

            coll.InsertAt(2, "C");
            Assert.AreEqual(coll.ToString(), "[A, B, C]");
        }

        [Test]
        public void Test_Collections_InsertAtInvalidIndex()
        {
            var coll = new Collection<int>(1, 2, 3);

            Assert.That(() =>
            {
                coll.InsertAt(5, 4);
            },
             Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collections_RemoveAtStart()
        {
            var coll = new Collection<string>("A", "B");

            coll.RemoveAt(0);
            Assert.AreEqual(coll.ToString(), "[B]");
        }

        [Test]
        public void Test_Collections_RemoveAll()
        {
            var coll = new Collection<string>("A", "B");

            coll.RemoveAt(1);
            coll.RemoveAt(0);

            Assert.AreEqual(coll.ToString(), "[]");
        }

        [Test]
        public void Test_Collections_RemoveAtInvalidIndexes()
        {
            var coll = new Collection<string>("A", "B");

            Assert.That(() =>
            {
                coll.RemoveAt(-1);
            },
             Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collections_ExchangeFirstLast()
        {
            var coll = new Collection<string>("A", "B");

            coll.Exchange(0, 1);
            Assert.AreEqual(coll.ToString(), "[B, A]");
        }

        [Test]
        public void Test_Collections_ExchangeMiddle()
        {
            var coll = new Collection<string>("A", "B", "C");

            coll.Exchange(1, 0);
            Assert.AreEqual(coll.ToString(), "[B, A, C]");
        }

        [Test]
        public void Test_Collections_ExchangeInvalidIndexes()
        {
            var coll = new Collection<int>(1, 2, 3);

            Assert.That(() =>
            {
                coll.Exchange(5, 4);
            },
             Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collections_Clear()
        {
            var coll = new Collection<string>("A", "B", "C");

            coll.Clear();
            Assert.AreEqual(coll.ToString(), "[]");
        }

        [Test]
        public void Test_Collections_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();

            nums.AddRange(newNums);

            string expectedColl = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedColl));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));

        }
    }
}