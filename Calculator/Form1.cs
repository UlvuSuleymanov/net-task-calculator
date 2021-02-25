using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public String value1;
        public String value2;
        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            inp.AppendText("!");
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            inp.AppendText("+");
        }

        private void minus_Click(object sender, EventArgs e)
        {
            inp.AppendText("-");

        }
        private void time_Click(object sender, EventArgs e)
        {
            inp.AppendText("x");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            inp.AppendText("/");
        }

        private void one_Click(object sender, EventArgs e)
        {
            inp.AppendText("1");
        }

        private void two_Click(object sender, EventArgs e)
        {
            inp.AppendText("2");
        }

        private void three_Click(object sender, EventArgs e)
        {
            inp.AppendText("3");
        }


        private void four_Click(object sender, EventArgs e)
        {
            inp.AppendText("4");
        }

        private void five_Click(object sender, EventArgs e)
        {
            inp.AppendText("5");
        }

        private void six_Click(object sender, EventArgs e)
        {
            inp.AppendText("6");
        }

        private void seven_Click(object sender, EventArgs e)
        {
            inp.AppendText("7");
        }

        private void eight_Click(object sender, EventArgs e)
        {
            inp.AppendText("8");
        }

        private void nine_Click(object sender, EventArgs e)
        {
            inp.AppendText("9");
        }

        private void zero_Click(object sender, EventArgs e)
        {
            inp.AppendText("0");
        }

        private void dot_Click(object sender, EventArgs e)
        {
            inp.AppendText(".");
        }

        private void equal_Click(object sender, EventArgs e)
        {
            String text = inp.Text;
            if (  text.Length > 0 && text[0].ToString().Equals("-")) {

                text = text.Remove(0,1);

            }
            else if(text.Length>0)
            {
                text = "-" + text;

            }

            inp.Text = text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int length = inp.Text.Length;

            if (length > 0)
            {
                inp.Text = inp.Text.Remove(length - 1);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            inp.Text = "";
            history.Text = "";
            label1.Text = "";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            String text = inp.Text;
            if (text.Length > 1)
            {


                char[] dividers = { 'x', '/', '+', '-' };

                List<string> sequence = new List<string>();
                List<string> numStrings = new List<string>();
                List<float> nums = new List<float>();

                bool firstNumIsNegative = false;

                if (text[0].ToString().Equals("-"))
                {
                    text = text.Remove(0, 1);
                    firstNumIsNegative = true;
                }

                numStrings = text.Trim().Split(dividers).ToList<string>();
                nums = stringsToFloats(numStrings);



                if (firstNumIsNegative)
                {
                    nums[0] = -1 * nums[0];
                }







                foreach (char c in text)
                {
                    foreach (char ch in dividers)
                    {
                        if (ch.Equals(c))
                        {
                            sequence.Add(ch.ToString());
                        }
                    }

                }







                for (int j = 0; j < dividers.Length; j++)
                {
                    char c = dividers[j];
                    for (int i = 0; i < sequence.Count; i++)
                    {



                        if (sequence[i].Equals(c.ToString()))
                        {
                            String expression = c.ToString();



                            switch (expression)
                            {

                                case "x":

                                    nums = product(nums, i);
                                    break;

                                case "/":
                                    nums = divide(nums, i);
                                    break;

                                case "+":
                                    nums = sum(nums, i);
                                    break;

                                case "-":
                                    nums = subtract(nums, i);
                                    break;


                            }



                            sequence.RemoveAt(i);






                        }

                    }

                }

                label1.Text = getNumberName(nums[0]);

                history.Text = inp.Text + "=";
                inp.Text = nums[0].ToString();

            }



        }


        List<float> stringsToFloats(List<string> nums)
        {
            List<float> numbers = new List<float>();


            foreach (string f in nums) {
                if (f[f.Length-1].ToString().Equals("!"))
                {
                    String t = f.Remove(f.Length - 1);
                   
                    numbers.Add(getFactorial(float.Parse(t, CultureInfo.InvariantCulture.NumberFormat)));
                   
                }
                else
                {
                    numbers.Add(float.Parse(f, CultureInfo.InvariantCulture.NumberFormat));
                }
            }

            return numbers;
        }


        float getFactorial(float a)
        { int factroial = 1;

            if (a == 0| a == 1)
            {
                return 1;
            }

            for (int i = 1; i <= a; i++)
            {
                factroial =factroial* i;
            }

            return factroial;

        }

    
        


        List<float> sum(List<float> nums,  int index)
        {
            nums[index] = nums[index] + nums[index + 1];
            nums.RemoveAt(index + 1);
            return nums;
        }

        List<float> divide(List<float> nums, int index)
        {
            nums[index] = nums[index] / nums[index + 1];
            nums.RemoveAt(index + 1);
            return nums;
        }

        List<float> subtract(List<float> nums, int index)
        {
            nums[index] = nums[index] - nums[index + 1];
            nums.RemoveAt(index + 1);
            return nums;
        }

        List<float> product(List<float> nums, int index)
        {
            nums[index] = nums[index] * nums[index + 1];
            nums.RemoveAt(index + 1);
            return nums;
        }





        String getNumberName(float num)
        {
            String[] digits = { "", "bir", "iki", "üç", "dörd", "beş", "altı", "yeddi", "səkkiz", "doqquz" };

            String[] decimals = { "", "on", "iyirmi", "otuz", "qırx", "əlli", "altmış", "yetmiş", "səksən", "doxsan" };

            String[] others = { "", "", "", "yüz", "min", "", "", "milyon", ""," "," ", "milyard" };


            String number = num.ToString();

            String result = "";

            bool isNegative = false;

            if (number[0].ToString().Equals("-"))
            {
                isNegative = true;
                number=number.Remove(0,1);
            }


                bool isInteger =! number.Contains(".".ToString());


            String[] parts = new string[2];

          

            String decString = "";

            if (isInteger) {


                parts[0] = number;

            }
            else
            { 

                parts = number.Split(".");

               
            }

           









            String text = parts[0];

           

            int length = text.Length;


            int dig;

 

            
            
            if(length>0)
            {
                dig = int.Parse(text[length - 1].ToString());
             
                result = result + digits[dig] + " ";

            }


            if (length > 1)
            {
                dig = int.Parse(text[length - 2].ToString());

                
                result = decimals[dig] + " "+result + " ";

            }

            if (length > 2)
            {

               
               dig = int.Parse(text[length - 3].ToString());
                if (dig != 0)
                {

                    result = " " + others[3] + " " + result;

                    if (dig > 1)
                        result = digits[dig]+" "+ result;

                }
            }

            if (length > 3)
            {


                dig = int.Parse(text[length - 4].ToString());

                if (dig != 0)
                {

                    result = " " + others[4] + " " + result;

                    if (dig > 1)
                        result = digits[dig] + " " + result;

                }

            }


            if (length > 4)
            {


                dig = int.Parse(text[length - 5].ToString());

                if (dig != 0)
                {

                    result = " " + decimals[dig] + " " + result;

                  

                }

            }

            if (length > 5)
            {


                dig = int.Parse(text[length - 6].ToString());
                if (dig != 0)
                {
                    result = " " + others[3] + " " + result;

                    if (dig > 1)
                    {
                        result = digits[dig] + result;
                    }
                }

            }

            if (length > 6)
            {


                dig = int.Parse(text[length - 7].ToString());
                
                
                    result = digits[dig] + " " + others[7]+" "+ result ;
                

            }



            //********************8888888888
            if (length > 7)
            {


                dig = int.Parse(text[length - 8].ToString());
                if (dig != 0)
                {
                    result = decimals[dig] + " " + result;
                }

            }



            //******************99999999999

            if (length > 8)
            {


                dig = int.Parse(text[length - 9].ToString());
                if (dig != 0)
                {
                    result = others[3] + " " + result+" ";

                    if (dig > 1)
                    {
                        result = digits[dig] + " " + result;
                    }


                }

            }

            if (length > 9)
            {


                dig = int.Parse(text[length - 7].ToString());


                result = digits[dig] + " " + others[11] + " " + result;


            }







            if(isInteger)
            {
                
                if (isNegative)
                {
                    result = "mənfi " + result;
                }
                return result;
            }
            else
            {
                String dec = getNumberName(float.Parse(parts[1]));

                 result = result + "tam ";

                int len = parts[1].Length;

                 if (len == 1)
                {
                    result = result + " onda ";
                }
                if (len == 2)
                {
                    result = result + " yüzdə ";
                }

                if (len == 3)
                {
                    result = result + " mində ";
                }
                if (len == 4)
                {
                    result = result + " on  mində ";
                }
                if (len == 5)
                {
                    result = result + " yüz mində ";
                }

                if (len == 6)
                {
                    result = result + " milyonda ";
                }
                if (len == 7)
                {
                    result = result + " on milyonda ";
                }
                if (len == 8)
                {
                    result = result + " yüz milyonda";
                }
                if (len == 9)
                {
                    result = result + " milyardda";
                }

                result = result + dec ;

                if(isNegative)
                {
                    result = "mənfi " + result;
                }

                return result;

            }







           



           
           

        }

        
    }







   
}
