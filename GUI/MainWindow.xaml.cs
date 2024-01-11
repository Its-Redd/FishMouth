using BIZ;
using Microsoft.Win32;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBIZ biz;
        public MainWindow()
        {
            InitializeComponent();
            biz = new BIZ.ClassBIZ();
            MainGrid.DataContext = biz;
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            biz.MakeEncryptedText();
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            biz.MakeDecryptedText();
        }

        private void EncryptButtonRolling_Click(object sender, RoutedEventArgs e)
        {
            biz.MakeRollingEncryptedText();
        }

        private void DecryptButtonRolling_Click(object sender, RoutedEventArgs e)
        {
            biz.MakeRollingDecryptedText();
        }

        private void EncryptButtonRollingExtra_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DecryptButtonRollingExtra_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadTextEncrypt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == true)
            {
                biz.ReadClearTextFromFile(ofd.FileName);
            }
        }

        private void SaveTextEncrypt_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\";
            sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            sfd.FilterIndex = 1;

            if (sfd.ShowDialog() == true)
            {
                biz.WriteClearTextToFile(sfd.FileName);
            }
        }

        private void LoadTextDecrypt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == true)
            {
                biz.ReadEncryptedTextFromFile(ofd.FileName);
            }
        }

        private void SaveTextDecrypt_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\";
            sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            sfd.FilterIndex = 1;

            if (sfd.ShowDialog() == true)
            {
                biz.WriteEncryptedTextToFile(sfd.FileName);
            }
        }
    }
}
