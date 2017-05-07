using System;
using System.Runtime.InteropServices;

namespace CLRBandicoot
{
    public static class PCSX
    {
        [DllImport("psx.dll",EntryPoint = "pcsxInit")]
        public static extern void Init([MarshalAs(UnmanagedType.LPStr)]string filename,out IntPtr regbase);

        [DllImport("psx.dll",EntryPoint = "pcsxReadGPR")]
        public static extern int ReadGPR(MIPS.Register register);

        [DllImport("psx.dll",EntryPoint = "pcsxWriteGPR")]
        public static extern void WriteGPR(MIPS.Register register,int value);

        [DllImport("psx.dll",EntryPoint = "pcsxReadHI")]
        public static extern int ReadHI();

        [DllImport("psx.dll",EntryPoint = "pcsxWriteHI")]
        public static extern void WriteHI(int value);

        [DllImport("psx.dll",EntryPoint = "pcsxReadLO")]
        public static extern int ReadLO();

        [DllImport("psx.dll",EntryPoint = "pcsxWriteLO")]
        public static extern void WriteLO(int value);

        [DllImport("psx.dll",EntryPoint = "pcsxReadPC")]
        public static extern int ReadPC();

        [DllImport("psx.dll",EntryPoint = "pcsxWritePC")]
        public static extern void WritePC(int value);

        [DllImport("psx.dll",EntryPoint = "pcsxReadMemory8")]
        public static extern byte ReadMemory8(int address);

        [DllImport("psx.dll",EntryPoint = "pcsxWriteMemory8")]
        public static extern void WriteMemory8(int address,byte value);

        [DllImport("psx.dll",EntryPoint = "pcsxReadMemory16")]
        public static extern short ReadMemory16(int address);

        [DllImport("psx.dll",EntryPoint = "pcsxWriteMemory16")]
        public static extern void WriteMemory16(int address,short value);

        [DllImport("psx.dll",EntryPoint = "pcsxReadMemory32")]
        public static extern int ReadMemory32(int address);

        [DllImport("psx.dll",EntryPoint = "pcsxWriteMemory32")]
        public static extern void WriteMemory32(int address,int value);

        [DllImport("psx.dll",EntryPoint = "pcsxReadCOPData")]
        public static extern int ReadCOPData(int copid,int copregister);

        [DllImport("psx.dll",EntryPoint = "pcsxWriteCOPData")]
        public static extern void WriteCOPData(int copid,int copregister,int value);

        [DllImport("psx.dll",EntryPoint = "pcsxReadCOPControl")]
        public static extern int ReadCOPControl(int copid,int copregister);

        [DllImport("psx.dll",EntryPoint = "pcsxWriteCOPControl")]
        public static extern void WriteCOPControl(int copid,int copregister,int value);

        [DllImport("psx.dll",EntryPoint = "pcsxExecuteCOP")]
        public static extern void ExecuteCOP(int copid,int copargs);

        [DllImport("psx.dll",EntryPoint = "pcsxExecuteOnce")]
        public static extern void ExecuteOnce();

        [DllImport("psx.dll",EntryPoint = "pcsxExecuteBlock")]
        public static extern void ExecuteBlock();

        [DllImport("psx.dll",EntryPoint = "pcsxSyscall")]
        public static extern void Syscall(int pc);

        [DllImport("psx.dll",EntryPoint = "pcsxCycle")]
        public static extern void Cycle(int clocks);

        [DllImport("psx.dll",EntryPoint = "pcsxRunInterrupts")]
        public static extern void RunInterrupts();

        [DllImport("psx.dll",EntryPoint = "pcsxA0Name")]
        [return:MarshalAs(UnmanagedType.LPStr)]
        public static extern string A0Name(int id);

        [DllImport("psx.dll",EntryPoint = "pcsxB0Name")]
        [return:MarshalAs(UnmanagedType.LPStr)]
        public static extern string B0Name(int id);

        [DllImport("psx.dll",EntryPoint = "pcsxC0Name")]
        [return:MarshalAs(UnmanagedType.LPStr)]
        public static extern string C0Name(int id);

        [DllImport("psx.dll",EntryPoint = "pcsxGetBaseMemoryAddress")]
        public static extern IntPtr GetBaseMemoryAddress();

        [DllImport("psx.dll",EntryPoint = "pcsxSetReadBP")]
        public static extern void SetReadBreakpoint(int address);

        [DllImport("psx.dll",EntryPoint = "pcsxSetWriteBP")]
        public static extern void SetWriteBreakpoint(int address);

        [DllImport("psx.dll",EntryPoint = "pcsxSetExecBP")]
        public static extern void SetExecuteBreakpoint(int address);
    }
}
