using BenchmarkDotNet.Attributes;

namespace MH06;

[MedianColumn]
[MinColumn]
[MaxColumn]
[RankColumn]
public class Synchronizations
{
    object locker = new object();
    Mutex mutex = new Mutex();
    SpinLock spinLock = new SpinLock();
    Semaphore semaphore = new Semaphore(1, 1); // 1 : 初始許可數  1 : 最大許可數
    ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
    AutoResetEvent autoResetEvent = new AutoResetEvent(true); // true : 初始狀態為有信號
    CountdownEvent countdownEvent = new CountdownEvent(1); // 1 : 計數器初始值
    Barrier barrier = new Barrier(1);
    int counter = 0;

    [Benchmark]
    public void NoLock()
    {
        counter++;
    }

    [Benchmark]
    public void UsingLock()
    {
        lock (locker)
        {
            counter++;
        }
    }

    [Benchmark]
    public void UsingInterlocked()
    {
        System.Threading.Interlocked.Increment(ref counter);
    }

    [Benchmark]
    public void UsingMonitor()
    {
        Monitor.Enter(locker);
        try
        {
            counter++;
        }
        finally
        {
            Monitor.Exit(locker);
        }
    }

    [Benchmark]
    public void UsingSpinLock()
    {
        bool lockTaken = false;
        try
        {
            spinLock.Enter(ref lockTaken);
            counter++;
        }
        finally
        {
            if (lockTaken) spinLock.Exit();
        }
    }

    [Benchmark]
    public void UsingMutex()
    {
        mutex.WaitOne();
        counter++;
        mutex.ReleaseMutex();
    }

    [Benchmark]
    public void UsingAutoResetEvent()
    {
        autoResetEvent.WaitOne();
        counter++;
        autoResetEvent.Set();
    }

    [Benchmark]
    public void UsingSemaphore()
    {
        semaphore.WaitOne();
        counter++;
        semaphore.Release();
    }

    [Benchmark]
    public void UsingSemaphoreSlim()
    {
        using (var semaphore = new System.Threading.SemaphoreSlim(1, 1))
        {
            semaphore.Wait();
            try
            {
                counter++;
            }
            finally
            {
                semaphore.Release();
            }
        }
    }

    [Benchmark]
    public void UsingReaderWriterLockSlim()
    {
        rwLock.EnterWriteLock();
        try
        {
            counter++;
        }
        finally
        {
            rwLock.ExitWriteLock();
        }
    }

    [Benchmark]
    public void UsingCountdownEvent()
    {
        countdownEvent.Signal();
        countdownEvent.Wait();
        counter++;
    }

    [Benchmark]
    public void UsingBarrier()
    {
        barrier.SignalAndWait();
        counter++;
    }
}
