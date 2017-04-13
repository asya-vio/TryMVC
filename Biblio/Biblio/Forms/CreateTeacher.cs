using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Biblio
{
    public partial class CreateTeacher : Form
    {
        TextBox LastNameBox;
        TextBox NameBox;
        TextBox SecondNameBox;
        TextBox AddressBox;
        TextBox PhoneNumberBox;
        TextBox TeacherNumbBox;
        TextBox FacultyBox;
        TextBox JobBox;
        Button CreatingTeacherButton;

        public CreateTeacher()
        {
            BackColor = Color.AntiqueWhite;
            WindowState = FormWindowState.Maximized;
            //this.Size = new Size(250, 500);

            InitializeComponent();

            var LastNameLabel = new Label
            {
                Text = "Фамилия",
                Dock = DockStyle.Left
            };

            this.LastNameBox = new TextBox
            {
                Width = 250,
                Dock = DockStyle.Left,
            };

            var NameLabel = new Label
            {
                Text = "Имя",
                Dock = DockStyle.Fill
            };

            this.NameBox = new TextBox
            {
                Width = 250,
                Dock = DockStyle.Left,
            };

            var SecondNameLabel = new Label
            {
                Text = "Отчество",
                Dock = DockStyle.Fill
            };

            this.SecondNameBox = new TextBox
            {
                Width = 250,
                Dock = DockStyle.Left,
            };

            var AddressLabel = new Label
            {
                Text = "Адрес",
                Dock = DockStyle.Left
            };

            this.AddressBox = new TextBox
            {
                Width = 250,
                Dock = DockStyle.Left
            };

            var PhoneNumberLabel = new Label
            {
                Text = "Телефон",
                Dock = DockStyle.Fill
            };

            this.PhoneNumberBox = new TextBox
            {
                Dock = DockStyle.Fill,
            };

            var TeacherNumberLabel = new Label
            {
                Text = "Табельный номер",
                Dock = DockStyle.Fill
            };

            this.TeacherNumbBox = new TextBox
            {
                Dock = DockStyle.Fill,
            };

            var FacultyLabel = new Label
            {
                Text = "Факультет",
                Dock = DockStyle.Fill
            };

            this.FacultyBox = new TextBox
            {
                Dock = DockStyle.Fill,
            };

            var JobLabel = new Label
            {
                Text = "Должность",
                Dock = DockStyle.Fill
            };

            this.JobBox = new TextBox
            {
                Width = 250,
                Dock = DockStyle.Fill,
            };

            this.CreatingTeacherButton = new Button
            {
                Text = "Внести в базу",
                BackColor = Color.Chocolate,
                Width = 200,
                Dock = DockStyle.Left
            };

            var table = new TableLayoutPanel();
            table.RowStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            for (int i = 0; i < 17; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30));
            }
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            table.Controls.Add(new Panel(), 0, 0);
            table.Controls.Add(LastNameLabel, 0, 1);
            table.Controls.Add(LastNameBox, 0, 2);
            table.Controls.Add(NameLabel, 0, 3);
            table.Controls.Add(NameBox, 0, 4);
            table.Controls.Add(SecondNameLabel, 0, 5);
            table.Controls.Add(SecondNameBox, 0, 6);
            table.Controls.Add(AddressLabel, 0, 7);
            table.Controls.Add(AddressBox, 0, 8);
            table.Controls.Add(PhoneNumberLabel, 0, 9);
            table.Controls.Add(PhoneNumberBox, 0, 10);
            table.Controls.Add(TeacherNumberLabel, 0, 11);
            table.Controls.Add(TeacherNumbBox, 0, 12);
            table.Controls.Add(FacultyLabel, 0, 13);
            table.Controls.Add(FacultyBox, 0, 14);
            table.Controls.Add(JobLabel, 0, 15);
            table.Controls.Add(JobBox, 0, 16);
            table.Controls.Add(CreatingTeacherButton, 0, 17);
            table.Controls.Add(new Panel(), 0, 18);

            table.Dock = DockStyle.Fill;
            Controls.Add(table);

            CreatingTeacherButton.Click += CreatingTeacherButton_Click;
        }

        private void CreatingTeacherButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(LastNameBox.Text) || string.IsNullOrWhiteSpace(NameBox.Text) ||
            string.IsNullOrWhiteSpace(SecondNameBox.Text) || string.IsNullOrWhiteSpace(AddressBox.Text) ||
            string.IsNullOrWhiteSpace(TeacherNumbBox.Text) || string.IsNullOrWhiteSpace(JobBox.Text))
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                Teacher teacher = new Teacher(LastNameBox.Text, NameBox.Text, SecondNameBox.Text,
                      AddressBox.Text, PhoneNumberBox.Text, int.Parse(TeacherNumbBox.Text), FacultyBox.Text, JobBox.Text);

                DBManager.WriteTeacher(teacher);

                Form teacherPass = new CreateTeacherPass(teacher);
                teacherPass.ShowDialog();

            }
        }
    }
}
