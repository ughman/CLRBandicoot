using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;

namespace CLRBandicoot.MIPS
{
    public sealed class Compiler
    {
        private static AssemblyBuilder assembly;
        private static ModuleBuilder module;
        private static Dictionary<Register,PropertyInfo> registers;
        private static PropertyInfo hiregister;
        private static PropertyInfo loregister;
        private static MethodInfo mem8readmethod;
        private static MethodInfo mem8writemethod;
        private static MethodInfo mem16readmethod;
        private static MethodInfo mem16writemethod;
        private static MethodInfo mem32readmethod;
        private static MethodInfo mem32writemethod;
        private static MethodInfo copreaddatamethod;
        private static MethodInfo copwritedatamethod;
        private static MethodInfo copreadcontrolmethod;
        private static MethodInfo copwritecontrolmethod;
        private static MethodInfo copexecutemethod;

        static Compiler()
        {
            AssemblyName assemblyname = new AssemblyName("CLRBandicoot.MIPS.Dynamic");
            assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyname,AssemblyBuilderAccess.Run);
            module = assembly.DefineDynamicModule("CLRBandicoot.MIPS.Dynamic.dll");
            registers = new Dictionary<Register,PropertyInfo>();
            for (Register register = Register.AT;register <= Register.RA;register++)
            {
                registers.Add(register,typeof(PSX).GetProperty(register.ToString()));
            }
            hiregister = typeof(PSX).GetProperty("HI");
            loregister = typeof(PSX).GetProperty("LO");
            mem8readmethod = typeof(PSX).GetMethod("ReadMemory8");
            mem8writemethod = typeof(PSX).GetMethod("WriteMemory8");
            mem16readmethod = typeof(PSX).GetMethod("ReadMemory16");
            mem16writemethod = typeof(PSX).GetMethod("WriteMemory16");
            mem32readmethod = typeof(PSX).GetMethod("ReadMemory32");
            mem32writemethod = typeof(PSX).GetMethod("WriteMemory32");
            copreaddatamethod = typeof(PSX).GetMethod("ReadCOPData");
            copwritedatamethod = typeof(PSX).GetMethod("WriteCOPData");
            copreadcontrolmethod = typeof(PSX).GetMethod("ReadCOPControl");
            copwritecontrolmethod = typeof(PSX).GetMethod("WriteCOPControl");
            copexecutemethod = typeof(PSX).GetMethod("ExecuteCOP");
        }

        private List<Word> marks;
        private List<Word> methods;
        private ILGenerator il;

        public Compiler()
        {
            this.marks = new List<Word>();
            this.methods = new List<Word>();
            this.il = null;
        }

        public ILGenerator IL
        {
            get
            {
                if (il == null)
                    throw new InvalidOperationException();
                return il;
            }
        }

        public void Mark(int address)
        {
            Word word = PSX.GetWord(address);
            if (word.Mark())
            {
                marks.Add(word);
            }
            if (word.MethodInfo == null)
            {
                methods.Add(word);
                word.MethodInfo = new DynamicMethod(string.Format("MIPS_{0:X8}",address),typeof(int),Type.EmptyTypes,module);
            }
        }

        public void MarkDirect(int address)
        {
            Word word = PSX.GetWord(address);
            if (word.Mark())
            {
                marks.Add(word);
            }
        }

        public void Compile()
        {
            while (marks.Count > 0)
            {
                Instruction.Disassemble(marks[0].Value).Mark(this,marks[0].Address);
                marks.RemoveAt(0);
            }
            foreach (Word methodword in methods)
            {
                DynamicMethod method = (DynamicMethod)methodword.MethodInfo;
                Word word = methodword;
                il = method.GetILGenerator();
                il.DeclareLocal(typeof(int));
                il.DeclareLocal(typeof(int));
                //il.EmitWriteLine(method.Name);
                while (Instruction.Disassemble(word.Value).Compile(this,word.Address,true))
                {
                    word = PSX.GetWord(word.Address + 4);
                    if (word.MethodInfo != null)
                    {
                        Jump(word);
                        break;
                    }
                }
                il = null;
                methodword.Method = (EmuDelegate)method.CreateDelegate(typeof(EmuDelegate));
            }
            methods.Clear();
        }

        public void LoadRegister(Register register)
        {
            if (il == null)
                throw new InvalidOperationException();
            switch (register)
            {
                case Register.R0:
                    il.Emit(OpCodes.Ldc_I4_0);
                    break;
                case Register.AT:
                case Register.V0:
                case Register.V1:
                case Register.A0:
                case Register.A1:
                case Register.A2:
                case Register.A3:
                case Register.T0:
                case Register.T1:
                case Register.T2:
                case Register.T3:
                case Register.T4:
                case Register.T5:
                case Register.T6:
                case Register.T7:
                case Register.S0:
                case Register.S1:
                case Register.S2:
                case Register.S3:
                case Register.S4:
                case Register.S5:
                case Register.S6:
                case Register.S7:
                case Register.T8:
                case Register.T9:
                case Register.K0:
                case Register.K1:
                case Register.GP:
                case Register.SP:
                case Register.FP:
                case Register.RA:
                    il.Emit(OpCodes.Ldsfld,typeof(PSX).GetField("RegBase"));
                    il.Emit(OpCodes.Ldc_I4,(int)register * 4);
                    il.Emit(OpCodes.Add);
                    il.Emit(OpCodes.Ldind_I4);
                    break;
                    //il.Emit(OpCodes.Call,registers[register].GetGetMethod());
                    //break;
                default:
                    throw new ArgumentException("Unrecognized register.");
            }
        }

        public void StoreRegister(Register register)
        {
            if (il == null)
                throw new InvalidOperationException();
            switch (register)
            {
                case Register.R0:
                    il.Emit(OpCodes.Pop);
                    break;
                case Register.AT:
                case Register.V0:
                case Register.V1:
                case Register.A0:
                case Register.A1:
                case Register.A2:
                case Register.A3:
                case Register.T0:
                case Register.T1:
                case Register.T2:
                case Register.T3:
                case Register.T4:
                case Register.T5:
                case Register.T6:
                case Register.T7:
                case Register.S0:
                case Register.S1:
                case Register.S2:
                case Register.S3:
                case Register.S4:
                case Register.S5:
                case Register.S6:
                case Register.S7:
                case Register.T8:
                case Register.T9:
                case Register.K0:
                case Register.K1:
                case Register.GP:
                case Register.SP:
                case Register.FP:
                case Register.RA:
                    il.Emit(OpCodes.Stloc_0);
                    il.Emit(OpCodes.Ldsfld,typeof(PSX).GetField("RegBase"));
                    il.Emit(OpCodes.Ldc_I4,(int)register * 4);
                    il.Emit(OpCodes.Add);
                    il.Emit(OpCodes.Ldloc_0);
                    il.Emit(OpCodes.Stind_I4);
                    break;
                    //il.Emit(OpCodes.Call,registers[register].GetSetMethod());
                    //break;
                default:
                    throw new ArgumentException("Unrecognized register.");
            }
        }

        public void LoadHI()
        {
            il.Emit(OpCodes.Call,hiregister.GetGetMethod());
        }

        public void StoreHI()
        {
            il.Emit(OpCodes.Call,hiregister.GetSetMethod());
        }

        public void LoadLO()
        {
            il.Emit(OpCodes.Call,loregister.GetGetMethod());
        }

        public void StoreLO()
        {
            il.Emit(OpCodes.Call,loregister.GetSetMethod());
        }

        public void LoadMemory8()
        {
            il.Emit(OpCodes.Call,mem8readmethod);
        }

        public void StoreMemory8()
        {
            il.Emit(OpCodes.Call,mem8writemethod);
        }

        public void LoadMemory16()
        {
            il.Emit(OpCodes.Call,mem16readmethod);
        }

        public void StoreMemory16()
        {
            il.Emit(OpCodes.Call,mem16writemethod);
        }

        public void LoadMemory32()
        {
            il.Emit(OpCodes.Call,mem32readmethod);
        }

        public void StoreMemory32()
        {
            il.Emit(OpCodes.Call,mem32writemethod);
        }

        public void LoadCOPData(int copid,int copregister)
        {
            il.Emit(OpCodes.Ldc_I4,copid);
            il.Emit(OpCodes.Ldc_I4,copregister);
            il.Emit(OpCodes.Call,copreaddatamethod);
        }

        public void StoreCOPData(int copid,int copregister)
        {
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldc_I4,copid);
            il.Emit(OpCodes.Ldc_I4,copregister);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Call,copwritedatamethod);
        }

        public void LoadCOPControl(int copid,int copregister)
        {
            il.Emit(OpCodes.Ldc_I4,copid);
            il.Emit(OpCodes.Ldc_I4,copregister);
            il.Emit(OpCodes.Call,copreadcontrolmethod);
        }

        public void StoreCOPControl(int copid,int copregister)
        {
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldc_I4,copid);
            il.Emit(OpCodes.Ldc_I4,copregister);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Call,copwritecontrolmethod);
        }

        public void InvokeCOP(int copid,int copargs)
        {
            il.Emit(OpCodes.Ldc_I4,copid);
            il.Emit(OpCodes.Ldc_I4,copargs);
            il.Emit(OpCodes.Call,copexecutemethod);
        }

        public void Jump(Word target)
        {
            il.Emit(OpCodes.Ldc_I4,target.Address);
            il.Emit(OpCodes.Ret);
        }
    }
}
