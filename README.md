# CLRBandicoot #

This project is an abandoned experiment in MIPS to CIL live conversion. This
project is __not__ the replacement for CrashEdit that you may be searching for;
that project will come out later.

This was an attempt to live-convert playstation game code to .NET CIL. It was
essentially the precursor to C2C, and the C2C discompiler is derived from this
codebase.

This project is likely of little interest to anyone, and I have no intention
of further developing it (although it did run and work). I am only uploading it
so it is not lost, and since it could theoretically have some minor value to
someone somewhere at some point in time, at least in concept.

Major issues with this release:

 * I have no idea if the current version will run. I'm uploading this basically
as-is from my drive.
 * The modified PCSX emulator used alongside this (as "psx.dll") does not seem
to be included. This would have to be hacked together again; the necessary API
calls to expose are all declared in `PCSX.cs`.
 * The `Main.cs` file is hardcoded to use the path `D:\C2C\C2C.BIN`.
 * The performance is atrocious. I do not have any strong theories on the exact
cause, but it is of little point; C2C is a much more reliable project for this
purpose.

I would not recommend attempting to use this software.
