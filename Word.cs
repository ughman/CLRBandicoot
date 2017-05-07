using System;
using System.Reflection;

namespace CLRBandicoot
{
    public sealed class Word
    {
        private int address;
        private bool marked;
        private EmuDelegate method;
        private MethodInfo methodinfo;

        internal Word(int address)
        {
            if ((address & 3) != 0)
                throw new ArgumentException("Address is unaligned.");
            this.Milliseconds = 0;
            this.address = address;
            this.marked = false;
            this.method = null;
            this.methodinfo = null;
        }

        public long Milliseconds;

        public int Address
        {
            get { return address; }
        }

        public int Value
        {
            get { return PCSX.ReadMemory32(address); }
            set { PCSX.WriteMemory32(address,value); }
        }

        public EmuDelegate Method
        {
            get { return method; }
            set { method = value; }
        }

        public MethodInfo MethodInfo
        {
            get { return methodinfo; }
            set { methodinfo = value; }
        }

        public bool Mark()
        {
            if (!marked)
            {
                marked = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
