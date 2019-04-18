namespace Task2.Utils
{
    using System;
    using System.Diagnostics;

    public class ElapsedTimeLogger : IDisposable
    {
        private readonly string _description;

        private readonly Stopwatch stopwatch;

        public ElapsedTimeLogger(string description)
        {
            _description = description;
            stopwatch = Stopwatch.StartNew();
            ElapsedTimeLoggerLevel.IncLevel();
        }

        public void Dispose()
        {
            Console.WriteLine(
                "{2} Elapsed time:{0}-{1} ms.",
                _description,
                stopwatch.ElapsedMilliseconds,
                ElapsedTimeLoggerLevel.Level);
            ElapsedTimeLoggerLevel.ReduceLevel();
            GC.SuppressFinalize(this);
        }
    }
}