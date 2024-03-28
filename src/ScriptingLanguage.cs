using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuntimeScripting.src
{
    public interface ScriptingLanguage
    {
        public void Compile(string code);

        public void Run();
    }
}