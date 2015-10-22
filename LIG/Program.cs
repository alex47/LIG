/*

   LIG

   Copyright 2015 alex47
 
   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 
*/

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
