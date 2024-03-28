namespace RuntimeScripting
{
    public partial class Form1 : Form
    {

        private LuaScripter? luaScripter;

        public Form1()
        {
            InitializeComponent();
        }

        private void CSharpCompile_Click(object sender, EventArgs e)
        {

        }

        private void CSharpRun_Click(object sender, EventArgs e)
        {

        }

        private void LuaCompile_Click(object sender, EventArgs e)
        {
            luaScripter = new LuaScripter();
            string resultMessage = luaScripter.Compile(LuaCode.Text);

            Log(LuaConsole, resultMessage);
        }

        private void LuaRun_Click(object sender, EventArgs e)
        {
            if (luaScripter == null)
            {
                Log(LuaConsole, "Lua code not compiled");
                return;
            }

            string resultMessage = luaScripter.Run();

            Log(LuaConsole, resultMessage);
        }

        private void PythonCompile_Click(object sender, EventArgs e)
        {

        }

        private void PythonRun_Click(object sender, EventArgs e)
        {

        }

        private void Log(TextBox console, string message)
        {
            console.Clear();
            console.Text = message;
        }
    }
}