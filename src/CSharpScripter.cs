using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis;
using System.Reflection;

namespace RuntimeScripting
{
    public class CSharpScripter : ScriptingLanguage
    {
        private Assembly? _assembly;

        public override bool CompileCode(string code, out string message)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText($@"
                using System;

                namespace RoslynCompileSample
                {{
                    public class Writer
                    {{
                        public object Write()
                        {{
                            {code}
                        }}
                    }}
                }}");

            string assemblyName = Path.GetRandomFileName();
            MetadataReference[] references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location)
            };

            CSharpCompilationOptions compileOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);
            CSharpCompilation compilation = CSharpCompilation.Create(assemblyName, [syntaxTree], references, compileOptions);

            using (var memoryStream = new MemoryStream())
            {
                EmitResult result = compilation.Emit(memoryStream);

                if (!result.Success)
                {
                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    message = "";
                    foreach (Diagnostic diagnostic in failures)
                    {
                        message += $"{diagnostic.Id}: {diagnostic.GetMessage()}" + Environment.NewLine;
                    }

                    return false;
                }
                else
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    _assembly = Assembly.Load(memoryStream.ToArray());

                    message = "No errors";
                    return true;
                }
            }
        }

        public override string ExecuteCode()
        {
            if (_assembly == null)
            {
                Console.WriteLine("Code not compiled");
                return "";
            }

            try
            {
                Type type = _assembly.GetType("RoslynCompileSample.Writer");
                object obj = Activator.CreateInstance(type);
                object result = type.InvokeMember("Write", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, []);

                if (result == null) return "Result is null";

                string resultMessage = result.ToString();
                return "Results: " + resultMessage;
            }
            catch (Exception exception)
            {
                return "Failed to run code: " + exception.Message;
            }
        }
    }
}