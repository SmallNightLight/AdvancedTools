using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace RuntimeScripting
{
    public class PythonScripter : ScriptingLanguage
    {
        private ScriptScope _scope;
        private CompiledCode _compiledCode;

        public override bool CompileCode(string code, out string message)
        {
            try
            {
                var engine = Python.CreateEngine();

                var searchPaths = engine.GetSearchPaths();
                searchPaths.Add(@"path");
                engine.SetSearchPaths(searchPaths);

                _scope = engine.CreateScope();
                _scope.SetVariable("result", null);


                string totalCode = $@"def Run():
    {code}

result = Run()
";

                var source = engine.CreateScriptSourceFromString(totalCode, Microsoft.Scripting.SourceCodeKind.Statements);
                _compiledCode = source.Compile();

                message = "No errors";
                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }

        public override string ExecuteCode()
        {
            if (_scope == null || _compiledCode == null)
            {
                Console.WriteLine("Code not compiled");
                return "";
            }

            try
            {
                _compiledCode.Execute(_scope);
                object targetVariableValue = _scope.GetVariable("result");
                return $"Results: {targetVariableValue}";
            }
            catch (Exception exception)
            {
                return "Failed to run code: " + exception.Message;
            }
        }
    }
}