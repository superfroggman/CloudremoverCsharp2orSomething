using System;
using System.Drawing;

namespace CloudremoverCsharp2orSomething
{
    class Program
    {
        string folderPath = "~";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        void removeClouds()
        {
            //making sure there are images
            if (folderPath == null)
            {
                return;
            }

            Bitmap[] bmps = new Bitmap[folderPath.Length];

            for (int i = 0; i < folderPath.Length; i++)
            {
                bmps[i] = new Bitmap(Image.FromFile(folderPath[i]));
            }
            bmp = bmps[0];
            pictureBox1.Image = bmp;
            this.Update();

            //For each image(except the first)
            for (int i = 1; i < folderPath.Length; i++)
            {
                //For each height row
                for (int y = 0; y < bmp.Height; y++)
                {
                    //For each width row
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        //Get current and new pixel and change to the brightest one
                        Color currentPixel = bmp.GetPixel(x, y);
                        Color newPixel = bmps[i].GetPixel(x, y);
                        if ((newPixel.R + newPixel.B + newPixel.G) < (currentPixel.R + currentPixel.B + currentPixel.G))
                        {
                            bmp.SetPixel(x, y, newPixel);
                        }
                    }
                    //Update image every height row if slowmode is activated
                    if (slowmode)
                    {
                        pictureBox1.Image = bmp;
                        this.Refresh();
                    }
                }
                //Update image after each image processed
                pictureBox1.Image = bmp;

                this.Refresh();

            }
        }
    }
}
