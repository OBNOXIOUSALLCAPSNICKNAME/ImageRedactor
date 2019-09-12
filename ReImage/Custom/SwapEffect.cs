using System.Threading;
using System.Windows.Forms;

namespace ReImage
{
    class SwapEffect
    {
        public static void _Hide()
        {
            for (; Application.OpenForms[0].Opacity > 0; Application.OpenForms[0].Opacity -= .05, Thread.Sleep(10)) ;
        }
        public static void _Show()
        {
            Application.OpenForms[0].Refresh();
            for (Application.OpenForms[0].Opacity = 0; Application.OpenForms[0].Opacity < 1; Application.OpenForms[0].Opacity += .05, Thread.Sleep(10)) ;
        }

        public static void SwapClose(Form ClosingForm, Form OpeningForm)
        {
            OpeningForm.Show();
            OpeningForm.Refresh();
            for (int i = 0; i < 20; i++)
            {
                ClosingForm.Opacity -= 0.05;
                OpeningForm.Opacity += 0.05;
                Thread.Sleep(10);
            }
        }
        public static void SwapOpen(Form OpeningForm, Form ClosingForm)
        {
            OpeningForm.Opacity = 0;
            OpeningForm.Refresh();
            for (int i = 0; i < 20; i++)
            {
                OpeningForm.Opacity += 0.05;
                ClosingForm.Opacity -= 0.05;
                Thread.Sleep(10);
            }
            ClosingForm.Refresh();
            ClosingForm.Hide();
        }
    }
}
