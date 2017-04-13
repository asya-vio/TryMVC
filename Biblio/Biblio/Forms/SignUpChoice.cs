using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblio
{
    public partial class SignUpChoice : Form
    {
        Button StudentButton;
        Button TeacherButton;

        public SignUpChoice()
        {
            InitializeComponent();
            BackColor = Color.AntiqueWhite;
            Font = new Font("Tahoma", 26, FontStyle.Bold);

            var ChoiceLabel = new Label
            {
                Text = "Выберите тип абонемента",
                Dock = DockStyle.Fill,
                Width = 500,
                Height = 50
            };

            this.StudentButton = new Button
            {
                Text = "Студент",
                Dock = DockStyle.Fill,
                Width = 500,
                Height = 200
            };

            this.TeacherButton = new Button
            {
                Text = "Преподаватель",
                Dock = DockStyle.Fill,
                Width = 500,
                Height = 200
            };

            var table = new TableLayoutPanel();
            table.RowStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            table.Controls.Add(new Panel(), 0, 0);
            table.Controls.Add(ChoiceLabel, 0, 1);
            table.Controls.Add(StudentButton, 0, 2);
            table.Controls.Add(TeacherButton, 0, 3);
            table.Controls.Add(new Panel(), 0, 4);

            table.Dock = DockStyle.Fill;
            Controls.Add(table);

            StudentButton.Click += StudentButton_Click;
            TeacherButton.Click += TeacherButton_Click;
        }

        private void TeacherButton_Click(object sender, EventArgs e)
        {
            Form teacher = new CreateTeacher();
            this.Hide();
            teacher.ShowDialog();
            this.Close();
            //throw new NotImplementedException();
        }

        private void StudentButton_Click(object sender, EventArgs e)
        {
            Form student = new CreateStudent();
            this.Hide();
            student.ShowDialog();
            this.Close();
            //throw new NotImplementedException();
        }
    }
}
