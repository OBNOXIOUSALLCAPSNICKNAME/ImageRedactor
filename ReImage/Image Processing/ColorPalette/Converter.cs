using System;
using System.Collections.Generic;
using System.Drawing;

namespace ReImage
{
    class Converter
    {
        static public List<CIELab> List_RGBtoCIELab(List<Color> inputList)
        {
            List<CIELab> outputList = new List<CIELab>();

            foreach (Color color in inputList)
                outputList.Add(CIELab.RGB_to_CIELab(color));

            return outputList;
        }
        static public List<Color> List_CIELabtoRBG(List<CIELab> inputList)
        {
            List<Color> outputList = new List<Color>();

            foreach (CIELab color in inputList)
                outputList.Add(CIELab.CIELab_to_RGB(color));

            return outputList;
        }

        static public List<List<Color>> GroupList_CIELabtoRBG(List<List<CIELab>> inputList)
        {
            List<List<Color>> outputList = new List<List<Color>>();
            List<Color> temp = new List<Color>();

            foreach (List<CIELab> list in inputList)
            {
                foreach (CIELab color in list)
                    temp.Add(CIELab.CIELab_to_RGB(color));

                outputList.Add(temp.GetRange(0, temp.Count));
                temp.Clear();
            }

            return outputList;
        }
        static public List<List<CIELab>> GroupList_RGBtoCIELab(List<List<Color>> inputList)
        {
            List<List<CIELab>> outputList = new List<List<CIELab>>();
            List<CIELab> temp = new List<CIELab>();

            foreach (List<Color> list in inputList)
            {
                foreach (Color color in list)
                    temp.Add(CIELab.RGB_to_CIELab(color));

                outputList.Add(temp.GetRange(0, temp.Count));
                temp.Clear();
            }

            return outputList;
        }

        static public List<CIELab> MergeGroups(List<List<CIELab>> inputList)
        {
            List<CIELab> outputList = new List<CIELab>();

            foreach (List<CIELab> list in inputList)
                outputList.AddRange(list.GetRange(0, list.Count));

            return outputList;
        }
        static public List<Color> MergeGroups(List<List<Color>> inputList)
        {
            List<Color> outputList = new List<Color>();

            foreach (List<Color> list in inputList)
                outputList.AddRange(list.GetRange(0, list.Count));

            return outputList;
        }
    }
}
