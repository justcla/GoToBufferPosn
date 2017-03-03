using System;
using System.Windows;
using System.Windows.Input;

namespace GoToBufferPosn
{
    /// <summary>
    /// Interaction logic for StringMatcherthis.xaml
    /// </summary>
    public partial class StringInputWindow : Window
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        public StringInputWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Shows the text input dialog.
        /// </summary>
        /// <exception cref="UserCancelledException">User closed dialog.</exception>
        /// <param name="title">The input dialog title.</param>
        /// <param name="prompt">The user facing prompt text.</param>
        /// <param name="initial">The initial value for the user input text box.</param>
        /// <returns>The user's input.</returns>
        public string ShowDialog(string title, string prompt, string initial)
        {
            this.Owner = Application.Current.MainWindow;
            this.CenterOnMouse();
            this.Title = title;
            this.PromptLabel.Content = prompt;
            this.InputTextBox.Text = initial;
            this.InputTextBox.Focus();
            this.InputTextBox.SelectAll();

            if (this.ShowDialog() ?? false)
            {
                return this.InputTextBox.Text;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Click handler for OK button, sets dialog result and closes the dialog.
        /// </summary>
        /// <param name="sender">The ok button.</param>
        /// <param name="e">The event args.</param>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Centers a window under a mouse. This method requires Application MainWindow to be
        /// visible to operate.
        /// </summary>
        /// <param name="window">The window to center under the mouse.</param>
        private void CenterOnMouse()
        {
            var mousePosInScreenCoords = Application.Current.MainWindow.PointToScreen(Mouse.GetPosition(Application.Current.MainWindow));

            this.Left = Math.Max(Math.Min(mousePosInScreenCoords.X - (this.Width / 2), SystemParameters.VirtualScreenWidth - this.Width), 0);
            this.Top = Math.Max(Math.Min(mousePosInScreenCoords.Y - (this.Height / 2), SystemParameters.VirtualScreenHeight - this.Height), 0);
        }

    }
}
