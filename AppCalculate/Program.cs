﻿using System;
using System.Windows.Forms;

namespace AppCalculate
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppCalculate());
        }
    }
}
