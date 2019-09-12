using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ReImage
{
    class ImageHandler
    {
        static public Bitmap ExpandImage(Bitmap image, int size)
        {
            //создать промежуточное изображение большего размера и дополнить края крайними пикселями старого изображения
            UnsafeBitmap Image = new UnsafeBitmap(image);
            UnsafeBitmap newImage = new UnsafeBitmap(Image.Bitmap.Width + size * 2, Image.Bitmap.Height + size * 2);
            using (Graphics gr = Graphics.FromImage(newImage.Bitmap))
            {
                gr.DrawImage(Image.Bitmap, new Rectangle(size, size, Image.Bitmap.Width, Image.Bitmap.Height));
            }
            Image.LockBitmap();
            newImage.LockBitmap();
            //верх 
            for (int x = 0; x < Image.Bitmap.Width; x++)
                for (int y = 0; y < size; y++)
                    newImage.SetPixel(x + size, y, Image.GetPixel(x, y));
            //низ
            for (int x = 0; x < Image.Bitmap.Width; x++)
                for (int y = Image.Bitmap.Height - size; y < Image.Bitmap.Height; y++)
                    newImage.SetPixel(x + size, y + size * 2, Image.GetPixel(x, y));
            //лево
            for (int x = 0; x < size; x++)
                for (int y = 0; y < newImage.Bitmap.Height; y++)
                    newImage.SetPixel(x, y, newImage.GetPixel(x + size, y));
            //право
            for (int x = Image.Bitmap.Width - size; x < Image.Bitmap.Width; x++)
                for (int y = 0; y < newImage.Bitmap.Height; y++)
                    newImage.SetPixel(x + size * 2, y, newImage.GetPixel(x + size, y));

            Image.UnlockBitmap();
            newImage.UnlockBitmap();
            Image.Dispose();
            return newImage.Bitmap;
        }

        static public Bitmap ReduceImage(Bitmap Image, int size)
        {
            Rectangle cropRect = new Rectangle(size, size, Image.Width - size * 2, Image.Height - size * 2);
            Bitmap newImage = new Bitmap(cropRect.Width, cropRect.Height);

            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(Image, new Rectangle(0, 0, newImage.Width, newImage.Height),
                                 cropRect,
                                 GraphicsUnit.Pixel);
            }
            return newImage;
        }

        public static Bitmap MergeTwoImages(Image firstImage, Image secondImage, string alignment)
        {
            int X = 0;
            int outputImageWidth = 0;
            int outputImageHeight = firstImage.Height + secondImage.Height;

            Point firstImagePoint = new Point();
            Point secondImagePoint = new Point();

            switch (alignment)
            {
                case "center":
                    X = Math.Abs(secondImage.Width - firstImage.Width) / 2;
                    break;
                case "left":
                    X = 0;
                    break;
                case "rignt":
                    X = secondImage.Width;
                    break;
            }

            if (firstImage.Width > secondImage.Width)
            {
                outputImageWidth = firstImage.Width;
                firstImagePoint.X = 0;
                firstImagePoint.Y = 0;

                secondImagePoint.X = X;
                secondImagePoint.Y = firstImage.Height + 5;
            }
            else
            {
                outputImageWidth = secondImage.Width;
                firstImagePoint.X = X;
                firstImagePoint.Y = 0;

                secondImagePoint.X = 0;
                secondImagePoint.Y = firstImage.Height + 5;
            }
             
            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(245, 245, 245)), 0, 0, outputImage.Width, outputImage.Height);
                graphics.DrawImage(firstImage, new Rectangle(firstImagePoint, firstImage.Size),
                    new Rectangle(new Point(), firstImage.Size), GraphicsUnit.Pixel);
                graphics.DrawImage(secondImage, new Rectangle(secondImagePoint, secondImage.Size),
                    new Rectangle(new Point(), secondImage.Size), GraphicsUnit.Pixel);
            }

            return outputImage;
        }

        public static Bitmap DivideTwoLayers(Bitmap firstImage, Bitmap secondImage)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(firstImage);
            UnsafeBitmap unsafeBitmap2 = new UnsafeBitmap(secondImage);
            unsafeBitmap.LockBitmap();
            unsafeBitmap2.LockBitmap();
            int width = firstImage.Width;
            int height = firstImage.Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    unsafeBitmap.SetPixel(x, y, PixelHandler.Divide(unsafeBitmap.GetPixel(x, y), unsafeBitmap2.GetPixel(x, y)));
                }
            }
            unsafeBitmap.UnlockBitmap();
            unsafeBitmap2.UnlockBitmap();
            return unsafeBitmap.Bitmap;
        }

        static public int[] PixelValues = new int[256];
        static public int MaxValue;

        static int maxValueIndex = 255;
        static public int MaxValueIndex
        {
            get => maxValueIndex;
            set { maxValueIndex = PixelHandler.FixOutOfRangeVaue(value); }
        }

        static public void CreateHistogram(Bitmap Image)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            unsafeBitmap.LockBitmap();
            PixelValues = new int[256];

            for (int x = 0; x < 256; x++)
                PixelValues[x] = 0;

            int upperbound = 0;
            int lowerboundX = unsafeBitmap.Bitmap.Width;
            int lowerboundY = unsafeBitmap.Bitmap.Height;

            for (int x = upperbound; x < lowerboundX; x++)
            {
                for (int y = upperbound; y < lowerboundY; y++)
                {
                    int value = unsafeBitmap.GetPixel(x, y).green;
                    PixelValues[value] += 1;
                }
            }
            int[] SortedPixelValues = new int[256];
            Array.Copy(PixelValues, SortedPixelValues, 256);
            Array.Sort(SortedPixelValues);
            MaxValue = SortedPixelValues[255];
            MaxValueIndex = Array.FindIndex(PixelValues, x => x == MaxValue);
            unsafeBitmap.UnlockBitmap();
        }
    }
}