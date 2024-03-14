/**************************************************************************
 *                                                                        *
 *  File:        Program.cs                                               *
 *  Copyright:   (c) 2022, Alexandra-Catalina Poleac                      *
 *  Description: Aplicatie pentru administrare magazin de cosmetice       *
 *                                                                        *
 *                                                                        *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazinCosmetice
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
