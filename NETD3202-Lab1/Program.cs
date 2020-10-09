/*  Daniel Hinbest
 *  October 2, 2020
 *  NETD 3202 - Lab 1 - Program class
 *  A WPF application that allows the user to create a list of projects and their elements - the name, budget, money spent, time remaining, and its progress to that point.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace NETD3202_Lab1
{
    public class Program
    {
        //class attribute members
        private string projectName;     //String for the project name
        private double projectBudget;   //Double for the project budget
        private double moneySpent;      //Double for the money spent
        private int hoursRemaining;     //Integer for hours remaining
        private string projectStatus;   //String for project status
        
        /// <summary>
        /// Default Constructor - sets the attributes of the class to the values from the mutators
        /// </summary>
        /// 
        //Note:this default constructor is not necessary you can delete it. 
        public Program()
        {
            projectName = this.ProjectName;
            projectBudget = this.ProjectBudget;
            moneySpent = this.MoneySpent;
            hoursRemaining = this.HoursRemaining;
            projectStatus = this.ProjectStatus;
        }

        /// <summary>
        /// Parameterized constructor that assigns user input to the class attributes
        /// </summary>
        /// <param name="name"></param>
        /// <param name="budget"></param>
        /// <param name="money"></param>
        /// <param name="hours"></param>
        /// <param name="status"></param>
        public Program(string name, double budget, double money, int hours, string status)
        {
            projectName = name;
            projectBudget = budget;
            moneySpent = money;
            hoursRemaining = hours;
            projectStatus = status;
        }

        /// <summary>
        /// Property Procedure for the projectName attribute
        /// </summary>
        public string ProjectName
        {
            //Mutator - sets the value provided as the projectName value
            set { this.projectName = value; }

            //Accessor - gets the value of projectName and returns it to where it is called
            get { return projectName; }
        }

        /// <summary>
        /// Property Procedure for the projectBudget attribute
        /// </summary>
        public double ProjectBudget
        {
            //Mutator - sets the value provided as the projectBudget value
            set { this.projectBudget = value; }

            //Accessor - gets the value of projectBudget and returns it to where it is called
            get { return projectBudget; }
        }


        /// <summary>
        /// Property Procedure for the moneySpent attribute
        /// </summary>
        public double MoneySpent
        {
            //Mutator - sets the value provided as the moneySpent value
            set { this.moneySpent = value; }

            //Accessor - gets the value of moneySpent and returns it to where it is called
            get { return moneySpent; }
        }

        /// <summary>
        /// Property Procedure for the hoursRemaining attribute
        /// </summary>
        public int HoursRemaining
        {
            //Mutator - sets the value provided as the hoursRemaining value
            set { this.hoursRemaining = value; }

            //Accessor - gets the value of hoursRemaining and returns it to where it is called
            get { return hoursRemaining; }
        }

        public string ProjectStatus
        {
            //Mutator - sets the value provided as the projectStatus value
            set { this.projectStatus = value; }

            //Accessor - gets the value of projectStatus and returns it to where it is called
            get { return projectStatus; }
        }
    }
}
