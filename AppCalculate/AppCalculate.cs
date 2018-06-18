using System;
using System.Collections.Generic;
using System.IO;
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
                ListViewItem item = listViewHistory.Items.Add(itemLog);
                listViewHistory.Items[listViewHistory.Items.Count - 1].EnsureVisible();
            }
        }

        private void TxtExpression_TextChanged(object sender, EventArgs e)
        {
            //label2.Text = TxtExpression_TextChanged.Text;
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            var s = TxtExpression_TextChanged.Text;
            if (s != " " && s != "")
            {
                TxtExpression_TextChanged.Text = "";
                listViewHistory.Items.Add(s);
                WriteLog(s);
                StringCalc rez = new StringCalc();
                var rezResult = rez.DoCalculation(s);
                
                listViewHistory.Items.Add(rezResult.ToString());
                listViewHistory.Refresh();
                listViewHistory.Items[listView1.Items.Count - 1].EnsureVisible();
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

        private static IEnumerable<string> ReadLog()
        {
            using (StreamReader sr = new StreamReader(LogFileName, System.Text.Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    yield return sr.ReadLine();
                }
            }
        }
    }
}
