﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StartMenu;

namespace WindowsFormsApp1
{
    class ButtomSettings
    {
        public ButtomSettings()
        {
            new Settings();

#if DEBUG
            Console.WriteLine(MessageBox.Show("Works!"));



#endif


        }
    }
}
