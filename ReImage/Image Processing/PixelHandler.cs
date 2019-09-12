using System;

namespace ReImage
{
    class PixelHandler
    {
        static PixelData pixel = new PixelData();
        static public PixelData NormalizePixel(double valueR, double valueG, double valueB)
        {
            pixel.red = FixOutOfRangeVaue(valueR);
            pixel.green = FixOutOfRangeVaue(valueG);
            pixel.blue = FixOutOfRangeVaue(valueB);
            return pixel;
        }
        static public byte FixOutOfRangeVaue(int value)
        {
            return (byte)(value < 0 ? 0 : (value > 255 ? 255 : (byte)value));
        }
        static public byte FixOutOfRangeVaue(float value)
        {
            return (byte)(value < 0 ? 0 : (value > 255 ? 255 : (byte)value));
        }
        static public byte FixOutOfRangeVaue(double value)
        {
            return (byte)(value < 0 ? 0 : (value > 255 ? 255 : (byte)value));
        }

        static public PixelData GetAverage(int[] getVectorR, int[] getVectorG, int[] getVectorB)
        {
            Array.Sort(getVectorR);
            Array.Sort(getVectorG);
            Array.Sort(getVectorB);
            int middle = getVectorR.Length / 2;

            pixel.red = (byte)getVectorR[middle];
            pixel.green = (byte)getVectorG[middle];
            pixel.blue = (byte)getVectorB[middle];

            return pixel;
        }

        static public PixelData Divide(PixelData getColor1, PixelData getColor2)
        {
            /*
            Divide
            Очень сильное осветление, напоминающее Color Dodge.
            Частное от деления значения яркости пикселя нижнего слоя
            на значение яркости соответствующего пикселя верхнего слоя умножается на 255.
            Формула: (b ÷ a) × 255.
            Если пиксель верхнего слоя белый, результирующим будет цвет нижнего слоя.
            Пиксели одинакового цвета становятся белыми, при условии, что они не чёрные.
            Одинаковые чёрные пиксели остаются чёрными. Режим Divide работает поканально, что приводит к дополнительному искажению цветов.
            
            */
            double resR = (double)getColor2.red / (double)getColor1.red * 255;
            double resG = (double)getColor2.green / (double)getColor1.green * 255;
            double resB = (double)getColor2.blue / (double)getColor1.blue * 255;

            pixel.red = FixOutOfRangeVaue(resR);
            pixel.green = FixOutOfRangeVaue(resG);
            pixel.blue = FixOutOfRangeVaue(resB);
            return pixel;
        }
        static public PixelData Exclusion(PixelData getColor1, PixelData getColor2)
        {
            /*
            Exclusion (применение не найдено)
            s — яркость исходного изображения; с — яркость корректирующего изображения; r — яркость финального изображения.
            r = (255 - 2 * c)/255*s + c
            r = s + c - ((2*s*c)/(255))
            */
            double resR = (255 - 2 * (float)getColor2.red) / 255 * getColor1.red + getColor2.red;
            double resG = (255 - 2 * (float)getColor2.green) / 255 * getColor1.green + getColor2.green;
            double resB = (255 - 2 * (float)getColor2.blue) / 255 * getColor1.blue + getColor2.blue;

            pixel.red = FixOutOfRangeVaue(resR);
            pixel.green = FixOutOfRangeVaue(resG);
            pixel.blue = FixOutOfRangeVaue(resB);
            return pixel;
        }
        static public PixelData Difference(PixelData getColor1, PixelData getColor2)
        {
            /*
            Difference (применение не найдено)
            r = s - c (s > c) или r = c - s (s <= c);
            */
            pixel.red = (byte)(255 - Math.Abs(getColor1.red - getColor2.red));
            pixel.green = (byte)(255 - Math.Abs(getColor1.green - getColor2.green));
            pixel.blue = (byte)(255 - Math.Abs(getColor1.blue - getColor2.blue));
            return pixel;
        }

        static public PixelData DiscolorPixel(PixelData getColor)
        {
            int Average = (getColor.red + getColor.green + getColor.blue) / 3;
            getColor.red = getColor.green = getColor.blue = (byte)Average;
            return getColor;
        }

        static public PixelData Treshold(PixelData getColor, int treshold)
        {
            if (getColor.blue > treshold)
                getColor.red = getColor.green = getColor.blue = 255;
            else
                getColor.red = getColor.green = getColor.blue = 0;
            return getColor;
        }

        static public PixelData InversePixelColor(PixelData getColor)
        {
            getColor.red = (byte)(255 - getColor.red);
            getColor.green = (byte)(255 - getColor.green);
            getColor.blue = (byte)(255 - getColor.blue);
            return getColor;
        }

        static public PixelData Gamma(PixelData getColor, double gamma)
        {
            getColor.red = FixOutOfRangeVaue(255 * Math.Pow((Convert.ToDouble(getColor.red) / 255), gamma));
            getColor.green = FixOutOfRangeVaue(255 * Math.Pow((Convert.ToDouble(getColor.green) / 255), gamma));
            getColor.blue = FixOutOfRangeVaue(255 * Math.Pow((Convert.ToDouble(getColor.blue) / 255), gamma));
            return getColor;
        }

        static public PixelData Brightness(PixelData getColor, double vol)
        {
            //  I = I + N • 128 / 100(1)
            //это old way в фотошопе, как сделать новый способ не нашел
            getColor.red = FixOutOfRangeVaue(getColor.red + vol);
            getColor.green = FixOutOfRangeVaue(getColor.green + vol);
            getColor.blue = FixOutOfRangeVaue(getColor.blue + vol);
            return getColor;
        }

        static public PixelData Contrast(PixelData getColor, double vol)
        {
            vol = vol * (-1);
            /*
             * Уменьшение контрастности на N процентов:
            I = (I • (100 – N) + 128 • N) / 100 (2)
            Увеличение контрастности на N процентов:
            I = (I • 100 – 128 • N) / (100 – N) (3)
            Если новое I не попадает в диапазон 0..255 – то его следует урезать.
             * */
            getColor.red = FixOutOfRangeVaue((getColor.red * (100 - vol) + 128 * vol) / 100);
            getColor.green = FixOutOfRangeVaue((getColor.green * (100 - vol) + 128 * vol) / 100);
            getColor.blue = FixOutOfRangeVaue((getColor.blue * (100 - vol) + 128 * vol) / 100);
            return getColor;
        }

        static public PixelData ReplaceColor(PixelData newColor, PixelData oldColor, PixelData currentColor)
        {
            if (
                currentColor.red == oldColor.red &&
                currentColor.green == oldColor.green &&
                currentColor.blue == oldColor.blue
                )
            {
                currentColor.red = newColor.red;
                currentColor.green = newColor.green;
                currentColor.blue = newColor.blue;
            }
            return currentColor;
        }

        static public PixelData ChangeColorBalance(PixelData getColor)
        {
            /*
                Фильтр «Цветовой баланс»
                Для изменения цветового баланса по одному из каналов R, G, B на N процентов следует вычислить новое значение цветового канала по формуле:
                I = I + N • 128 / 100, где I – это R, G или B каждой точки изображения. (4)
                Если новое I не попадает в диапазон 0..255 – то его следует урезать.
             * */
            switch (Effects.SelectedChannel)
            {
                case Effects.colorChannel.R:
                    getColor.red = FixOutOfRangeVaue((double)getColor.red + Effects.ValueR * 128 / 100);
                    break;
                case Effects.colorChannel.G:
                    getColor.green = FixOutOfRangeVaue((double)getColor.green + Effects.ValueG * 128 / 100);
                    break;
                case Effects.colorChannel.B:
                    getColor.blue = FixOutOfRangeVaue((double)getColor.blue + Effects.ValueB * 128 / 100);
                    break;
            }
            return getColor;
        }
        static public PixelData Disable(PixelData getColor)
        {
            switch (Effects.SelectedChannel)
            {
                case Effects.colorChannel.R:
                    getColor.red = 0;
                    break;
                case Effects.colorChannel.G:
                    getColor.green = 0;
                    break;
                case Effects.colorChannel.B:
                    getColor.blue = 0;
                    break;
            }
            return getColor;
        }
        static public PixelData Enable(PixelData getColor, PixelData getColor2)
        {
            switch (Effects.SelectedChannel)
            {
                case Effects.colorChannel.R:
                    getColor.red = getColor2.red;
                    break;
                case Effects.colorChannel.G:
                    getColor.green = getColor2.green;
                    break;
                case Effects.colorChannel.B:
                    getColor.blue = getColor2.blue;
                    break;
            }
            return getColor;
        }
    }
}