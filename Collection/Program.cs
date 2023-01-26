using Collections;

namespace Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = new Collection<int>();
            Console.WriteLine("Current collection: " + collection);

            Console.WriteLine("Collection count: " + collection.Count);
            Console.WriteLine("Collection capacity: " + collection.Capacity);

            collection.Add(5);
            Console.WriteLine("Current collection: " + collection);

            collection.AddRange(6, 7);
            Console.WriteLine("Current range: " + collection);

            collection.InsertAt(0, 4);
            Console.WriteLine("Current collection: " + collection);

            collection.Exchange(0, 3);
            Console.WriteLine("Current collection: " + collection);

            collection.Clear();
            Console.WriteLine("Current collection: " + collection);
        }
    }
}