using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ReImage
{
    public partial class Interface : MetroFramework.Forms.MetroForm
    {
        Bitmap LoadedImage, CurrentImage;
        public static Bitmap SavedImage { get; private set; }

        Thread thread;
        delegate Bitmap ChooseFilter(Bitmap bmp);
        ChooseFilter SelectedFilter;

        bool ControlLocked = true;
        bool ImageLoaded = false;
        
        public Interface()
        {
            InitializeComponent();
            this.StyleManager = mnmMain;
        }
        private void RunFilter()
        {
            try
            {
                ControlLocked = true;
                customPbox.AllowUserDrag = false;
                customPbox.AllowUserZoom = false;
                CurrentImage = SelectedFilter(SavedImage);
                customPbox.SetImageOnCenter = true;
                customPbox.Image = CurrentImage;
                ControlLocked = false;
                customPbox.AllowUserDrag = true;
                customPbox.AllowUserZoom = true;
                GC.Collect();
                customPbox.Focus();
            }
            catch {  }
        }
        
        #region Верхняя панель
        private void load_Click(object sender, EventArgs e)
        {
            if (ImageLoaded && ControlLocked)
                return;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            string FileName = openFile.FileName;
            if (FileName != "")
            {
                LoadedImage = new Bitmap((Bitmap)Image.FromFile(FileName));
                customPbox.SetImageOnCenter = true;
                customPbox.Image = CurrentImage = SavedImage = LoadedImage;
                ControlLocked = false;
                ImageLoaded = true;
                customPbox.Zoom = 1;
                zoom_value.Text = (customPbox.Zoom * 100).ToString() + "%";
            }
            customPbox.Focus();
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (ControlLocked)
                return;
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
                CurrentImage.Save(sfd.FileName + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            customPbox.Focus();
        }

        private void normal_size_Click(object sender, EventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            customPbox.Zoom = 1;
            customPbox.SetImageOnCenter = true;
            customPbox.Image = CurrentImage;
        }
        private void fill_size_Click(object sender, EventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            customPbox.SetImageOnCenter = true;
            customPbox.Image = CurrentImage;
            if (CurrentImage.Width >= CurrentImage.Height * (float)customPbox.Width / (float)customPbox.Height)
                customPbox.Zoom = (float)customPbox.Size.Width / (float)CurrentImage.Width;
            else
                customPbox.Zoom = (float)customPbox.Size.Height / (float)CurrentImage.Height;
        }

        private void customPbox_ZoomValueChanged(object sender, EventArgs e)
        {
            zoom_value.Text = ((int)(customPbox.Zoom * 100)).ToString() + "%";
        }

        private void show_saved_MouseDown(object sender, MouseEventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            customPbox.Image = SavedImage;
        }
        private void show_saved_MouseUp(object sender, MouseEventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            customPbox.Image = CurrentImage;
        }

        private void show_original_MouseDown(object sender, MouseEventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            customPbox.Image = LoadedImage;
        }
        private void show_original_MouseUp(object sender, MouseEventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            customPbox.Image = CurrentImage;
        }
        
        private void cancel_Click(object sender, EventArgs e)
        {
            CurrentImage = SavedImage;
            customPbox.SetImageOnCenter = true;
            customPbox.Image = CurrentImage;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            SavedImage = CurrentImage;
        }
        #endregion

        #region Effects
        private void Effects_Tbar_ValueChanged(object sender, EventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            MetroFramework.Controls.MetroTrackBar Tbar = sender as MetroFramework.Controls.MetroTrackBar;
            switch (Tbar.Tag)
            {
                case "R":
                    Effects.ValueR = Tbar.Value;
                    R_value.Text = Effects.ValueR.ToString() + "%";
                    Effects.SelectedChannel = Effects.colorChannel.R;
                    SelectedFilter = Effects.ChangeColorBalanсe;
                    break;
                case "G":
                    Effects.ValueG = Tbar.Value;
                    G_value.Text = Effects.ValueG.ToString() + "%";
                    Effects.SelectedChannel = Effects.colorChannel.G;
                    SelectedFilter = Effects.ChangeColorBalanсe;
                    break;
                case "B":
                    Effects.ValueB = Tbar.Value;
                    B_value.Text = Effects.ValueB.ToString() + "%";
                    Effects.SelectedChannel = Effects.colorChannel.B;
                    SelectedFilter = Effects.ChangeColorBalanсe;
                    break;
                case "contrast":
                    Effects.ContrastValue = Tbar.Value;
                    contrast_value.Text = Effects.ContrastValue.ToString();
                    SelectedFilter = Effects.Contrast;
                    break;
                case "brightness":
                    Effects.BrightValue = Tbar.Value;
                    brightness_value.Text = Effects.BrightValue.ToString();
                    SelectedFilter = Effects.Bright;
                    break;
                case "gamma":
                    if (Tbar.Value < 35)
                    {
                        Effects.GammaValue = Math.Pow(Math.Abs(Tbar.Value - 35) * 0.1 + 1, -1);
                        gamma_value.Text = "1/" + ((35 - Tbar.Value) * 0.1).ToString();
                    }
                    else
                    {
                        Effects.GammaValue = (Tbar.Value - 25) * 0.1;
                        gamma_value.Text = Effects.GammaValue.ToString();
                    }
                    SelectedFilter = Effects.GammaCorrection;
                    break;
                case "treshold":
                    Effects.BinaryValue = Tbar.Value;
                    treshold_value.Text = Effects.BinaryValue.ToString();
                    SelectedFilter = Effects.Binary;
                    break;
            }
            if ((thread != null && thread.IsAlive == true))
                return;
            thread = new Thread(RunFilter);
            thread.Start();
        }
        private void Effects_link_Click(object sender, EventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            MetroFramework.Controls.MetroLink Check = sender as MetroFramework.Controls.MetroLink;
            switch (Check.Tag)
            {
                case "discolor":
                    SelectedFilter = Effects.DiscolorImage;
                    break;
                case "inverse colors":
                    SelectedFilter = Effects.InverseImageColors;
                    break;
            }
            thread = new Thread(RunFilter);
            thread.Start();
        }
        private void channel_switcher_CheckedChanged(object sender, EventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            MetroFramework.Controls.MetroCheckBox Check = sender as MetroFramework.Controls.MetroCheckBox;
            switch (Check.Tag)
            {
                case "R":
                    Effects.SelectedChannel = Effects.colorChannel.R;
                    break;
                case "G":
                    Effects.SelectedChannel = Effects.colorChannel.G;
                    break;
                case "B":
                    Effects.SelectedChannel = Effects.colorChannel.B;
                    break;
            }
            if (Check.Checked == false)
                SelectedFilter = Effects.DisableChannel;
            else
                SelectedFilter = Effects.EnableChannel;
            thread = new Thread(RunFilter);
            thread.Start();
        }
        #endregion

        #region Filters
        private void median_recursive_CheckedChanged(object sender, EventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            MetroFramework.Controls.MetroRadioButton Rbtn = sender as MetroFramework.Controls.MetroRadioButton;
            if (Rbtn.Checked == true)
                Filters.MedianMode = Rbtn.Tag.ToString();
        }
        private void Filters_Tbar_ValueChanged(object sender, EventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            MetroFramework.Controls.MetroTrackBar Tbar = sender as MetroFramework.Controls.MetroTrackBar;
            switch (Tbar.Tag)
            {
                case "gaussian":
                    GaussianBlur.KernelSize = Tbar.Value;
                    gaussian_value.Text = Tbar.Value.ToString();
                    break;
                case "median":
                    Filters.KernelSize = Tbar.Value * 2 + 1;
                    median_value.Text = Filters.KernelSize.ToString() + "x" + Filters.KernelSize.ToString();
                    break;
            }
        }
        private void Filters_link_Click(object sender, EventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            MetroFramework.Controls.MetroLink Check = sender as MetroFramework.Controls.MetroLink;
            switch (Check.Tag)
            {
                case "emboss":
                case "blur":
                case "sharpness":
                case "laplassian":
                    Filters.SelectKernel(Check.Tag.ToString());
                    SelectedFilter = Filters.ConvolutionFilter;
                    break;
                case "sobel":
                    SelectedFilter = Filters.SobelFilter;
                    break;
                case "gaussian1d":
                    GaussianBlur.Sigma = GaussianBlur.KernelSize / 3;
                    SelectedFilter = GaussianBlur.GaussianBlurFilter1D;
                    break;
                case "gaussian2d":
                    GaussianBlur.Sigma = GaussianBlur.KernelSize / 3;
                    SelectedFilter = GaussianBlur.GaussianBlurFilter2D;
                    break;
                case "median":
                    SelectedFilter = Filters.MedianFilter;
                    break;
                case "autolevels":
                    SelectedFilter = Filters.Autolevels;
                    break;
                case "ScreenShot":
                    SelectedFilter = Filters.PrepareScreenShot;
                    break;
            }
            thread = new Thread(RunFilter);
            thread.Start();
        }
        private void canny_Click(object sender, EventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            SelectedFilter = CannyEdgeDetector.RunAlgorithm;
            thread = new Thread(RunFilter);
            thread.Start();
        }

        private void light_alignment_Click(object sender, EventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            SelectedFilter = Filters.LightAlligment;
            thread = new Thread(RunFilter);
            thread.Start();
        }
        #endregion

        #region Other
        private void other_any_btn_Click(object sender, EventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            MetroFramework.Controls.MetroLink lnk = sender as MetroFramework.Controls.MetroLink;
            switch(lnk.Tag)
            {
                case "sobel":
                    SelectedFilter = CannyEdgeDetector.Sobel;
                    break;
                case "non max":
                    SelectedFilter = CannyEdgeDetector.NonMaximumSuppression;
                    break;
                case "double treshold":
                    SelectedFilter = CannyEdgeDetector.DoubleTheshold;
                    break;
                case "trace":
                    SelectedFilter = CannyEdgeDetector.Trace;
                    break;
                case "hvga":
                    SelectedFilter = ColorPalette.GetMainColors;
                    break;
            }
            thread = new Thread(RunFilter);
            thread.Start();
        }

        private void Other_tbar_ValueChanged(object sender, EventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;
            MetroFramework.Controls.MetroTrackBar Tbar = sender as MetroFramework.Controls.MetroTrackBar;
            switch (Tbar.Tag)
            {
                case "upper":
                    CannyEdgeDetector.UpperTreshold = Tbar.Value;
                    upper_value.Text = CannyEdgeDetector.UpperTreshold.ToString();
                    break;
                case "lower":
                    CannyEdgeDetector.LowerTreshold = Tbar.Value;
                    lower_value.Text = CannyEdgeDetector.LowerTreshold.ToString();
                    break;
            }
        }

        private void any_channel_TextChanged(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTextBox tBox = sender as MetroFramework.Controls.MetroTextBox;
            tBox.Text = Regex.Replace(tBox.Text, @"[^0-9$,]", "");
            if (tBox.Text != "" && Int32.Parse(tBox.Text) > 255)
                tBox.Text = "255";
        }

        private void Other_replace_color_Click(object sender, EventArgs e)
        {
            if (!ImageLoaded || ControlLocked)
                return;

            Effects.oldColor.red = Byte.Parse(old_R.Text);
            Effects.oldColor.green = Byte.Parse(old_G.Text);
            Effects.oldColor.blue = Byte.Parse(old_B.Text);

            Effects.newColor.red = Byte.Parse(new_R.Text);
            Effects.newColor.green = Byte.Parse(new_G.Text);
            Effects.newColor.blue = Byte.Parse(new_B.Text);

            SelectedFilter = Effects.ReplaceColor;

            thread = new Thread(RunFilter);
            thread.Start();
        }
        #endregion
    }
}