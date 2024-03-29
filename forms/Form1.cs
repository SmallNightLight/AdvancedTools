namespace RuntimeScripting
{
    public partial class Form1 : Form
    {
        private CSharpScripter? _cSharpScripter;
        private LuaScripter? _luaScripter;
        private PythonScripter? _pythonScripter;

        public Form1()
        {
            InitializeComponent();
        }

        private void CSharpCompile_Click(object sender, EventArgs e)
        {
            _cSharpScripter = new CSharpScripter();
            string resultMessage = _cSharpScripter.Compile(CSharpCode.Text);
            Log(CSharpConsole, resultMessage);
        }

        private void CSharpRun_Click(object sender, EventArgs e)
        {
            if (_cSharpScripter == null)
            {
                Log(CSharpConsole, "C# code not compiled");
                return;
            }

            string resultMessage = _cSharpScripter.Run();
            Log(CSharpConsole, resultMessage);
        }

        private void LuaCompile_Click(object sender, EventArgs e)
        {
            _luaScripter = new LuaScripter();
            string resultMessage = _luaScripter.Compile(LuaCode.Text);
            Log(LuaConsole, resultMessage);
        }

        private void LuaRun_Click(object sender, EventArgs e)
        {
            if (_luaScripter == null)
            {
                Log(LuaConsole, "Lua code not compiled");
                return;
            }

            string resultMessage = _luaScripter.Run();
            Log(LuaConsole, resultMessage);
        }

        private void PythonCompile_Click(object sender, EventArgs e)
        {
            _pythonScripter = new PythonScripter();
            string resultMessage = _pythonScripter.Compile(PythonCode.Text);
            Log(PythonConsole, resultMessage);
        }

        private void PythonRun_Click(object sender, EventArgs e)
        {
            if (_pythonScripter == null)
            {
                Log(PythonCode, "Lua code not compiled");
                return;
            }

            string resultMessage = _pythonScripter.Run();
            Log(PythonConsole, resultMessage);
        }

        private void Log(TextBox console, string message)
        {
            console.Clear();
            console.Text = message;
        }
    }
}