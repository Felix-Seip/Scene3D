using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Scene3D
{
    /// <summary>
    /// Interaction logic for AboutDialog.xaml
    /// </summary>
    public partial class AboutDialog : Window
    {
        private string tempFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Berufsschule\Scene3D";
        public AboutDialog()
        {
            InitializeComponent();

            //Create the dialog in the middle of the owner dialog, if one exists.
            if (this.Owner != null)
                WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //Else, set the window in the middle of the screen.
            else
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void OnDocumentationClick(object sender, MouseButtonEventArgs e)
        {
            //Write the resource file bytes of the documentation to a temporary folder.
            File.WriteAllBytes(tempFilePath + @"\tempDocumentation.docx", Properties.Resources.Computer_Graphic_3D_Documentation);

            //Create a new Process for the file to be opened with the correct program.
            Process documentationViewProcess = new Process();
            documentationViewProcess.StartInfo.FileName = tempFilePath + @"\tempDocumentation.docx";
            documentationViewProcess.StartInfo.UseShellExecute = true;
            documentationViewProcess.EnableRaisingEvents = true;
            
            //Add an exited event to delete the temporary file once the processes has ended.
            documentationViewProcess.Exited += new EventHandler(DocumentationViewingEnded);
            documentationViewProcess.Start();
        }

        private void DocumentationViewingEnded(object sender, System.EventArgs e)
        {
            //Delete the temporary file.
            File.Delete(tempFilePath + @"\tempDocumentation.docx");
        }

    }
}
