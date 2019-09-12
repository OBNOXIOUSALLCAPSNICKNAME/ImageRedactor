using System;
using System.Drawing;

namespace ReImage
{
    class CannyEdgeDetector
    {
        static public Bitmap RunAlgorithm(Bitmap Image)
        {
            Image = Filters.Autolevels(Image);

            int temp = GaussianBlur.KernelSize;
            GaussianBlur.KernelSize = 3;
            Image = GaussianBlur.GaussianBlurFilter1D(Image);
            GaussianBlur.KernelSize = temp;

            Image = Sobel(Image);
            Image = NonMaximumSuppression(Image);
            Image = DoubleTheshold(Image);
            Image = Trace(Image);
            Image = SetEdgeToImage(Image);

            return Image;
        }

        static double[,] sobelX = new double[3, 3]
        {
            {1, 0, -1 },
            {2, 0, -2 },
            {1, 0, -1 },
        };
        static double[,] sobelY = new double[3, 3]
        {
            {1, 2, 1 },
            {0, 0, 0 },
            {-1, -2, -1 },
        };

        static int[,] AngleMatrix;
        static void CalculateAngle(int x, int y, double valueX, double valueY)
        {
            double theta = 0;
            if (valueX == 0 && valueY == 0)
                AngleMatrix[x, y] = 0;
            else if (valueX == 0 && valueY != 0)
                AngleMatrix[x, y] = 90;
            else
            {
                theta = 180 * Math.Atan(valueY / valueX) / Math.PI;
                if (theta < 0)
                    theta = theta + 180;
                theta = NormalizeAngle(theta);
                AngleMatrix[x, y] = (int)theta;
            }
        }
        static double NormalizeAngle(double theta)
        {
            if ((theta >= 0 && theta < 22.5) || (theta >= 157.5 && theta <= 180))
                return 0;
            else if (theta >= 22.5 && theta < 67.5)
                return 45;
            else if (theta >= 67.5 && theta < 112.5)
                return 90;
            else if (theta >= 112.5 && theta < 157.5)
                return 135;
            else
                return theta;
        }
        static public Bitmap Sobel(Bitmap Image)
        {
            int KernelSize = 3;
            PixelData newPixel = new PixelData();
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
            byte DominantColor;

            AngleMatrix = new int[unsafeBitmap.Bitmap.Width, unsafeBitmap.Bitmap.Height];

            int upperbound = KernelSize - 2;
            int lowerboundX = unsafeBitmap.Bitmap.Width - KernelSize - 1;
            int lowerboundY = unsafeBitmap.Bitmap.Height - KernelSize - 1;
            int WindowUpperBoundX;
            int WindowLowerBoundX;
            int WindowUpperBounY;
            int WindowLowerBoundY;
            resR = resG = resB = DominantColor = 0;

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

                    newPixel = PixelHandler.NormalizePixel(resR, resG, resB);
                    DominantColor = Math.Max(newPixel.red, Math.Max(newPixel.green, newPixel.blue));

                    if (newPixel.red == DominantColor)
                        CalculateAngle(x, y, valueR_X, valueR_Y);
                    else if (newPixel.green == DominantColor)
                        CalculateAngle(x, y, valueG_X, valueG_Y);
                    else
                        CalculateAngle(x, y, valueB_X, valueB_Y);

                    newPixel.red = newPixel.green = newPixel.blue = DominantColor;
                    unsafeBitmap.SetPixel(x, y, newPixel);
                }
            }
            unsafeBitmap.UnlockBitmap();
            unsafeBitmapTemp.UnlockBitmap();
            unsafeBitmap.Bitmap = ImageHandler.ReduceImage(unsafeBitmap.Bitmap, KernelSize);
            return unsafeBitmap.Bitmap;
        }

        static public Bitmap NonMaximumSuppression(Bitmap Image)
        {
            if (AngleMatrix == null)
                return Image;
            PixelData RedPixel = new PixelData();
            PixelData GreenPixel = new PixelData();
            PixelData BluePixel = new PixelData();
            PixelData YellowPixel = new PixelData();
            RedPixel.red = 255; RedPixel.green = RedPixel.blue = 0;
            GreenPixel.green = 255; GreenPixel.red = GreenPixel.blue = 0;
            BluePixel.blue = 255; BluePixel.red = BluePixel.green = 0;
            YellowPixel.red = YellowPixel.green = 255; YellowPixel.blue = 0;

            int KernelSize = 3;
            PixelData currentPixel = new PixelData();
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(ImageHandler.ExpandImage(Image, KernelSize));
            UnsafeBitmap unsafeBitmapTemp = new UnsafeBitmap(unsafeBitmap.Bitmap);
            unsafeBitmapTemp.LockBitmap();
            unsafeBitmap.LockBitmap();

            int upperbound = KernelSize - 2;
            int lowerboundX = unsafeBitmap.Bitmap.Width - KernelSize - 1;
            int lowerboundY = unsafeBitmap.Bitmap.Height - KernelSize - 1;

            PixelData elsepixel = new PixelData();
            elsepixel.red = elsepixel.green = elsepixel.blue = 0;

            for (int x = upperbound; x <= lowerboundX; x++)
            {
                for (int y = upperbound; y <= lowerboundY; y++)
                {
                    currentPixel = unsafeBitmapTemp.GetPixel(x, y);
                    switch (AngleMatrix[x, y])
                    {
                        case 90:
                            if (currentPixel.red >= unsafeBitmapTemp.GetPixel(x - 1, y).red && currentPixel.red >= unsafeBitmapTemp.GetPixel(x + 1, y).red)
                                unsafeBitmap.SetPixel(x, y, currentPixel);
                            else
                                unsafeBitmap.SetPixel(x, y, elsepixel);
                            break;
                        case 135:
                            if (currentPixel.red >= unsafeBitmapTemp.GetPixel(x - 1, y + 1).red && currentPixel.red >= unsafeBitmapTemp.GetPixel(x + 1, y - 1).red)
                                unsafeBitmap.SetPixel(x, y, currentPixel);
                            else
                                unsafeBitmap.SetPixel(x, y, elsepixel);
                            break;
                        case 0:
                            if (currentPixel.red >= unsafeBitmapTemp.GetPixel(x, y - 1).red && currentPixel.red >= unsafeBitmapTemp.GetPixel(x, y + 1).red)
                                unsafeBitmap.SetPixel(x, y, currentPixel);
                            else
                                unsafeBitmap.SetPixel(x, y, elsepixel);
                            break;
                        case 45:
                            if (currentPixel.red >= unsafeBitmapTemp.GetPixel(x - 1, y - 1).red && currentPixel.red >= unsafeBitmapTemp.GetPixel(x + 1, y + 1).red)
                                unsafeBitmap.SetPixel(x, y, currentPixel);
                            else
                                unsafeBitmap.SetPixel(x, y, elsepixel);
                            break;
                    }
                }
            }

            unsafeBitmap.UnlockBitmap();
            unsafeBitmapTemp.UnlockBitmap();
            unsafeBitmap.Bitmap = ImageHandler.ReduceImage(unsafeBitmap.Bitmap, KernelSize);
            return unsafeBitmap.Bitmap;
        }
        
        static int upperTreshold = 45; // предположительно начало контура
        public static int UpperTreshold
        {
            get => upperTreshold;
            set
            {
                if (value <= 250 && value >= 5)
                    upperTreshold = value;
            }
        }
        static int lowerTreshold = 17; // предположительно продолжение контура
        public static int LowerTreshold
        {
            get => lowerTreshold;
            set
            {
                if (value <= 250 && value >= 5)
                    lowerTreshold = value;
            }
        }

        static public Bitmap DoubleTheshold(Bitmap Image)
        {
            int KernelSize = 3;
            PixelData currentPixel = new PixelData();

            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(ImageHandler.ExpandImage(Image, KernelSize));
            UnsafeBitmap unsafeBitmapTemp = new UnsafeBitmap(unsafeBitmap.Bitmap);

            unsafeBitmapTemp.LockBitmap();
            unsafeBitmap.LockBitmap();

            int upperbound = KernelSize - 2;
            int lowerboundX = unsafeBitmap.Bitmap.Width - KernelSize - 1;
            int lowerboundY = unsafeBitmap.Bitmap.Height - KernelSize - 1;

            PixelData elsepixel = new PixelData();
            elsepixel.red = elsepixel.green = elsepixel.blue = 0;
            for (int x = upperbound; x <= lowerboundX; x++)
            {
                for (int y = upperbound; y <= lowerboundY; y++)
                {
                    currentPixel = unsafeBitmapTemp.GetPixel(x, y);
                    if (currentPixel.red >= upperTreshold)
                    {
                        currentPixel.red = currentPixel.green = currentPixel.blue = 255;
                        unsafeBitmap.SetPixel(x, y, currentPixel);
                    }
                    else if (currentPixel.red < upperTreshold && currentPixel.red >= lowerTreshold)
                    {
                        currentPixel.red = currentPixel.blue = 0;
                        currentPixel.green = 255;
                        unsafeBitmap.SetPixel(x, y, currentPixel);
                    }
                    else
                    {
                        currentPixel.red = currentPixel.green = currentPixel.blue = 0;
                        unsafeBitmap.SetPixel(x, y, currentPixel);
                    }
                }
            }
            unsafeBitmap.UnlockBitmap();
            unsafeBitmapTemp.UnlockBitmap();
            unsafeBitmap.Bitmap = ImageHandler.ReduceImage(unsafeBitmap.Bitmap, KernelSize);
            return unsafeBitmap.Bitmap;
        }

        static public Bitmap Trace(Bitmap Image)
        {
            int KernelSize = 3;
            PixelData currentPixel = new PixelData();
            PixelData whitePix = new PixelData();
            PixelData blackPix = new PixelData();
            whitePix.red = whitePix.green = whitePix.blue = 255;
            blackPix.red = blackPix.green = blackPix.blue = 0;

            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(ImageHandler.ExpandImage(Image, KernelSize));
            unsafeBitmap.LockBitmap();

            int upperbound = KernelSize - 2;
            int lowerboundX = unsafeBitmap.Bitmap.Width - KernelSize - 1;
            int lowerboundY = unsafeBitmap.Bitmap.Height - KernelSize - 1;
            int[,] DirMatrix = new int[2, 8]
            {
                {-1, 1, 0, 0, -1, 1, 1,-1 }, // x
                { 0, 0,-1, 1, -1, 1,-1, 1 },  // y
            };

            for (int x = upperbound; x <= lowerboundX; x++)
            {
                for (int y = upperbound; y <= lowerboundY; y++)
                {
                    currentPixel = unsafeBitmap.GetPixel(x, y);
                    if (currentPixel.green == 255 && currentPixel.red == 0)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (unsafeBitmap.GetPixel(x + DirMatrix[0, i], y + DirMatrix[1, i]).green == 255 &&
                                unsafeBitmap.GetPixel(x + DirMatrix[0, i], y + DirMatrix[1, i]).red == 255)
                            {
                                unsafeBitmap.SetPixel(x, y, whitePix);
                                i = 8;
                            }
                        }
                    }
                }
            }

            for (int x = upperbound; x <= lowerboundX; x++)
            {
                for (int y = upperbound; y <= lowerboundY; y++)
                {
                    currentPixel = unsafeBitmap.GetPixel(x, y);
                    if (currentPixel.green == 255 && currentPixel.red == 0)
                    {
                        unsafeBitmap.SetPixel(x, y, blackPix);
                    }
                }
            }

            unsafeBitmap.UnlockBitmap();
            unsafeBitmap.Bitmap = ImageHandler.ReduceImage(unsafeBitmap.Bitmap, KernelSize);
            return unsafeBitmap.Bitmap;
        }

        static public Bitmap SetEdgeToImage(Bitmap Image)
        {
            PixelData EdgePixel = new PixelData();
            EdgePixel.green = EdgePixel.blue = 0;
            EdgePixel.red = 255;
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            UnsafeBitmap unsafeBitmapOrig = new UnsafeBitmap(Interface.SavedImage);
            unsafeBitmap.LockBitmap();
            unsafeBitmapOrig.LockBitmap();

            int upperbound = 0;
            int lowerboundX = unsafeBitmap.Bitmap.Width;
            int lowerboundY = unsafeBitmap.Bitmap.Height;

            for (int x = upperbound; x < lowerboundX; x++)
            {
                for (int y = upperbound; y < lowerboundY; y++)
                {
                    if (unsafeBitmap.GetPixel(x, y).red == unsafeBitmap.GetPixel(x, y).green &&
                        unsafeBitmap.GetPixel(x, y).green == unsafeBitmap.GetPixel(x, y).blue &&
                        unsafeBitmap.GetPixel(x, y).red == 255)
                        unsafeBitmapOrig.SetPixel(x, y, EdgePixel);
                }
            }

            unsafeBitmap.UnlockBitmap();
            unsafeBitmapOrig.UnlockBitmap();
            return unsafeBitmapOrig.Bitmap;
        }
    }
}
