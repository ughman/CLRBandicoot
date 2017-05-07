using System;
using System.Collections.Generic;

namespace CLRBandicoot
{
    public static class BIOS
    {
        [EmuDirectMethodAttribute(0xA0)]
        public static int A0Handler()
        {
            switch (PSX.T1)
            {
                default:
                    Console.WriteLine("[BIOS] Unknown command A0/{0:X}h ({1})",PSX.T1,PCSX.A0Name(PSX.T1));
                    PSX.PC = 0xA0;
                    PCSX.ExecuteOnce();
                    return PSX.PC;
            }
        }

        [EmuDirectMethodAttribute(0xB0)]
        public static int B0Handler()
        {
            switch (PSX.T1)
            {
                //case 0x7:
                //case 0x8:
                //case 0xC:
                case 0x17:
                //case 0x18:
                //case 0x19:
                    PSX.PC = 0xB0;
                    PCSX.ExecuteOnce();
                    return PSX.PC;
                default:
                    Console.WriteLine("[BIOS] Unknown command B0/{0:X}h ({1})",PSX.T1,PCSX.B0Name(PSX.T1));
                    PSX.PC = 0xB0;
                    PCSX.ExecuteOnce();
                    return PSX.PC;
            }
        }

        [EmuDirectMethodAttribute(0xC0)]
        public static int C0Handler()
        {
            switch (PSX.T1)
            {
                default:
                    Console.WriteLine("[BIOS] Unknown command C0/{0:X}h ({1})",PSX.T1,PCSX.C0Name(PSX.T1));
                    PSX.PC = 0xC0;
                    PCSX.ExecuteOnce();
                    return PSX.PC;
            }
        }
    }
}
