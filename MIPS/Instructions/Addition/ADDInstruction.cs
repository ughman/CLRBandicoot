using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class ADDInstruction : Instruction
    {
        private Register rs;
        private Register rt;
        private Register rd;

        public ADDInstruction(Register rs,Register rt,Register rd)
        {
            this.rs = rs;
            this.rt = rt;
            this.rd = rd;
        }

        public override string ToString()
        {
            return string.Format("ADD ${0},${1},${2}",rd,rs,rt);
        }

        public override int Execute(Instruction next)
        {
            int rsv = PSX.ReadRegister(rs);
            int rtv = PSX.ReadRegister(rt);
            checked
            {
                PSX.WriteRegister(rd,rsv + rtv);
            }
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.LoadRegister(rt);
            c.IL.Emit(OpCodes.Add_Ovf);
            c.StoreRegister(rd);
            return true;
        }
    }
}
