using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AppCalculate
{
    public partial class AppCalculate : Form
    {
        private static readonly string LogFileName = "D:\\history_log";

        public AppCalculate()
        {
            InitializeComponent();

            Load += LoadEvent;
            button1.Text = "Рассчитать";
            //textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void LoadEvent(object sender, EventArgs e)
        {
            var log = ReadLog();
            foreach (var itemLog in log)
            {
                ListViewItem item = listView1.Items.Add(itemLog);
                listView1.Items[listView1.Items.Count - 1].EnsureVisible();
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //label2.Text = textBox1.Text;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var s = textBox1.Text;
            if (s != " " && s != "")
            {
                textBox1.Text = "";
                listView1.Items.Add(s);
                WriteLog(s);
                StringCalc rez = new StringCalc();
                var rezResult = rez.DoCalculation(s);
                
                listView1.Items.Add(rezResult.ToString());
                listView1.Refresh();
                listView1.Items[listView1.Items.Count - 1].EnsureVisible();
                WriteLog(rezResult.ToString());
            }
            else
            {
                MessageBox.Show(this, "Введите выражение");
            }
        }

        private static void WriteLog(string input)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(LogFileName, true))
                {
                    writer.WriteLine(input);
                    writer.Close();
                }
            }
            catch (IOException exc)
            {
                Console.Error.WriteLine(exc);
            }
            
        }

        private static List<string> ReadLog()
        {
            using (StreamReader sr = new StreamReader(LogFileName, System.Text.Encoding.Default))
            {
                string line;
                var list = new List<string>();
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
                return list;
            }
        }
    }
}
