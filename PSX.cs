using System;
using System.Reflection;

namespace CLRBandicoot
{
    public static class PSX
    {
        private static long lasttime;
        private static System.Diagnostics.Stopwatch stopwatch;
        private static Word[] words;

        static PSX()
        {
            lasttime = 0;
            stopwatch = System.Diagnostics.Stopwatch.StartNew();
            words = new Word [524288];
            for (int i = 0;i < words.Length;i++)
            {
                words[i] = new Word(int.MinValue + i * 4);
            }
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Static))
                {
                    foreach (EmuDirectMethodAttribute attribute in method.GetCustomAttributes(typeof(EmuDirectMethodAttribute),false))
                    {
                        Word word = GetWord(attribute.Address);
                        if (!word.Mark())
                            throw new InvalidOperationException();
                        word.MethodInfo = method;
                        word.Method = (EmuDelegate)Delegate.CreateDelegate(typeof(EmuDelegate),method);
                    }
                }
            }
        }

        public static IntPtr RegBase;

        public static int AT
        {
            get { return PCSX.ReadGPR(MIPS.Register.AT); }
            set { PCSX.WriteGPR(MIPS.Register.AT,value); }
        }

        public static int V0
        {
            get { return PCSX.ReadGPR(MIPS.Register.V0); }
            set { PCSX.WriteGPR(MIPS.Register.V0,value); }
        }

        public static int V1
        {
            get { return PCSX.ReadGPR(MIPS.Register.V1); }
            set { PCSX.WriteGPR(MIPS.Register.V1,value); }
        }

        public static int A0
        {
            get { return PCSX.ReadGPR(MIPS.Register.A0); }
            set { PCSX.WriteGPR(MIPS.Register.A0,value); }
        }

        public static int A1
        {
            get { return PCSX.ReadGPR(MIPS.Register.A1); }
            set { PCSX.WriteGPR(MIPS.Register.A1,value); }
        }

        public static int A2
        {
            get { return PCSX.ReadGPR(MIPS.Register.A2); }
            set { PCSX.WriteGPR(MIPS.Register.A2,value); }
        }

        public static int A3
        {
            get { return PCSX.ReadGPR(MIPS.Register.A3); }
            set { PCSX.WriteGPR(MIPS.Register.A3,value); }
        }

        public static int T0
        {
            get { return PCSX.ReadGPR(MIPS.Register.T0); }
            set { PCSX.WriteGPR(MIPS.Register.T0,value); }
        }

        public static int T1
        {
            get { return PCSX.ReadGPR(MIPS.Register.T1); }
            set { PCSX.WriteGPR(MIPS.Register.T1,value); }
        }

        public static int T2
        {
            get { return PCSX.ReadGPR(MIPS.Register.T2); }
            set { PCSX.WriteGPR(MIPS.Register.T2,value); }
        }

        public static int T3
        {
            get { return PCSX.ReadGPR(MIPS.Register.T3); }
            set { PCSX.WriteGPR(MIPS.Register.T3,value); }
        }

        public static int T4
        {
            get { return PCSX.ReadGPR(MIPS.Register.T4); }
            set { PCSX.WriteGPR(MIPS.Register.T4,value); }
        }

        public static int T5
        {
            get { return PCSX.ReadGPR(MIPS.Register.T5); }
            set { PCSX.WriteGPR(MIPS.Register.T5,value); }
        }

        public static int T6
        {
            get { return PCSX.ReadGPR(MIPS.Register.T6); }
            set { PCSX.WriteGPR(MIPS.Register.T6,value); }
        }

        public static int T7
        {
            get { return PCSX.ReadGPR(MIPS.Register.T7); }
            set { PCSX.WriteGPR(MIPS.Register.T7,value); }
        }

        public static int S0
        {
            get { return PCSX.ReadGPR(MIPS.Register.S0); }
            set { PCSX.WriteGPR(MIPS.Register.S0,value); }
        }

        public static int S1
        {
            get { return PCSX.ReadGPR(MIPS.Register.S1); }
            set { PCSX.WriteGPR(MIPS.Register.S1,value); }
        }

        public static int S2
        {
            get { return PCSX.ReadGPR(MIPS.Register.S2); }
            set { PCSX.WriteGPR(MIPS.Register.S2,value); }
        }

        public static int S3
        {
            get { return PCSX.ReadGPR(MIPS.Register.S3); }
            set { PCSX.WriteGPR(MIPS.Register.S3,value); }
        }

        public static int S4
        {
            get { return PCSX.ReadGPR(MIPS.Register.S4); }
            set { PCSX.WriteGPR(MIPS.Register.S4,value); }
        }

        public static int S5
        {
            get { return PCSX.ReadGPR(MIPS.Register.S5); }
            set { PCSX.WriteGPR(MIPS.Register.S5,value); }
        }

        public static int S6
        {
            get { return PCSX.ReadGPR(MIPS.Register.S6); }
            set { PCSX.WriteGPR(MIPS.Register.S6,value); }
        }

        public static int S7
        {
            get { return PCSX.ReadGPR(MIPS.Register.S7); }
            set { PCSX.WriteGPR(MIPS.Register.S7,value); }
        }

        public static int T8
        {
            get { return PCSX.ReadGPR(MIPS.Register.T8); }
            set { PCSX.WriteGPR(MIPS.Register.T8,value); }
        }

        public static int T9
        {
            get { return PCSX.ReadGPR(MIPS.Register.T9); }
            set { PCSX.WriteGPR(MIPS.Register.T9,value); }
        }

        public static int K0
        {
            get { return PCSX.ReadGPR(MIPS.Register.K0); }
            set { PCSX.WriteGPR(MIPS.Register.K0,value); }
        }

        public static int K1
        {
            get { return PCSX.ReadGPR(MIPS.Register.K1); }
            set { PCSX.WriteGPR(MIPS.Register.K1,value); }
        }

        public static int GP
        {
            get { return PCSX.ReadGPR(MIPS.Register.GP); }
            set { PCSX.WriteGPR(MIPS.Register.GP,value); }
        }

        public static int SP
        {
            get { return PCSX.ReadGPR(MIPS.Register.SP); }
            set { PCSX.WriteGPR(MIPS.Register.SP,value); }
        }

        public static int FP
        {
            get { return PCSX.ReadGPR(MIPS.Register.FP); }
            set { PCSX.WriteGPR(MIPS.Register.FP,value); }
        }

        public static int RA
        {
            get { return PCSX.ReadGPR(MIPS.Register.RA); }
            set { PCSX.WriteGPR(MIPS.Register.RA,value); }
        }

        public static int HI
        {
            get { return PCSX.ReadHI(); }
            set { PCSX.WriteHI(value); }
        }

        public static int LO
        {
            get { return PCSX.ReadLO(); }
            set { PCSX.WriteLO(value); }
        }

        public static int PC
        {
            get { return PCSX.ReadPC(); }
            set { PCSX.WritePC(value); }
        }

        public static void Init(string filename)
        {
            PCSX.Init(filename,out RegBase);
        }

        public static Word GetWord(int address)
        {
            if ((address & 3) != 0)
                throw new ArgumentException("Address is unaligned.");
            uint uaddress = (uint)address;
            if (uaddress < 0x200000)
            {
                return words[uaddress / 4];
            }
            else if (uaddress >= 0x80000000 && uaddress < 0x80200000)
            {
                return words[(uaddress - 0x80000000) / 4];
            }
            else if (uaddress >= 0xA0000000 && uaddress < 0xA0200000)
            {
                return words[(uaddress - 0xA0000000) / 4];
            }
            else
            {
                throw new PSXException();
            }
        }

        public static int ReadRegister(MIPS.Register register)
        {
            switch (register)
            {
                case MIPS.Register.R0:
                    return 0;
                case MIPS.Register.AT:
                    return AT;
                case MIPS.Register.V0:
                    return V0;
                case MIPS.Register.V1:
                    return V1;
                case MIPS.Register.A0:
                    return A0;
                case MIPS.Register.A1:
                    return A1;
                case MIPS.Register.A2:
                    return A2;
                case MIPS.Register.A3:
                    return A3;
                case MIPS.Register.T0:
                    return T0;
                case MIPS.Register.T1:
                    return T1;
                case MIPS.Register.T2:
                    return T2;
                case MIPS.Register.T3:
                    return T3;
                case MIPS.Register.T4:
                    return T4;
                case MIPS.Register.T5:
                    return T5;
                case MIPS.Register.T6:
                    return T6;
                case MIPS.Register.T7:
                    return T7;
                case MIPS.Register.S0:
                    return S0;
                case MIPS.Register.S1:
                    return S1;
                case MIPS.Register.S2:
                    return S2;
                case MIPS.Register.S3:
                    return S3;
                case MIPS.Register.S4:
                    return S4;
                case MIPS.Register.S5:
                    return S5;
                case MIPS.Register.S6:
                    return S6;
                case MIPS.Register.S7:
                    return S7;
                case MIPS.Register.T8:
                    return T8;
                case MIPS.Register.T9:
                    return T9;
                case MIPS.Register.K0:
                    return K0;
                case MIPS.Register.K1:
                    return K1;
                case MIPS.Register.GP:
                    return GP;
                case MIPS.Register.SP:
                    return SP;
                case MIPS.Register.FP:
                    return FP;
                case MIPS.Register.RA:
                    return RA;
                default:
                    throw new ArgumentException("Unrecognized register.");
            }
        }

        public static void WriteRegister(MIPS.Register register,int value)
        {
            switch (register)
            {
                case MIPS.Register.R0:
                    break;
                case MIPS.Register.AT:
                    AT = value;
                    break;
                case MIPS.Register.V0:
                    V0 = value;
                    break;
                case MIPS.Register.V1:
                    V1 = value;
                    break;
                case MIPS.Register.A0:
                    A0 = value;
                    break;
                case MIPS.Register.A1:
                    A1 = value;
                    break;
                case MIPS.Register.A2:
                    A2 = value;
                    break;
                case MIPS.Register.A3:
                    A3 = value;
                    break;
                case MIPS.Register.T0:
                    T0 = value;
                    break;
                case MIPS.Register.T1:
                    T1 = value;
                    break;
                case MIPS.Register.T2:
                    T2 = value;
                    break;
                case MIPS.Register.T3:
                    T3 = value;
                    break;
                case MIPS.Register.T4:
                    T4 = value;
                    break;
                case MIPS.Register.T5:
                    T5 = value;
                    break;
                case MIPS.Register.T6:
                    T6 = value;
                    break;
                case MIPS.Register.T7:
                    T7 = value;
                    break;
                case MIPS.Register.S0:
                    S0 = value;
                    break;
                case MIPS.Register.S1:
                    S1 = value;
                    break;
                case MIPS.Register.S2:
                    S2 = value;
                    break;
                case MIPS.Register.S3:
                    S3 = value;
                    break;
                case MIPS.Register.S4:
                    S4 = value;
                    break;
                case MIPS.Register.S5:
                    S5 = value;
                    break;
                case MIPS.Register.S6:
                    S6 = value;
                    break;
                case MIPS.Register.S7:
                    S7 = value;
                    break;
                case MIPS.Register.T8:
                    T8 = value;
                    break;
                case MIPS.Register.T9:
                    T9 = value;
                    break;
                case MIPS.Register.K0:
                    K0 = value;
                    break;
                case MIPS.Register.K1:
                    K1 = value;
                    break;
                case MIPS.Register.GP:
                    GP = value;
                    break;
                case MIPS.Register.SP:
                    SP = value;
                    break;
                case MIPS.Register.FP:
                    FP = value;
                    break;
                case MIPS.Register.RA:
                    RA = value;
                    break;
                default:
                    throw new ArgumentException("Unrecognized register.");
            }
        }

        public static byte ReadMemory8(int address)
        {
            return PCSX.ReadMemory8(address);
        }

        public static void WriteMemory8(int address,byte value)
        {
            PCSX.WriteMemory8(address,value);
        }

        public static short ReadMemory16(int address)
        {
            return PCSX.ReadMemory16(address);
        }

        public static void WriteMemory16(int address,short value)
        {
            PCSX.WriteMemory16(address,value);
        }

        public static int ReadMemory32(int address)
        {
            return PCSX.ReadMemory32(address);
        }

        public static void WriteMemory32(int address,int value)
        {
            PCSX.WriteMemory32(address,value);
        }

        public static int ReadCOPData(int copid,int copregister)
        {
            return PCSX.ReadCOPData(copid,copregister);
        }

        public static void WriteCOPData(int copid,int copregister,int value)
        {
            PCSX.WriteCOPData(copid,copregister,value);
        }

        public static int ReadCOPControl(int copid,int copregister)
        {
            return PCSX.ReadCOPControl(copid,copregister);
        }

        public static void WriteCOPControl(int copid,int copregister,int value)
        {
            PCSX.WriteCOPControl(copid,copregister,value);
        }

        public static void ExecuteCOP(int copid,int copargs)
        {
            PCSX.ExecuteCOP(copid,copargs);
        }

        public static void Invoke(int address)
        {
            //Profiler.Enter(GetWord(address));
            int lastra = RA;
            //RA = 0;
            PC = address;
            do
            {
                /*Word word = GetWord(PC);
                if (word.Method != null)
                {
                    PC = word.Method();
                }
                else*/
                {
                    //Profiler.Enter(null);
                    PCSX.ExecuteBlock();
                    //Profiler.Exit();
                }
                //PCSX.Cycle(60);
                PCSX.RunInterrupts();
            }
            while (PC != lastra);
            RA = lastra;
            //Profiler.Exit();
        }
    }
}
