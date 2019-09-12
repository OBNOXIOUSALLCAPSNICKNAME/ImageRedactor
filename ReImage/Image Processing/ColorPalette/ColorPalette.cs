using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ReImage
{
    class ColorPalette
    {
        static public Bitmap GetMainColors(Bitmap Image)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int ColorsCount = 20;
            int Suppression = 0;

            #region берем цвета из изображения
            List<Color> RGB_Colors = new List<Color>();

            PixelData CurrentPixel = new PixelData();
            Color CurrentColor = new Color();

            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(Image);
            int upperbound = 0;
            int lowerboundX = unsafeBitmap.Bitmap.Width;
            int lowerboundY = unsafeBitmap.Bitmap.Height;

            unsafeBitmap.LockBitmap();
            for (int x = upperbound; x < lowerboundX; x++)
            {
                for (int y = upperbound; y < lowerboundY; y++)
                {
                    CurrentPixel = unsafeBitmap.GetPixel(x, y);
                    CurrentColor = Color.FromArgb(CurrentPixel.red, CurrentPixel.green, CurrentPixel.blue);

                    if (CurrentColor.R <= 255 - Suppression && CurrentColor.G <= 255 - Suppression && CurrentColor.B <= 255 - Suppression &&
                        CurrentColor.R >= Suppression && CurrentColor.G >= Suppression && CurrentColor.B >= Suppression)
                        RGB_Colors.Add(CurrentColor);
                }
            }
            unsafeBitmap.UnlockBitmap();
            #endregion

            //  RGB_Colors = DistrictByRGB(RGB_Colors);
            //  RGB_Colors = DeleteLowSaturated(RGB_Colors);
            //  RGB_Colors = DistrictByHue(RGB_Colors);

            List<List<Color>> RGB_GroupedColors = K_means.RunAlgorithm(RGB_Colors, ColorsCount);
            List<Color> PaletteColors = GetNearestColors(RGB_GroupedColors);
            Bitmap Palette = new Bitmap(CreatePalette(960, 60, PaletteColors));
            Image = ImageHandler.MergeTwoImages(Image, Palette, "center");

            RGB_GroupedColors.Clear();
            RGB_GroupedColors = K_means.RunAlgorithm(PaletteColors, 5);
            PaletteColors.Clear();
            PaletteColors = GetCustomColors(RGB_GroupedColors, "saturated");
            Palette = new Bitmap(CreatePalette(960, 130, PaletteColors));
            Image = ImageHandler.MergeTwoImages(Image, Palette, "center");

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            System.Windows.Forms.MessageBox.Show(((float)elapsedMs / 1000).ToString() + "s");
            return Image;
        }
        
        public static Bitmap CreatePalette(int width, int height, List<Color> paleteColors)
        {
            UnsafeBitmap palette = new UnsafeBitmap(width, height);
            PixelData currentColor = new PixelData();

            int CoordStep = width / paleteColors.Count;
            int lowerX = (width - CoordStep * paleteColors.Count) / 2;
            int upperX = CoordStep;

            foreach (Color color in paleteColors)
            {
                currentColor.red = color.R;
                currentColor.green = color.G;
                currentColor.blue = color.B;

                palette.LockBitmap();
                for (int x = lowerX; x < upperX; x++)
                    for (int y = 0; y < palette.Bitmap.Height; y++)
                        palette.SetPixel(x, y, currentColor);
                palette.UnlockBitmap();

                lowerX += CoordStep;
                upperX += CoordStep;
            }

            Effects.oldColor.red = Effects.oldColor.green = Effects.oldColor.blue = 0;
            Effects.newColor.red = Effects.newColor.green = Effects.newColor.blue = 255;
            palette.Bitmap = Effects.ReplaceColor(palette.Bitmap);

            return palette.Bitmap;
        }
        public static Bitmap CreateSpectre(int height, List<Color> spectreColors)
        {
            int width = spectreColors.Count;
            PixelData CurrentPixel = new PixelData();
            UnsafeBitmap spectre = new UnsafeBitmap(width, height);

            spectre.LockBitmap();
            for (int x = 0; x < spectre.Bitmap.Width; x++)
            {
                for (int y = 0; y < spectre.Bitmap.Height; y++)
                {
                    CurrentPixel.red = spectreColors[x].R;
                    CurrentPixel.green = spectreColors[x].G;
                    CurrentPixel.blue = spectreColors[x].B;

                    spectre.SetPixel(x, y, CurrentPixel);
                }
            }
            spectre.UnlockBitmap();

            return spectre.Bitmap;
        }

        public static List<Color> GetAverageColors(List<List<Color>> colors)
        {
            List<Color> AverageColors = new List<Color>();
            foreach (List<Color> list in colors)
            {
                int r = 0, g = 0, b = 0;

                foreach(Color color in list)
                {
                    r += color.R;
                    g += color.G;
                    b += color.B;
                }

                r = r / list.Count;
                g = g / list.Count;
                b = b / list.Count;

                AverageColors.Add(Color.FromArgb(r, g, b));
            }

            for (int i = 0; i < AverageColors.Count; i++)
            {
                if (AverageColors[i].R == 255 && AverageColors[i].G == 255 && AverageColors[i].B == 254)
                {
                    AverageColors.RemoveAt(i);
                    i -= 1;
                }
            }

            AverageColors.Sort(delegate (Color left, Color right)
            { return right.GetHue().CompareTo(left.GetHue()); });

            return AverageColors;
        }
        public static List<Color> GetCustomColors(List<List<Color>> colors, string mode)
        {
            List<Color> CustomColors = new List<Color>();
            int index = 0;
            double value = 0d;

            foreach (List<Color> list in colors)
            {
                switch(mode)
                {
                    case "bright":
                        value = 0d;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if(list[i].GetBrightness() > value)
                            {
                                index = i;
                                value = list[i].GetBrightness();
                            }
                        }
                        CustomColors.Add(list[index]);
                        break;
                    case "dark":
                        value = 100000d;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].GetBrightness() < value)
                            {
                                index = i;
                                value = list[i].GetBrightness();
                            }
                        }
                        CustomColors.Add(list[index]);
                        break;
                    case "muffled":
                        value = 100000d;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].GetSaturation() < value)
                            {
                                index = i;
                                value = list[i].GetSaturation();
                            }
                        }
                        CustomColors.Add(list[index]);
                        break;
                    case "saturated":
                        value = 0d;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].GetSaturation() > value)
                            {
                                index = i;
                                value = list[i].GetSaturation();
                            }
                        }
                        CustomColors.Add(list[index]);
                        break;
                }
            }

            return CustomColors;
        }
        public static List<Color> GetNearestColors(List<List<Color>> colors)
        {
            List<Color> AverageColors = new List<Color>();
            foreach (List<Color> list in colors)
            {
                int r = 0, g = 0, b = 0;

                foreach (Color color in list)
                {
                    r += color.R;
                    g += color.G;
                    b += color.B;
                }

                r = r / list.Count;
                g = g / list.Count;
                b = b / list.Count;

                Color averageColor = Color.FromArgb(r, g, b);
                double minDistance = 100000000d;
                double currentDistance = 0d;
                List<double> allDistance = new List<double>();
                foreach (Color color in list)
                {
                    currentDistance = K_means.Euclidean(averageColor, color);
                    allDistance.Add(currentDistance);
                    if (currentDistance < minDistance)
                        minDistance = currentDistance;
                }
                List<double> sortedAllDistance = new List<double>();
                sortedAllDistance.AddRange(allDistance.GetRange(0, allDistance.Count));
                sortedAllDistance.Sort();
                AverageColors.Add(list[allDistance.FindIndex(x => x == sortedAllDistance[0])]);
            }

            for (int i = 0; i < AverageColors.Count; i++)
            {
                if (AverageColors[i].R == 255 && AverageColors[i].G == 255 && AverageColors[i].B == 254)
                {
                    AverageColors.RemoveAt(i);
                    i -= 1;
                }
            }

            AverageColors.Sort(delegate (Color left, Color right)
            { return right.GetHue().CompareTo(left.GetHue()); });

            return AverageColors;
        }
        public static List<Color> GetPrevailingColors(List<List<Color>> colors)
        {
            List<Color> AverageColors = new List<Color>();
            foreach (List<Color> list in colors)
            {
                Color c = list.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
                AverageColors.Add(c);
            }

            for (int i = 0; i < AverageColors.Count; i++)
            {
                if (AverageColors[i].R == 255 && AverageColors[i].G == 255 && AverageColors[i].B == 254)
                {
                    AverageColors.RemoveAt(i);
                    i -= 1;
                }
            }

            AverageColors.Sort(delegate (Color left, Color right)
            { return right.GetHue().CompareTo(left.GetHue()); });

            return AverageColors;
        }
        public static List<Color> GetMiddleColors(List<List<Color>> colors)
        {
            List<Color> AverageColors = new List<Color>();
            foreach (List<Color> list in colors)
            {
                List<double> saturations = new List<double>();
                foreach(Color color in list)
                {
                    saturations.Add(color.GetSaturation());
                }
                saturations.Sort();

                AverageColors.Add(list.Find(x => x.GetSaturation() == saturations[saturations.Count/2]));
            }

            for (int i = 0; i < AverageColors.Count; i++)
            {
                if (AverageColors[i].R == 255 && AverageColors[i].G == 255 && AverageColors[i].B == 254)
                {
                    AverageColors.RemoveAt(i);
                    i -= 1;
                }
            }

            AverageColors.Sort(delegate (Color left, Color right)
            { return right.GetHue().CompareTo(left.GetHue()); });

            return AverageColors;
        }

        public static Color GetAverageColor(List<Color> colors)
        {
            int r = 0, g = 0, b = 0;

            foreach (Color color in colors)
            {
                r += color.R;
                g += color.G;
                b += color.B;
            }

            r = r / colors.Count;
            g = g / colors.Count;
            b = b / colors.Count;

            return Color.FromArgb(r, g, b);
        }

        static public List<Color> DistrictByHue(List<Color> ColorsList, bool flag = false)
        {
            List<Color> DistrictByHue = new List<Color>();

            ColorsList.Sort(delegate (Color left, Color right)
            { return left.GetHue().CompareTo(right.GetHue()); });

            DistrictByHue = ColorsList.GroupBy(x => (float)x.GetHue()).Select(y => y.First()).ToList();

            if (DistrictByHue.Count * 5 > ColorsList.Count || flag == true)
            {
                ColorsList.Clear();
                ColorsList.AddRange(DistrictByHue.GetRange(0, DistrictByHue.Count));
            }
            return ColorsList;
        }
        static public List<Color> DistrictByRGB(List<Color> ColorsList, bool flag = false)
        {
            List<Color> DistrictList = new List<Color>();
            DistrictList.AddRange(ColorsList.GetRange(0, ColorsList.Count()));
            DistrictList = DistrictList.Distinct().ToList();

            //меняем только если изображение не в паинте из трех каракуль нарисовано
            if (DistrictList.Count * 5 > ColorsList.Count || flag == true)
            {
                ColorsList.Clear();
                ColorsList.AddRange(DistrictList);
            }

            return ColorsList;
        }
        static public List<Color> DeleteLowSaturated(List<Color> ColorsList)
        {
            float averageSaturation = 0;
            float averageBrightness = 0;
            for (int q = 0; q < ColorsList.Count; q++)
            {
                averageBrightness += ColorsList[q].GetBrightness();
                averageSaturation += ColorsList[q].GetSaturation();
            }
            averageBrightness = averageBrightness / ColorsList.Count;
            averageSaturation = averageSaturation / ColorsList.Count;

            List<Color> tempList = new List<Color>();
            foreach (Color color in ColorsList)
            {
                if ((float)color.GetSaturation() > (float)averageSaturation * 0.95)
                    tempList.Add(color);
            }

            ColorsList.Clear();
            ColorsList.AddRange(tempList.GetRange(0, tempList.Count));

            return ColorsList;
        }
    }
}
