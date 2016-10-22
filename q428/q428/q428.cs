using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace q428
{
    public partial class q428 : Form
    {
        public q428()
        {
            InitializeComponent();
            extraFieldTextBox.Hide(); // initially hide
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            employeeTypeComboBox.SelectedItem = 0;
            
            firstNameTextBox.Text = listBox1.SelectedItem.get_firstName();
        }

        private void hireEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enterInformationButton.Show(); // allow user to enter data
        }

        private void enterInformationButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = employeeTypeComboBox.SelectedIndex;
            if (firstNameTextBox.Text != "" && lastNameTextBox.Text != "" && salaryTextBox.Text != "") // to prevent errors
            {
                // add entry to ListBox
                if (selectedIndex == 0)
                    listBox1.Items.Add(new Employee(firstNameTextBox.Text, lastNameTextBox.Text, double.Parse(salaryTextBox.Text)));
                if (extraFieldTextBox.Text != "") // prevent errors from extra text box being empty
                {
                    if (selectedIndex == 1)
                        listBox1.Items.Add(new Manager(firstNameTextBox.Text, lastNameTextBox.Text, double.Parse(salaryTextBox.Text), extraFieldTextBox.Text));
                    if (selectedIndex == 2)
                        listBox1.Items.Add(new Peon(firstNameTextBox.Text, lastNameTextBox.Text, double.Parse(salaryTextBox.Text), double.Parse(extraFieldTextBox.Text)));
                    if (selectedIndex == 3)
                        listBox1.Items.Add(new Trainer(firstNameTextBox.Text, lastNameTextBox.Text, double.Parse(salaryTextBox.Text), extraFieldTextBox.Text));
                }
            }
            enterInformationButton.Hide(); // done with entry mode
        }

        private void employeeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = employeeTypeComboBox.SelectedIndex;
            if (selectedIndex == 0)
            {
                extraFieldLabel.Text = ""; // clear label
                extraFieldTextBox.Hide(); // hide text box
            }
            if (selectedIndex == 1)
            {
                extraFieldLabel.Text = "Store:"; // set label text to corresponding object type
                extraFieldTextBox.Show();
            }
            if (selectedIndex == 2)
            {
                extraFieldLabel.Text = "Hours:";
                extraFieldTextBox.Show();
            }
            if (selectedIndex == 3)
            {
                extraFieldTextBox.Show();
                extraFieldLabel.Text = "Subject:";
            }
        }
    }
}