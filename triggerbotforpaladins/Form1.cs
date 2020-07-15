using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using AutoItX3Lib;


namespace triggerbotforpaladins
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")] // I love getasynckeystate
        static extern short GetAsyncKeyState(Keys vkey);


        object pixel;

        int newCol;
        int[] coor = { 961, 527 }; // works for 1920x1080
        
        AutoItX3 au3 = new AutoItX3(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread mn = new Thread(Main) { IsBackground = true }; // You can do this with a backgroundworker if you want, I prefer threads tho
            mn.Start();
        }

        private void Main()
        {
            while (true)
            {
                if (GetAsyncKeyState(Keys.XButton2)<0) // Change the hotkey to whatever you want, mouse5 is just my fav.
                {
                    newCol = GrabColor();

                    if (newCol > 7000000) // Crosshair color won't go over this value, it's changing between 4000000 and 6500000. When aiming at the enemy the red and orange color is over 10000000
                    {
                        au3.MouseClick("LEFT"); // I got problems with mouse_events in this game so just made everything in autoitx 
                        Thread.Sleep(10);
                    }
                    Thread.Sleep(10);
                }
                Thread.Sleep(10);
            }
        }

        int GrabColor()
        {
            pixel = au3.PixelGetColor(coor[0], coor[1]); // These coordinates work for 1920x1080, make sure to check your own resolution in-game and set your own if you don't have the same resolution as me.
            return Int32.Parse(pixel.ToString());
        }
    }
}
