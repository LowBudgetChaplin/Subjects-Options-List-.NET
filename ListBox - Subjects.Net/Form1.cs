using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBox___Subjects.Net
{
    public partial class Form1 : Form
    {
        private DataTable dtCourses = new DataTable();
        private DataTable dtSelectedCourses = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillCoursesTable();
            SelectedCourseTable();


            listBox1.DataSource = dtCourses;
            listBox1.DisplayMember = "Course Name";

            listBox2.DataSource = dtSelectedCourses;
            listBox2.DisplayMember = "Course Name";
        }

        private void FillCoursesTable()
        {
            dtCourses.Columns.Add("CourseID", typeof(int));
            dtCourses.Columns.Add("CourseName");
            dtCourses.Columns.Add("CourseDuration");


            dtCourses.Rows.Add(1, "OOP", "14 Months");
            dtCourses.Rows.Add(2, "Java", "14 Months");
            dtCourses.Rows.Add(3, "Web Development", "12 Months");
            dtCourses.Rows.Add(4, "Management", "6 Months");
            dtCourses.Rows.Add(5, "Finance", "6 Months");
        }

        private void SelectedCourseTable()
        {
            dtSelectedCourses.Columns.Add("CourseID", typeof(int));
            dtSelectedCourses.Columns.Add("CourseName");
            dtSelectedCourses.Columns.Add("Duration");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count > 0)
            {
                dtSelectedCourses.ImportRow(dtCourses.Rows[listBox1.SelectedIndex]);
                dtCourses.Rows[listBox1.SelectedIndex].Delete();
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {
                dtCourses.ImportRow(dtSelectedCourses.Rows[listBox2.SelectedIndex]);
                dtSelectedCourses.Rows[listBox2.SelectedIndex].Delete();
            }
        }

        private void AddAllButton_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                int counter = dtCourses.Rows.Count;

                for(int i=counter-1; i>=0; i--)
                { 
                    dtSelectedCourses.ImportRow(dtCourses.Rows[listBox1.SelectedIndex]);
                    dtCourses.Rows[listBox1.SelectedIndex].Delete();
                }
            }
        }

        private void removeAllButton_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {
                int counter = dtSelectedCourses.Rows.Count;

                for (int i = counter - 1; i >= 0; i--)
                {
                    dtCourses.ImportRow(dtSelectedCourses.Rows[listBox2.SelectedIndex]);
                    dtSelectedCourses.Rows[listBox2.SelectedIndex].Delete();
                }
            }
        }

        private void finalizeButton_Click(object sender, EventArgs e)
        {
           DialogResult dialog = MessageBox.Show("Are you sure you want to finalize the selected courses?", 
                                 "Confimation Message", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                dataGridView1.DataSource = dtSelectedCourses;
                dataGridView1.Enabled = false;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.RowHeadersVisible = false;

                dataGridView1.Columns[1].Width = 350;
                dataGridView1.Columns[2].Width = 500;
            }
            else
            {
                MessageBox.Show("Please select at least 1 course.",
                                 "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
