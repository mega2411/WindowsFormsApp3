using Sharp7;
using System;
using System.Windows.Forms;
using JCS;
//using System.Security.Cryptography.X509Certificates;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
           
    {
        static S7Client plc = new S7Client();
        static string IP_adress = "192.168.0.3";
        int result = plc.ConnectTo(IP_adress, 0, 2);
       
        byte[] db1buffer = {0, 0, 0, 0,0,0,0,0,0,0,0,0};
        byte[] db1buffer_1 = {0, 0};

        //public static buffer1 = new byte[16];
        public Form1()
        {
            InitializeComponent();
        }

        private void ReadPLC()
        {
            int DB = 2;
            int readresult = plc.DBRead(DB, 0, 3, db1buffer);
            if (readresult == 0)
            {
                label2.Text = "DB" + DB +" Read OK!";
                toggleSwitch1.Checked = S7.GetBitAt(db1buffer, 0, 0);
                toggleSwitch2.Checked = S7.GetBitAt(db1buffer, 0, 1);
                toggleSwitch3.Checked = S7.GetBitAt(db1buffer, 0, 2);
                toggleSwitch4.Checked = S7.GetBitAt(db1buffer, 0, 3);
                toggleSwitch5.Checked = S7.GetBitAt(db1buffer, 0, 4);
                toggleSwitch6.Checked = S7.GetBitAt(db1buffer, 0, 5);
                toggleSwitch7.Checked = S7.GetBitAt(db1buffer, 0, 6);
                toggleSwitch8.Checked = S7.GetBitAt(db1buffer, 0, 7);
                toggleSwitch9.Checked = S7.GetBitAt(db1buffer, 1, 0);
                toggleSwitch10.Checked = S7.GetBitAt(db1buffer, 1, 1);
                toggleSwitch11.Checked = S7.GetBitAt(db1buffer, 1, 2);
                toggleSwitch12.Checked = S7.GetBitAt(db1buffer, 1, 3);
                toggleSwitch13.Checked = S7.GetBitAt(db1buffer, 1, 4);
                toggleSwitch14.Checked = S7.GetBitAt(db1buffer, 1, 5);
                toggleSwitch15.Checked = S7.GetBitAt(db1buffer, 1, 6);
                toggleSwitch16.Checked = S7.GetBitAt(db1buffer, 1, 7);
                //label3.Text = Convert.ToString(S7.GetLRealAt(db1buffer, 2));
               label3.Text = Convert.ToString(S7.GetRealAt(db1buffer, 2));    
            }
            else
            {
                label2.Text = "DB" + DB + " Read ERROR!";
            }
        }
        private void WritePLC()
        {
            int writeresult = plc.DBWrite(1, 0, db1buffer_1.Length, db1buffer_1);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ReadPLC();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (result == 0)
            {
                label1.Text = "Connected to" + " " + IP_adress;
                timer1.Enabled=true;
                timer1.Start();
                S7.SetBitAt(ref db1buffer_1, 0, 0, toggleSwitch1.Checked);
                S7.SetBitAt(ref db1buffer_1, 0, 1, toggleSwitch2.Checked);
                S7.SetBitAt(ref db1buffer_1, 0, 2, toggleSwitch3.Checked);
                S7.SetBitAt(ref db1buffer_1, 0, 3, toggleSwitch4.Checked);
                S7.SetBitAt(ref db1buffer_1, 0, 4, toggleSwitch5.Checked);
                S7.SetBitAt(ref db1buffer_1, 0, 5, toggleSwitch6.Checked);
                S7.SetBitAt(ref db1buffer_1, 0, 6, toggleSwitch7.Checked);
                S7.SetBitAt(ref db1buffer_1, 0, 7, toggleSwitch8.Checked);
                S7.SetBitAt(ref db1buffer_1, 1, 0, toggleSwitch9.Checked);
                S7.SetBitAt(ref db1buffer_1, 1, 1, toggleSwitch10.Checked);
                S7.SetBitAt(ref db1buffer_1, 1, 2, toggleSwitch11.Checked);
                S7.SetBitAt(ref db1buffer_1, 1, 3, toggleSwitch12.Checked);
                S7.SetBitAt(ref db1buffer_1, 1, 4, toggleSwitch13.Checked);
                S7.SetBitAt(ref db1buffer_1, 1, 5, toggleSwitch14.Checked);
                S7.SetBitAt(ref db1buffer_1, 1, 6, toggleSwitch15.Checked);
                S7.SetBitAt(ref db1buffer_1, 1, 7, toggleSwitch16.Checked);
            }
            else
            {
                label1.Text = plc.ErrorText(result) + " " + IP_adress;
                plc.Disconnect();
                timer1.Enabled = false;
                timer1.Stop();
                return;
            }
                        //var db1buffer = new byte[2];
            
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 0, 0, toggleSwitch1.Checked);
            WritePLC();
        }

        private void toggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 0, 1, toggleSwitch2.Checked);
            WritePLC();
        }

        private void toggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 0, 2, toggleSwitch3.Checked);
            WritePLC();
        }

        private void toggleSwitch4_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 0, 3, toggleSwitch4.Checked);
            WritePLC();
        }

        private void toggleSwitch5_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 0, 4, toggleSwitch5.Checked);
            WritePLC();
        }

        private void toggleSwitch6_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 0, 5, toggleSwitch6.Checked);
            WritePLC();
        }

        private void toggleSwitch7_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 0, 6, toggleSwitch7.Checked);
            WritePLC();
        }

        private void toggleSwitch8_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 0, 7, toggleSwitch8.Checked);
            WritePLC();
        }

        private void toggleSwitch9_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 1, 0, toggleSwitch9.Checked);
            WritePLC();
        }

        private void toggleSwitch10_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 1, 1, toggleSwitch10.Checked);
            WritePLC();
        }

        private void toggleSwitch11_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 1, 2, toggleSwitch11.Checked);
            WritePLC();
        }

        private void toggleSwitch12_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 1, 3, toggleSwitch12.Checked);
            WritePLC();
        }

        private void toggleSwitch13_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 1, 4, toggleSwitch13.Checked);
            WritePLC();
        }

        private void toggleSwitch14_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 1, 5, toggleSwitch14.Checked);
            WritePLC();
        }

        private void toggleSwitch15_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 1, 6, toggleSwitch15.Checked);
            WritePLC();
        }

        private void toggleSwitch16_CheckedChanged(object sender, EventArgs e)
        {
            S7.SetBitAt(ref db1buffer_1, 1, 7, toggleSwitch16.Checked);
            WritePLC();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = maskedTextBox1.Text;
        }
    }
}
