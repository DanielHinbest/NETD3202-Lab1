using System;
using System.Collections.Generic;
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
        public List<Program> projectList = new List<Program>();
        public string projectName;
        public object sender;
        string output;
        public SecondWindow(Program program, List<Program> projectList, object sender)
        {
            ////Note: do the same thing to the list! 
            this.program = program;
            this.projectList = projectList;
            this.sender = sender;

            InitializeComponent();

            //Note:now we can set the program object properties equal to the textboxes.
            txtProjectName.Text = this.program.ProjectName;
            txtProjectBudget.Text = this.program.ProjectBudget.ToString();
            txtMoneySpent.Text = this.program.MoneySpent.ToString();
            txtHoursRemaining.Text = this.program.HoursRemaining.ToString();
            txtProjectStatus.Text = this.program.ProjectStatus;
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnChangeProject_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < projectList.Count; i++)
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
                            if (projectList[i].ProjectName == projectName)
                            {
                                projectList[i].ProjectName = txtProjectName.Text;
                                projectList[i].ProjectBudget = double.Parse(txtProjectBudget.Text);
                                projectList[i].MoneySpent = double.Parse(txtMoneySpent.Text);
                                projectList[i].HoursRemaining = int.Parse(txtHoursRemaining.Text);
                                projectList[i].ProjectStatus = txtProjectStatus.Text;
                                CollectionViewSource.GetDefaultView(projectList).Refresh();
                                }
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
