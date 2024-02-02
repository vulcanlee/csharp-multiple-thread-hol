﻿using System.Diagnostics;

namespace MH06;

internal class Program
{
    static void Main(string[] args)
    {
        int counter = 0;
        int max = int.MaxValue;
        object locker = new object();
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Thread thread1 = new Thread(() =>
        {
            int subCounter = 0;
            for (int i = 0; i < max; i++)
            {
                subCounter++;
            }
            lock (locker)
            {
                counter += subCounter;
            }
        });
        Thread thread2 = new Thread(() =>
        {
            int subCounter = 0;
            for (int i = 0; i < max; i++)
            {
                subCounter++;
            }
            lock (locker)
            {
                counter -= subCounter;
            }
        });
        thread1.Start(); thread2.Start();
        thread1.Join(); thread2.Join();
        sw.Stop();
        Console.WriteLine("Counter: " + counter);
        Console.WriteLine("Time: " + sw.Elapsed);
    }
}