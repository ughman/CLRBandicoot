using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace CLRBandicoot
{
    public static class Profiler
    {
        private static long lasttime;
        private static Stopwatch stopwatch;
        private static Word currentroutine;
        private static Stack<Word> routinestack;
        private static long nativetime;

        static Profiler()
        {
            lasttime = 0;
            stopwatch = Stopwatch.StartNew();
            currentroutine = null;
            routinestack = new Stack<Word>();
            nativetime = 0;
        }

        private static long SplitTime()
        {
            long thistime = stopwatch.ElapsedMilliseconds;
            long difftime = thistime - lasttime;
            lasttime = thistime;
            return difftime;
        }

        public static long NativeTime
        {
            get { return nativetime; }
        }

        public static void Enter(Word word)
        {
            if (currentroutine != null)
            {
                currentroutine.Milliseconds += SplitTime();
            }
            else
            {
                nativetime += SplitTime();
            }
            routinestack.Push(currentroutine);
            currentroutine = word;
        }

        public static void Exit()
        {
            if (routinestack.Count == 0)
                throw new InvalidOperationException();
            if (currentroutine != null)
            {
                currentroutine.Milliseconds += SplitTime();
            }
            else
            {
                nativetime += SplitTime();
            }
            currentroutine = routinestack.Pop();
        }
    }
}
