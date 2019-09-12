using System.Drawing;
using System;
using System.Threading.Tasks;

namespace ReImage
{
    class Filters
    {
        static int kernelSize = 3;// размер окна медианного фильтра
        static public int KernelSize
        {
            get => kernelSize;
            set
            {
                if (value < 12 && value > 2)
                    kernelSize = value;
            }
        }
        static string medianMode;// режим медиального фильтра
        public static string MedianMode
        {
            get => medianMode;
            set
            {
                if (value == "normal" || value == "recursive")
                    medianMode = value;
            }
        }

        static public Bitmap MedianFilter(Bitmap Image)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(ImageHandler.ExpandImage(Image, KernelSize));
            UnsafeBitmap unsafeBitmapTemp = new UnsafeBitmap(unsafeBitmap.Bitmap);
            unsafeBitmap.LockBitmap();
            unsafeBitmapTemp.LockBitmap();
            int[] VectorR = new int[KernelSize * KernelSize];
            int[] VectorG = new int[KernelSize * KernelSize];
            int[] VectorB = new int[KernelSize * KernelSize];
            int index;
            int upperbound = kernelSize - 2;
            int lowerboundX = unsafeBitmap.Bitmap.Width - kernelSize - 1;
            int lowerboundY = unsafeBitmap.Bitmap.Height - kernelSize - 1;

            int WindowUpperBoundX;
            int WindowLowerBoundX;
            int WindowUpperBounY;
            int WindowLowerBoundY;

            for (int x = upperbound; x <= lowerboundX; x++)
            {
                for (int y = upperbound; y <= lowerboundY; y++)
                {
                    WindowUpperBoundX = x - kernelSize / 2;
                    WindowLowerBoundX = x + kernelSize / 2;

                    WindowUpperBounY = y - kernelSize / 2;
                    WindowLowerBoundY = y + kernelSize / 2;

                    for (int windowX = WindowUpperBoundX; windowX <= WindowLowerBoundX; windowX++)
                        for (int windowY = WindowUpperBounY; windowY <= WindowLowerBoundY; windowY++)
                        {
                            index = (windowX - x + KernelSize / 2) * KernelSize + windowY - y + KernelSize / 2;
                            if (medianMode == "normal")
                            {
                                VectorR[index] = unsafeBitmapTemp.GetPixel(windowX, windowY).red;
                                VectorG[index] = unsafeBitmapTemp.GetPixel(windowX, windowY).green;
                                VectorB[index] = unsafeBitmapTemp.GetPixel(windowX, windowY).blue;
                            }
                            else
                            {
                                VectorR[index] = unsafeBitmap.GetPixel(windowX, windowY).red;
                                VectorG[index] = unsafeBitmap.GetPixel(windowX, windowY).green;
                                VectorB[index] = unsafeBitmap.GetPixel(windowX, windowY).blue;
                            }
                        }
                    unsafeBitmap.SetPixel(x, y, PixelHandler.GetAverage(VectorR, VectorG, VectorB));
                }
            }
            unsafeBitmap.UnlockBitmap();
            unsafeBitmapTemp.UnlockBitmap();
            unsafeBitmap.Bitmap = ImageHandler.ReduceImage(unsafeBitmap.Bitmap, KernelSize);
            return unsafeBitmap.Bitmap;
        }

        static double[,] Kernel;
        static int Div;
        static public void SelectKernel(string name)
        {
            switch (name)
            {
                case "sharpness":
                    Kernel = SharpenKernel;
                    Div = SharpenDiv;
                    break;
                case "laplassian":
                    Kernel = LaplasianKernel;
                    Div = LaplasianDiv;
                    break;
                case "blur":
                    Kernel = BlurKernel;
                    Div = BlurnDiv;
                    break;
                case "emboss":
                    Kernel = EmbossKernel;
                    Div = EmbossDiv;
                    break;
            }
        }

        static int SharpenDiv = 1;
        static double[,] SharpenKernel = new double[3, 3]
        { // резкость
            {0, -1, 0 },
            {-1, 5, -1 },
            {0, -1, 0 },
        };
        static int BlurnDiv = 9;
        static double[,] BlurKernel = new double[3, 3]
        { // размытие
            {1, 1, 1 },
            {1, 1, 1 },
            {1, 1, 1 },
        };
        static int LaplasianDiv = 1;
        static double[,] LaplasianKernel = new double[3, 3]
        { // выделение контуров
            {0, -1, 0 },
            {-1, 4, -1 },
            {0, -1, 0 },
        };
        static int EmbossDiv = 1;
        static double[,] EmbossKernel = new double[3, 3]
        { // выделение рельефа
            {-2, -1, 0 },
            {-1, 1, 1 },
            {0, 1, 2 },
        };
        static double[,] sobelX = new double[3, 3]
        { // выделение контуров
            {1, 0, -1 },
            {2, 0, -2 },
            {1, 0, -1 },
        };
        static double[,] sobelY = new double[3, 3]
        { // выделение контуров
            {1, 2, 1 },
            {0, 0, 0 },
            {-1, -2, -1 },
        };

        static public Bitmap ConvolutionFilter(Bitmap Image)
        {
            int KernelSize = 3;
            PixelData currentPixel = new PixelData();
            double CurrentKernelValue = 0;
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(ImageHandler.ExpandImage(Image, KernelSize));
            UnsafeBitmap unsafeBitmapTemp = new UnsafeBitmap(unsafeBitmap.Bitmap);
            unsafeBitmapTemp.LockBitmap();
            unsafeBitmap.LockBitmap();
            int indexX, indexY;
            double valueR, valueG, valueB;
            int upperbound = KernelSize - 2;
            int lowerboundX = unsafeBitmap.Bitmap.Width - upperbound;
            int lowerboundY = unsafeBitmap.Bitmap.Height - upperbound;

            int WindowUpperBoundX;
            int WindowLowerBoundX;
            int WindowUpperBounY;
            int WindowLowerBoundY;

            for (int x = upperbound; x < lowerboundX; x++)
            {
                for (int y = upperbound; y < lowerboundY; y++)
                {
                    valueR = valueG = valueB = 0;

                    WindowUpperBoundX = x - KernelSize / 2;
                    WindowLowerBoundX = x + KernelSize / 2;

                    WindowUpperBounY = y - KernelSize / 2;
                    WindowLowerBoundY = y + KernelSize / 2;

                    for (int windowX = WindowUpperBoundX; windowX <= WindowLowerBoundX; windowX++)
                    {
                        for (int windowY = WindowUpperBounY; windowY <= WindowLowerBoundY; windowY++)
                        {

                            indexX = windowX - WindowUpperBoundX;
                            indexY = windowY - WindowUpperBounY;
                            currentPixel = unsafeBitmapTemp.GetPixel(windowX, windowY);
                            CurrentKernelValue = Kernel[indexX, indexY];
                            valueR += currentPixel.red * CurrentKernelValue / Div;
                            valueG += currentPixel.green * CurrentKernelValue / Div;
                            valueB += currentPixel.blue * CurrentKernelValue / Div;

                        }
                    }
                    unsafeBitmap.SetPixel(x, y, PixelHandler.NormalizePixel(valueR, valueG, valueB));
                }
            }
            unsafeBitmap.UnlockBitmap();
            unsafeBitmapTemp.UnlockBitmap();
            unsafeBitmap.Bitmap = ImageHandler.ReduceImage(unsafeBitmap.Bitmap, KernelSize);
            return unsafeBitmap.Bitmap;
        }

        static public Bitmap Autolevels(Bitmap Image)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            unsafeBitmap.LockBitmap();
            int width = Image.Width;
            int height = Image.Height;
            double Rmax, Rmin, Gmax, Gmin, Bmax, Bmin;
            Rmax = Gmax = Bmax = 1;
            Rmin = Gmin = Bmin = 255;
            PixelData CurrentPixel = new PixelData();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    CurrentPixel = unsafeBitmap.GetPixel(x, y);
                    Rmax = Math.Max(Rmax, CurrentPixel.red);
                    Rmin = Math.Min(Rmin, CurrentPixel.red);

                    Gmax = Math.Max(Gmax, CurrentPixel.green);
                    Gmin = Math.Min(Gmin, CurrentPixel.green);

                    Bmax = Math.Max(Bmax, CurrentPixel.blue);
                    Bmin = Math.Min(Bmin, CurrentPixel.blue);
                }
            }

            double Rnew, Gnew, Bnew;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    CurrentPixel = unsafeBitmap.GetPixel(x, y);

                    Rnew = (CurrentPixel.red - Rmin) * 255 / (Rmax - Rmin);
                    Gnew = (CurrentPixel.green - Gmin) * 255 / (Gmax - Gmin);
                    Bnew = (CurrentPixel.blue - Bmin) * 255 / (Bmax - Bmin);
                    unsafeBitmap.SetPixel(x, y, PixelHandler.NormalizePixel(Rnew, Gnew, Bnew));
                }
            }
            unsafeBitmap.UnlockBitmap();
            return unsafeBitmap.Bitmap;
        }

        static public Bitmap SobelFilter(Bitmap Image)
        {
            int KernelSize = 3;
            PixelData currentPixel = new PixelData();
            double CurrentKernelValue = 0;
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(ImageHandler.ExpandImage(Image, KernelSize));
            UnsafeBitmap unsafeBitmapTemp = new UnsafeBitmap(unsafeBitmap.Bitmap);
            unsafeBitmapTemp.LockBitmap();
            unsafeBitmap.LockBitmap();
            int indexX, indexY;
            double valueR_X, valueG_X, valueB_X;
            double valueR_Y, valueG_Y, valueB_Y;
            double resR, resG, resB;

            int upperbound = KernelSize - 2;
            int lowerboundX = unsafeBitmap.Bitmap.Width - KernelSize - 1;
            int lowerboundY = unsafeBitmap.Bitmap.Height - KernelSize - 1;

            int WindowUpperBoundX;
            int WindowLowerBoundX;
            int WindowUpperBounY;
            int WindowLowerBoundY;
            resR = resG = resB = 0;

            for (int x = upperbound; x <= lowerboundX; x++)
            {
                for (int y = upperbound; y <= lowerboundY; y++)
                {
                    valueR_X = valueG_X = valueB_X = 0;
                    valueR_Y = valueG_Y = valueB_Y = 0;

                    WindowUpperBoundX = x - KernelSize / 2;
                    WindowLowerBoundX = x + KernelSize / 2;

                    WindowUpperBounY = y - KernelSize / 2;
                    WindowLowerBoundY = y + KernelSize / 2;

                    for (int windowX = WindowUpperBoundX; windowX <= WindowLowerBoundX; windowX++)
                    {
                        for (int windowY = WindowUpperBounY; windowY <= WindowLowerBoundY; windowY++)
                        {
                            indexX = windowX - WindowUpperBoundX;
                            indexY = windowY - WindowUpperBounY;
                            currentPixel = unsafeBitmapTemp.GetPixel(windowX, windowY);

                            CurrentKernelValue = sobelX[indexX, indexY];
                            valueR_X += currentPixel.red * CurrentKernelValue;
                            valueG_X += currentPixel.green * CurrentKernelValue;
                            valueB_X += currentPixel.blue * CurrentKernelValue;

                            CurrentKernelValue = sobelY[indexX, indexY];
                            valueR_Y += currentPixel.red * CurrentKernelValue;
                            valueG_Y += currentPixel.green * CurrentKernelValue;
                            valueB_Y += currentPixel.blue * CurrentKernelValue;
                        }
                    }
                    resR = Math.Sqrt(valueR_X * valueR_X + valueR_Y * valueR_Y);
                    resG = Math.Sqrt(valueG_X * valueG_X + valueG_Y * valueG_Y);
                    resB = Math.Sqrt(valueB_X * valueB_X + valueB_Y * valueB_Y);
                    unsafeBitmap.SetPixel(x, y, PixelHandler.NormalizePixel(resR, resG, resB));
                }
            }
            unsafeBitmap.UnlockBitmap();
            unsafeBitmapTemp.UnlockBitmap();
            unsafeBitmap.Bitmap = ImageHandler.ReduceImage(unsafeBitmap.Bitmap, KernelSize);
            return unsafeBitmap.Bitmap;
        }

        static public Bitmap LightAlligment(Bitmap Image)
        {
            int temp = GaussianBlur.KernelSize;
            GaussianBlur.KernelSize = 35;
            Image = GaussianBlur.GaussianBlurFilter1D(Image);
            GaussianBlur.KernelSize = temp;
            Image = ImageHandler.DivideTwoLayers(Image, Interface.SavedImage);
            return Image;
        }

        static public Bitmap PrepareScreenShot(Bitmap Image)
        {
            ImageHandler.CreateHistogram(Image);
            if (ImageHandler.MaxValueIndex <= 50)
            {
                Image = Effects.InverseImageColors(Image);
                ImageHandler.CreateHistogram(Image);
            }
            Effects.oldColor.red = Effects.oldColor.green = Effects.oldColor.blue = (byte)ImageHandler.MaxValueIndex;
            Effects.newColor.red = Effects.newColor.green = Effects.newColor.blue = 255;
            Image = Effects.ReplaceColor(Image);
            Image = Effects.DiscolorImage(Image);
            Image = Autolevels(Image);
            return Image;
        }
    }
}