using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace MH06;

internal class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Synchronizations>();
    }
}
