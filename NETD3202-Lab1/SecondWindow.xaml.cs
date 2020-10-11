/*  Daniel Hinbest
 *  October 11, 2020
 *  NETD 3202 - Communication Activity 1
 *  A WPF Window class that updates the information that gets sent back into the MainWindow lstProjects object
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Xps;

namespace NETD3202_Lab1
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        MainWindow mainWindow = new MainWindow();
        //Note:What you want to do here is the following:  declare a program and a list then set it equal to whatever you passed I showed you an example for the Program, complete it for the list! 
        Program program = new Program();
        ////Note: do the same thing for the list.
        public List<Program> projectList = new List<Program>();     //Project list
        public object sender;                                       //Object to pass through an event handler                
        public int selectedIndex;                                   //Variable to store the selected index
        string output;                                              //Error output variable

        /// <summary>
        /// Parameterized constructor - generates a new instance of the SecondWindow with the project selected from the MainWindow, its list and its object
        /// </summary>
        /// <param name="selectedProject"></param>
        /// <param name="projectList"></param>
        /// <param name="sender"></param>
        public SecondWindow(int selectedProject, List<Program> projectList, object sender)
        {
            //Sets the index, project list, and sender to the SecondWindow variable class
            this.selectedIndex = selectedProject;
            this.projectList = projectList;
            this.sender = sender;

            InitializeComponent();
            
            //Creates a program based on the elements of the selected item from the MainWindow
            Program editedProgram = projectList[selectedIndex];

            //Sets all the text boxes to the attributes of the editedProgram
            txtProjectName.Text = editedProgram.ProjectName;
            txtProjectBudget.Text = editedProgram.ProjectBudget.ToString();
            txtMoneySpent.Text = editedProgram.MoneySpent.ToString();
            txtHoursRemaining.Text = editedProgram.HoursRemaining.ToString();
            txtProjectStatus.Text = editedProgram.ProjectStatus;
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event handler for changing the attributes of the project selected from MainWindow and alters the project item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeProject_Click(object sender, RoutedEventArgs e)
        {
            //Checks if any of the input fields are empty
            if (txtProjectName.Text != string.Empty || txtProjectBudget.Text != string.Empty || txtMoneySpent.Text != string.Empty || txtHoursRemaining.Text != string.Empty || txtProjectStatus.Text != string.Empty)
            {
                //Checks if the numeric input is valid
                if (ValidateDouble(txtProjectBudget) && ValidateDouble(txtMoneySpent) && ValidateInteger(txtHoursRemaining))
                {
                    //Checks if the range is valid
                    if (Convert.ToDouble(txtProjectBudget.Text) >= 0 || Convert.ToDouble(txtMoneySpent.Text) > 0 || Convert.ToInt32(txtHoursRemaining.Text) > 0)
                    {
                        //Creates a program based on the information provided
                        projectList[selectedIndex] = new Program(txtProjectName.Text, Convert.ToInt32(txtProjectBudget.Text), Convert.ToInt32(txtMoneySpent.Text), Convert.ToInt32(txtHoursRemaining.Text), txtProjectStatus.Text);
                        CollectionViewSource.GetDefaultView(projectList).Refresh();
                        btnCloseWindow_Click(sender, e);
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
    }
}
