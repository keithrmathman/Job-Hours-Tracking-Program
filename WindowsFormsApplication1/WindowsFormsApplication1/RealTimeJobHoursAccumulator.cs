using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class RealTimeJobHoursAccumulator : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        FileUtilities file = new FileUtilities();
        string filepath = "C:\\Users\\KMAN\\Documents\\AccumulatorLog";

        long total_time_elapsed_today = 0, total_time_elapsed_to_date = 0;


        public RealTimeJobHoursAccumulator()
        {
            InitializeComponent();
            long value;
            string s = file.read_from_file(filepath);
            if (s == "" || !long.TryParse(s, out value))
            {
                total_time_elapsed_to_date = 0;
                return;
            }

                total_time_elapsed_to_date = Convert.ToInt32(s);
           // bool flag = Check_if_New_Day();
            //Thread t = new Thread(new ThreadStart(Check_if_New_Day));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            stopwatch.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            accumulateSum();
            textBox2.Text = ((float)total_time_elapsed_today / (1000.00 * 60.00) ).ToString();
            textBox1.Text = ((float)total_time_elapsed_to_date / (1000.00 * 60.00)).ToString();
            file.write_to_file(filepath, ((float)total_time_elapsed_today / (1000.00 * 60.00)).ToString());

        }

        void accumulateSum()
        {
            stopwatch.Stop();
            total_time_elapsed_today += stopwatch.ElapsedMilliseconds;
            total_time_elapsed_to_date += total_time_elapsed_today;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        static bool Check_if_New_Day()
        {
            DateTime day = new DateTime();
            day = DateTime.Today;

           while(day.Equals(DateTime.Today))
            {
              
                // Yield the rest of the time slice.
                Thread.Sleep(10000);
            }

            return true;
        }

       

    }
}
