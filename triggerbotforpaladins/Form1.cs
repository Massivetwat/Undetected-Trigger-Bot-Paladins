using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoItX3Lib;

namespace triggerbotforpaladins
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vkey);


        object pixel;

        int newCol;
        
        
        AutoItX3 au3 = new AutoItX3();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread mn = new Thread(Main);
            mn.Start();
        }

        private void Main()
        {
            while (true)
            {
                if (GetAsyncKeyState(Keys.XButton2)<0)
                {
                    newCol = GrabColor();

                    if (newCol > 7000000)
                    {
                        au3.MouseClick("LEFT");
                        Thread.Sleep(10);
                    }
                    Thread.Sleep(10);
                }
                Thread.Sleep(10);
            }
        }

        int GrabColor()
        {
            pixel = au3.PixelGetColor(961, 527);
            return Int32.Parse(pixel.ToString());
        }
    }
}
