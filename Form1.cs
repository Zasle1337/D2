using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eunoia.Net.Collections;
using System.Net.NetworkInformation;
namespace D2IpWalker
{
    public partial class Form1 : Form
    {


        public List<string> texts { get; set; }
        public Form1()

        {
            InitTimer();


            InitializeComponent();
     


        }


        private Timer timer1;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckIps();
        }




        private void button1_Click(object sender, EventArgs e)
        {


            string[] row = { textBox1.Text };
            var listViewItem = new ListViewItem(row);
            
            listView1.Items.Add(listViewItem);
            textBox1.Clear();

        }

        private static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }



        public void CheckIps()
        {
            String s;
            List<string> ips = new List<string>();
            var ip = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties();

            if (listView1.Items.Count != 0)
            {


                TcpConnectionInformation[] connections = ip.GetActiveTcpConnections();
                foreach (TcpConnectionInformation c in connections)
                {
                    s = c.RemoteEndPoint.Address.ToString();

                    if (s.StartsWith("5.42.181") || s.StartsWith("127.0.0"))
                    {
                        string[] values = s.Split('.');

                        ips.Add(values[3]);
                    }



                }



                    foreach (var item in listView1.Items)
                         {

                

                    string f = GetNumbers( item.ToString());

                    for (int i = 0; i < ips.Count; i++)
                    {
                        if (ips[i] == f) 
                    {
                        System.Media.SystemSounds.Beep.Play();
                    }

                    }

                    


                }



            }

    











        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 m = new Form2();
            m.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}
