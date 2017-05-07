using System;

namespace CLRBandicoot
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class EmuDirectMethodAttribute : Attribute
    {
        private int address;

        public EmuDirectMethodAttribute(int address)
        {
            this.address = address;
        }

        public int Address
        {
            get { return address; }
        }
    }
}
