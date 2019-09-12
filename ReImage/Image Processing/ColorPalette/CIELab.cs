using System;
using System.Drawing;

namespace ReImage
{
    class CIELab
    {
        //ref_x 95.047 ref_y 100.000 ref_z 108.883 (d65 2)

        public double L;
        public double a;
        public double b;

        static double ref_x = 95.047d;
        static double ref_y = 100.000d;
        static double ref_z = 108.883d;

        public CIELab()
        {
            L = 0f;
            a = 0f;
            b = 0f;
        }
        public CIELab(double get_L, double get_a, double get_b)
        {
            L = get_L;
            a = get_a;
            b = get_b;
        }

        static public CIELab RGB_to_CIELab(Color RGB)
        {
            double[] XYZ = new double[3];
            XYZ = RGB_to_XYZ(RGB);

            return XYZ_to_CIELab(XYZ);
        }
        static public Color CIELab_to_RGB(CIELab LAB)
        {
            double[] XYZ = new double[3];
            XYZ = CIELab_to_XYZ(LAB);

            return XYZ_to_RGB(XYZ);
        }

        static public int FixOutOfRangeVaue(double value)
        {
            return (int)(value < 0 ? 0 : (value > 255 ? 255 : (int)value));
        }
        static public Color XYZ_to_RGB(double[] XYZ)
        {
            double var_X = XYZ[0] / 100d;
            double var_Y = XYZ[1] / 100d;
            double var_Z = XYZ[2] / 100d;

            double var_R = var_X * 3.2406d + var_Y * -1.5372d + var_Z * -0.4986d;
            double var_G = var_X * -0.9689d + var_Y * 1.8758d + var_Z * 0.0415d;
            double var_B = var_X * 0.0557d + var_Y * -0.2040d + var_Z * 1.0570d;

            if (var_R > 0.0031308d) var_R = 1.055d * Math.Pow(var_R, (1d / 2.4d)) - 0.055d;
            else var_R = 12.92d * var_R;
            if (var_G > 0.0031308d) var_G = 1.055d * Math.Pow(var_G, (1d / 2.4d)) - 0.055d;
            else var_G = 12.92d * var_G;
            if (var_B > 0.0031308d) var_B = 1.055d * Math.Pow(var_B, (1d / 2.4d)) - 0.055d;
            else var_B = 12.92d * var_B;

            /*
            int sR = (int)(var_R * 255);
            int sG = (int)(var_G * 255);
            int sB = (int)(var_B * 255);
            */

            int sR = FixOutOfRangeVaue(var_R * 255);
            int sG = FixOutOfRangeVaue(var_G * 255);
            int sB = FixOutOfRangeVaue(var_B * 255);

            return Color.FromArgb(sR, sG, sB);
        }
        static public CIELab XYZ_to_CIELab(double[] XYZ)
        {
            double L = 0f;
            double a = 0f;
            double b = 0f;

            double var_X = XYZ[0] / ref_x;
            double var_Y = XYZ[1] / ref_y;
            double var_Z = XYZ[2] / ref_z;

            if (var_X > 0.008856d) var_X = Math.Pow(var_X, (1d / 3d));
            else var_X = (7.787d * var_X) + (16d / 116d);
            if (var_Y > 0.008856d) var_Y = Math.Pow(var_Y, (1d / 3d));
            else var_Y = (7.787d * var_Y) + (16d / 116d);
            if (var_Z > 0.008856d) var_Z = Math.Pow(var_Z, (1d / 3d));
            else var_Z = (7.787d * var_Z) + (16d / 116d);

            L = (116d * var_Y) - 16d;
            a = 500d * (var_X - var_Y);
            b = 200d * (var_Y - var_Z);
            return new CIELab(L, a, b);
        }

        static public double[] RGB_to_XYZ(Color RGB)
        {
            double[] XYZ = new double[3];
            double var_R = (((double)RGB.R / 255f));
            double var_G = (((double)RGB.G / 255f));
            double var_B = (((double)RGB.B / 255f));

            if (var_R > 0.04045) var_R = Math.Pow(((var_R + 0.055) / 1.055), 2.4);
            else var_R = var_R / 12.92;
            if (var_G > 0.04045) var_G = Math.Pow(((var_G + 0.055) / 1.055), 2.4);
            else var_G = var_G / 12.92;
            if (var_B > 0.04045) var_B = Math.Pow(((var_B + 0.055) / 1.055), 2.4);
            else var_B = var_B / 12.92;

            var_R = var_R * 100;
            var_G = var_G * 100;
            var_B = var_B * 100;

            XYZ[0] = var_R * 0.4124 + var_G * 0.3576 + var_B * 0.1805;
            XYZ[1] = var_R * 0.2126 + var_G * 0.7152 + var_B * 0.0722;
            XYZ[2] = var_R * 0.0193 + var_G * 0.1192 + var_B * 0.9505;
            return XYZ;
        }
        static public double[] CIELab_to_XYZ(CIELab LAB)
        {
            double[] XYZ = new double[3];
            double var_Y = (LAB.L + 16d) / 116d;
            double var_X = LAB.a / 500d + var_Y;
            double var_Z = var_Y - LAB.b / 200d;

            if (Math.Pow(var_Y, 3d) > 0.008856d) var_Y = Math.Pow(var_Y, 3);
            else var_Y = (var_Y - 16d / 116d) / 7.787d;
            if (Math.Pow(var_X, 3d) > 0.008856d) var_X = Math.Pow(var_X, 3);
            else var_X = (var_X - 16d / 116d) / 7.787d;
            if (Math.Pow(var_Z, 3d) > 0.008856) var_Z = Math.Pow(var_Z, 3);
            else var_Z = (var_Z - 16d / 116d) / 7.787d;

            XYZ[0] = var_X * ref_x;
            XYZ[1] = var_Y * ref_y;
            XYZ[2] = var_Z * ref_z;
            return XYZ;
        }

        static public double deltaE76(CIELab first, CIELab second)
        {
            double var_L = (second.L - first.L) * (second.L - first.L);
            double var_a = (second.a - first.a) * (second.a - first.a);
            double var_b = (second.b - first.b) * (second.b - first.b);

            return var_L + var_a + var_b;
        }
        static public double Difference(CIELab first, CIELab second)
        {
            double result = 0d;

            double dif_L = Math.Abs(first.L - second.L);
            double dif_a = Math.Abs(first.a - second.a);
            double dif_b = Math.Abs(first.b - second.b);
            result = (dif_L + dif_a + dif_b);

            return result;
        }

        //это зло пиздец
        static public double deltaE2000(CIELab first, CIELab second)
        {
            const double k_L = 1.0, k_C = 1.0, k_H = 1.0;
            double deg360InRad = degtorad(360.0);
            double deg180InRad = degtorad(180.0);
            const double pow25To7 = 6103515625.0;

            double C1 = Math.Sqrt((first.a * first.a) + (first.b * first.b));
            double C2 = Math.Sqrt((second.a * second.a) + (second.b * second.b));

            double barC = (C1 + C2) / 2.0;

            double G = 0.5 * (1 - Math.Sqrt(Math.Pow(barC, 7) / (Math.Pow(barC, 7) + pow25To7)));

            double a1Prime = (1.0 + G) * first.a;
            double a2Prime = (1.0 + G) * second.a;

            double CPrime1 = Math.Sqrt((a1Prime * a1Prime) + (first.b * first.b));
            double CPrime2 = Math.Sqrt((a2Prime * a2Prime) + (second.b * second.b));

            double hPrime1;
            if (first.b == 0 && a1Prime == 0)
                hPrime1 = 0.0;
            else
            {
                hPrime1 = Math.Atan2(first.b, a1Prime);

                if (hPrime1 < 0)

                    hPrime1 += deg360InRad;
            }
            double hPrime2;
            if (second.b == 0 && a2Prime == 0)
                hPrime2 = 0.0;
            else
            {
                hPrime2 = Math.Atan2(second.b, a2Prime);

                if (hPrime2 < 0)

                    hPrime2 += deg360InRad;
            }


            double deltaLPrime = second.L - first.L;

            double deltaCPrime = CPrime2 - CPrime1;

            double deltahPrime;
            double CPrimeProduct = CPrime1 * CPrime2;
            if (CPrimeProduct == 0)
                deltahPrime = 0;
            else
            {
                deltahPrime = hPrime2 - hPrime1;
                if (deltahPrime < -deg180InRad)

                    deltahPrime += deg360InRad;
                else if (deltahPrime > deg180InRad)
                    deltahPrime -= deg360InRad;
            }

            double deltaHPrime = 2.0 * Math.Sqrt(CPrimeProduct) *
                Math.Sin(deltahPrime / 2.0);


            double barLPrime = (first.L + second.L) / 2.0;

            double barCPrime = (CPrime1 + CPrime2) / 2.0;

            double barhPrime, hPrimeSum = hPrime1 + hPrime2;
            if (CPrime1 * CPrime2 == 0)
            {
                barhPrime = hPrimeSum;
            }
            else
            {
                if (Math.Abs(hPrime1 - hPrime2) <= deg180InRad)
                    barhPrime = hPrimeSum / 2.0;
                else
                {
                    if (hPrimeSum < deg360InRad)

                        barhPrime = (hPrimeSum + deg360InRad) / 2.0;
                    else
                        barhPrime = (hPrimeSum - deg360InRad) / 2.0;
                }
            }

            double T = 1.0 - (0.17 * Math.Cos(barhPrime - degtorad(30.0))) +
                (0.24 * Math.Cos(2.0 * barhPrime)) +
                (0.32 * Math.Cos((3.0 * barhPrime) + degtorad(6.0))) -
                (0.20 * Math.Cos((4.0 * barhPrime) - degtorad(63.0)));

            double deltaTheta = degtorad(30.0) *
                Math.Exp(-Math.Pow((barhPrime - degtorad(275.0)) / degtorad(25.0), 2.0));

            double R_C = 2.0 * Math.Sqrt(Math.Pow(barCPrime, 7.0) /
                (Math.Pow(barCPrime, 7.0) + pow25To7));

            double S_L = 1 + ((0.015 * Math.Pow(barLPrime - 50.0, 2.0)) /
                Math.Sqrt(20 + Math.Pow(barLPrime - 50.0, 2.0)));

            double S_C = 1 + (0.045 * barCPrime);

            double S_H = 1 + (0.015 * barCPrime * T);

            double R_T = (-Math.Sin(2.0 * deltaTheta)) * R_C;

            double deltaE = Math.Sqrt(
                Math.Pow(deltaLPrime / (k_L * S_L), 2.0) +
                Math.Pow(deltaCPrime / (k_C * S_C), 2.0) +
                Math.Pow(deltaHPrime / (k_H * S_H), 2.0) +
                (R_T * (deltaCPrime / (k_C * S_C)) * (deltaHPrime / (k_H * S_H))));

            return (deltaE);
        }
        static public double degtorad(double deg)
        {
            return (deg * (Math.PI / 180.0));
        }
    }
}
