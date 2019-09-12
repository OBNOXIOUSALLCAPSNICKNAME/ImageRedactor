using System;
using System.Collections.Generic;
using System.Drawing;

namespace ReImage
{
    class K_means
    {
        unsafe static public List<List<Color>> RunAlgorithm(List<Color> list, int clasterCount)
        {
            int count = 0;

            List<List<CIELab>> CurrentClasters = new List<List<CIELab>>();
            List<List<CIELab>> ResultClasters = new List<List<CIELab>>();
            List<CIELab> CurrentCentroids = new List<CIELab>();
            List<CIELab> PreviousCentroids = new List<CIELab>();
            List<CIELab> Colors = Converter.List_RGBtoCIELab(list);

            for (int i = 0; i < clasterCount; i++)
            {
                PreviousCentroids.Add(Colors[0]);
                CurrentClasters.Add(new List<CIELab>());
            }

            CurrentCentroids = Converter.List_RGBtoCIELab(InitializeCentroidsv1(list, clasterCount));

            double[] currentMinE = new double[clasterCount];

            CIELab currentCentroid = new CIELab();
            double* currentMinEe = stackalloc double[clasterCount];
            double* p;
            double var_L, var_a, var_b;

            bool contnue = true;
            while (contnue)
            {
                if (CompareClasters(CurrentCentroids, PreviousCentroids) == true)
                    contnue = false;
                else if (count >= 500)
                    contnue = false;
                else
                    contnue = true;

                count += 1;
                /*
                foreach (CIELab color in Colors)
                {
                     for (int i = 0; i < clasterCount; i++)
                        currentMinE[i] = CIELab.deltaE76(color, CurrentCentroids[i]);

                    int clasterNumber = FindNearestClaster(currentMinE);
                    CurrentClasters[clasterNumber].Add(color);
                }
                */

                foreach (CIELab color in Colors)
                {
                    p = currentMinEe;
                    for (int i = 0; i < clasterCount; i++)
                    {
                        currentCentroid = CurrentCentroids[i];
                        var_L = (color.L - currentCentroid.L);
                        var_a = (color.a - currentCentroid.a);
                        var_b = (color.b - currentCentroid.b);
                        var_L = var_L * var_L;
                        var_a = var_a * var_a;
                        var_b = var_b * var_b;
                        *p = var_L + var_a + var_b;
                        p++;
                    }

                    double minValue = 1000000d;
                    int index = 0;

                    p = currentMinEe;
                    for (int i = 0; i < clasterCount; i++)
                    {
                        if ((*p) < minValue)
                        {
                            minValue = *p;
                            index = i;
                        }
                        p++;
                    }
                    CurrentClasters[index].Add(color);
                }

                ResultClasters.Clear();
                foreach (List<CIELab> claster in CurrentClasters)
                {
                    if (claster.Count == 0)
                        claster.Add(new CIELab(100, 0, 0));
                    ResultClasters.Add(claster.GetRange(0, claster.Count));
                }

                PreviousCentroids.Clear();
                PreviousCentroids.AddRange(CurrentCentroids.GetRange(0, CurrentCentroids.Count));

                CurrentCentroids.Clear();
                foreach (List<CIELab> claster in CurrentClasters)
                {
                    CIELab newCentroid = new CIELab();
                    newCentroid = FindClasterCentroid(claster);
                    CurrentCentroids.Add(newCentroid);
                    claster.Clear();
                }
            }
         //   System.Windows.Forms.MessageBox.Show(count.ToString());
            return Converter.GroupList_CIELabtoRBG(ResultClasters);
        }

        static bool CompareClasters(List<CIELab> first, List<CIELab> second)
        {
            bool result = true;
            for (int i = 0; i < first.Count; i++)
            {
                if (CIELab.Difference(first[i], second[i]) != 0.0d)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        static int FindNearestClaster(double[] values)
        {
            double minValue = 1000000d;
            int index = 0;

            for (int i = 0; i < values.Length; i++)
                if (values[i] < minValue)
                {
                    minValue = values[i];
                    index = i;
                }
            //разница в скорости примерно в полтора раза
            // return Array.FindIndex(values, x => x == minValue);
            return index;
        }
        static CIELab FindClasterCentroid(List<CIELab> list)
        {
            double L = 0d;
            double a = 0d;
            double b = 0d;

            foreach (CIELab color in list)
            {
                L += color.L;
                a += color.a;
                b += color.b;
            }
            L = L / list.Count;
            a = a / list.Count;
            b = b / list.Count;

            return new CIELab(L, a, b);
        }

        static public double Euclidean(Color first, Color second)
        {
            double R = (first.R - second.R) * (first.R - second.R);
            double G = (first.G - second.G) * (first.G - second.G);
            double B = (first.B - second.B) * (first.B - second.B);

            return Math.Sqrt(R + G + B);
        }

        static List<Color> InitializeCentroidsv1(List<Color> list, int ColorsCount)
        {
            List<List<Color>> GroupedByHue = new List<List<Color>>();
            List<Color> Part = new List<Color>();
            int maxLenght = 0;
            int emptyListCount = 0;
            int[] groupLengths = new int[ColorsCount];

            list.Sort(delegate (Color left, Color right)
            { return right.GetHue().CompareTo(left.GetHue()); });

            float lower = (float)list[list.Count - 1].GetHue();
            float upper = (float)list[0].GetHue();

            float KeyStep = (upper - lower) / ColorsCount;
            upper = KeyStep + lower;

            for (int i = 0; i < ColorsCount; i++)
            {
                if (i == ColorsCount - 1)
                    upper = (float)list[0].GetHue();
                float currentHueValue = 0f;
                foreach (Color item in list)
                {
                    currentHueValue = item.GetHue();
                    if ((float)currentHueValue >= (float)lower && (float)currentHueValue <= (float)upper)
                        Part.Add(item);
                }

                if (Part.Count >= 2)
                {
                    Part = ColorPalette.DistrictByHue(Part, true);
                    Part.Sort(delegate (Color left, Color right)
                    { return left.GetBrightness().CompareTo(right.GetBrightness()); });
                }

                if (maxLenght < Part.Count)
                    maxLenght = Part.Count;
                if (Part.Count == 0)
                    emptyListCount += 1;

                groupLengths[i] = Part.Count;

                GroupedByHue.Add(Part.GetRange(0, Part.Count));
                Part.Clear();

                lower = lower + KeyStep;
                upper = upper + KeyStep;
            }

            List<Color> maxList = new List<Color>();
            List<List<Color>> emptyLists = new List<List<Color>>();

            Array.Sort(groupLengths);
            maxList = GroupedByHue.Find(group => group.Count == maxLenght);
            emptyLists = GroupedByHue.FindAll(x => x.Count == 0);

            if (emptyListCount != 0 && maxLenght > 1)
            {
                double e = 0d;
                int count = 1;
                bool flag = false;

                while (flag == false)
                {
                    count += 1;
                    if (count > groupLengths.Length)
                        break;
                    Color left = ColorPalette.GetAverageColor(maxList.GetRange(0, maxList.Count / 2));
                    Color right = ColorPalette.GetAverageColor(maxList.GetRange(maxList.Count / 2, maxList.Count / 2));
                    e = Euclidean(left, right);

                    if (e < 2.0d)
                    {
                        maxLenght = groupLengths[groupLengths.Length - count];
                        maxList = GroupedByHue.Find(group => group.Count == maxLenght);
                    }
                    else flag = true;
                }

                for (int i = 0; i < emptyLists.Count; i++)
                {
                    int col = 0;
                    int LargestPartIndex = 0;

                    Array.Sort(groupLengths);
                    maxLenght = groupLengths[groupLengths.Length - 1];
                    LargestPartIndex = GroupedByHue.FindIndex(group => group.Count == maxLenght);

                    col = GroupedByHue[LargestPartIndex].Count / 2;
                    emptyLists[i].AddRange(GroupedByHue[LargestPartIndex].GetRange(0, col));
                    GroupedByHue[LargestPartIndex].RemoveRange(0, col);
                    groupLengths[groupLengths.Length - 1] = groupLengths[groupLengths.Length - 1] / 2;
                }

                int cnt = 0;
                for (int i = 0; i < GroupedByHue.Count; i++)
                {
                    if (GroupedByHue[i].Count == 0)
                    {
                        GroupedByHue[i] = emptyLists[cnt];
                        cnt += 1;
                    }
                }
            }

            for (int i = 0; i < GroupedByHue.Count; i++)
            {
                if (GroupedByHue[i].Count == 0)
                    GroupedByHue[i].Add(maxList[0]);
            }

            return ColorPalette.GetAverageColors(GroupedByHue);
        }

        #region неиспользуемые способы инициализации первоначальных центроидов
        static List<Color> InitializeCentroidsv2(List<Color> list, int ColorsCount)
        {
            List<List<Color>> GroupedByHue = new List<List<Color>>();
            List<Color> Part = new List<Color>();
            int maxLenght = 0;
            int emptyListCount = 0;
            int[] groupLengths = new int[ColorsCount];

            list = ColorPalette.DistrictByHue(list);
            list = ColorPalette.DeleteLowSaturated(list);

            list.Sort(delegate (Color left, Color right)
            {
                return right.GetHue().CompareTo(left.GetHue());
            });

            float lower = (float)list[list.Count - 1].GetHue();
            float upper = (float)list[0].GetHue();

            float KeyStep = (upper - lower) / ColorsCount;
            upper = KeyStep + lower;

            for (int i = 0; i < ColorsCount; i++)
            {
                if (i == ColorsCount - 1)
                    upper = (float)list[0].GetHue();
                foreach (Color item in list)
                {
                    if ((float)item.GetHue() >= (float)lower && (float)item.GetHue() <= (float)upper)
                        Part.Add(item);
                }

                if (Part.Count > 2)
                {
                    Part = ColorPalette.DistrictByHue(Part, true);
                    Part.Sort(delegate (Color left, Color right)
                    { return left.GetBrightness().CompareTo(right.GetBrightness()); });
                }

                if (maxLenght < Part.Count)
                    maxLenght = Part.Count;
                if (Part.Count == 0)
                    emptyListCount += 1;

                groupLengths[i] = Part.Count;

                GroupedByHue.Add(Part.GetRange(0, Part.Count));
                Part.Clear();

                lower = lower + KeyStep;
                upper = upper + KeyStep;
            }

            if (emptyListCount != 0)
            {
                List<Color> maxList = new List<Color>();
                List<List<Color>> emptyLists = new List<List<Color>>();

                Array.Sort(groupLengths);
                maxList = GroupedByHue.Find(group => group.Count == maxLenght);
                emptyLists = GroupedByHue.FindAll(x => x.Count == 0);

                Color c1 = ColorPalette.GetAverageColor(maxList.GetRange(0, maxList.Count / 2));
                Color c2 = ColorPalette.GetAverageColor(maxList.GetRange(maxList.Count / 2, maxList.Count / 2));
                double e = Euclidean(c1, c2);
                if (e < 2.0d)
                {
                    maxLenght = groupLengths[groupLengths.Length - 2];
                    maxList = GroupedByHue.Find(group => group.Count == maxLenght);
                }

                for (int i = 0; i < emptyLists.Count; i++)
                {
                    int col = 0, from = 0;
                    from = (maxList.Count / (emptyListCount + 1)) * (i + 1);
                    col = (maxList.Count / (emptyListCount + 1)) - 1;

                    emptyLists[i].AddRange(maxList.GetRange(from, col));
                }

                int cnt = 0;
                for (int i = 0; i < GroupedByHue.Count; i++)
                {
                    if (GroupedByHue[i].Count == 0)
                    {
                        GroupedByHue[i] = emptyLists[cnt];
                        cnt += 1;
                    }
                }

                int index = GroupedByHue.FindIndex(group => group.Count == maxLenght);
                GroupedByHue[index] = GroupedByHue[index].GetRange(0, maxList.Count / (emptyListCount + 1));
            }
            return ColorPalette.GetAverageColors(GroupedByHue);
        }
        static List<CIELab> InitializeCentroidsv3(List<CIELab> list, int clasterCount)
        {
            Random rnd = new Random();
            List<CIELab> Centriods = new List<CIELab>();
            Centriods.Add(list[rnd.Next(1, list.Count - 2)]);

            for (int i = 0; i < clasterCount; i++)
            {
                double sum = 0d;
                double newSum = 0d;
                double[] currentMinE = new double[i + 1];

                foreach (CIELab color in list)
                {
                    for (int j = 0; j < currentMinE.Length; j++)
                    {
                        currentMinE[j] = CIELab.deltaE76(color, Centriods[j]);
                    }

                    int clasterNumber = FindNearestClaster(currentMinE);
                    sum += currentMinE[clasterNumber];
                }

                newSum = rnd.NextDouble() * sum;
                sum = 0d;

                for (int f = 0; f < list.Count; f++)
                {

                    for (int j = 0; j < currentMinE.Length; j++)
                    {
                        currentMinE[j] = CIELab.deltaE76(list[f], Centriods[j]);
                    }

                    int clasterNumber = FindNearestClaster(currentMinE);
                    sum += currentMinE[clasterNumber];

                    if (sum >= newSum)
                    {
                        Centriods.Add(list[f]);
                        break;
                    }
                }
            }
            return Centriods;
        }
        static List<Color> InitializeCentroidsv4(List<Color> list, int ColorsCount)
        {
            List<List<Color>> GroupedByHue = new List<List<Color>>();
            List<Color> Part = new List<Color>();

            list = ColorPalette.DistrictByHue(list);
            list = ColorPalette.DeleteLowSaturated(list);

            list.Sort(delegate (Color left, Color right)
            {
                return right.GetHue().CompareTo(left.GetHue());
            });

            int KeyStep = list.Count / ColorsCount;

            for (int i = 0; i < ColorsCount; i++)
                GroupedByHue.Add(list.GetRange(KeyStep * i, KeyStep));

            return ColorPalette.GetAverageColors(GroupedByHue);
        }
        #endregion
    }
}