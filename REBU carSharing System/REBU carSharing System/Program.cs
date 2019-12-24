using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REBU_carSharing_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.SetCompatibleTextRenderingDefault(false);
            Form2 form = new Form2();
            form.ShowDialog();
            Application.Run(new Form1());
        }
    }
}
