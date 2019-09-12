namespace ReImage
{
    partial class Interface
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interface));
            this.mnmMain = new MetroFramework.Components.MetroStyleManager(this.components);
            this.TabPanel = new MetroFramework.Controls.MetroTabControl();
            this.effects_panel = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.inverse_colors = new MetroFramework.Controls.MetroLink();
            this.discolor = new MetroFramework.Controls.MetroLink();
            this.B_state = new MetroFramework.Controls.MetroCheckBox();
            this.G_state = new MetroFramework.Controls.MetroCheckBox();
            this.R_state = new MetroFramework.Controls.MetroCheckBox();
            this.B_Tbar = new MetroFramework.Controls.MetroTrackBar();
            this.B_value = new MetroFramework.Controls.MetroLabel();
            this.G_Tbar = new MetroFramework.Controls.MetroTrackBar();
            this.G_value = new MetroFramework.Controls.MetroLabel();
            this.R_Tbar = new MetroFramework.Controls.MetroTrackBar();
            this.R_value = new MetroFramework.Controls.MetroLabel();
            this.treshold_name = new MetroFramework.Controls.MetroLabel();
            this.treshold_Tbar = new MetroFramework.Controls.MetroTrackBar();
            this.treshold_value = new MetroFramework.Controls.MetroLabel();
            this.gamma_name = new MetroFramework.Controls.MetroLabel();
            this.gamma_Tbar = new MetroFramework.Controls.MetroTrackBar();
            this.gamma_value = new MetroFramework.Controls.MetroLabel();
            this.contrast_name = new MetroFramework.Controls.MetroLabel();
            this.contrast_Tbar = new MetroFramework.Controls.MetroTrackBar();
            this.contrast_value = new MetroFramework.Controls.MetroLabel();
            this.brightness_name = new MetroFramework.Controls.MetroLabel();
            this.brightness_Tbar = new MetroFramework.Controls.MetroTrackBar();
            this.brightness_value = new MetroFramework.Controls.MetroLabel();
            this.filters_panel = new MetroFramework.Controls.MetroTabPage();
            this.filters_ScreenShot = new MetroFramework.Controls.MetroLink();
            this.gaussian1d = new MetroFramework.Controls.MetroLink();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.light_alignment = new MetroFramework.Controls.MetroLink();
            this.canny = new MetroFramework.Controls.MetroLink();
            this.autolevels = new MetroFramework.Controls.MetroLink();
            this.median = new MetroFramework.Controls.MetroLink();
            this.median_value = new MetroFramework.Controls.MetroLabel();
            this.median_Tbar = new MetroFramework.Controls.MetroTrackBar();
            this.median_normal = new MetroFramework.Controls.MetroRadioButton();
            this.median_filter_name = new MetroFramework.Controls.MetroLabel();
            this.median_recursive = new MetroFramework.Controls.MetroRadioButton();
            this.gaussian2d = new MetroFramework.Controls.MetroLink();
            this.metroTrackBar8 = new MetroFramework.Controls.MetroTrackBar();
            this.gaussian_value = new MetroFramework.Controls.MetroLabel();
            this.gausiian_blur_name = new MetroFramework.Controls.MetroLabel();
            this.emboss = new MetroFramework.Controls.MetroLink();
            this.sharpness = new MetroFramework.Controls.MetroLink();
            this.sobel = new MetroFramework.Controls.MetroLink();
            this.blur = new MetroFramework.Controls.MetroLink();
            this.laplassian = new MetroFramework.Controls.MetroLink();
            this.convolution_filters_name = new MetroFramework.Controls.MetroLabel();
            this.other_panel = new MetroFramework.Controls.MetroTabPage();
            this.hdga = new MetroFramework.Controls.MetroLink();
            this.new_B = new MetroFramework.Controls.MetroTextBox();
            this.new_G = new MetroFramework.Controls.MetroTextBox();
            this.new_R = new MetroFramework.Controls.MetroTextBox();
            this.old_B = new MetroFramework.Controls.MetroTextBox();
            this.old_G = new MetroFramework.Controls.MetroTextBox();
            this.old_R = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.other_replace_color = new MetroFramework.Controls.MetroLink();
            this.upper_name = new MetroFramework.Controls.MetroLabel();
            this.upper_tbar = new MetroFramework.Controls.MetroTrackBar();
            this.upper_value = new MetroFramework.Controls.MetroLabel();
            this.lower_name = new MetroFramework.Controls.MetroLabel();
            this.lower_tbar = new MetroFramework.Controls.MetroTrackBar();
            this.lower_value = new MetroFramework.Controls.MetroLabel();
            this.other_trace = new MetroFramework.Controls.MetroLink();
            this.other_non_max = new MetroFramework.Controls.MetroLink();
            this.other_double_treshold = new MetroFramework.Controls.MetroLink();
            this.other_sobel = new MetroFramework.Controls.MetroLink();
            this.load = new MetroFramework.Controls.MetroLink();
            this.save = new MetroFramework.Controls.MetroLink();
            this.zoom_value = new MetroFramework.Controls.MetroLabel();
            this.show_original = new MetroFramework.Controls.MetroLink();
            this.show_saved = new MetroFramework.Controls.MetroLink();
            this.normal_size = new MetroFramework.Controls.MetroLink();
            this.fill_size = new MetroFramework.Controls.MetroLink();
            this.progress_bar = new MetroFramework.Controls.MetroLabel();
            this.ok = new ReImage.CustomButton();
            this.customPbox = new ReImage.CustomPbox();
            this.cancel = new ReImage.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.mnmMain)).BeginInit();
            this.TabPanel.SuspendLayout();
            this.effects_panel.SuspendLayout();
            this.filters_panel.SuspendLayout();
            this.other_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnmMain
            // 
            this.mnmMain.Owner = this;
            this.mnmMain.Style = MetroFramework.MetroColorStyle.Silver;
            // 
            // TabPanel
            // 
            this.TabPanel.Controls.Add(this.effects_panel);
            this.TabPanel.Controls.Add(this.filters_panel);
            this.TabPanel.Controls.Add(this.other_panel);
            this.TabPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.TabPanel.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.TabPanel.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.TabPanel.ItemSize = new System.Drawing.Size(80, 45);
            this.TabPanel.Location = new System.Drawing.Point(992, 60);
            this.TabPanel.Name = "TabPanel";
            this.TabPanel.SelectedIndex = 2;
            this.TabPanel.Size = new System.Drawing.Size(248, 760);
            this.TabPanel.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabPanel.Style = MetroFramework.MetroColorStyle.Teal;
            this.TabPanel.TabIndex = 0;
            this.TabPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabPanel.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TabPanel.UseSelectable = true;
            // 
            // effects_panel
            // 
            this.effects_panel.AutoScroll = true;
            this.effects_panel.AutoScrollMinSize = new System.Drawing.Size(240, 660);
            this.effects_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.effects_panel.Controls.Add(this.metroLabel1);
            this.effects_panel.Controls.Add(this.inverse_colors);
            this.effects_panel.Controls.Add(this.discolor);
            this.effects_panel.Controls.Add(this.B_state);
            this.effects_panel.Controls.Add(this.G_state);
            this.effects_panel.Controls.Add(this.R_state);
            this.effects_panel.Controls.Add(this.B_Tbar);
            this.effects_panel.Controls.Add(this.B_value);
            this.effects_panel.Controls.Add(this.G_Tbar);
            this.effects_panel.Controls.Add(this.G_value);
            this.effects_panel.Controls.Add(this.R_Tbar);
            this.effects_panel.Controls.Add(this.R_value);
            this.effects_panel.Controls.Add(this.treshold_name);
            this.effects_panel.Controls.Add(this.treshold_Tbar);
            this.effects_panel.Controls.Add(this.treshold_value);
            this.effects_panel.Controls.Add(this.gamma_name);
            this.effects_panel.Controls.Add(this.gamma_Tbar);
            this.effects_panel.Controls.Add(this.gamma_value);
            this.effects_panel.Controls.Add(this.contrast_name);
            this.effects_panel.Controls.Add(this.contrast_Tbar);
            this.effects_panel.Controls.Add(this.contrast_value);
            this.effects_panel.Controls.Add(this.brightness_name);
            this.effects_panel.Controls.Add(this.brightness_Tbar);
            this.effects_panel.Controls.Add(this.brightness_value);
            this.effects_panel.HorizontalScrollbar = true;
            this.effects_panel.HorizontalScrollbarBarColor = false;
            this.effects_panel.HorizontalScrollbarHighlightOnWheel = false;
            this.effects_panel.HorizontalScrollbarSize = 10;
            this.effects_panel.Location = new System.Drawing.Point(4, 49);
            this.effects_panel.Name = "effects_panel";
            this.effects_panel.Size = new System.Drawing.Size(240, 707);
            this.effects_panel.Style = MetroFramework.MetroColorStyle.Teal;
            this.effects_panel.TabIndex = 0;
            this.effects_panel.Text = "Effects";
            this.effects_panel.Theme = MetroFramework.MetroThemeStyle.Light;
            this.effects_panel.VerticalScrollbar = true;
            this.effects_panel.VerticalScrollbarBarColor = true;
            this.effects_panel.VerticalScrollbarHighlightOnWheel = true;
            this.effects_panel.VerticalScrollbarSize = 8;
            // 
            // metroLabel1
            // 
            this.metroLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(0, 423);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(240, 30);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel1.TabIndex = 31;
            this.metroLabel1.Text = "color balance";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel1.UseStyleColors = true;
            // 
            // inverse_colors
            // 
            this.inverse_colors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inverse_colors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.inverse_colors.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.inverse_colors.Location = new System.Drawing.Point(56, 361);
            this.inverse_colors.Name = "inverse_colors";
            this.inverse_colors.Size = new System.Drawing.Size(130, 23);
            this.inverse_colors.Style = MetroFramework.MetroColorStyle.Teal;
            this.inverse_colors.TabIndex = 30;
            this.inverse_colors.Tag = "inverse colors";
            this.inverse_colors.Text = "inverse colors";
            this.inverse_colors.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inverse_colors.UseSelectable = true;
            this.inverse_colors.Click += new System.EventHandler(this.Effects_link_Click);
            // 
            // discolor
            // 
            this.discolor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discolor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.discolor.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.discolor.Location = new System.Drawing.Point(56, 332);
            this.discolor.Name = "discolor";
            this.discolor.Size = new System.Drawing.Size(130, 23);
            this.discolor.Style = MetroFramework.MetroColorStyle.Teal;
            this.discolor.TabIndex = 29;
            this.discolor.Tag = "discolor";
            this.discolor.Text = "discolor";
            this.discolor.Theme = MetroFramework.MetroThemeStyle.Light;
            this.discolor.UseSelectable = true;
            this.discolor.Click += new System.EventHandler(this.Effects_link_Click);
            // 
            // B_state
            // 
            this.B_state.AutoSize = true;
            this.B_state.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.B_state.Checked = true;
            this.B_state.CheckState = System.Windows.Forms.CheckState.Checked;
            this.B_state.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.B_state.Location = new System.Drawing.Point(19, 581);
            this.B_state.Name = "B_state";
            this.B_state.Size = new System.Drawing.Size(38, 25);
            this.B_state.Style = MetroFramework.MetroColorStyle.Teal;
            this.B_state.TabIndex = 25;
            this.B_state.Tag = "B";
            this.B_state.Text = "B";
            this.B_state.Theme = MetroFramework.MetroThemeStyle.Light;
            this.B_state.UseSelectable = true;
            this.B_state.CheckedChanged += new System.EventHandler(this.channel_switcher_CheckedChanged);
            // 
            // G_state
            // 
            this.G_state.AutoSize = true;
            this.G_state.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.G_state.Checked = true;
            this.G_state.CheckState = System.Windows.Forms.CheckState.Checked;
            this.G_state.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.G_state.Location = new System.Drawing.Point(19, 520);
            this.G_state.Name = "G_state";
            this.G_state.Size = new System.Drawing.Size(40, 25);
            this.G_state.Style = MetroFramework.MetroColorStyle.Teal;
            this.G_state.TabIndex = 24;
            this.G_state.Tag = "G";
            this.G_state.Text = "G";
            this.G_state.Theme = MetroFramework.MetroThemeStyle.Light;
            this.G_state.UseSelectable = true;
            this.G_state.CheckedChanged += new System.EventHandler(this.channel_switcher_CheckedChanged);
            // 
            // R_state
            // 
            this.R_state.AutoSize = true;
            this.R_state.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.R_state.Checked = true;
            this.R_state.CheckState = System.Windows.Forms.CheckState.Checked;
            this.R_state.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.R_state.Location = new System.Drawing.Point(19, 459);
            this.R_state.Name = "R_state";
            this.R_state.Size = new System.Drawing.Size(39, 25);
            this.R_state.Style = MetroFramework.MetroColorStyle.Teal;
            this.R_state.TabIndex = 23;
            this.R_state.Tag = "R";
            this.R_state.Text = "R";
            this.R_state.Theme = MetroFramework.MetroThemeStyle.Light;
            this.R_state.UseSelectable = true;
            this.R_state.CheckedChanged += new System.EventHandler(this.channel_switcher_CheckedChanged);
            // 
            // B_Tbar
            // 
            this.B_Tbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.B_Tbar.Location = new System.Drawing.Point(19, 609);
            this.B_Tbar.Minimum = -100;
            this.B_Tbar.Name = "B_Tbar";
            this.B_Tbar.Size = new System.Drawing.Size(200, 23);
            this.B_Tbar.Style = MetroFramework.MetroColorStyle.Teal;
            this.B_Tbar.TabIndex = 19;
            this.B_Tbar.Tag = "B";
            this.B_Tbar.Text = "metroTrackBar5";
            this.B_Tbar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.B_Tbar.Value = 0;
            this.B_Tbar.ValueChanged += new System.EventHandler(this.Effects_Tbar_ValueChanged);
            // 
            // B_value
            // 
            this.B_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.B_value.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.B_value.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.B_value.Location = new System.Drawing.Point(147, 581);
            this.B_value.Name = "B_value";
            this.B_value.Size = new System.Drawing.Size(70, 23);
            this.B_value.Style = MetroFramework.MetroColorStyle.Teal;
            this.B_value.TabIndex = 18;
            this.B_value.Text = "0%";
            this.B_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_value.Theme = MetroFramework.MetroThemeStyle.Light;
            this.B_value.UseStyleColors = true;
            // 
            // G_Tbar
            // 
            this.G_Tbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.G_Tbar.Location = new System.Drawing.Point(19, 548);
            this.G_Tbar.Minimum = -100;
            this.G_Tbar.Name = "G_Tbar";
            this.G_Tbar.Size = new System.Drawing.Size(200, 23);
            this.G_Tbar.Style = MetroFramework.MetroColorStyle.Teal;
            this.G_Tbar.TabIndex = 17;
            this.G_Tbar.Tag = "G";
            this.G_Tbar.Text = "metroTrackBar6";
            this.G_Tbar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.G_Tbar.Value = 0;
            this.G_Tbar.ValueChanged += new System.EventHandler(this.Effects_Tbar_ValueChanged);
            // 
            // G_value
            // 
            this.G_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.G_value.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.G_value.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.G_value.Location = new System.Drawing.Point(147, 520);
            this.G_value.Name = "G_value";
            this.G_value.Size = new System.Drawing.Size(70, 23);
            this.G_value.Style = MetroFramework.MetroColorStyle.Teal;
            this.G_value.TabIndex = 16;
            this.G_value.Text = "0%";
            this.G_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.G_value.Theme = MetroFramework.MetroThemeStyle.Light;
            this.G_value.UseStyleColors = true;
            // 
            // R_Tbar
            // 
            this.R_Tbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.R_Tbar.Location = new System.Drawing.Point(19, 487);
            this.R_Tbar.Minimum = -100;
            this.R_Tbar.Name = "R_Tbar";
            this.R_Tbar.Size = new System.Drawing.Size(200, 23);
            this.R_Tbar.Style = MetroFramework.MetroColorStyle.Teal;
            this.R_Tbar.TabIndex = 15;
            this.R_Tbar.Tag = "R";
            this.R_Tbar.Text = "metroTrackBar7";
            this.R_Tbar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.R_Tbar.Value = 0;
            this.R_Tbar.ValueChanged += new System.EventHandler(this.Effects_Tbar_ValueChanged);
            // 
            // R_value
            // 
            this.R_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.R_value.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.R_value.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.R_value.Location = new System.Drawing.Point(147, 459);
            this.R_value.Name = "R_value";
            this.R_value.Size = new System.Drawing.Size(70, 23);
            this.R_value.Style = MetroFramework.MetroColorStyle.Teal;
            this.R_value.TabIndex = 14;
            this.R_value.Text = "0%";
            this.R_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.R_value.Theme = MetroFramework.MetroThemeStyle.Light;
            this.R_value.UseStyleColors = true;
            // 
            // treshold_name
            // 
            this.treshold_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.treshold_name.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.treshold_name.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.treshold_name.Location = new System.Drawing.Point(19, 236);
            this.treshold_name.Name = "treshold_name";
            this.treshold_name.Size = new System.Drawing.Size(100, 30);
            this.treshold_name.Style = MetroFramework.MetroColorStyle.Teal;
            this.treshold_name.TabIndex = 13;
            this.treshold_name.Text = "treshold";
            this.treshold_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.treshold_name.Theme = MetroFramework.MetroThemeStyle.Light;
            this.treshold_name.UseStyleColors = true;
            // 
            // treshold_Tbar
            // 
            this.treshold_Tbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.treshold_Tbar.Location = new System.Drawing.Point(19, 271);
            this.treshold_Tbar.Maximum = 250;
            this.treshold_Tbar.Minimum = 5;
            this.treshold_Tbar.Name = "treshold_Tbar";
            this.treshold_Tbar.Size = new System.Drawing.Size(200, 23);
            this.treshold_Tbar.Style = MetroFramework.MetroColorStyle.Teal;
            this.treshold_Tbar.TabIndex = 12;
            this.treshold_Tbar.Tag = "treshold";
            this.treshold_Tbar.Text = "metroTrackBar4";
            this.treshold_Tbar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.treshold_Tbar.Value = 120;
            this.treshold_Tbar.ValueChanged += new System.EventHandler(this.Effects_Tbar_ValueChanged);
            // 
            // treshold_value
            // 
            this.treshold_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.treshold_value.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.treshold_value.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.treshold_value.Location = new System.Drawing.Point(147, 243);
            this.treshold_value.Name = "treshold_value";
            this.treshold_value.Size = new System.Drawing.Size(70, 23);
            this.treshold_value.Style = MetroFramework.MetroColorStyle.Teal;
            this.treshold_value.TabIndex = 11;
            this.treshold_value.Text = "120";
            this.treshold_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.treshold_value.Theme = MetroFramework.MetroThemeStyle.Light;
            this.treshold_value.UseStyleColors = true;
            // 
            // gamma_name
            // 
            this.gamma_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.gamma_name.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.gamma_name.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.gamma_name.Location = new System.Drawing.Point(19, 175);
            this.gamma_name.Name = "gamma_name";
            this.gamma_name.Size = new System.Drawing.Size(100, 30);
            this.gamma_name.Style = MetroFramework.MetroColorStyle.Teal;
            this.gamma_name.TabIndex = 10;
            this.gamma_name.Text = "gamma";
            this.gamma_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gamma_name.Theme = MetroFramework.MetroThemeStyle.Light;
            this.gamma_name.UseStyleColors = true;
            // 
            // gamma_Tbar
            // 
            this.gamma_Tbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.gamma_Tbar.Location = new System.Drawing.Point(19, 210);
            this.gamma_Tbar.Maximum = 60;
            this.gamma_Tbar.Name = "gamma_Tbar";
            this.gamma_Tbar.Size = new System.Drawing.Size(200, 23);
            this.gamma_Tbar.Style = MetroFramework.MetroColorStyle.Teal;
            this.gamma_Tbar.TabIndex = 9;
            this.gamma_Tbar.Tag = "gamma";
            this.gamma_Tbar.Text = "metroTrackBar3";
            this.gamma_Tbar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.gamma_Tbar.Value = 45;
            this.gamma_Tbar.ValueChanged += new System.EventHandler(this.Effects_Tbar_ValueChanged);
            // 
            // gamma_value
            // 
            this.gamma_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.gamma_value.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.gamma_value.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.gamma_value.Location = new System.Drawing.Point(147, 182);
            this.gamma_value.Name = "gamma_value";
            this.gamma_value.Size = new System.Drawing.Size(70, 23);
            this.gamma_value.Style = MetroFramework.MetroColorStyle.Teal;
            this.gamma_value.TabIndex = 8;
            this.gamma_value.Text = "1";
            this.gamma_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.gamma_value.Theme = MetroFramework.MetroThemeStyle.Light;
            this.gamma_value.UseStyleColors = true;
            // 
            // contrast_name
            // 
            this.contrast_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.contrast_name.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.contrast_name.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.contrast_name.Location = new System.Drawing.Point(19, 114);
            this.contrast_name.Name = "contrast_name";
            this.contrast_name.Size = new System.Drawing.Size(100, 30);
            this.contrast_name.Style = MetroFramework.MetroColorStyle.Teal;
            this.contrast_name.TabIndex = 7;
            this.contrast_name.Text = "contrast";
            this.contrast_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.contrast_name.Theme = MetroFramework.MetroThemeStyle.Light;
            this.contrast_name.UseStyleColors = true;
            // 
            // contrast_Tbar
            // 
            this.contrast_Tbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.contrast_Tbar.Location = new System.Drawing.Point(19, 149);
            this.contrast_Tbar.Minimum = -100;
            this.contrast_Tbar.Name = "contrast_Tbar";
            this.contrast_Tbar.Size = new System.Drawing.Size(200, 23);
            this.contrast_Tbar.Style = MetroFramework.MetroColorStyle.Teal;
            this.contrast_Tbar.TabIndex = 6;
            this.contrast_Tbar.Tag = "contrast";
            this.contrast_Tbar.Text = "metroTrackBar2";
            this.contrast_Tbar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.contrast_Tbar.Value = 0;
            this.contrast_Tbar.ValueChanged += new System.EventHandler(this.Effects_Tbar_ValueChanged);
            // 
            // contrast_value
            // 
            this.contrast_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.contrast_value.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.contrast_value.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.contrast_value.Location = new System.Drawing.Point(147, 121);
            this.contrast_value.Name = "contrast_value";
            this.contrast_value.Size = new System.Drawing.Size(70, 23);
            this.contrast_value.Style = MetroFramework.MetroColorStyle.Teal;
            this.contrast_value.TabIndex = 5;
            this.contrast_value.Text = "0";
            this.contrast_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.contrast_value.Theme = MetroFramework.MetroThemeStyle.Light;
            this.contrast_value.UseStyleColors = true;
            // 
            // brightness_name
            // 
            this.brightness_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.brightness_name.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.brightness_name.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.brightness_name.Location = new System.Drawing.Point(19, 51);
            this.brightness_name.Name = "brightness_name";
            this.brightness_name.Size = new System.Drawing.Size(100, 30);
            this.brightness_name.Style = MetroFramework.MetroColorStyle.Teal;
            this.brightness_name.TabIndex = 4;
            this.brightness_name.Text = "brightness";
            this.brightness_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brightness_name.Theme = MetroFramework.MetroThemeStyle.Light;
            this.brightness_name.UseStyleColors = true;
            // 
            // brightness_Tbar
            // 
            this.brightness_Tbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.brightness_Tbar.Location = new System.Drawing.Point(19, 86);
            this.brightness_Tbar.Maximum = 150;
            this.brightness_Tbar.Minimum = -150;
            this.brightness_Tbar.Name = "brightness_Tbar";
            this.brightness_Tbar.Size = new System.Drawing.Size(200, 23);
            this.brightness_Tbar.Style = MetroFramework.MetroColorStyle.Teal;
            this.brightness_Tbar.TabIndex = 3;
            this.brightness_Tbar.Tag = "brightness";
            this.brightness_Tbar.Text = "metroTrackBar1";
            this.brightness_Tbar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.brightness_Tbar.Value = 0;
            this.brightness_Tbar.ValueChanged += new System.EventHandler(this.Effects_Tbar_ValueChanged);
            // 
            // brightness_value
            // 
            this.brightness_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.brightness_value.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.brightness_value.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.brightness_value.Location = new System.Drawing.Point(147, 58);
            this.brightness_value.Name = "brightness_value";
            this.brightness_value.Size = new System.Drawing.Size(70, 23);
            this.brightness_value.Style = MetroFramework.MetroColorStyle.Teal;
            this.brightness_value.TabIndex = 2;
            this.brightness_value.Text = "0";
            this.brightness_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.brightness_value.Theme = MetroFramework.MetroThemeStyle.Light;
            this.brightness_value.UseStyleColors = true;
            // 
            // filters_panel
            // 
            this.filters_panel.AutoScroll = true;
            this.filters_panel.AutoScrollMinSize = new System.Drawing.Size(240, 660);
            this.filters_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.filters_panel.Controls.Add(this.filters_ScreenShot);
            this.filters_panel.Controls.Add(this.gaussian1d);
            this.filters_panel.Controls.Add(this.metroLabel2);
            this.filters_panel.Controls.Add(this.light_alignment);
            this.filters_panel.Controls.Add(this.canny);
            this.filters_panel.Controls.Add(this.autolevels);
            this.filters_panel.Controls.Add(this.median);
            this.filters_panel.Controls.Add(this.median_value);
            this.filters_panel.Controls.Add(this.median_Tbar);
            this.filters_panel.Controls.Add(this.median_normal);
            this.filters_panel.Controls.Add(this.median_filter_name);
            this.filters_panel.Controls.Add(this.median_recursive);
            this.filters_panel.Controls.Add(this.gaussian2d);
            this.filters_panel.Controls.Add(this.metroTrackBar8);
            this.filters_panel.Controls.Add(this.gaussian_value);
            this.filters_panel.Controls.Add(this.gausiian_blur_name);
            this.filters_panel.Controls.Add(this.emboss);
            this.filters_panel.Controls.Add(this.sharpness);
            this.filters_panel.Controls.Add(this.sobel);
            this.filters_panel.Controls.Add(this.blur);
            this.filters_panel.Controls.Add(this.laplassian);
            this.filters_panel.Controls.Add(this.convolution_filters_name);
            this.filters_panel.HorizontalScrollbar = true;
            this.filters_panel.HorizontalScrollbarBarColor = false;
            this.filters_panel.HorizontalScrollbarHighlightOnWheel = false;
            this.filters_panel.HorizontalScrollbarSize = 10;
            this.filters_panel.Location = new System.Drawing.Point(4, 49);
            this.filters_panel.Name = "filters_panel";
            this.filters_panel.Size = new System.Drawing.Size(240, 707);
            this.filters_panel.Style = MetroFramework.MetroColorStyle.Teal;
            this.filters_panel.TabIndex = 1;
            this.filters_panel.Text = "Filters";
            this.filters_panel.Theme = MetroFramework.MetroThemeStyle.Light;
            this.filters_panel.VerticalScrollbar = true;
            this.filters_panel.VerticalScrollbarBarColor = true;
            this.filters_panel.VerticalScrollbarHighlightOnWheel = true;
            this.filters_panel.VerticalScrollbarSize = 8;
            // 
            // filters_ScreenShot
            // 
            this.filters_ScreenShot.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.filters_ScreenShot.Location = new System.Drawing.Point(31, 604);
            this.filters_ScreenShot.Name = "filters_ScreenShot";
            this.filters_ScreenShot.Size = new System.Drawing.Size(171, 23);
            this.filters_ScreenShot.Style = MetroFramework.MetroColorStyle.Silver;
            this.filters_ScreenShot.TabIndex = 27;
            this.filters_ScreenShot.Tag = "ScreenShot";
            this.filters_ScreenShot.Text = "ScreenShot";
            this.filters_ScreenShot.Theme = MetroFramework.MetroThemeStyle.Light;
            this.filters_ScreenShot.UseSelectable = true;
            this.filters_ScreenShot.Click += new System.EventHandler(this.Filters_link_Click);
            // 
            // gaussian1d
            // 
            this.gaussian1d.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gaussian1d.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.gaussian1d.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.gaussian1d.Location = new System.Drawing.Point(7, 274);
            this.gaussian1d.Name = "gaussian1d";
            this.gaussian1d.Size = new System.Drawing.Size(54, 23);
            this.gaussian1d.Style = MetroFramework.MetroColorStyle.Teal;
            this.gaussian1d.TabIndex = 33;
            this.gaussian1d.Tag = "gaussian1d";
            this.gaussian1d.Text = "1d";
            this.gaussian1d.Theme = MetroFramework.MetroThemeStyle.Light;
            this.gaussian1d.UseSelectable = true;
            this.gaussian1d.Click += new System.EventHandler(this.Filters_link_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(37, 464);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(162, 30);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel2.TabIndex = 32;
            this.metroLabel2.Text = "comgined filters";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel2.UseStyleColors = true;
            // 
            // light_alignment
            // 
            this.light_alignment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.light_alignment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.light_alignment.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.light_alignment.Location = new System.Drawing.Point(16, 497);
            this.light_alignment.Name = "light_alignment";
            this.light_alignment.Size = new System.Drawing.Size(207, 30);
            this.light_alignment.Style = MetroFramework.MetroColorStyle.Teal;
            this.light_alignment.TabIndex = 31;
            this.light_alignment.Tag = "light alignment";
            this.light_alignment.Text = "light alignment";
            this.light_alignment.Theme = MetroFramework.MetroThemeStyle.Light;
            this.light_alignment.UseSelectable = true;
            this.light_alignment.Click += new System.EventHandler(this.light_alignment_Click);
            // 
            // canny
            // 
            this.canny.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.canny.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.canny.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.canny.Location = new System.Drawing.Point(16, 533);
            this.canny.Name = "canny";
            this.canny.Size = new System.Drawing.Size(207, 30);
            this.canny.Style = MetroFramework.MetroColorStyle.Teal;
            this.canny.TabIndex = 30;
            this.canny.Tag = "Canny";
            this.canny.Text = "Canny\'s edge detector";
            this.canny.Theme = MetroFramework.MetroThemeStyle.Light;
            this.canny.UseSelectable = true;
            this.canny.Click += new System.EventHandler(this.canny_Click);
            // 
            // autolevels
            // 
            this.autolevels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autolevels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.autolevels.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.autolevels.Location = new System.Drawing.Point(51, 569);
            this.autolevels.Name = "autolevels";
            this.autolevels.Size = new System.Drawing.Size(130, 29);
            this.autolevels.Style = MetroFramework.MetroColorStyle.Teal;
            this.autolevels.TabIndex = 29;
            this.autolevels.Tag = "autolevels";
            this.autolevels.Text = "autolevels";
            this.autolevels.Theme = MetroFramework.MetroThemeStyle.Light;
            this.autolevels.UseSelectable = true;
            this.autolevels.Click += new System.EventHandler(this.Filters_link_Click);
            // 
            // median
            // 
            this.median.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.median.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.median.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.median.Location = new System.Drawing.Point(15, 380);
            this.median.Name = "median";
            this.median.Size = new System.Drawing.Size(54, 23);
            this.median.Style = MetroFramework.MetroColorStyle.Teal;
            this.median.TabIndex = 26;
            this.median.Tag = "median";
            this.median.Text = "use";
            this.median.Theme = MetroFramework.MetroThemeStyle.Light;
            this.median.UseSelectable = true;
            this.median.Click += new System.EventHandler(this.Filters_link_Click);
            // 
            // median_value
            // 
            this.median_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.median_value.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.median_value.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.median_value.Location = new System.Drawing.Point(161, 373);
            this.median_value.Name = "median_value";
            this.median_value.Size = new System.Drawing.Size(68, 23);
            this.median_value.Style = MetroFramework.MetroColorStyle.Teal;
            this.median_value.TabIndex = 25;
            this.median_value.Text = "5x5";
            this.median_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.median_value.Theme = MetroFramework.MetroThemeStyle.Light;
            this.median_value.UseStyleColors = true;
            // 
            // median_Tbar
            // 
            this.median_Tbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.median_Tbar.Location = new System.Drawing.Point(80, 384);
            this.median_Tbar.Maximum = 5;
            this.median_Tbar.Minimum = 1;
            this.median_Tbar.Name = "median_Tbar";
            this.median_Tbar.Size = new System.Drawing.Size(75, 23);
            this.median_Tbar.Style = MetroFramework.MetroColorStyle.Teal;
            this.median_Tbar.TabIndex = 24;
            this.median_Tbar.Tag = "median";
            this.median_Tbar.Text = "metroTrackBar9";
            this.median_Tbar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.median_Tbar.Value = 2;
            this.median_Tbar.ValueChanged += new System.EventHandler(this.Filters_Tbar_ValueChanged);
            // 
            // median_normal
            // 
            this.median_normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.median_normal.Checked = true;
            this.median_normal.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.median_normal.Location = new System.Drawing.Point(15, 413);
            this.median_normal.Name = "median_normal";
            this.median_normal.Size = new System.Drawing.Size(104, 24);
            this.median_normal.Style = MetroFramework.MetroColorStyle.Teal;
            this.median_normal.TabIndex = 23;
            this.median_normal.TabStop = true;
            this.median_normal.Tag = "normal";
            this.median_normal.Text = "normal";
            this.median_normal.Theme = MetroFramework.MetroThemeStyle.Light;
            this.median_normal.UseSelectable = true;
            this.median_normal.CheckedChanged += new System.EventHandler(this.median_recursive_CheckedChanged);
            // 
            // median_filter_name
            // 
            this.median_filter_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.median_filter_name.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.median_filter_name.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.median_filter_name.Location = new System.Drawing.Point(37, 347);
            this.median_filter_name.Name = "median_filter_name";
            this.median_filter_name.Size = new System.Drawing.Size(162, 30);
            this.median_filter_name.Style = MetroFramework.MetroColorStyle.Teal;
            this.median_filter_name.TabIndex = 22;
            this.median_filter_name.Text = "median filter";
            this.median_filter_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.median_filter_name.Theme = MetroFramework.MetroThemeStyle.Light;
            this.median_filter_name.UseStyleColors = true;
            // 
            // median_recursive
            // 
            this.median_recursive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.median_recursive.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.median_recursive.Location = new System.Drawing.Point(125, 413);
            this.median_recursive.Name = "median_recursive";
            this.median_recursive.Size = new System.Drawing.Size(104, 24);
            this.median_recursive.Style = MetroFramework.MetroColorStyle.Teal;
            this.median_recursive.TabIndex = 21;
            this.median_recursive.Tag = "recursive";
            this.median_recursive.Text = "recursive";
            this.median_recursive.Theme = MetroFramework.MetroThemeStyle.Light;
            this.median_recursive.UseSelectable = true;
            this.median_recursive.CheckedChanged += new System.EventHandler(this.median_recursive_CheckedChanged);
            // 
            // gaussian2d
            // 
            this.gaussian2d.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gaussian2d.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.gaussian2d.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.gaussian2d.Location = new System.Drawing.Point(7, 303);
            this.gaussian2d.Name = "gaussian2d";
            this.gaussian2d.Size = new System.Drawing.Size(54, 23);
            this.gaussian2d.Style = MetroFramework.MetroColorStyle.Teal;
            this.gaussian2d.TabIndex = 20;
            this.gaussian2d.Tag = "gaussian2d";
            this.gaussian2d.Text = "2d";
            this.gaussian2d.Theme = MetroFramework.MetroThemeStyle.Light;
            this.gaussian2d.UseSelectable = true;
            this.gaussian2d.Click += new System.EventHandler(this.Filters_link_Click);
            // 
            // metroTrackBar8
            // 
            this.metroTrackBar8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.metroTrackBar8.Location = new System.Drawing.Point(67, 290);
            this.metroTrackBar8.Maximum = 50;
            this.metroTrackBar8.Name = "metroTrackBar8";
            this.metroTrackBar8.Size = new System.Drawing.Size(100, 23);
            this.metroTrackBar8.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroTrackBar8.TabIndex = 19;
            this.metroTrackBar8.Tag = "gaussian";
            this.metroTrackBar8.Text = "metroTrackBar8";
            this.metroTrackBar8.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTrackBar8.Value = 25;
            this.metroTrackBar8.ValueChanged += new System.EventHandler(this.Filters_Tbar_ValueChanged);
            // 
            // gaussian_value
            // 
            this.gaussian_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.gaussian_value.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.gaussian_value.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.gaussian_value.Location = new System.Drawing.Point(176, 279);
            this.gaussian_value.Name = "gaussian_value";
            this.gaussian_value.Size = new System.Drawing.Size(50, 23);
            this.gaussian_value.Style = MetroFramework.MetroColorStyle.Teal;
            this.gaussian_value.TabIndex = 18;
            this.gaussian_value.Text = "25";
            this.gaussian_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gaussian_value.Theme = MetroFramework.MetroThemeStyle.Light;
            this.gaussian_value.UseStyleColors = true;
            // 
            // gausiian_blur_name
            // 
            this.gausiian_blur_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.gausiian_blur_name.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.gausiian_blur_name.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.gausiian_blur_name.Location = new System.Drawing.Point(37, 247);
            this.gausiian_blur_name.Name = "gausiian_blur_name";
            this.gausiian_blur_name.Size = new System.Drawing.Size(162, 30);
            this.gausiian_blur_name.Style = MetroFramework.MetroColorStyle.Teal;
            this.gausiian_blur_name.TabIndex = 17;
            this.gausiian_blur_name.Text = "Gaussian blur";
            this.gausiian_blur_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gausiian_blur_name.Theme = MetroFramework.MetroThemeStyle.Light;
            this.gausiian_blur_name.UseStyleColors = true;
            // 
            // emboss
            // 
            this.emboss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.emboss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.emboss.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.emboss.Location = new System.Drawing.Point(37, 179);
            this.emboss.Name = "emboss";
            this.emboss.Size = new System.Drawing.Size(109, 23);
            this.emboss.Style = MetroFramework.MetroColorStyle.Teal;
            this.emboss.TabIndex = 16;
            this.emboss.Tag = "emboss";
            this.emboss.Text = "emboss";
            this.emboss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.emboss.Theme = MetroFramework.MetroThemeStyle.Light;
            this.emboss.UseSelectable = true;
            this.emboss.Click += new System.EventHandler(this.Filters_link_Click);
            // 
            // sharpness
            // 
            this.sharpness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sharpness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.sharpness.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.sharpness.Location = new System.Drawing.Point(37, 150);
            this.sharpness.Name = "sharpness";
            this.sharpness.Size = new System.Drawing.Size(109, 23);
            this.sharpness.Style = MetroFramework.MetroColorStyle.Teal;
            this.sharpness.TabIndex = 15;
            this.sharpness.Tag = "sharpness";
            this.sharpness.Text = "sharpness";
            this.sharpness.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sharpness.Theme = MetroFramework.MetroThemeStyle.Light;
            this.sharpness.UseSelectable = true;
            this.sharpness.Click += new System.EventHandler(this.Filters_link_Click);
            // 
            // sobel
            // 
            this.sobel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sobel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.sobel.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.sobel.Location = new System.Drawing.Point(37, 121);
            this.sobel.Name = "sobel";
            this.sobel.Size = new System.Drawing.Size(109, 23);
            this.sobel.Style = MetroFramework.MetroColorStyle.Teal;
            this.sobel.TabIndex = 14;
            this.sobel.Tag = "sobel";
            this.sobel.Text = "sobel";
            this.sobel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sobel.Theme = MetroFramework.MetroThemeStyle.Light;
            this.sobel.UseSelectable = true;
            this.sobel.Click += new System.EventHandler(this.Filters_link_Click);
            // 
            // blur
            // 
            this.blur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.blur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.blur.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.blur.Location = new System.Drawing.Point(37, 92);
            this.blur.Name = "blur";
            this.blur.Size = new System.Drawing.Size(109, 23);
            this.blur.Style = MetroFramework.MetroColorStyle.Teal;
            this.blur.TabIndex = 13;
            this.blur.Tag = "blur";
            this.blur.Text = "blur";
            this.blur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.blur.Theme = MetroFramework.MetroThemeStyle.Light;
            this.blur.UseSelectable = true;
            this.blur.Click += new System.EventHandler(this.Filters_link_Click);
            // 
            // laplassian
            // 
            this.laplassian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.laplassian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.laplassian.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.laplassian.Location = new System.Drawing.Point(37, 63);
            this.laplassian.Name = "laplassian";
            this.laplassian.Size = new System.Drawing.Size(109, 23);
            this.laplassian.Style = MetroFramework.MetroColorStyle.Teal;
            this.laplassian.TabIndex = 12;
            this.laplassian.Tag = "laplassian";
            this.laplassian.Text = "laplassian";
            this.laplassian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.laplassian.Theme = MetroFramework.MetroThemeStyle.Light;
            this.laplassian.UseSelectable = true;
            this.laplassian.Click += new System.EventHandler(this.Filters_link_Click);
            // 
            // convolution_filters_name
            // 
            this.convolution_filters_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.convolution_filters_name.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.convolution_filters_name.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.convolution_filters_name.Location = new System.Drawing.Point(37, 30);
            this.convolution_filters_name.Name = "convolution_filters_name";
            this.convolution_filters_name.Size = new System.Drawing.Size(162, 30);
            this.convolution_filters_name.Style = MetroFramework.MetroColorStyle.Black;
            this.convolution_filters_name.TabIndex = 5;
            this.convolution_filters_name.Text = "convolution filters";
            this.convolution_filters_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.convolution_filters_name.Theme = MetroFramework.MetroThemeStyle.Light;
            this.convolution_filters_name.UseStyleColors = true;
            // 
            // other_panel
            // 
            this.other_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.other_panel.Controls.Add(this.hdga);
            this.other_panel.Controls.Add(this.new_B);
            this.other_panel.Controls.Add(this.new_G);
            this.other_panel.Controls.Add(this.new_R);
            this.other_panel.Controls.Add(this.old_B);
            this.other_panel.Controls.Add(this.old_G);
            this.other_panel.Controls.Add(this.old_R);
            this.other_panel.Controls.Add(this.metroLabel4);
            this.other_panel.Controls.Add(this.metroLabel3);
            this.other_panel.Controls.Add(this.other_replace_color);
            this.other_panel.Controls.Add(this.upper_name);
            this.other_panel.Controls.Add(this.upper_tbar);
            this.other_panel.Controls.Add(this.upper_value);
            this.other_panel.Controls.Add(this.lower_name);
            this.other_panel.Controls.Add(this.lower_tbar);
            this.other_panel.Controls.Add(this.lower_value);
            this.other_panel.Controls.Add(this.other_trace);
            this.other_panel.Controls.Add(this.other_non_max);
            this.other_panel.Controls.Add(this.other_double_treshold);
            this.other_panel.Controls.Add(this.other_sobel);
            this.other_panel.HorizontalScrollbarBarColor = false;
            this.other_panel.HorizontalScrollbarHighlightOnWheel = false;
            this.other_panel.HorizontalScrollbarSize = 10;
            this.other_panel.Location = new System.Drawing.Point(4, 49);
            this.other_panel.Name = "other_panel";
            this.other_panel.Size = new System.Drawing.Size(240, 707);
            this.other_panel.Style = MetroFramework.MetroColorStyle.Teal;
            this.other_panel.TabIndex = 2;
            this.other_panel.Text = "Other";
            this.other_panel.Theme = MetroFramework.MetroThemeStyle.Light;
            this.other_panel.VerticalScrollbar = true;
            this.other_panel.VerticalScrollbarBarColor = true;
            this.other_panel.VerticalScrollbarHighlightOnWheel = true;
            this.other_panel.VerticalScrollbarSize = 8;
            // 
            // hdga
            // 
            this.hdga.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.hdga.Location = new System.Drawing.Point(37, 487);
            this.hdga.Name = "hdga";
            this.hdga.Size = new System.Drawing.Size(171, 23);
            this.hdga.Style = MetroFramework.MetroColorStyle.Silver;
            this.hdga.TabIndex = 31;
            this.hdga.Tag = "hvga";
            this.hdga.Text = "HereWeGoAgain";
            this.hdga.Theme = MetroFramework.MetroThemeStyle.Light;
            this.hdga.UseSelectable = true;
            this.hdga.UseStyleColors = true;
            this.hdga.Click += new System.EventHandler(this.other_any_btn_Click);
            // 
            // new_B
            // 
            // 
            // 
            // 
            this.new_B.CustomButton.Image = null;
            this.new_B.CustomButton.Location = new System.Drawing.Point(15, 1);
            this.new_B.CustomButton.Name = "";
            this.new_B.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.new_B.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.new_B.CustomButton.TabIndex = 1;
            this.new_B.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.new_B.CustomButton.UseSelectable = true;
            this.new_B.CustomButton.Visible = false;
            this.new_B.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.new_B.Lines = new string[] {
        "0"};
            this.new_B.Location = new System.Drawing.Point(171, 398);
            this.new_B.MaxLength = 3;
            this.new_B.Name = "new_B";
            this.new_B.PasswordChar = '\0';
            this.new_B.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.new_B.SelectedText = "";
            this.new_B.SelectionLength = 0;
            this.new_B.SelectionStart = 0;
            this.new_B.ShortcutsEnabled = true;
            this.new_B.Size = new System.Drawing.Size(37, 23);
            this.new_B.TabIndex = 28;
            this.new_B.Text = "0";
            this.new_B.UseSelectable = true;
            this.new_B.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.new_B.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.new_B.TextChanged += new System.EventHandler(this.any_channel_TextChanged);
            // 
            // new_G
            // 
            // 
            // 
            // 
            this.new_G.CustomButton.Image = null;
            this.new_G.CustomButton.Location = new System.Drawing.Point(15, 1);
            this.new_G.CustomButton.Name = "";
            this.new_G.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.new_G.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.new_G.CustomButton.TabIndex = 1;
            this.new_G.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.new_G.CustomButton.UseSelectable = true;
            this.new_G.CustomButton.Visible = false;
            this.new_G.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.new_G.Lines = new string[] {
        "0"};
            this.new_G.Location = new System.Drawing.Point(128, 398);
            this.new_G.MaxLength = 3;
            this.new_G.Name = "new_G";
            this.new_G.PasswordChar = '\0';
            this.new_G.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.new_G.SelectedText = "";
            this.new_G.SelectionLength = 0;
            this.new_G.SelectionStart = 0;
            this.new_G.ShortcutsEnabled = true;
            this.new_G.Size = new System.Drawing.Size(37, 23);
            this.new_G.TabIndex = 27;
            this.new_G.Text = "0";
            this.new_G.UseSelectable = true;
            this.new_G.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.new_G.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.new_G.TextChanged += new System.EventHandler(this.any_channel_TextChanged);
            // 
            // new_R
            // 
            // 
            // 
            // 
            this.new_R.CustomButton.Image = null;
            this.new_R.CustomButton.Location = new System.Drawing.Point(15, 1);
            this.new_R.CustomButton.Name = "";
            this.new_R.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.new_R.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.new_R.CustomButton.TabIndex = 1;
            this.new_R.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.new_R.CustomButton.UseSelectable = true;
            this.new_R.CustomButton.Visible = false;
            this.new_R.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.new_R.Lines = new string[] {
        "0"};
            this.new_R.Location = new System.Drawing.Point(85, 398);
            this.new_R.MaxLength = 3;
            this.new_R.Name = "new_R";
            this.new_R.PasswordChar = '\0';
            this.new_R.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.new_R.SelectedText = "";
            this.new_R.SelectionLength = 0;
            this.new_R.SelectionStart = 0;
            this.new_R.ShortcutsEnabled = true;
            this.new_R.Size = new System.Drawing.Size(37, 23);
            this.new_R.TabIndex = 26;
            this.new_R.Text = "0";
            this.new_R.UseSelectable = true;
            this.new_R.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.new_R.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.new_R.TextChanged += new System.EventHandler(this.any_channel_TextChanged);
            // 
            // old_B
            // 
            // 
            // 
            // 
            this.old_B.CustomButton.Image = null;
            this.old_B.CustomButton.Location = new System.Drawing.Point(15, 1);
            this.old_B.CustomButton.Name = "";
            this.old_B.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.old_B.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.old_B.CustomButton.TabIndex = 1;
            this.old_B.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.old_B.CustomButton.UseSelectable = true;
            this.old_B.CustomButton.Visible = false;
            this.old_B.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.old_B.Lines = new string[] {
        "0"};
            this.old_B.Location = new System.Drawing.Point(171, 372);
            this.old_B.MaxLength = 3;
            this.old_B.Name = "old_B";
            this.old_B.PasswordChar = '\0';
            this.old_B.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.old_B.SelectedText = "";
            this.old_B.SelectionLength = 0;
            this.old_B.SelectionStart = 0;
            this.old_B.ShortcutsEnabled = true;
            this.old_B.Size = new System.Drawing.Size(37, 23);
            this.old_B.TabIndex = 25;
            this.old_B.Text = "0";
            this.old_B.UseSelectable = true;
            this.old_B.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.old_B.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.old_B.TextChanged += new System.EventHandler(this.any_channel_TextChanged);
            // 
            // old_G
            // 
            // 
            // 
            // 
            this.old_G.CustomButton.Image = null;
            this.old_G.CustomButton.Location = new System.Drawing.Point(15, 1);
            this.old_G.CustomButton.Name = "";
            this.old_G.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.old_G.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.old_G.CustomButton.TabIndex = 1;
            this.old_G.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.old_G.CustomButton.UseSelectable = true;
            this.old_G.CustomButton.Visible = false;
            this.old_G.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.old_G.Lines = new string[] {
        "0"};
            this.old_G.Location = new System.Drawing.Point(128, 372);
            this.old_G.MaxLength = 3;
            this.old_G.Name = "old_G";
            this.old_G.PasswordChar = '\0';
            this.old_G.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.old_G.SelectedText = "";
            this.old_G.SelectionLength = 0;
            this.old_G.SelectionStart = 0;
            this.old_G.ShortcutsEnabled = true;
            this.old_G.Size = new System.Drawing.Size(37, 23);
            this.old_G.TabIndex = 24;
            this.old_G.Text = "0";
            this.old_G.UseSelectable = true;
            this.old_G.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.old_G.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.old_G.TextChanged += new System.EventHandler(this.any_channel_TextChanged);
            // 
            // old_R
            // 
            // 
            // 
            // 
            this.old_R.CustomButton.Image = null;
            this.old_R.CustomButton.Location = new System.Drawing.Point(15, 1);
            this.old_R.CustomButton.Name = "";
            this.old_R.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.old_R.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.old_R.CustomButton.TabIndex = 1;
            this.old_R.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.old_R.CustomButton.UseSelectable = true;
            this.old_R.CustomButton.Visible = false;
            this.old_R.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.old_R.Lines = new string[] {
        "0"};
            this.old_R.Location = new System.Drawing.Point(85, 372);
            this.old_R.MaxLength = 3;
            this.old_R.Name = "old_R";
            this.old_R.PasswordChar = '\0';
            this.old_R.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.old_R.SelectedText = "";
            this.old_R.SelectionLength = 0;
            this.old_R.SelectionStart = 0;
            this.old_R.ShortcutsEnabled = true;
            this.old_R.Size = new System.Drawing.Size(37, 23);
            this.old_R.TabIndex = 23;
            this.old_R.Text = "0";
            this.old_R.UseSelectable = true;
            this.old_R.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.old_R.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.old_R.TextChanged += new System.EventHandler(this.any_channel_TextChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(30, 395);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(49, 26);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel4.TabIndex = 22;
            this.metroLabel4.Text = "new";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel4.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(30, 369);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(49, 26);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel3.TabIndex = 21;
            this.metroLabel3.Text = "old";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel3.UseStyleColors = true;
            // 
            // other_replace_color
            // 
            this.other_replace_color.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.other_replace_color.Location = new System.Drawing.Point(85, 343);
            this.other_replace_color.Name = "other_replace_color";
            this.other_replace_color.Size = new System.Drawing.Size(123, 23);
            this.other_replace_color.Style = MetroFramework.MetroColorStyle.Silver;
            this.other_replace_color.TabIndex = 20;
            this.other_replace_color.Tag = "replace color";
            this.other_replace_color.Text = "replace color";
            this.other_replace_color.Theme = MetroFramework.MetroThemeStyle.Light;
            this.other_replace_color.UseSelectable = true;
            this.other_replace_color.UseStyleColors = true;
            this.other_replace_color.Click += new System.EventHandler(this.Other_replace_color_Click);
            // 
            // upper_name
            // 
            this.upper_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.upper_name.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.upper_name.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.upper_name.Location = new System.Drawing.Point(21, 149);
            this.upper_name.Name = "upper_name";
            this.upper_name.Size = new System.Drawing.Size(100, 30);
            this.upper_name.Style = MetroFramework.MetroColorStyle.Teal;
            this.upper_name.TabIndex = 19;
            this.upper_name.Text = "upper";
            this.upper_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.upper_name.Theme = MetroFramework.MetroThemeStyle.Light;
            this.upper_name.UseStyleColors = true;
            // 
            // upper_tbar
            // 
            this.upper_tbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.upper_tbar.Location = new System.Drawing.Point(21, 184);
            this.upper_tbar.Maximum = 250;
            this.upper_tbar.Minimum = 5;
            this.upper_tbar.Name = "upper_tbar";
            this.upper_tbar.Size = new System.Drawing.Size(200, 23);
            this.upper_tbar.Style = MetroFramework.MetroColorStyle.Teal;
            this.upper_tbar.TabIndex = 18;
            this.upper_tbar.Tag = "upper";
            this.upper_tbar.Text = "metroTrackBar4";
            this.upper_tbar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.upper_tbar.Value = 45;
            this.upper_tbar.ValueChanged += new System.EventHandler(this.Other_tbar_ValueChanged);
            // 
            // upper_value
            // 
            this.upper_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.upper_value.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.upper_value.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.upper_value.Location = new System.Drawing.Point(149, 156);
            this.upper_value.Name = "upper_value";
            this.upper_value.Size = new System.Drawing.Size(70, 23);
            this.upper_value.Style = MetroFramework.MetroColorStyle.Teal;
            this.upper_value.TabIndex = 17;
            this.upper_value.Text = "45";
            this.upper_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.upper_value.Theme = MetroFramework.MetroThemeStyle.Light;
            this.upper_value.UseStyleColors = true;
            // 
            // lower_name
            // 
            this.lower_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.lower_name.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lower_name.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lower_name.Location = new System.Drawing.Point(21, 211);
            this.lower_name.Name = "lower_name";
            this.lower_name.Size = new System.Drawing.Size(100, 30);
            this.lower_name.Style = MetroFramework.MetroColorStyle.Teal;
            this.lower_name.TabIndex = 16;
            this.lower_name.Text = "lower";
            this.lower_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lower_name.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lower_name.UseStyleColors = true;
            // 
            // lower_tbar
            // 
            this.lower_tbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.lower_tbar.Location = new System.Drawing.Point(21, 246);
            this.lower_tbar.Maximum = 250;
            this.lower_tbar.Minimum = 5;
            this.lower_tbar.Name = "lower_tbar";
            this.lower_tbar.Size = new System.Drawing.Size(200, 23);
            this.lower_tbar.Style = MetroFramework.MetroColorStyle.Teal;
            this.lower_tbar.TabIndex = 15;
            this.lower_tbar.Tag = "lower";
            this.lower_tbar.Text = "metroTrackBar4";
            this.lower_tbar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lower_tbar.Value = 17;
            this.lower_tbar.ValueChanged += new System.EventHandler(this.Other_tbar_ValueChanged);
            // 
            // lower_value
            // 
            this.lower_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.lower_value.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lower_value.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lower_value.Location = new System.Drawing.Point(149, 218);
            this.lower_value.Name = "lower_value";
            this.lower_value.Size = new System.Drawing.Size(70, 23);
            this.lower_value.Style = MetroFramework.MetroColorStyle.Teal;
            this.lower_value.TabIndex = 14;
            this.lower_value.Text = "17";
            this.lower_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lower_value.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lower_value.UseStyleColors = true;
            // 
            // other_trace
            // 
            this.other_trace.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.other_trace.Location = new System.Drawing.Point(31, 275);
            this.other_trace.Name = "other_trace";
            this.other_trace.Size = new System.Drawing.Size(171, 23);
            this.other_trace.Style = MetroFramework.MetroColorStyle.Silver;
            this.other_trace.TabIndex = 5;
            this.other_trace.Tag = "trace";
            this.other_trace.Text = "trace";
            this.other_trace.Theme = MetroFramework.MetroThemeStyle.Light;
            this.other_trace.UseSelectable = true;
            this.other_trace.UseStyleColors = true;
            this.other_trace.Click += new System.EventHandler(this.other_any_btn_Click);
            // 
            // other_non_max
            // 
            this.other_non_max.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.other_non_max.Location = new System.Drawing.Point(31, 94);
            this.other_non_max.Name = "other_non_max";
            this.other_non_max.Size = new System.Drawing.Size(171, 23);
            this.other_non_max.Style = MetroFramework.MetroColorStyle.Silver;
            this.other_non_max.TabIndex = 4;
            this.other_non_max.Tag = "non max";
            this.other_non_max.Text = "non max";
            this.other_non_max.Theme = MetroFramework.MetroThemeStyle.Light;
            this.other_non_max.UseSelectable = true;
            this.other_non_max.UseStyleColors = true;
            this.other_non_max.Click += new System.EventHandler(this.other_any_btn_Click);
            // 
            // other_double_treshold
            // 
            this.other_double_treshold.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.other_double_treshold.Location = new System.Drawing.Point(31, 123);
            this.other_double_treshold.Name = "other_double_treshold";
            this.other_double_treshold.Size = new System.Drawing.Size(171, 23);
            this.other_double_treshold.Style = MetroFramework.MetroColorStyle.Silver;
            this.other_double_treshold.TabIndex = 3;
            this.other_double_treshold.Tag = "double treshold";
            this.other_double_treshold.Text = "double treshold";
            this.other_double_treshold.Theme = MetroFramework.MetroThemeStyle.Light;
            this.other_double_treshold.UseSelectable = true;
            this.other_double_treshold.UseStyleColors = true;
            this.other_double_treshold.Click += new System.EventHandler(this.other_any_btn_Click);
            // 
            // other_sobel
            // 
            this.other_sobel.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.other_sobel.Location = new System.Drawing.Point(31, 65);
            this.other_sobel.Name = "other_sobel";
            this.other_sobel.Size = new System.Drawing.Size(171, 23);
            this.other_sobel.Style = MetroFramework.MetroColorStyle.Silver;
            this.other_sobel.TabIndex = 2;
            this.other_sobel.Tag = "sobel";
            this.other_sobel.Text = "sobel";
            this.other_sobel.Theme = MetroFramework.MetroThemeStyle.Light;
            this.other_sobel.UseSelectable = true;
            this.other_sobel.UseStyleColors = true;
            this.other_sobel.Click += new System.EventHandler(this.other_any_btn_Click);
            // 
            // load
            // 
            this.load.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.load.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.load.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.load.Location = new System.Drawing.Point(0, 16);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(65, 32);
            this.load.Style = MetroFramework.MetroColorStyle.Teal;
            this.load.TabIndex = 4;
            this.load.Text = "Load";
            this.load.Theme = MetroFramework.MetroThemeStyle.Light;
            this.load.UseSelectable = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.save.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.save.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.save.Location = new System.Drawing.Point(71, 16);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(65, 32);
            this.save.Style = MetroFramework.MetroColorStyle.Teal;
            this.save.TabIndex = 5;
            this.save.Text = "Save";
            this.save.Theme = MetroFramework.MetroThemeStyle.Light;
            this.save.UseSelectable = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // zoom_value
            // 
            this.zoom_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.zoom_value.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.zoom_value.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.zoom_value.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.zoom_value.Location = new System.Drawing.Point(178, 17);
            this.zoom_value.MaximumSize = new System.Drawing.Size(61, 32);
            this.zoom_value.MinimumSize = new System.Drawing.Size(61, 32);
            this.zoom_value.Name = "zoom_value";
            this.zoom_value.Size = new System.Drawing.Size(61, 32);
            this.zoom_value.Style = MetroFramework.MetroColorStyle.Teal;
            this.zoom_value.TabIndex = 8;
            this.zoom_value.Text = "100%";
            this.zoom_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.zoom_value.Theme = MetroFramework.MetroThemeStyle.Light;
            this.zoom_value.UseStyleColors = true;
            // 
            // show_original
            // 
            this.show_original.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.show_original.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.show_original.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.show_original.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.show_original.Location = new System.Drawing.Point(681, 16);
            this.show_original.MaximumSize = new System.Drawing.Size(75, 32);
            this.show_original.MinimumSize = new System.Drawing.Size(75, 32);
            this.show_original.Name = "show_original";
            this.show_original.Size = new System.Drawing.Size(75, 32);
            this.show_original.Style = MetroFramework.MetroColorStyle.Teal;
            this.show_original.TabIndex = 10;
            this.show_original.Text = "original";
            this.show_original.Theme = MetroFramework.MetroThemeStyle.Light;
            this.show_original.UseSelectable = true;
            this.show_original.MouseDown += new System.Windows.Forms.MouseEventHandler(this.show_original_MouseDown);
            this.show_original.MouseUp += new System.Windows.Forms.MouseEventHandler(this.show_original_MouseUp);
            // 
            // show_saved
            // 
            this.show_saved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.show_saved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.show_saved.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.show_saved.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.show_saved.Location = new System.Drawing.Point(600, 16);
            this.show_saved.MaximumSize = new System.Drawing.Size(75, 32);
            this.show_saved.MinimumSize = new System.Drawing.Size(75, 32);
            this.show_saved.Name = "show_saved";
            this.show_saved.Size = new System.Drawing.Size(75, 32);
            this.show_saved.Style = MetroFramework.MetroColorStyle.Teal;
            this.show_saved.TabIndex = 11;
            this.show_saved.Text = "saved";
            this.show_saved.Theme = MetroFramework.MetroThemeStyle.Light;
            this.show_saved.UseSelectable = true;
            this.show_saved.MouseDown += new System.Windows.Forms.MouseEventHandler(this.show_saved_MouseDown);
            this.show_saved.MouseUp += new System.Windows.Forms.MouseEventHandler(this.show_saved_MouseUp);
            // 
            // normal_size
            // 
            this.normal_size.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.normal_size.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.normal_size.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.normal_size.Location = new System.Drawing.Point(245, 17);
            this.normal_size.MaximumSize = new System.Drawing.Size(44, 32);
            this.normal_size.MinimumSize = new System.Drawing.Size(44, 32);
            this.normal_size.Name = "normal_size";
            this.normal_size.Size = new System.Drawing.Size(44, 32);
            this.normal_size.Style = MetroFramework.MetroColorStyle.Teal;
            this.normal_size.TabIndex = 12;
            this.normal_size.Text = "1:1";
            this.normal_size.Theme = MetroFramework.MetroThemeStyle.Light;
            this.normal_size.UseSelectable = true;
            this.normal_size.Click += new System.EventHandler(this.normal_size_Click);
            // 
            // fill_size
            // 
            this.fill_size.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.fill_size.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.fill_size.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.fill_size.Location = new System.Drawing.Point(295, 17);
            this.fill_size.MaximumSize = new System.Drawing.Size(44, 32);
            this.fill_size.MinimumSize = new System.Drawing.Size(44, 32);
            this.fill_size.Name = "fill_size";
            this.fill_size.Size = new System.Drawing.Size(44, 32);
            this.fill_size.Style = MetroFramework.MetroColorStyle.Teal;
            this.fill_size.TabIndex = 13;
            this.fill_size.Text = "fill";
            this.fill_size.Theme = MetroFramework.MetroThemeStyle.Light;
            this.fill_size.UseSelectable = true;
            this.fill_size.Click += new System.EventHandler(this.fill_size_Click);
            // 
            // progress_bar
            // 
            this.progress_bar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progress_bar.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.progress_bar.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.progress_bar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progress_bar.Location = new System.Drawing.Point(453, 820);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(120, 28);
            this.progress_bar.Style = MetroFramework.MetroColorStyle.Teal;
            this.progress_bar.TabIndex = 14;
            this.progress_bar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.progress_bar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.progress_bar.UseStyleColors = true;
            // 
            // ok
            // 
            this.ok.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.ok.Alpha = 180;
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.AutoSize = true;
            this.ok.BackColor = System.Drawing.Color.White;
            this.ok.ClickEffect = true;
            this.ok.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.ok.Location = new System.Drawing.Point(875, 14);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(105, 40);
            this.ok.TabIndex = 3;
            this.ok.Text = "Ok";
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // customPbox
            // 
            this.customPbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.customPbox.Cursor = System.Windows.Forms.Cursors.Default;
            this.customPbox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            this.customPbox.InterpolationModeZoomOut = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            this.customPbox.Location = new System.Drawing.Point(10, 60);
            this.customPbox.Name = "customPbox";
            this.customPbox.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.customPbox.Size = new System.Drawing.Size(970, 760);
            this.customPbox.TabIndex = 1;
            this.customPbox.VisibleCenter = ((System.Drawing.PointF)(resources.GetObject("customPbox.VisibleCenter")));
            this.customPbox.ZoomValueChanged += new System.EventHandler(this.customPbox_ZoomValueChanged);
            // 
            // cancel
            // 
            this.cancel.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.cancel.Alpha = 180;
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.AutoSize = true;
            this.cancel.BackColor = System.Drawing.Color.White;
            this.cancel.ClickEffect = true;
            this.cancel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.cancel.Location = new System.Drawing.Point(770, 14);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(105, 40);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel ";
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 850);
            this.Controls.Add(this.fill_size);
            this.Controls.Add(this.normal_size);
            this.Controls.Add(this.show_saved);
            this.Controls.Add(this.show_original);
            this.Controls.Add(this.zoom_value);
            this.Controls.Add(this.save);
            this.Controls.Add(this.load);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.customPbox);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.TabPanel);
            this.Controls.Add(this.progress_bar);
            this.MinimumSize = new System.Drawing.Size(1050, 750);
            this.Name = "Interface";
            this.Padding = new System.Windows.Forms.Padding(10, 60, 10, 30);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            ((System.ComponentModel.ISupportInitialize)(this.mnmMain)).EndInit();
            this.TabPanel.ResumeLayout(false);
            this.effects_panel.ResumeLayout(false);
            this.effects_panel.PerformLayout();
            this.filters_panel.ResumeLayout(false);
            this.other_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager mnmMain;
        private MetroFramework.Controls.MetroTabPage effects_panel;
        private MetroFramework.Controls.MetroTabPage filters_panel;
        private MetroFramework.Controls.MetroTabPage other_panel;
        private CustomPbox customPbox;
        private CustomButton cancel;
        private CustomButton ok;
        private MetroFramework.Controls.MetroLink load;
        private MetroFramework.Controls.MetroLink save;
        private MetroFramework.Controls.MetroLabel zoom_value;
        private MetroFramework.Controls.MetroLink show_original;
        private MetroFramework.Controls.MetroLink show_saved;
        private MetroFramework.Controls.MetroLink normal_size;
        private MetroFramework.Controls.MetroLink fill_size;
        private MetroFramework.Controls.MetroLabel contrast_name;
        private MetroFramework.Controls.MetroTrackBar contrast_Tbar;
        private MetroFramework.Controls.MetroLabel contrast_value;
        private MetroFramework.Controls.MetroLabel brightness_name;
        private MetroFramework.Controls.MetroTrackBar brightness_Tbar;
        private MetroFramework.Controls.MetroLabel brightness_value;
        private MetroFramework.Controls.MetroLabel gamma_name;
        private MetroFramework.Controls.MetroTrackBar gamma_Tbar;
        private MetroFramework.Controls.MetroLabel gamma_value;
        private MetroFramework.Controls.MetroTrackBar B_Tbar;
        private MetroFramework.Controls.MetroLabel B_value;
        private MetroFramework.Controls.MetroTrackBar G_Tbar;
        private MetroFramework.Controls.MetroLabel G_value;
        private MetroFramework.Controls.MetroTrackBar R_Tbar;
        private MetroFramework.Controls.MetroLabel R_value;
        private MetroFramework.Controls.MetroLabel treshold_name;
        private MetroFramework.Controls.MetroTrackBar treshold_Tbar;
        private MetroFramework.Controls.MetroLabel treshold_value;
        private MetroFramework.Controls.MetroCheckBox B_state;
        private MetroFramework.Controls.MetroCheckBox G_state;
        private MetroFramework.Controls.MetroCheckBox R_state;
        private MetroFramework.Controls.MetroLink emboss;
        private MetroFramework.Controls.MetroLink sharpness;
        private MetroFramework.Controls.MetroLink sobel;
        private MetroFramework.Controls.MetroLink blur;
        private MetroFramework.Controls.MetroLink laplassian;
        private MetroFramework.Controls.MetroLabel convolution_filters_name;
        private MetroFramework.Controls.MetroLink gaussian2d;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar8;
        private MetroFramework.Controls.MetroLabel gaussian_value;
        private MetroFramework.Controls.MetroLabel gausiian_blur_name;
        private MetroFramework.Controls.MetroLink median;
        private MetroFramework.Controls.MetroLabel median_value;
        private MetroFramework.Controls.MetroTrackBar median_Tbar;
        private MetroFramework.Controls.MetroRadioButton median_normal;
        private MetroFramework.Controls.MetroLabel median_filter_name;
        private MetroFramework.Controls.MetroRadioButton median_recursive;
        private MetroFramework.Controls.MetroLink autolevels;
        private MetroFramework.Controls.MetroLink inverse_colors;
        private MetroFramework.Controls.MetroLink discolor;
        private MetroFramework.Controls.MetroLink canny;
        private MetroFramework.Controls.MetroLabel progress_bar;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLink light_alignment;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLink other_double_treshold;
        private MetroFramework.Controls.MetroLink other_trace;
        private MetroFramework.Controls.MetroLink other_non_max;
        private MetroFramework.Controls.MetroLink gaussian1d;
        public MetroFramework.Controls.MetroTabControl TabPanel;
        private MetroFramework.Controls.MetroLabel upper_name;
        private MetroFramework.Controls.MetroTrackBar upper_tbar;
        private MetroFramework.Controls.MetroLabel upper_value;
        private MetroFramework.Controls.MetroLabel lower_name;
        private MetroFramework.Controls.MetroTrackBar lower_tbar;
        private MetroFramework.Controls.MetroLabel lower_value;
        private MetroFramework.Controls.MetroLink filters_ScreenShot;
        private MetroFramework.Controls.MetroTextBox new_B;
        private MetroFramework.Controls.MetroTextBox new_G;
        private MetroFramework.Controls.MetroTextBox new_R;
        private MetroFramework.Controls.MetroTextBox old_B;
        private MetroFramework.Controls.MetroTextBox old_G;
        private MetroFramework.Controls.MetroTextBox old_R;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLink other_replace_color;
        private MetroFramework.Controls.MetroLink other_sobel;
        private MetroFramework.Controls.MetroLink hdga;
    }
}

