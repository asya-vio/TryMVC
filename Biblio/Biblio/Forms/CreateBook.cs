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
    public partial class CreateBook : Form
    {
        TextBox nameBox;
        TextBox authorsBox;
        Button okButton;

        public CreateBook()
        {
            InitializeComponent();

            BackColor = Color.AntiqueWhite;
            //WindowState = FormWindowState.Maximized;
            this.Size = new Size(300, 500);

            var nameLabel = new Label
            {
                Text = "Введите название ниги",
                Dock = DockStyle.Fill
            };

            this.nameBox = new TextBox
            {
                Width = 250,
                Dock = DockStyle.Left
            };

            var authorLabel = new Label
            {
                Text = "Введите через запятую авторов книги",
                Dock = DockStyle.Fill
            };

            this.authorsBox = new TextBox
            {
                Width = 250,
                Dock = DockStyle.Left
            };

            this.okButton = new Button
            {
                Text = "Готово",
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
            table.Controls.Add(nameLabel, 0, 1);
            table.Controls.Add(nameBox, 0, 2);
            table.Controls.Add(authorLabel, 0, 3);
            table.Controls.Add(authorsBox, 0, 4);
            table.Controls.Add(okButton, 0, 5);
            table.Controls.Add(new Panel(), 0, 6);

            table.Dock = DockStyle.Fill;
            Controls.Add(table);

            okButton.Click += OkButton_Click;



        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text) || string.IsNullOrWhiteSpace(authorsBox.Text))
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                Book book = new Book(nameBox.Text, authorsBox.Text);

                DBManager.WriteBook(book);

                Form createBookExamplar = new CreateBookExemplar(nameBox.Text);

                createBookExamplar.ShowDialog();

                this.Close();
            }
        }
    }
}
