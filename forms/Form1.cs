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
            _cSharpScripter.Compile(CSharpCode.Text, out string resultMessage, out double time);
            Log(CSharpConsole, resultMessage);
        }

        private void CSharpRun_Click(object sender, EventArgs e)
        {
            if (_cSharpScripter == null)
            {
                Log(CSharpConsole, "C# code not compiled");
                return;
            }

            _cSharpScripter.Run(out string resultMessage, out double time);
            Log(CSharpConsole, resultMessage);
        }

        private void LuaCompile_Click(object sender, EventArgs e)
        {
            _luaScripter = new LuaScripter();
            _luaScripter.Compile(LuaCode.Text, out string resultMessage, out double time);
            Log(LuaConsole, resultMessage);
        }

        private void LuaRun_Click(object sender, EventArgs e)
        {
            if (_luaScripter == null)
            {
                Log(LuaConsole, "Lua code not compiled");
                return;
            }

            _luaScripter.Run(out string resultMessage, out double time);
            Log(LuaConsole, resultMessage);
        }

        private void PythonCompile_Click(object sender, EventArgs e)
        {
            _pythonScripter = new PythonScripter();
            _pythonScripter.Compile(PythonCode.Text, out string resultMessage, out double time);
            Log(PythonConsole, resultMessage);
        }

        private void PythonRun_Click(object sender, EventArgs e)
        {
            if (_pythonScripter == null)
            {
                Log(PythonCode, "Lua code not compiled");
                return;
            }

            _pythonScripter.Run(out string resultMessage, out double time);
            Log(PythonConsole, resultMessage);
        }

        private void TestAllButton_Click(object sender, EventArgs e)
        {
            int compilationCount = 5;
            int runCount = 10;

            //Test C#
            _cSharpScripter = new CSharpScripter();
            TestScriptingLanguage(_cSharpScripter, CSharpCode, CSharpConsole, compilationCount, runCount);

            //Test Lua
            _luaScripter = new LuaScripter();
            TestScriptingLanguage(_luaScripter, LuaCode, LuaConsole, compilationCount, runCount);

            //Test python
            _pythonScripter = new PythonScripter();
            TestScriptingLanguage(_pythonScripter, PythonCode, PythonConsole, compilationCount, runCount);
        }

        private void TestScriptingLanguage(ScriptingLanguage scriptingLanguage, TextBox code, TextBox console, int compilationCount, int runCount)
        {
            List<double> compilationResults = TestCompilation(scriptingLanguage, code, console, compilationCount);
            if (compilationResults.Count != compilationCount)
            {
                Log(console, "Failed to complete compilation test");
                return;
            }

            Log(console, $"Median compile time: {GetMedian(compilationResults)} ms");

            List<double> runResults = TestRun(scriptingLanguage, console, runCount);
            if (runResults.Count != runCount)
            {
                Log(console, "Failed to complete run test", false);
                return;
            }

            Log(console, $"Median run time: {GetMedian(runResults)} ms", false);
        }

        private List<double> TestCompilation(ScriptingLanguage scriptingLanguage, TextBox code, TextBox console, int count)
        {
            List<double> results = new List<double>();
            for (int i = 0; i < count; i++)
            {
                if (!scriptingLanguage.Compile(code.Text, out string resultMessage, out double time))
                {
                    Log(console, resultMessage);
                    break;
                }
                results.Add(time);
            }
            return results;
        }

        private List<double> TestRun(ScriptingLanguage scriptingLanguage, TextBox console, int count)
        {
            List<double> results = new List<double>();
            for (int i = 0; i < count; i++)
            {
                if (!scriptingLanguage.Run(out string resultMessage, out double time))
                {
                    Log(console, resultMessage, false);
                    break;
                }
                results.Add(time);
            }
            return results;
        }

        private double GetMedian(List<double> values)
        {
            if (values == null || values.Count == 0)
                throw new ArgumentException("The list must contain at least one value.");

            values.Sort();

            int count = values.Count;
            if (count % 2 == 0)
            {
                int middleIndex = count / 2;
                return (values[middleIndex - 1] + values[middleIndex]) / 2;
            }

            return values[count / 2];
        }

        private void Log(TextBox console, string message, bool clear = true)
        {
            if (clear)
            {
                console.Text = message;
                return;
            }

            console.Text += Environment.NewLine + message;
        }
    }
}