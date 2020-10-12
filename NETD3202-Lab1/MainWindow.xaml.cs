/*  Daniel Hinbest
 *  October 2, 2020
 *  NETD 3202 - Lab 1
 *  A WPF application that allows the user to create a list of projects and their elements - the name, budget, money spent, time remaining, and its progress to that point.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NETD3202_Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variable declarations
        public List<Program> projectList = new List<Program>();  //A list of Program objects
        string output;                                                  //Error output

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates an object of the Project class based on the user input and puts it in a list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            //Checks if any of the input fields are empty
            if (txtProjectName.Text != string.Empty || txtProjectBudget.Text != string.Empty || txtMoneySpent.Text != string.Empty || txtHoursRemaining.Text != string.Empty || cmbProjectStatus.SelectedIndex != -1)
            {
                //Checks if the numeric input is valid
                if (ValidateDouble(txtProjectBudget) && ValidateDouble(txtMoneySpent) && ValidateInteger(txtHoursRemaining))
                {
                    //Checks if the range is valid
                    if (Convert.ToDouble(txtProjectBudget.Text) >= 0 || Convert.ToDouble(txtMoneySpent.Text) > 0 || Convert.ToInt32(txtHoursRemaining.Text) > 0)
                    {
                        //Adds a program object to the project list
                        projectList.Add(new Program(txtProjectName.Text, double.Parse(txtProjectBudget.Text), double.Parse(txtMoneySpent.Text), int.Parse(txtHoursRemaining.Text), cmbProjectStatus.Text));

                        //Adds the project to the list box
                        for (int i = 0; i < projectList.Count; i++)
                        {
                            lstProjects.Items.Add(projectList[i].ProjectName);
                        }

                        //Resets the input
                        Reset();
                    }
                    else
                    {
                        //Adds to the error output if there is a range error
                        output += "The project budget, money spent, and hours remaining must be a positive number\n";
                        if (output != string.Empty)
                        {
                            MessageBox.Show(output);
                        }
                    }
                }
                else
                {
                    //Adds to the error output if there is non-numeric input
                    output += "The project budget, money spent, and hours remaining must be a numeric value\n";
                    if (output != string.Empty)
                    {
                        MessageBox.Show(output);
                    }
                }
            }
            else
            {
                //Adds to the error output if a field is empty
                output += "The fields cannot be empty";
                if (output != string.Empty)
                {
                    MessageBox.Show(output);
                }
            }
        }

        /// <summary>
        /// Handles the second window in the Communication Activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstProjects_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SecondWindow secondWindow = new SecondWindow(lstProjects.SelectedIndex, projectList, sender);

            secondWindow.Show();
        }

        /// <summary>
        /// Event handler for the reset button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            // Changed to this because this.Close() only closes the current window, and will ensure the program completely closes
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// Validation for the double data type variables
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static bool ValidateDouble(TextBox textBox)
        {
            // Variable declarations
            double numeric;

            if (double.TryParse(textBox.Text, out numeric))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Validation for the integer data type variables
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static bool ValidateInteger(TextBox textBox)
        {
            //Variable declarations
            int numeric;

            if (int.TryParse(textBox.Text, out numeric))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Reset function for clearing user input
        /// </summary>
        private void Reset()
        {
            txtProjectName.Text = string.Empty;
            txtProjectBudget.Text = string.Empty;
            txtMoneySpent.Text = string.Empty;
            txtHoursRemaining.Text = string.Empty;
            cmbProjectStatus.SelectedIndex = -1;
        }


    }
}
