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
    public partial class MainForm : Form
    {
        Button SignUpButton;
        Button CatalogButton;
        Button LandedItemsButton;

        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{
        //    Image img = Image.FromFile(@"D:\ИИТ\ООП\Git\UniversityGUI\Biblio\pict.jpg");
        //    Bitmap temp = new Bitmap(img);
        //    Graphics g = Graphics.FromImage(temp);

        //    //Приписываем g к нашему окну.
        //    g = this.CreateGraphics();
        //    int a = this.ClientSize.Width;
        //    int b = this.ClientSize.Height;

        //    //Выводим на g рисунок.
        //    g.DrawImage(img, 0, 0, a, b);
        //    g.Dispose();

        //}
        public MainForm()
        {
            InitializeComponent();
            
            

            WindowState = FormWindowState.Maximized;
            BackColor = Color.AliceBlue;
            Font = new Font("Tahoma", 50, FontStyle.Regular);

            this.SignUpButton = new Button
            {
                Text = "Зарегистрировать",
                Dock = DockStyle.Fill,
                Width = 700,
                Height = 200,
                BackColor = Color.BlanchedAlmond
            };

            this.CatalogButton = new Button
            {
                Text = "Просмотреть каталог",
                Dock = DockStyle.Fill,
                Width = 700,
                Height = 200,
                BackColor = Color.BlanchedAlmond

            };

            this.LandedItemsButton = new Button
            {
                Text = "Просмотр выданных книг",
                Dock = DockStyle.Fill,
                Width = 500,
                Height = 200,
                BackColor = Color.BlanchedAlmond
            };

            var table = new TableLayoutPanel();
            table.RowStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            for (int i = 0; i < 3; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30));
            }
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));


            table.Controls.Add(new Panel(), 0, 0);
            table.Controls.Add(SignUpButton, 0, 1);
            table.Controls.Add(CatalogButton, 0, 2);
            table.Controls.Add(LandedItemsButton, 0, 3);
            table.Controls.Add(new Panel(), 0, 4);

            table.Dock = DockStyle.Fill;
            Controls.Add(table);

            SignUpButton.Click += SignUpButton_Click;
            CatalogButton.Click += CatalogButton_Click;

            SignUpButton.MouseHover += SignUpButton_MouseHover;
            SignUpButton.MouseLeave += SignUpButton_MouseLeave;
        }

        void SignUpButton_MouseLeave(object sender, EventArgs e)
        {
            SignUpButton.BackColor = Color.BlanchedAlmond;
            //throw new NotImplementedException();
        }

        void SignUpButton_MouseHover(object sender, EventArgs e)
        {
            SignUpButton.BackColor = Color.Coral;
            //throw new NotImplementedException();
        }

        //private void CatalogButton_Click(object sender, EventArgs e)
        //{
        //    BookCatalog catalog = new BookCatalog();
        //    catalog.AddExpertiseArea("Наука");
        //    catalog.AddExpertiseArea("Не наука");
        //    string[] auth = { "Акапян", "Моисеенко" };

        //    Book book1 = new Book("Книжечка", auth);
        //    catalog.ListOfExpertiseArea[0].AddBook(book1);

        //    Book book2 = new Book("Кнчка", auth);
        //    catalog.ListOfExpertiseArea[1].AddBook(book2);

        //    book1.AddExemplar(1987, 123);
        //    book1.AddExemplar(1980, 124);

        //    book2.AddExemplar(1890, 456);

        //    Form ShowCatalog = new ShowCatalog(catalog);
        //    this.Hide();
        //    ShowCatalog.ShowDialog();

        //    this.Visible = true;
        //    //throw new NotImplementedException();
        //}

        private void CatalogButton_Click(object sender, EventArgs e)
        {
            Form ShowCatalog = new ShowCatalog();
            this.Hide();
            ShowCatalog.ShowDialog();

            this.Visible = true;
        }


        private void SignUpButton_Click(object sender, EventArgs e)
        {
            Form SignUpChoice = new SignUpChoice();
            this.Hide();
            SignUpChoice.ShowDialog();

            this.Visible = true;
            //throw new NotImplementedException();
        }


    }
}
