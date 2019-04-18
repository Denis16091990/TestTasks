namespace Task2.Utils
{
    public static class ElapsedTimeLoggerLevel
    {
        private static readonly object _lockObject = new object();

        private static string level;

        public static string Level => string.Format("{0}({1})", level, level.Length);

        public static void IncLevel()
        {
            lock (_lockObject)
            {
                level += "*";
            }
        }

        public static void ReduceLevel()
        {
            lock (_lockObject)
            {
                if (level.Length > 0)
                {
                    level = level.Substring(0, level.Length - 1);
                }
            }
        }
    }
}