using System;
using BenchmarkDotNet.Attributes;

namespace AnonymousFuncBenchmarking
{
    [MemoryDiagnoser]
    public class FuncBenchmark
    {
        private string answer = " is the answer";
        private static string answerStatic = " is the answer";
        private string AddConstMember(string adding) => adding + answer;
        private static string AddConstStatic(string adding) => adding + answerStatic;

        private string Invoker(Func<string, string> adder) => adder("AddingMember");

        [Benchmark]
        public string LambdaFromMember() => Invoker(x => AddConstMember(x));
        
        [Benchmark]
        public string LambdaFromStaticMember() => Invoker(x => AddConstStatic(x));
        
        [Benchmark]
        public string StaticLambdaFromStaticMember() => Invoker(static x => AddConstStatic(x));

        [Benchmark]
        public string MethodGroup() => Invoker(AddConstMember);
        
        [Benchmark]
        public string StaticMethodGroup() => Invoker(AddConstStatic);
        
        [Benchmark]
        public string AnonymousLambda() => Invoker(x => x + answer);
        
        [Benchmark]
        public string AnonymousStaticLambda() => Invoker(static x => x + answerStatic);
    }
}