using NLua;
using NLua.Exceptions;

namespace RuntimeScripting
{
    public class LuaScripter : ScriptingLanguage
    {
        private Lua lua;

        public override void CompileCode(string code)
        {
            lua = new Lua();

            lua.DoString($@"
	function LuaFunction()
		{code}
	end
	");
        }

        public override string ExecuteCode()
        {
            if (lua == null)
            {
                Console.WriteLine("Code not compiled");
                return "";
            }

            try
            {
                var luaFunction = lua["LuaFunction"] as LuaFunction;

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