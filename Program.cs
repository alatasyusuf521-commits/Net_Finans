using System;
using System.Windows.Forms;
using MuhasebeOtomasyonu.Forms;

namespace MuhasebeOtomasyonu
{
    internal static class Program
    {
        /// <summary>
        ///  Uygulamanın ana giriş noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
