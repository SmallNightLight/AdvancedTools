using System.Diagnostics;

namespace RuntimeScripting
{
    public abstract class ScriptingLanguage
    {
        protected bool _isCompiled;

        public abstract bool CompileCode(string code, out string message);

        public abstract string ExecuteCode();

        public bool Compile(string code, out string resultMessage, out double time)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                _isCompiled = CompileCode(code, out string message);

                stopwatch.Stop();
                time = stopwatch.Elapsed.TotalMilliseconds;

                if (_isCompiled)
                    resultMessage = $"Completed compile in {time} ms";
                else
                    resultMessage = "Failed to compile code: " + message;

                return _isCompiled;
            }
            catch (Exception exception)
            {
                _isCompiled = false;
                time = 0.0;
                resultMessage = exception.ToString();
                return false;
            }
        }

        public bool Run(out string resultMessage, out double time)
        {
            if (!_isCompiled)
            {
                resultMessage = "Compile code first without errors";
                time = 0.0;
                return false;
            }
            
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string result = ExecuteCode();
                stopwatch.Stop();

                time = stopwatch.Elapsed.TotalMilliseconds;
                resultMessage = result + Environment.NewLine + $"Completed run in {time} ms";

                return true;
            }
            catch (Exception exception)
            {
                time = 0.0;
                resultMessage = exception.ToString();
                return false;
            }
        }
    }
}