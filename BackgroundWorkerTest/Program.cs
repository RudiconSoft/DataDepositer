using System;
using System.ComponentModel;
using System.Threading;

class Program
{
    const int ThreadCount = 10;

    static readonly Random r = new Random();
    static readonly object sync = new object();
    static readonly CountdownEvent countdown = new CountdownEvent(ThreadCount);
    static readonly BackgroundWorker[] workers = new BackgroundWorker[ThreadCount];

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.WriteLine("Starting the workers...");

        for (int i = 0; i < workers.Length; i++)
        {
            workers[i] = new BackgroundWorker();
            workers[i].WorkerSupportsCancellation = true;
            workers[i].WorkerReportsProgress = true;
            workers[i].DoWork += DoWork;
            workers[i].ProgressChanged += ProgressChanged;
            workers[i].RunWorkerCompleted += RunWorkerCompleted;
            workers[i].RunWorkerAsync(i + 1);
        }

        while (!countdown.Wait(TimeSpan.FromMilliseconds(100)))
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                Array.ForEach(workers, w => w.CancelAsync());

        Console.SetCursorPosition(0, workers.Length + 1);
        Console.ResetColor();
        Console.WriteLine("All workers finished!\r\nPress any key to continue...");
        Console.ReadKey(true);
    }

    static void DoWork(object sender, DoWorkEventArgs e)
    {
        var worker = sender as BackgroundWorker;
        e.Result = e.Argument;

        int progress = 0;
        do
        {
            worker.ReportProgress(progress, e.Argument);
            int interval;
            lock (r) interval = r.Next(1000);
            Thread.Sleep(interval);
        } while (progress++ < 100 && !worker.CancellationPending);
    }

    static void ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        int x = e.ProgressPercentage * 40 / 100 + 5;
        int y = (int)e.UserState;
        var color = (ConsoleColor)(y + 1 % Enum.GetValues(typeof(ConsoleColor)).Length);

        lock (sync)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(0, y);
            Console.Write("{0,3}%", e.ProgressPercentage);
            Console.SetCursorPosition(x, y);
            Console.Write('\u2592');
        }
    }

    static void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        countdown.Signal();
    }
}