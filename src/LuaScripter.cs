namespace RuntimeScripting.src
{
    public class LuaScripter : ScriptingLanguage
    {
        private dynamic? lua;

        public void Compile(string code)
        {
            lua = new DynamicLua.DynamicLua();
            lua("function luafunction() return 99 + 1 end");
        }

        public void Run()
        {
            if (lua == null)
            {
                Console.WriteLine("Code not compiled");
                return;
            }

            dynamic answer2 = lua.luafunction();
            Console.WriteLine(answer2);
        }
    }
}