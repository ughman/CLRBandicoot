using System.Reflection.Emit;

using System;

namespace CLRBandicoot.MIPS
{
    public sealed class JRInstruction : Instruction
    {
        private Register rs;

        public JRInstruction(Register rs)
        {
            this.rs = rs;
        }

        public override string ToString()
        {
            return string.Format("JR ${0}",rs);
        }

        public override int Execute(Instruction next)
        {
            if (next == null)
                throw new PSXException();
            int rsv = PSX.ReadRegister(rs);
            next.Execute(null);
            return rsv;
        }

        public override void Mark(Compiler c,int address)
        {
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefaultBranch(c,address,direct);
            if (!direct)
                throw new PSXException();
            Word nextword = PSX.GetWord(address + 4);
            Disassemble(nextword.Value).Compile(c,address + 4,false);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Ret);
            return false;
        }
    }
}
