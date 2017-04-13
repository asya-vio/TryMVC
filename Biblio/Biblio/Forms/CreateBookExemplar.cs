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
    public partial class CreateBookExemplar : Form
    {
        TextBox inventoryNumberBox;
        TextBox publicationDateBox;
        TextBox presenceBox;
        Button okButton;
        string Name;

        public CreateBookExemplar(string name)
        {
            InitializeComponent();

            this.Name = name;

            BackColor = Color.AntiqueWhite;
            //WindowState = FormWindowState.Maximized;
            this.Size = new Size(300, 500);

            var inventoryLabel = new Label
            {
                Text = "Введите инв. №",
                Dock = DockStyle.Fill
            };

            this.inventoryNumberBox = new TextBox
            {
                Width = 250,
                Dock = DockStyle.Left
            };

            var publicationLabel = new Label
            {
                Text = "Введите год издания",
                Dock = DockStyle.Fill
            };

            this.publicationDateBox = new TextBox
            {
                Width = 250,
                Dock = DockStyle.Left
            };

            var presenceLabel = new Label
            {
                Text = "Наличие",
                Dock = DockStyle.Fill
            };

            this.presenceBox = new TextBox
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
            for (int i = 0; i < 7; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30));
            }
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            table.Controls.Add(new Panel(), 0, 0);
            table.Controls.Add(inventoryLabel, 0, 1);
            table.Controls.Add(inventoryNumberBox, 0, 2);
            table.Controls.Add(publicationLabel, 0, 3);
            table.Controls.Add(publicationDateBox, 0, 4);
            table.Controls.Add(presenceLabel, 0, 5);
            table.Controls.Add(presenceBox, 0, 6);
            table.Controls.Add(okButton, 0, 7);
            table.Controls.Add(new Panel(), 0, 8);

            table.Dock = DockStyle.Fill;
            Controls.Add(table);

            okButton.Click += OkButton_Click;
        }



        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inventoryNumberBox.Text) || string.IsNullOrWhiteSpace(publicationDateBox.Text)
                || string.IsNullOrWhiteSpace(presenceBox.Text))
            {
                MessageBox.Show("Не все поля заполнены!");
            }

            DBManager.AddBookExemplar(Name, inventoryNumberBox.Text, publicationDateBox.Text, presenceBox.Text);

            this.Close();

        }
    }
}

