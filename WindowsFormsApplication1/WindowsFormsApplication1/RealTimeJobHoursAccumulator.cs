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
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class RealTimeJobHoursAccumulator : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        FileUtilities file = new FileUtilities();
        string path;
        bool BreakFlag = false;
        bool Clockedin = false;
        


        string filepath; 

        float total_time_elapsed_this_shift= 0, total_time_elapsed_to_date = 0; //this will be the total time in ms


        public RealTimeJobHoursAccumulator()
        {
            InitializeComponent();

             path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            filepath = path + "\\bin\\Release\\AccumulatorLog.txt";
            float value;
            string s = file.read_from_file(filepath);
            if (s == "" || !float.TryParse(s, out value))
            {
                total_time_elapsed_to_date = 0;
                return;
            }
           
            total_time_elapsed_to_date = Convert.ToSingle(s) * 1000 * 60 * 60;

            display_text_boxes();
            // bool flag = Check_if_New_Day();
            //Thread t = new Thread(new ThreadStart(Check_if_New_Day));
        }

        void display_text_boxes()
        {
            
            textBox2.Text = Math.Round(((float)total_time_elapsed_this_shift / (1000.00 * 60.00 * 60.00)), 2).ToString();
            textBox1.Text = Math.Round(((float)total_time_elapsed_to_date / (1000.00 * 60.00 * 60.00)), 2).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "Status:Clocked in.";
            if (!Clockedin)
            {
                Clockedin = true;
                stopwatch.Start();
                MessageBox.Show(s);
                label5.Text = s;
            }
            else MessageBox.Show("Whoops, \n Maybe you meant to Press another button?");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "Status: Clocked Out.";
            if (Clockedin)
            {
                accumulateSum();
                display_text_boxes();
                file.write_to_file(filepath, ((float)total_time_elapsed_to_date / (1000.00 * 60.00 * 60.00)).ToString());
                total_time_elapsed_this_shift = 0.0f;
                Clockedin = false;
                BreakFlag = false; //reset to initial values
                MessageBox.Show(s);
                label5.Text = s;
            }
            else MessageBox.Show("Whoops.\n Maybe you meant to Press another button?");


        }

        void accumulateSum()
        {
            stopwatch.Stop();
            total_time_elapsed_this_shift += stopwatch.ElapsedMilliseconds;
            total_time_elapsed_to_date += total_time_elapsed_this_shift;
            stopwatch.Reset();


        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "Status: On Break.";
            if (!BreakFlag && Clockedin) //if the break flag is set to true
            {
                accumulateSum();
                display_text_boxes();
                file.write_to_file(filepath, ((float)total_time_elapsed_to_date / (1000.00 * 60.00 * 60.00)).ToString());
                BreakFlag = true;
                MessageBox.Show(s);
                label5.Text = s;
            }
            else  MessageBox.Show("Whoops,\n Maybe you meant to Press another button?");


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string warningPrompt = "Are you Sure? This will delete all prior logged work hours.";
            var Dialogform = new PromptDialog(warningPrompt);
            Dialogform.ShowDialog();
           // this.Close();

           // while(Dialogform.)
            if (Dialogform.getYesOrNO())
            {
                file.clear(filepath); //clear all data
                total_time_elapsed_this_shift = 0;
                total_time_elapsed_to_date = 0;
                display_text_boxes();
            }

           
            

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new Form1();
            form.ShowDialog();
            total_time_elapsed_to_date += form.getTotalHoursEnteredManually() * 1000 * 60 * 60;
            display_text_boxes();

        }

      

        private void RealTimeJobHoursAccumulator_FormClosed(object sender, FormClosedEventArgs e)
        {
            file.write_to_file(filepath, ((float)total_time_elapsed_to_date / (1000.00 * 60.00 * 60.00)).ToString());
            MessageBox.Show("Don't Worry! The total job hours this shift\nhave been logged.");
        }

        private void RealTimeJobHoursAccumulator_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(RealTimeJobHoursAccumulator_FormClosed);

            MessageBox.Show("Don't Forget to Clock in :) ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = "Status: Back From Break.";
            if (BreakFlag && Clockedin)
            {
                BreakFlag = false;
                stopwatch.Start();
                MessageBox.Show(s);
                label5.Text = s;

            }
          
            else  MessageBox.Show("Whoops, \n Maybe you meant to Press 'another button?");
        }

        private void label5_Click(object sender, EventArgs e)
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
