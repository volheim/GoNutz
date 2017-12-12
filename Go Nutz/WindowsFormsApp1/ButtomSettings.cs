using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StartMenu;


namespace StartMenu
{
    class ButtomSettings
    {
        public ButtomSettings()
        {
            new Settings.Settings();

#if DEBUG
            Console.WriteLine(MessageBox.Show("Works!"));

#endif

        }
    }
}
