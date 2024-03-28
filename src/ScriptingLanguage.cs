using System.Diagnostics;

namespace RuntimeScripting
{
    public abstract class ScriptingLanguage
    {
        protected bool _isCompiled;

        public abstract bool CompileCode(string code, out string message);

        public abstract string ExecuteCode();

        public string Compile(string code)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                _isCompiled = CompileCode(code, out string message);

                stopwatch.Stop();

                if (_isCompiled)
                    return $"Completed compile in {stopwatch.Elapsed.TotalMilliseconds} ms";

                return "Failed to compile code: " + Environment.NewLine + message;
            }
            catch(Exception exception)
            {
                _isCompiled = false;
                return exception.ToString();
            }
        }

        public string Run()
        {
            if (!_isCompiled)
                return "Compile code first without errors";

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