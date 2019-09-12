using System;
using System.Drawing;

namespace ReImage
{
    class GaussianBlur
    {
        static double sigma = 1.4;
        static public double Sigma
        {
            get => sigma;
            set
            {
                if (value < 100 && value > 0)
                    sigma = value;
            }
        }

        static int kernelSize = 50;
        static public int KernelSize
        {
            get => kernelSize / 2;
            set
            {
                if (value <= 50 && value >= 1)
                    kernelSize = value * 2 + 1;
            }
        }

        static double[,] Kernel2D;
        static double[] Kernel1D;

        static public void CreateKernel2D()
        {
            Kernel2D = new double[kernelSize, kernelSize];
            double mean = kernelSize / 2;
            double div = 0.0;
            for (int x = 0; x < kernelSize; ++x)
                for (int y = 0; y < kernelSize; ++y)
                {
                    Kernel2D[x, y] = Math.Exp(-0.5 * (Math.Pow((x - mean) / sigma, 2.0) + Math.Pow((y - mean) / sigma, 2.0)))
                                     / (2 * Math.PI * sigma * sigma);
                    div += Kernel2D[x, y];
                }
            for (int x = 0; x < kernelSize; ++x)
                for (int y = 0; y < kernelSize; ++y)
                    Kernel2D[x, y] /= div;
        }

        static public void CreateKernel1D()
        {
            int radius = kernelSize / 2;
            Kernel1D = new double[radius * 2 + 1];
            double twoRadiusSquaredRecip = 1.0 / (2.0 * radius * radius);
            double sqrtTwoPiTimesRadiusRecip = 1.0 / (Math.Sqrt(2.0 * Math.PI * radius * radius));
            double radiusModifier = 1.4;
            double div = 0;

            int r = -radius;
            for (int i = 0; i < Kernel1D.Length; i++)
            {
                double x = r * radiusModifier;
                x *= x;
                Kernel1D[i] =
                sqrtTwoPiTimesRadiusRecip * Math.Exp(-x * twoRadiusSquaredRecip);
                r++;
                div += Kernel1D[i];
            }

            for (int i = 0; i < Kernel1D.Length; i++)
                Kernel1D[i] /= div;
        }

        static public Bitmap GaussianBlurFilter2D(Bitmap Image)
        {
            CreateKernel2D();
            PixelData currentPixel = new PixelData();
            double CurrentKernelValue = 0;
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(ImageHandler.ExpandImage(Image, kernelSize));
            UnsafeBitmap unsafeBitmapTemp = new UnsafeBitmap(unsafeBitmap.Bitmap);
            unsafeBitmapTemp.LockBitmap();
            unsafeBitmap.LockBitmap();
            int indexX, indexY;
            double valueR, valueG, valueB;
            int upperbound = kernelSize - 2;
            int lowerboundX = unsafeBitmap.Bitmap.Width - kernelSize - 1;
            int lowerboundY = unsafeBitmap.Bitmap.Height - kernelSize - 1;

            int WindowUpperBoundX;
            int WindowLowerBoundX;
            int WindowUpperBoundY;
            int WindowLowerBoundY;

            for (int x = upperbound; x <= lowerboundX; x++)
            {
                for (int y = upperbound; y <= lowerboundY; y++)
                {
                    valueR = valueG = valueB = 0;

                    WindowUpperBoundX = x - kernelSize / 2;
                    WindowLowerBoundX = x + kernelSize / 2;

                    WindowUpperBoundY = y - kernelSize / 2;
                    WindowLowerBoundY = y + kernelSize / 2;

                    for (int windowX = WindowUpperBoundX; windowX <= WindowLowerBoundX; windowX++)
                        for (int windowY = WindowUpperBoundY; windowY <= WindowLowerBoundY; windowY++)
                        {
                            {
                                indexX = windowX - WindowUpperBoundX;
                                indexY = windowY - WindowUpperBoundY;
                                currentPixel = unsafeBitmapTemp.GetPixel(windowX, windowY);
                                CurrentKernelValue = Kernel2D[indexX, indexY];
                                valueR += currentPixel.red * CurrentKernelValue;
                                valueG += currentPixel.green * CurrentKernelValue;
                                valueB += currentPixel.blue * CurrentKernelValue;
                            }
                        }
                    unsafeBitmap.SetPixel(x, y, PixelHandler.NormalizePixel(valueR, valueG, valueB));
                }
            }
            unsafeBitmap.UnlockBitmap();
            unsafeBitmapTemp.UnlockBitmap();
            unsafeBitmap.Bitmap = ImageHandler.ReduceImage(unsafeBitmap.Bitmap, kernelSize);
            return unsafeBitmap.Bitmap;
        }

        static public Bitmap GaussianBlurFilter1D(Bitmap Image)
        {
            CreateKernel1D();
            PixelData currentPixel = new PixelData();
            double CurrentKernelValue = 0;
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(ImageHandler.ExpandImage(Image, kernelSize));
            UnsafeBitmap unsafeBitmapTemp = new UnsafeBitmap(unsafeBitmap.Bitmap);
            unsafeBitmapTemp.LockBitmap();
            unsafeBitmap.LockBitmap();
            int indexX, indexY;
            double valueR, valueG, valueB;
            int upperbound = kernelSize - 2;
            int lowerboundX = unsafeBitmap.Bitmap.Width - kernelSize - 1;
            int lowerboundY = unsafeBitmap.Bitmap.Height - kernelSize - 1;

            int WindowUpperBoundX;
            int WindowLowerBoundX;
            int WindowUpperBoundY;
            int WindowLowerBoundY;

            for (int x = upperbound; x <= lowerboundX; x++)
            {
                for (int y = upperbound; y <= lowerboundY; y++)
                {
                    valueR = valueG = valueB = 0;

                    WindowUpperBoundX = x - kernelSize / 2;
                    WindowLowerBoundX = x + kernelSize / 2;

                    for (int windowX = WindowUpperBoundX; windowX <= WindowLowerBoundX; windowX++)
                    {
                        indexX = windowX - WindowUpperBoundX;
                        currentPixel = unsafeBitmapTemp.GetPixel(windowX, y);
                        CurrentKernelValue = Kernel1D[indexX];
                        valueR += currentPixel.red * CurrentKernelValue;
                        valueG += currentPixel.green * CurrentKernelValue;
                        valueB += currentPixel.blue * CurrentKernelValue;
                    }
                    unsafeBitmap.SetPixel(x, y, PixelHandler.NormalizePixel(valueR, valueG, valueB));
                }
            }

            unsafeBitmap.UnlockBitmap();
            unsafeBitmapTemp.UnlockBitmap();
            unsafeBitmapTemp = new UnsafeBitmap(unsafeBitmap.Bitmap);
            unsafeBitmapTemp.LockBitmap();
            unsafeBitmap.LockBitmap();

            for (int x = upperbound; x <= lowerboundX; x++)
            {
                for (int y = upperbound; y <= lowerboundY; y++)
                {
                    valueR = valueG = valueB = 0;

                    WindowUpperBoundY = y - kernelSize / 2;
                    WindowLowerBoundY = y + kernelSize / 2;

                    for (int windowY = WindowUpperBoundY; windowY <= WindowLowerBoundY; windowY++)
                    {
                        indexY = windowY - WindowUpperBoundY;
                        currentPixel = unsafeBitmapTemp.GetPixel(x, windowY);
                        CurrentKernelValue = Kernel1D[indexY];
                        valueR += currentPixel.red * CurrentKernelValue;
                        valueG += currentPixel.green * CurrentKernelValue;
                        valueB += currentPixel.blue * CurrentKernelValue;
                    }
                    unsafeBitmap.SetPixel(x, y, PixelHandler.NormalizePixel(valueR, valueG, valueB));
                }
            }
            unsafeBitmap.UnlockBitmap();
            unsafeBitmapTemp.UnlockBitmap();
            unsafeBitmap.Bitmap = ImageHandler.ReduceImage(unsafeBitmap.Bitmap, kernelSize);
            return unsafeBitmap.Bitmap;
        }
    }
}
