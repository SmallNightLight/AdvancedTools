using System;
using System.Diagnostics;

namespace RuntimeScripting
{
    public abstract class ScriptingLanguage
    {
        public abstract void CompileCode(string code);

        public abstract string ExecuteCode();

        public string Compile(string code)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                CompileCode(code);

                stopwatch.Stop();

                return $"Completed compile in {stopwatch.Elapsed.TotalMilliseconds} ms";
            }
            catch(Exception exception)
            {
                return exception.ToString();
            }
        }

        public string Run()
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string resultMessage = ExecuteCode();
                stopwatch.Stop();

                return resultMessage + Environment.NewLine + $"Completed run in {stopwatch.Elapsed.TotalMilliseconds} ms";
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }
    }
}