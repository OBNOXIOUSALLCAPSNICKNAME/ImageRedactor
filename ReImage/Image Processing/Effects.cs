using System.Drawing;
using System.Threading.Tasks;

namespace ReImage
{
    class Effects
    {
        static public Bitmap DiscolorImage(Bitmap Image)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            unsafeBitmap.LockBitmap();
            int width = Image.Width;
            int height = Image.Height;
            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                {
                    unsafeBitmap.SetPixel(x, y, PixelHandler.DiscolorPixel(unsafeBitmap.GetPixel(x, y)));
                }
            });
            unsafeBitmap.UnlockBitmap();
            return unsafeBitmap.Bitmap;
        }

        static public Bitmap InverseImageColors(Bitmap Image)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            unsafeBitmap.LockBitmap();
            int width = Image.Width;
            int height = Image.Height;
            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                {
                    unsafeBitmap.SetPixel(x, y, PixelHandler.InversePixelColor(unsafeBitmap.GetPixel(x, y)));
                }
            });
            unsafeBitmap.UnlockBitmap();
            return unsafeBitmap.Bitmap;
        }

        static double brightValue = -150; // -150 - 150 (0 - не менять)
        public static double BrightValue
        {
            get => brightValue;
            set
            {
                if (value <= 150 && value >= -150)
                    brightValue = value;
            }
        }
        static public Bitmap Bright(Bitmap Image)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            unsafeBitmap.LockBitmap();
            int width = Image.Width;
            int height = Image.Height;
            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                {
                    unsafeBitmap.SetPixel(x, y, PixelHandler.Brightness(unsafeBitmap.GetPixel(x, y), brightValue));
                }
            });
            unsafeBitmap.UnlockBitmap();
            return unsafeBitmap.Bitmap;
        }

        static double contrastValue = 50; // -100 - 100 (0 - не менять)
        public static double ContrastValue
        {
            get => contrastValue;
            set
            {
                if (value <= 100 && value >= -100)
                    contrastValue = value;
            }
        }
        static public Bitmap Contrast(Bitmap Image)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            unsafeBitmap.LockBitmap();
            int width = Image.Width;
            int height = Image.Height;
            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                {
                    unsafeBitmap.SetPixel(x, y, PixelHandler.Contrast(unsafeBitmap.GetPixel(x, y), contrastValue));
                }
            });
            unsafeBitmap.UnlockBitmap();
            return unsafeBitmap.Bitmap;
        }

        static int binaryValue = 50;//порог для выбора цвета (5 - 250)
        public static int BinaryValue
        {
            get => binaryValue;
            set
            {
                if (value <= 250 && value >= 5)
                    binaryValue = value;
            }
        }
        static public Bitmap Binary(Bitmap Image)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            unsafeBitmap.LockBitmap();
            int width = Image.Width;
            int height = Image.Height;
            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                {
                    unsafeBitmap.SetPixel(x, y, PixelHandler.Treshold(unsafeBitmap.GetPixel(x, y), binaryValue));
                }
            });
            unsafeBitmap.UnlockBitmap();
            return unsafeBitmap.Bitmap;
        }

        static double gammaValue = 1 / 1.4;// 1/3.5 - 3.5 (0 - не менять)
        public static double GammaValue
        {
            get => gammaValue;
            set
            {
                if (value <= 3.5 && value >= 1 / 3.5)
                    gammaValue = value;
            }
        }
        static public Bitmap GammaCorrection(Bitmap Image)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            unsafeBitmap.LockBitmap();
            int width = Image.Width;
            int height = Image.Height;
            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                {
                    unsafeBitmap.SetPixel(x, y, PixelHandler.Gamma(unsafeBitmap.GetPixel(x, y), gammaValue));
                }
            });
            unsafeBitmap.UnlockBitmap();
            return unsafeBitmap.Bitmap;
        }

        static double valueR = 0, valueG = 0, valueB = 0; // -100 - 100 (0 - не менять)
        public static double ValueR
        {
            get => valueR;
            set
            {
                if (value <= 100 && value >= -100)
                    valueR = value;
            }
        }
        public static double ValueG
        {
            get => valueG;
            set
            {
                if (value <= 100 && value >= -100)
                    valueG = value;
            }
        }
        public static double ValueB
        {
            get => valueB;
            set
            {
                if (value <= 100 && value >= -100)
                    valueB = value;
            }
        }
        public enum colorChannel : int
        {
            R,
            G,
            B
        }
        static public colorChannel SelectedChannel;

        static public Bitmap ChangeColorBalanсe(Bitmap Image)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            unsafeBitmap.LockBitmap();
            int width = Image.Width;
            int height = Image.Height;
            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                {
                    unsafeBitmap.SetPixel(x, y, PixelHandler.ChangeColorBalance(unsafeBitmap.GetPixel(x, y)));
                }
            });
            unsafeBitmap.UnlockBitmap();
            return unsafeBitmap.Bitmap;
        }
        static public Bitmap EnableChannel(Bitmap Image)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            UnsafeBitmap unsafeBitmapOrig = new UnsafeBitmap(Interface.SavedImage);
            unsafeBitmap.LockBitmap();
            unsafeBitmapOrig.LockBitmap();
            int width = Image.Width;
            int height = Image.Height;
            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                {
                    unsafeBitmap.SetPixel(x, y, PixelHandler.Enable(unsafeBitmap.GetPixel(x, y), unsafeBitmapOrig.GetPixel(x, y)));
                }
            });
            unsafeBitmap.UnlockBitmap();
            unsafeBitmapOrig.UnlockBitmap();
            return unsafeBitmap.Bitmap;
        }
        static public Bitmap DisableChannel(Bitmap Image)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            unsafeBitmap.LockBitmap();
            int width = Image.Width;
            int height = Image.Height;
            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                {
                    unsafeBitmap.SetPixel(x, y, PixelHandler.Disable(unsafeBitmap.GetPixel(x, y)));
                }
            });
            unsafeBitmap.UnlockBitmap();
            return unsafeBitmap.Bitmap;
        }

        static public PixelData oldColor = new PixelData();
        static public PixelData newColor = new PixelData();
        static public Bitmap ReplaceColor(Bitmap Image)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            unsafeBitmap.LockBitmap();
            int width = Image.Width;
            int height = Image.Height;
            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                {
                    unsafeBitmap.SetPixel(x, y, PixelHandler.ReplaceColor(newColor, oldColor, unsafeBitmap.GetPixel(x, y)));
                }
            });
            unsafeBitmap.UnlockBitmap();
            return unsafeBitmap.Bitmap;
        }
    }
}