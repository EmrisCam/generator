using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int kolGen;                       //которое необходимо выполнить
        public string Pref = null;
        private void button1_Click(object sender, EventArgs e)          //методнажатия книпки "Генерировать"
        {
            //Pref = textBox2.Text;
            //richTextBox1.Text = "";
            kolGenFact = 0;                                     
            kolGen = Convert.ToInt16(textBox1.Text);
            timer1.Interval = 50;                   //интервал срабатывания метода Timer_tick
            timer1.Tick += timer1_Tick;             //указание кокой метод необходимо выполнить после 50млсекунд
            if (timer1.Enabled == false)
                timer1.Start();
            else timer1.Stop();
        }
        public int kolGenFact = 0;              //фактическое количество генераций программы
        public static string PrefixGeneration()
        {
            //string Mass1 = "47AC593";
            //string Mass2 = "28B9A";
            string[] StartPref = { "0", "0", "0", "0", "0", "0", "0", "1", "0", "0", "8", "C", "0", "0", "0", "B", "1" };
            //Random rand = new Random();
            //int zam = 0;
            //for (int i = 0; i < StartPref.Length-1; i++)
            //{
            //    switch (StartPref[i]=="X")
            //    {
            //        case true:
            //            {
            //                if (zam==0)
            //                 {
            //                      StartPref[i] = Mass1[rand.Next(0, Mass1.Length - 1)].ToString();
            //                      zam++;
            //                 }
            //                if (zam==1)
            //                 {
            //                      StartPref[i] = Mass2[rand.Next(0, Mass2.Length - 1)].ToString();
                                  
            //                 }
            //                break;
            //            }
            //    }
                
                //if (StartPref[i] == "X")
                //{
                //    if (zam==0)
                //    {
                //    StartPref[i] = Mass1[rand.Next(0, Mass1.Length - 1)].ToString();
                //    zam++;
                //    }
                //    if 
                //}
                
        //}
            string PrefRez = null;
            for (int i = 0; i < StartPref.Length; i++)
                {
                    PrefRez += StartPref[i];
                }
            return PrefRez;
        }
        void timer1_Tick(object sender, EventArgs e)            
        {
            
            if (kolGenFact < kolGen)
            {
                string value = RunGenerator();
                if (value != "")
                {
                    if (value[0] != '3')
                    {
                        richTextBox1.Text += PrefixGeneration() +""+ value + "\n";
                        kolGenFact++;
                    }
                }
                
            }
            else
            {
                timer1.Stop();
                timer1.Dispose();
                kolGenFact = 0;
                
            }
        }
        static string RunGenerator()
        {
            string value = Generation();
            int sum = 0;
            for (int i = 0; i < value.Length; i++)
            {
                sum += Convert.ToInt32(value[i].ToString());
            }
            string rezult = null;
            if (sum > 70 && sum < 107)
            {
                rezult = Revers(Convert10To16(value));
                return rezult;
            }

            else return "";
        }
        static string Generation()               //генератор без префикса
        {
            string rez = "288";
            Random rand = new Random();
            //rez += rand.Next(8, 9).ToString();
            for (int i = 0; i < 15; i++)
            {
                rez += rand.Next(0, 9);
            }
            return rez;
        }
        static string Switching(int x)           //перевод значений более 9 в буквенный формат
        {
            switch (x)
            {
                case 10:
                    {
                        return "A";
                    }
                case 11:
                    {
                        return "B";
                    }
                case 12:
                    {
                        return "C";
                    }
                case 13:
                    {
                        return "D";
                    }
                case 14:
                    {
                        return "E";
                    }
                case 15:
                    {
                        return "F";
                    }
                default: return "Error";
            }
        }
       
        static string Convert10To16(string chislo10)             //перевод 10го числа в 16ричную систему счисления
        {
            long x10 = Convert.ToInt64(chislo10);
            long mod = 0;
            mod = x10;
            int h = 0;
            string rez = null;
            long[] massMod = new long[50];
            if (mod > 10)
            {
                for (int i = 0; mod > 16; i++)
                {
                    massMod[i] = (mod % 16);
                    mod = mod / 16;
                    h++;

                }
                massMod[h] = mod;
                for (int i = 0; i < h + 1; i++)
                {
                    if (Convert.ToInt32(massMod[i]) > 9)
                        rez += Switching(Convert.ToInt32(massMod[i]));
                    else rez += Convert.ToInt32(massMod[i]);
                }
                //int RemoveInt = rez.Length;
                //for (int i = 0; i < RemoveInt; i++)
                //{
                //    rez += rez[i];
                //}
                //rez = rez.Remove(0, RemoveInt);
                return rez;
            }
            else return x10.ToString();

        }
        static string Revers(string mass)            //сортировка результата согласно методу перевода 10й системы сичсления в 16ричную
        {
            int leng = mass.Length;
            string[] PromMass = new string[leng];

            for (int i = 0; i < mass.Length; i++)
            {
                PromMass[i] = mass[leng - 1].ToString();
                leng--;
            }
            mass = null;
            foreach (string str in PromMass)
            {
                mass += str;
            }
            return mass;
        }

      
    }
}
