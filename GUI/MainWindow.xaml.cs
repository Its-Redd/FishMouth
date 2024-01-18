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

        /// <summary>
        /// Initializes MainWindow and all of its elements
        /// Initializes ClassBIZ. Sets DataContext to ClassBIZ.
        /// </summary>
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
            biz.MakeExtraEncryptedText();
        }

        private void DecryptButtonRollingExtra_Click(object sender, RoutedEventArgs e)
        {
            biz.MakeExtraDecryptedText();
        }

        /// <summary>
        /// Loads encrypted text from file and puts it into the clearText property of ClassBIZ (or, is supposed to)
        /// </summary>
        /// <param name="sender">Refers to the object that invoked the event that fired the handler</param>
        /// <param name="e">Event argument(s)</param>
        private void LoadTextEncrypt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); // Initialize OpenFileDialog
            ofd.InitialDirectory = @"C:\"; // Sets initial directory to C:\
            ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"; // Sets filter to only show .txt files
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == true)
            {
                biz.ReadClearTextFromFile(ofd.FileName); // Does nothing currently
            }
        }

        /// <summary>
        /// Saves encrypted text to a file (or, is supposed to)
        /// </summary>
        /// <param name="sender">Refers to the object that invoked the event that fired the handler</param>
        /// <param name="e">Event argument(s)</param>
        private void SaveTextEncrypt_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\";
            sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            sfd.FilterIndex = 1;

            if (sfd.ShowDialog() == true)
            {
                biz.WriteClearTextToFile(sfd.FileName); // Does nothing currently
            }
        }

        /// <summary>
        /// Loads decrypted text from file and puts it into the encryptedText property of ClassBIZ (or, is supposed to)
        /// </summary>
        /// <param name="sender">Refers to the object that invoked the event that fired the handler</param>
        /// <param name="e">Event argument(s)</param>
        private void LoadTextDecrypt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == true)
            {
                biz.ReadEncryptedTextFromFile(ofd.FileName); // Does nothing currently
            }
        }

        /// <summary>
        /// Saves decrypted text to a file (or, is supposed to)
        /// </summary>
        /// <param name="sender">Refers to the object that invoked the event that fired the handler</param>
        /// <param name="e">Event argument(s)</param>
        private void SaveTextDecrypt_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\";
            sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            sfd.FilterIndex = 1;

            if (sfd.ShowDialog() == true)
            {
                biz.WriteEncryptedTextToFile(sfd.FileName); // Does nothing currently
            }
        }
    }
}
