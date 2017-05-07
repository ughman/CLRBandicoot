using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class SBInstruction : Instruction
    {
        private Register rs;
        private Register rt;
        private int imm;

        public SBInstruction(Register rs,Register rt,int imm)
        {
            this.rs = rs;
            this.rt = rt;
            this.imm = imm;
        }

        public override string ToString()
        {
            return string.Format("SB ${0},{2}(${1})",rt,rs,imm);
        }

        public override int Execute(Instruction next)
        {
            int rsv = PSX.ReadRegister(rs);
            int rtv = PSX.ReadRegister(rt);
            PSX.WriteMemory32(rsv + imm,(byte)rtv);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Ldc_I4,imm);
            c.IL.Emit(OpCodes.Add);
            c.LoadRegister(rt);
            c.IL.Emit(OpCodes.Conv_I1);
            c.StoreMemory8();
            return true;
        }
    }
}
