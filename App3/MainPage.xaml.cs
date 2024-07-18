using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //reset loop
        private void ResetAllControls(DependencyObject parent)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }

                else if (child is PasswordBox PasswordBox)
                {
                    PasswordBox.Password = string.Empty;
                }

                else if (child is CheckBox checkBox)
                {
                    checkBox.IsChecked = false;
                }
                else if (child is RadioButton radioButton)
                {
                    radioButton.IsChecked = false;
                }

                if (child is Panel || child is ContentControl)
                {
                    ResetAllControls(child);
                }
            }

        }

        private void signup_btn_Click(object sender, RoutedEventArgs e)
        {

            if (user_txt.Text == "")
            {
                var myMsg = new MessageDialog("Please fill in your username", "Incomplete Form!");

                myMsg.Commands.Add(new UICommand("OK") { Id = 0 });
                myMsg.DefaultCommandIndex = 0;

                var res = myMsg.ShowAsync();

            }

            else if (pass_box.Password == "")
            {
                var myMsg = new MessageDialog("Please fill in your Password", "Incomplete Form!");

                myMsg.Commands.Add(new UICommand("OK") { Id = 0 });
                myMsg.DefaultCommandIndex = 0;

                var res = myMsg.ShowAsync();
            }
                        
            else if (!Convert.ToBoolean(male_btn.IsChecked) && !Convert.ToBoolean(female_btn.IsChecked))
            {
                var myMsg = new MessageDialog("Please select your gender", "Incomplete Form!");

                myMsg.Commands.Add(new UICommand("OK") { Id = 0 });
                myMsg.DefaultCommandIndex = 0;

                var res = myMsg.ShowAsync();
            }

            else if (!Convert.ToBoolean(credit_btn.IsChecked) && !Convert.ToBoolean(netbank_opt.IsChecked) && !Convert.ToBoolean(paypal_opt.IsChecked) )
            {
                var myMsg = new MessageDialog("Please select a payment option", "Incomplete Form!");

                myMsg.Commands.Add(new UICommand("OK") { Id = 0 });
                myMsg.DefaultCommandIndex = 0;

                var res = myMsg.ShowAsync();
            }

            else if (!Convert.ToBoolean(terms_btn.IsChecked))
            {
                var myMsg = new MessageDialog( "Please accept the Terms & Conditions", "Incomplete Form!");

                myMsg.Commands.Add(new UICommand("OK") { Id = 0 });
                myMsg.DefaultCommandIndex = 0;

                var res = myMsg.ShowAsync();
            }

            else
            {
                async void fin_msg()
                {
                    var myMsg = new MessageDialog("You have successfully completed the form", "Success!!");

                    myMsg.Commands.Add(new UICommand("OK") { Id = 0 });
                    myMsg.DefaultCommandIndex = 0;

                    var res = await myMsg.ShowAsync();
                    CoreApplication.Exit();
                }

                fin_msg();
            }

        }

            private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            async void close_msg()
            {
                var myMsg = new MessageDialog("The App Will Close ", "Thank You!!");

                myMsg.Commands.Add(new UICommand("OK") { Id = 0 });
                myMsg.DefaultCommandIndex = 0;

                var res = await myMsg.ShowAsync();
                CoreApplication.Exit();
            }

            close_msg();

        }

        private void rst_form_Click(object sender, RoutedEventArgs e)
        {
            ResetAllControls(grid_lay);
        }

        private void rst_pass_Click(object sender, RoutedEventArgs e)
        {
            pass_box.Password = string.Empty;
        }

        private void showPlain(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            pass_box.PasswordRevealMode = PasswordRevealMode.Visible;
        }

        private void showHide(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            pass_box.PasswordRevealMode = PasswordRevealMode.Hidden;
        }

    }
}
