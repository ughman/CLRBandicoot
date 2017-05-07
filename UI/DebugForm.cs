using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace CLRBandicoot.UI
{
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
            tmUpdate_Tick(null,null);
        }

        private void tmUpdate_Tick(object sender,EventArgs e)
        {
            List<Word> words = new List<Word>();
            for (int i = 0;i < 0x200000;i += 4)
            {
                Word word = PSX.GetWord(i);
                if (word.Milliseconds > 0)
                {
                    words.Add(word);
                }
            }
            words.Sort(ProfileComparison);
            lblProfile.Text = "";
            for (int i = 0;i < 12 && i < words.Count;i++)
            {
                Word word = words[i];
                lblProfile.Text += string.Format("{0:X8}: {1,8}ms\n",word.Address,word.Milliseconds);
            }
            lblMemoryBase.Text = PCSX.GetBaseMemoryAddress().ToString("X8");
            lblAT.Text = PSX.AT.ToString("X8");
            lblV0.Text = PSX.V0.ToString("X8");
            lblV1.Text = PSX.V1.ToString("X8");
            lblA0.Text = PSX.A0.ToString("X8");
            lblA1.Text = PSX.A1.ToString("X8");
            lblA2.Text = PSX.A2.ToString("X8");
            lblA3.Text = PSX.A3.ToString("X8");
            lblPC.Text = PSX.PC.ToString("X8");
            /*StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Host Address: {0:X8}\n",PCSX.GetBaseMemoryAddress());
            sb.AppendLine();
            sb.AppendFormat("AT: {0:X8}\n",PSX.AT);
            sb.AppendFormat("V0: {0:X8}\n",PSX.V0);
            sb.AppendFormat("V1: {0:X8}\n",PSX.V1);
            sb.AppendFormat("A0: {0:X8}\n",PSX.A0);
            sb.AppendFormat("A1: {0:X8}\n",PSX.A1);
            sb.AppendFormat("A2: {0:X8}\n",PSX.A2);
            sb.AppendFormat("A3: {0:X8}\n",PSX.A3);
            sb.AppendFormat("T0: {0:X8}\n",PSX.T0);
            sb.AppendFormat("T1: {0:X8}\n",PSX.T1);
            sb.AppendFormat("T2: {0:X8}\n",PSX.T2);
            sb.AppendFormat("T3: {0:X8}\n",PSX.T3);
            sb.AppendFormat("T4: {0:X8}\n",PSX.T4);
            sb.AppendFormat("T5: {0:X8}\n",PSX.T5);
            sb.AppendFormat("T6: {0:X8}\n",PSX.T6);
            sb.AppendFormat("T7: {0:X8}\n",PSX.T7);
            sb.AppendFormat("S0: {0:X8}\n",PSX.S0);
            sb.AppendFormat("S1: {0:X8}\n",PSX.S1);
            sb.AppendFormat("S2: {0:X8}\n",PSX.S2);
            sb.AppendFormat("S3: {0:X8}\n",PSX.S3);
            sb.AppendFormat("S4: {0:X8}\n",PSX.S4);
            sb.AppendFormat("S5: {0:X8}\n",PSX.S5);
            sb.AppendFormat("S6: {0:X8}\n",PSX.S6);
            sb.AppendFormat("S7: {0:X8}\n",PSX.S7);
            sb.AppendFormat("T8: {0:X8}\n",PSX.T8);
            sb.AppendFormat("T9: {0:X8}\n",PSX.T9);
            sb.AppendFormat("K0: {0:X8}\n",PSX.K0);
            sb.AppendFormat("K1: {0:X8}\n",PSX.K1);
            sb.AppendFormat("GP: {0:X8}\n",PSX.GP);
            sb.AppendFormat("SP: {0:X8}\n",PSX.SP);
            sb.AppendFormat("FP: {0:X8}\n",PSX.FP);
            sb.AppendFormat("RA: {0:X8}\n",PSX.RA);
            sb.AppendLine();
            sb.AppendFormat("HI: {0:X8}\n",PSX.HI);
            sb.AppendFormat("LO: {0:X8}\n",PSX.LO);
            sb.AppendLine();
            sb.AppendFormat("PC: {0:X8}",PSX.PC);
            lblRegisters.Text = sb.ToString();*/
        }

        private int ProfileComparison(Word left,Word right)
        {
            return Math.Sign(right.Milliseconds - left.Milliseconds);
        }

        private void chkReadBreakpoint_CheckedChanged(object sender,EventArgs e)
        {
            if (!chkReadBreakpoint.Checked)
            {
                PCSX.SetReadBreakpoint(0);
            }
            else
            {
                int address;
                if (int.TryParse(txtReadBreakpoint.Text,NumberStyles.HexNumber,null,out address))
                    PCSX.SetReadBreakpoint(address);
                else
                    chkReadBreakpoint.Checked = false;
            }
            txtReadBreakpoint.ReadOnly = chkReadBreakpoint.Checked;
        }

        private void chkWriteBreakpoint_CheckedChanged(object sender,EventArgs e)
        {
            if (!chkWriteBreakpoint.Checked)
            {
                PCSX.SetWriteBreakpoint(0);
            }
            else
            {
                int address;
                if (int.TryParse(txtWriteBreakpoint.Text,NumberStyles.HexNumber,null,out address))
                    PCSX.SetWriteBreakpoint(address);
                else
                    chkWriteBreakpoint.Checked = false;
            }
            txtWriteBreakpoint.ReadOnly = chkWriteBreakpoint.Checked;
        }

        private void chkExecuteBreakpoint_CheckedChanged(object sender,EventArgs e)
        {
            if (!chkExecuteBreakpoint.Checked)
            {
                PCSX.SetExecuteBreakpoint(0);
            }
            else
            {
                int address;
                if (int.TryParse(txtExecuteBreakpoint.Text,NumberStyles.HexNumber,null,out address))
                    PCSX.SetExecuteBreakpoint(address);
                else
                    chkExecuteBreakpoint.Checked = false;
            }
            txtExecuteBreakpoint.ReadOnly = chkExecuteBreakpoint.Checked;
        }
    }
}
