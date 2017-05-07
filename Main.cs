using System;
using CLRBandicoot.UI;

namespace CLRBandicoot
{
    internal static class MainClass
    {
        [STAThread]
        private static void Main()
        {
            PSX.Init(@"D:\C2C\C2C.BIN");
            MIPS.Compiler compiler = new MIPS.Compiler();
            compiler.Mark(PSX.PC);
            compiler.Compile();
            using (DebugForm debugform = new DebugForm())
            {
                debugform.Show();
                PSX.Invoke(PSX.PC);
            }
        }
    }
}
