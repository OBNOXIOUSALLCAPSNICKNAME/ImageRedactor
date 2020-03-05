using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для BndBoxes.xaml
    /// </summary>
    public partial class Images : Window
    {

        public class OverallViewData
        {
            private string _Title;
            public string Title
            {
                get { return this._Title; }
                set { this._Title = value; }
            }

            private BitmapImage _ImageData;
            public BitmapImage ImageData
            {
                get { return this._ImageData; }
                set { this._ImageData = value; }
            }

        }

        public int OverallViewRows { get; set; } = 6;
        public int OverallViewColumns { get; set; } = 6;

        public Images()
        {
            InitializeComponent();

            OverallViewPagination.Visibility = Visibility.Hidden;
            OverallView.Visibility = Visibility.Hidden;

            CloseViewPaginaton.Visibility = Visibility.Visible;
            CloseView.Visibility = Visibility.Visible;

            History_UndoRedo.Height = new GridLength(0, GridUnitType.Pixel);

            List<OverallViewData> data = new List<OverallViewData>();
            for (int i = 0; i < OverallViewRows * OverallViewColumns; i++)
                data.Add(new OverallViewData { Title = "" });

            this.OverallView.ItemsSource = data;

            ViewSettingsPopup.CustomPopupPlacementCallback =
                new CustomPopupPlacementCallback(placePopup);
        }

        public CustomPopupPlacement[] placePopup(Size popupSize,
                                           Size targetSize,
                                           Point offset)
        {
            CustomPopupPlacement placement1 =
               new CustomPopupPlacement(new Point(-targetSize.Width / 2 + 10, targetSize.Height + 5), PopupPrimaryAxis.Vertical);

            CustomPopupPlacement[] ttplaces =
                    new CustomPopupPlacement[] { placement1 };

            return ttplaces;
        }

        private void ViewSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            ViewSettingsPopup.PlacementTarget = ViewSettingsButton;
            ViewSettingsPopup.IsOpen = true;
        }
        private void ViewSettingsPopup_Opened(object sender, EventArgs e)
        {
            ViewSettingsButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xE4, 0xE6, 0xF7));
        }
        private void ViewSettingsPopup_Closed(object sender, EventArgs e)
        {
            ViewSettingsButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            try
            {
                DragMove();
            }
            catch (System.Exception)
            {
                //throw;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xA3, 0xB4, 0xCB));
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x25, 0x40, 0xBE));
        }

        private void NavigationCloseButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationCloseButton.Visibility = Visibility.Hidden;
            NavigationOpenButton.Visibility = Visibility.Visible;
        }

        private void NavigationOpenButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationCloseButton.Visibility = Visibility.Visible;
            NavigationOpenButton.Visibility = Visibility.Hidden;
        }

        private void EditorButton_Click(object sender, RoutedEventArgs e)
        {
            EditorButton.Background = EditorButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xDE, 0xEB, 0xFE));
            CustomButton.Background = CustomButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xF6, 0xFA, 0xFB));
            HistoryButton.Background = HistoryButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xF6, 0xFA, 0xFB));
            ToolsButton.Background = ToolsButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xF6, 0xFA, 0xFB));

            EditorGrid.Visibility = Visibility.Visible;
            HistoryGrid.Visibility = Visibility.Collapsed;
        }
        private void CustomButton_Click(object sender, RoutedEventArgs e)
        {
            CustomButton.Background = CustomButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xDE, 0xEB, 0xFE));
            EditorButton.Background = EditorButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xF6, 0xFA, 0xFB));
            HistoryButton.Background = HistoryButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xF6, 0xFA, 0xFB));
            ToolsButton.Background = ToolsButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xF6, 0xFA, 0xFB));
        }
        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            HistoryButton.Background = HistoryButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xDE, 0xEB, 0xFE));
            CustomButton.Background = CustomButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xF6, 0xFA, 0xFB));
            EditorButton.Background = EditorButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xF6, 0xFA, 0xFB));
            ToolsButton.Background = ToolsButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xF6, 0xFA, 0xFB));

            EditorGrid.Visibility = Visibility.Collapsed;
            HistoryGrid.Visibility = Visibility.Visible;
        }
        private void ToolsButton_Click(object sender, RoutedEventArgs e)
        {
            ToolsButton.Background = ToolsButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xDE, 0xEB, 0xFE));
            CustomButton.Background = CustomButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xF6, 0xFA, 0xFB));
            EditorButton.Background = EditorButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xF6, 0xFA, 0xFB));
            HistoryButton.Background = HistoryButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xF6, 0xFA, 0xFB));
        }

        bool SeparatorEnabled = false;
        private void Separation_Switch_Click(object sender, RoutedEventArgs e)
        {
            if (SeparatorEnabled)
            {
                MaterialDesignThemes.Wpf.ButtonAssist.SetCornerRadius(Separation_Switch, new CornerRadius(4));
                Separation_Switch.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x36, 0x5D));
                Separation_Switch.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x36, 0x5D));
                Separation_Switch.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));

                Separation_DoubleWindow.IsEnabled = true;
                Separation_SingleWindow.IsEnabled = true;
                Separation_RotateLeft.IsEnabled = true;
                Separation_RotateRignt.IsEnabled = true;

                HistoryViewer.Visibility = Visibility.Collapsed;
                SeparationViewer.Visibility = Visibility.Visible;

                SeparatorEnabled = !SeparatorEnabled;

                History_UndoRedo.Height = new GridLength(0, GridUnitType.Pixel);
            }
            else
            {
                MaterialDesignThemes.Wpf.ButtonAssist.SetCornerRadius(Separation_Switch, new CornerRadius(20));
                Separation_Switch.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x36, 0x5D));
                Separation_Switch.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xDC, 0xE0, 0xE6));
                Separation_Switch.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));

                Separation_DoubleWindow.IsEnabled = false;
                Separation_SingleWindow.IsEnabled = false;
                Separation_RotateLeft.IsEnabled = false;
                Separation_RotateRignt.IsEnabled = false;

                HistoryViewer.Visibility = Visibility.Visible;
                SeparationViewer.Visibility = Visibility.Collapsed;

                SeparatorEnabled = !SeparatorEnabled;

                History_UndoRedo.Height = new GridLength(40, GridUnitType.Pixel);
            }
        }

        private void OverallViewButton_Click(object sender, RoutedEventArgs e)
        {
            MaterialDesignThemes.Wpf.ButtonAssist.SetCornerRadius(OverallViewButton, new CornerRadius(4));
            OverallViewButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x36, 0x5D));
            OverallViewButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x36, 0x5D));
            OverallViewButton.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));

            MaterialDesignThemes.Wpf.ButtonAssist.SetCornerRadius(CloseViewButton, new CornerRadius(20));
            CloseViewButton.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x36, 0x5D));
            CloseViewButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xDC, 0xE0, 0xE6));
            CloseViewButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));

            OverallViewPagination.Visibility = Visibility.Visible;
            OverallView.Visibility = Visibility.Visible;

            CloseViewPaginaton.Visibility = Visibility.Hidden;
            CloseView.Visibility = Visibility.Hidden;
        }

        private void CloseViewButton_Click(object sender, RoutedEventArgs e)
        {
            MaterialDesignThemes.Wpf.ButtonAssist.SetCornerRadius(CloseViewButton, new CornerRadius(4));
            CloseViewButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x36, 0x5D));
            CloseViewButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x36, 0x5D));
            CloseViewButton.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));

            MaterialDesignThemes.Wpf.ButtonAssist.SetCornerRadius(OverallViewButton, new CornerRadius(20));
            OverallViewButton.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x36, 0x5D));
            OverallViewButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xDC, 0xE0, 0xE6));
            OverallViewButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));

            OverallViewPagination.Visibility = Visibility.Hidden;
            OverallView.Visibility = Visibility.Hidden;

            CloseViewPaginaton.Visibility = Visibility.Visible;
            CloseView.Visibility = Visibility.Visible;
        }

        private void SelectionOpenButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectionMenu.Visibility == Visibility.Hidden)
            {
                MaterialDesignThemes.Wpf.ButtonAssist.SetCornerRadius(SelectionOpenButton, new CornerRadius(4));
                SelectionOpenButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x36, 0x5D));
                SelectionOpenButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x36, 0x5D));
                SelectionOpenButton.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));

                SelectionMenu.Visibility = Visibility.Visible;
            }
            else
            {
                MaterialDesignThemes.Wpf.ButtonAssist.SetCornerRadius(SelectionOpenButton, new CornerRadius(20));
                SelectionOpenButton.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x36, 0x5D));
                SelectionOpenButton.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xDC, 0xE0, 0xE6));
                SelectionOpenButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));

                SelectionMenu.Visibility = Visibility.Hidden;
            }
        }
    }
}
