using System.Collections.Generic;

namespace CLRBandicoot.MIPS
{
    public sealed class NativeCodeInstruction : Instruction
    {
        private static List<string> methods;

        static NativeCodeInstruction()
        {
            methods = new List<string>();
            methods.Add("???");
        }

        public static int Create(string name)
        {
            methods.Add(name);
            return (0xFF << 24) + methods.Count - 1;
        }

        private int id;

        public NativeCodeInstruction(int id)
        {
            if (id < methods.Count)
            {
                this.id = id;
            }
            else
            {
                this.id = 0;
            }
        }

        public override string ToString()
        {
            return string.Format("*** NATIVE CODE ({0}) ***",id);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            throw new PSXException();
        }
    }
}
