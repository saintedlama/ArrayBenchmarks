using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ArrayBenchmarks
{
    public class ArrayIterations
    {
        private const int N = 10000;

        private readonly int[] arr;
        public ArrayIterations()
        {
            arr = new int[N];
        }

        [Benchmark]
        public void IterateWithLength()
        {
            var a = arr;
            var c = new int[N];

            for (var i = 0; i < a.Length; i++)
            {
                c[i] = a[i];
            }
        }

        [Benchmark]
        public void IterateWithLengthFromConstant()
        {
            var a = arr;
            var c = new int[N];

            for (var i = 0; i < N; i++)
            {
                c[i] = a[i];
            }
        }

        [Benchmark]
        public void IterateWithLengthFromVariable()
        {
            var a = arr;
            var c = new int[N];
            var n = a.Length;

            for (var i = 0; i < n; i++)
            {
                c[i] = a[i];
            }
        }

        [Benchmark]
        public void IterateWithLengthMinusOne()
        {
            var a = arr;
            var c = new int[N];

            for (var i = 0; i < a.Length - 1; i++)
            {
                c[i] = a[i];
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ArrayIterations>();
        }
    }
}
