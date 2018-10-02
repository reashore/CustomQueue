using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomQueue
{
    public class Program
    {
        public static void Main()
        {
            CustomQueue customQueue = new CustomQueue();

            for (int n = 1; n <= 100; n++)
            {
                customQueue.Add(n);
            }

            for (int n = 1; n <= 50; n++)
            {
                customQueue.Remove();
            }

            double average1 = customQueue.Average1();
            double average2 = customQueue.Average2();

            Console.WriteLine($"Average1 = {average1}, Average2 = {average2}");
            Console.ReadKey();
        }
    }

    public class CustomQueue
    {
        private int _sum;
        private int _count;
        private readonly Queue<int> _queue = new Queue<int>();

        public void Add(int value)
        {
            _sum += value;
            _count++;
            _queue.Enqueue(value);
        }

        public int Remove()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("Cannot dequeue from an empty queue.");
            }

            int value = _queue.Dequeue();
            _count--;
            _sum -= value;

            return value;
        }

        public double Average1()
        {
            double average = (double)_sum / _count;
            return average;
        }

        public double Average2()
        {
            double average = (double)_queue.Sum(n => n) / _queue.Count;
            return average;
        }
    }
}
