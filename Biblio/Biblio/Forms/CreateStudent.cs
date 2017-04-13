using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace Biblio
{
    public partial class CreateStudent : Form
    {
        TextBox LastNameBox;
        TextBox NameBox;
        TextBox SecondNameBox;
        TextBox AddressBox;
        TextBox PhoneNumberBox;
        TextBox IDCardBox;
        TextBox FacultyBox;
        TextBox CourseBox;
        Button CreatingStudentButton;           

        public CreateStudent()
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

            LastNameBox = new TextBox
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

            var IDCardLabel = new Label
            {
                Text = "Номер студенческого билета",
                Dock = DockStyle.Fill
            };

            this.IDCardBox = new TextBox
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

            var CourseLabel = new Label
            {
                Text = "Курс",
                Dock = DockStyle.Fill
            };

            this.CourseBox = new TextBox
            {
                Width = 250,
                Dock = DockStyle.Fill,
            };

            this.CreatingStudentButton = new Button
            {
                Text = "Внести в базу",
                BackColor = Color.Chocolate,
                Width = 200,
                Dock = DockStyle.Left
            };

            var table = new TableLayoutPanel();
            table.RowStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            for (int i = 0; i < 17; i++ )
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
            table.Controls.Add(IDCardLabel, 0, 11);
            table.Controls.Add(IDCardBox, 0, 12);
            table.Controls.Add(FacultyLabel, 0, 13);
            table.Controls.Add(FacultyBox, 0, 14);
            table.Controls.Add(CourseLabel, 0, 15);
            table.Controls.Add(CourseBox, 0, 16);
            table.Controls.Add(CreatingStudentButton, 0, 17);
            table.Controls.Add(new Panel(), 0, 18);

            table.Dock = DockStyle.Fill;
            Controls.Add(table);

            CreatingStudentButton.Click += CreatingStudentButton_OnClick;
        }

        void CreatingStudentButton_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameBox.Text) || string.IsNullOrWhiteSpace(NameBox.Text) ||
               string.IsNullOrWhiteSpace(SecondNameBox.Text) || string.IsNullOrWhiteSpace(AddressBox.Text) ||
               string.IsNullOrWhiteSpace(IDCardBox.Text) || string.IsNullOrWhiteSpace(CourseBox.Text))
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                Student student = new Student(LastNameBox.Text, NameBox.Text, SecondNameBox.Text,
                       AddressBox.Text, PhoneNumberBox.Text, int.Parse(IDCardBox.Text), FacultyBox.Text, int.Parse(CourseBox.Text));

                DBManager.WriteStudent(student);

                Form studentPass = new CreateStudentPass(student);
                studentPass.ShowDialog();

            }

        }



    }
}
