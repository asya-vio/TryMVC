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
    public partial class CreateStudentPass : Form
    {
        TextBox IDPassBox;
        TextBox IDLenderBox;
        Button CreatePassButton;
        Student student;

        public CreateStudentPass(Student student)
        {
            InitializeComponent();
            this.student = student;

            var IDPassLabel = new Label
            {
                Text = "Номер читательского билета",
                Dock = DockStyle.Fill
            };

            this.IDPassBox = new TextBox
            {
                Width = 300,
                Dock = DockStyle.Left,
            };

            var IDLibraryLabel = new Label
            {
                Text = "Номер библиотеки или читального зала",
                Dock = DockStyle.Fill
            };

            this.IDLenderBox = new TextBox
            {
                Width = 250,
                Dock = DockStyle.Left,
            };

            this.CreatePassButton = new Button
            {
                Text = "Зарегистрировать билет",
                BackColor = Color.Chocolate,
                Width = 200,
                Dock = DockStyle.Left
            };

            var table = new TableLayoutPanel();
            table.RowStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            for (int i = 0; i < 5; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30));
            }
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            table.Controls.Add(new Panel(), 0, 0);
            table.Controls.Add(IDPassLabel, 0, 1);
            table.Controls.Add(IDPassBox, 0, 2);
            table.Controls.Add(IDLibraryLabel, 0, 3);
            table.Controls.Add(IDLenderBox, 0, 4);
            table.Controls.Add(CreatePassButton, 0, 5);
            table.Controls.Add(new Panel(), 0, 6);

            table.Dock = DockStyle.Fill;
            Controls.Add(table);

            CreatePassButton.Click += CreatePassButton_Click;

        }

        void CreatePassButton_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrWhiteSpace(IDPassBox.Text) || string.IsNullOrWhiteSpace(IDLenderBox.Text))
            {
                 MessageBox.Show("Не все поля заполнены!");
            }

            else
            {
                StudentPass studentPass = new StudentPass(student, int.Parse(IDPassBox.Text), int.Parse(IDLenderBox.Text));

                DBManager.WriteStudentPass(studentPass);

                this.Close();

            }
            
        }
    }
}
