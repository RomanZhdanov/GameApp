using GameApp.Application.Common.Interfaces;
using GameApp.Infrastructure.Common;
using IronPython.Hosting;

namespace GameApp.Infrastructure.Services
{
    internal static class HowLongToBeatPyService
    {
        public static IHowLongToBeatService Create()
        {
            var eng = Python.CreateEngine();
            var scope = eng.CreateScope();
            var filePath = PythonScript.GetScriptPath("HowLongToBeat.py");
            eng.ExecuteFile(filePath, scope);

            dynamic howlongtobeat = scope.GetVariable("HowLongToBeat");

            return eng.Operations.CreateInstance(howlongtobeat);
        }
    }
}
