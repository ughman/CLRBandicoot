using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class BEQInstruction : Instruction
    {
        private Register rs;
        private Register rt;
        private int offset;

        public BEQInstruction(Register rs,Register rt,int offset)
        {
            this.rs = rs;
            this.rt = rt;
            this.offset = offset;
        }

        public override string ToString()
        {
            return string.Format("BEQ ${0},${1},{2:X}",rs,rt,offset * 4 + 4);
        }

        public override int Execute(Instruction next)
        {
            if (next == null)
                throw new PSXException();
            int rsv = PSX.ReadRegister(rs);
            int rtv = PSX.ReadRegister(rt);
            if (rsv == rtv)
            {
                next.Execute(null);
                return PSX.PC + offset * 4 + 4;
            }
            else
            {
                return PSX.PC + 4;
            }
        }

        public override void Mark(Compiler c,int address)
        {
            base.Mark(c,address);
            c.Mark(address + offset * 4 + 4);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefaultBranch(c,address,direct);
            if (!direct)
                throw new PSXException();
            Word nextword = PSX.GetWord(address + 4);
            Word branchword = PSX.GetWord(address + offset * 4 + 4);
            Label label = c.IL.DefineLabel();
            c.LoadRegister(rs);
            c.LoadRegister(rt);
            c.IL.Emit(OpCodes.Bne_Un,label);
            Disassemble(nextword.Value).Compile(c,address + 4,false);
            c.Jump(branchword);
            c.IL.MarkLabel(label);
            return true;
        }
    }
}
