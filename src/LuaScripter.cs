using NLua;

namespace RuntimeScripting
{
    public class LuaScripter : ScriptingLanguage
    {
        private Lua _lua;

        public override bool CompileCode(string code, out string message)
        {
            try
            {
                _lua = new Lua();

                _lua.DoString($@"
	function LuaFunction()
		{code}
	end
	");
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
            if (_lua == null)
            {
                Console.WriteLine("Code not compiled");
                return "";
            }

            try
            {
                var luaFunction = _lua["LuaFunction"] as LuaFunction;

                if (luaFunction == null) throw new Exception("Compilation error");

                var results = luaFunction.Call();

                string resultMessage = "";
                foreach (var result in results)
                {
                    resultMessage += Environment.NewLine + result;
                }

                return "Results: " + resultMessage;
            }
            catch (Exception exception)
            {
                return "Failed to run code: " + exception.Message;
            }
        }
    }
}