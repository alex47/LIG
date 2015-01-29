using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //the argument must be the path to a JPG or a PNG file
            //more than one argument is not accepted
            if(args.Length > 1)
            {
                MessageBox.Show("Only one image can be opened!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //one argument
            if(args.Length == 1)
            {
/*TODO: find better solution to check file extension*/
                if (args[0].EndsWith(".jpg") || args[0].EndsWith(".JPG") || args[0].EndsWith(".jpeg") || args[0].EndsWith(".JPEG") || args[0].EndsWith(".png") || args[0].EndsWith(".PNG"))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(args[0]));

                    return;
                }
                else
                {
                    MessageBox.Show("File format not supported!\n" + args[0], "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }                
            }

            //zero arguments
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
