using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        float TotalhoursWorkedfortimeperiod = 0;
        List<float> rolling_sum = new List<float>();
        int hours1 =12, min1= 30, hours2 = 1, min2 = 50;
        float time1, time2;
        Merridean merridean1 = Merridean.AM, merridean2 = Merridean.PM;
        
        enum Merridean { PM = 1, AM = 0};

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // textBox1.Text = "Total time worked: " + TotalhoursWorked + " Hrs";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            TotalhoursWorkedfortimeperiod = 0;
            ChangeLabel8Text();
        }

        private void Clear()
        {
            rolling_sum.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeLabel8Text();
        }
        private void button3_Click(object sender, EventArgs e)
        {
           

            hours1 = Convert.ToInt32(textBox2.Text);
            hours2 = Convert.ToInt32(textBox6.Text);
            min1 = Convert.ToInt32(textBox3.Text);
            min2 = Convert.ToInt32(textBox5.Text);
            if (!check_for_blank_entries()) return;
            if (!isTimeValid())
            {
                label10.Text = "Invalid input";
                return;
            }

            do_time_arithmetic();
            ChangeLabel8Text();

            // do_time_arithmetic();
        }

        bool check_for_blank_entries()
        {
            if (comboBox1.Text.Equals("AM")) merridean1 = Merridean.AM;
            else if (comboBox1.Text.Equals("PM")) merridean1 = Merridean.PM;
            else
            {
                label9.Text = "One or more things not inputted";
                return false;
            }

            if (comboBox2.Text.Equals("AM")) merridean2 = Merridean.AM;
            else if (comboBox2.Text.Equals("PM")) merridean2 = Merridean.PM;
            else
            {
                label9.Text = "One or more things not inputted";
                return false;
            }

            return true;
        }

        bool isTimeValid()
        {
            if (hours1 < 1 || hours1 > 12)
                return false;
            if (hours2 < 1 || hours2 > 12)
                return false;
            if (min1 < 0 || min1 > 59)
                return false;
            if (min1 < 0 || min2 > 59)
                return false;

            
            return true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.ResetText();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.ResetText();
        }

        float do_time_arithmetic()
        {
            if (hours1 == 12 && merridean1 == Merridean.AM && merridean2 == Merridean.AM && hours2 != 12)
            {
                
                hours1 = 0;
                time1 = (float)hours1 + (float)min1 / 60.0f + (12.0f * (int)merridean1);
                time2 = hours2 + (float)min2 / 60.0f + (12.0f * (int)merridean2);
                TotalhoursWorkedfortimeperiod += Math.Abs(time1 - time2);
            }

            else if (hours2 == 12 && merridean2 == Merridean.AM && hours1 != 12)
            {
                
                hours2 = 0;
                time1 = (float)hours1 + (float)min1 / 60.0f + (12.0f * (int)merridean1);
                time2 = 24 - hours2 + (float)min2 / 60.0f + (12.0f * (int)merridean2);
                TotalhoursWorkedfortimeperiod += Math.Abs(time1 - time2);
            }


            else if ( ( merridean2 == Merridean.AM && merridean1 == Merridean.AM && hours2 < hours1)|| (merridean2 == Merridean.AM && merridean1 == Merridean.AM  && hours2 == hours1 && min2 < min1))
            {
                if (hours1 == 12) hours1 = 0;
                if (hours2 == 12) hours2 = 0;
                time1 = (float)hours1 + (float)min1 / 60.0f + (12.0f * (int)merridean1);
                time2 = hours2 + (float)min2 / 60.0f + (12.0f * (int)merridean2);
                TotalhoursWorkedfortimeperiod += 24 - Math.Abs( (time1 - time2));
            }

            else if ((merridean2 == Merridean.AM && merridean1 == Merridean.AM && hours1 < hours2) || (merridean2 == Merridean.AM && merridean1 == Merridean.AM  && hours2 == hours1 && min2 > min1))
            {
                if (hours1 == 12) hours1 = 0;
                if (hours2 == 12) hours2 = 0;
                time1 = (float)hours1 + (float)min1 / 60.0f + (12.0f * (int)merridean1);
                time2 = hours2 + (float)min2 / 60.0f + (12.0f * (int)merridean2);
                TotalhoursWorkedfortimeperiod +=  Math.Abs((time1 - time2));
            }


            else if ((merridean2 == Merridean.PM && merridean1 == Merridean.PM && hours1 < hours2 && hours2 < 12) || (merridean2 == Merridean.PM && merridean1 == Merridean.PM && hours2 == hours1 && min2 > min1 && hours2 < 12))
            {
                if (hours1 == 12) hours1 = 0;
                if (hours2 == 12) hours2 = 0;
                time1 = (float)hours1 + (float)min1 / 60.0f + (12.0f * (int)merridean1);
                time2 = hours2 + (float)min2 / 60.0f + (12.0f * (int)merridean2);
                TotalhoursWorkedfortimeperiod += Math.Abs((time1 - time2));


            }


            else if ((merridean2 == Merridean.PM && merridean1 == Merridean.PM && (hours2 > hours1 && hours2 < 12)) || (merridean2 == Merridean.PM && merridean1 == Merridean.PM && (hours2 == hours1 ) && min2 > min1 && hours2 < 12))
            {
                if (hours1 == 12) hours1 = 0;
                if (hours2 == 12) hours2 = 0;
                time1 = (float)hours1 + (float)min1 / 60.0f + (12.0f * (int)merridean1);
                time2 = hours2 + (float)min2 / 60.0f + (12.0f * (int)merridean2);
                TotalhoursWorkedfortimeperiod +=  Math.Abs((time1 - time2));
            }

            else if ((merridean2 == Merridean.PM && merridean1 == Merridean.PM && (hours2 < hours1 || hours2 == 12 )) || (merridean2 == Merridean.PM && merridean1 == Merridean.PM && hours2 == hours1 && min2 < min1))
            {
                if (hours1 == 12) hours1 = 0;
                if (hours2 == 12) hours2 = 0;
                time1 = (float)hours1 + (float)min1 / 60.0f + (12.0f * (int)merridean1);
                time2 = hours2 + (float)min2 / 60.0f + (12.0f * (int)merridean2);
                TotalhoursWorkedfortimeperiod += 24 -  Math.Abs((time1 - time2));
            }

            //else if (merridean2 == Merridean.PM && hours2 == 12)
            //{
            //    if (hours1 == 12) hours1 = 0;
            //    if (hours2 == 12) hours2 = 0;
            //    time1 = (float)hours1 + (float)min1 / 60.0f + (12.0f * (int)merridean1);
            //    time2 = hours2 + (float)min2 / 60.0f + (12.0f * (int)merridean2);
            //    TotalhoursWorkedfortimeperiod +=  Math.Abs((time1 - time2));
            //}

            else if ((merridean2 == Merridean.AM && merridean1 == Merridean.PM))
            {
                if (hours1 == 12) hours1 = 0;
                if (hours2 == 12) hours2 = 0;
                time1 = (float)hours1 + (float)min1 / 60.0f + (12.0f * (int)merridean1);
                time2 = hours2 + (float)min2 / 60.0f + (12.0f * (int)merridean2);
                TotalhoursWorkedfortimeperiod += 24 - Math.Abs(time1 - time2);
            }

            else
            {
                if (hours1 == 12) hours1 = 0;
                if (hours2 == 12) hours2 = 0;
                time1 = (float)hours1 + (float)min1 / 60.0f + (12.0f * (int)merridean1);
                time2 = hours2 + (float)min2 / 60.0f + (12.0f * (int)merridean2);
                TotalhoursWorkedfortimeperiod += Math.Abs(time1 - time2);
            }




                //TotalhoursWorkedfortimeperiod = 
                return TotalhoursWorkedfortimeperiod;
        }
        void ChangeLabel8Text()
        {
            label8.Text = "Total time worked: " + TotalhoursWorkedfortimeperiod + " Hrs";
        }
        private void label8_Click(object sender, EventArgs e)
        {
            label8.Text = "Total time worked: " + TotalhoursWorkedfortimeperiod + " Hrs";
        }
    }
}
