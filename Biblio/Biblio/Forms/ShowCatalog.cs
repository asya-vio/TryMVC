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
    public partial class ShowCatalog : Form
    {
        ListBox listBox;
        TreeView treeView;
        Button addBookButton;
        Button deleteBookButton;
        Button addExemplarBookButton;
        Button deleteExemplarBookButton;

        public ShowCatalog()
        {

            InitializeComponent();

            BackColor = Color.AntiqueWhite;
            WindowState = FormWindowState.Maximized;
            Font = new Font("Tahoma", 12, FontStyle.Regular);

            this.listBox = new ListBox
            {
                Width = 600,
                Height = 1000
            };

            this.treeView = new TreeView
            {
                Width = 800,
                Height = 1000
            };
         
            this.addBookButton = new Button()
            {
                Location = new Point(900, 100),
                Width = 200,
                Height = 150,
                Text = "Добавить книгу",
                BackColor = Color.Azure
            };

            this.deleteBookButton = new Button()
            {
                Location = new Point(1200, 100),
                Width = 200,
                Height = 150,
                Text = "Удалить книгу",
                BackColor = Color.Azure
            };

            this.addExemplarBookButton = new Button()
            {
                Location = new Point(900, 300),
                Width = 200,
                Height = 150,
                Text = "Добавить экземпляр книги",
                BackColor = Color.Azure
            };

            this.deleteExemplarBookButton = new Button()
            {
                Location = new Point(1200, 300),
                Width = 200,
                Height = 150,
                Text = "Удалить экземпляр книги",
                BackColor = Color.Azure
            };


            Controls.Add(addBookButton);
            Controls.Add(deleteBookButton);
            Controls.Add(addExemplarBookButton);
            Controls.Add(deleteExemplarBookButton);
            Controls.Add(treeView);

            addBookButton.Click += AddBookButton_Click;
            deleteBookButton.Click += deleteBookButton_Click;
            addExemplarBookButton.Click += AddExemplarBookButton_Click;
            deleteExemplarBookButton.Click += DeleteExemplarBookButton_Click;

            ReadTree();
        }

        void ReadTree()
        {
            treeView.Nodes.Clear();

            var catalog = DBManager.GetBookCatalog();

            foreach (Book book in catalog.ListOfBook)
            {
                TreeNode newNode = new TreeNode();
                newNode.Text = "\"" + book.Name + "\"  " + book.Author;
                newNode.Name = book.Name;

                foreach(BookExemplar exemplar in book.ListOfExemplar)
                {
                    TreeNode newNode1 = new TreeNode();

                    newNode1.Text = string.Format("Инв. № {0}, Год издания: {1}, в наличии: {2}",
                        exemplar.InventoryNumber.ToString(),
                        exemplar.PublicationDate.ToString(),
                        exemplar.Presence.ToString());

                    newNode1.Name = exemplar.InventoryNumber.ToString();

                    newNode.Nodes.Add(newNode1);

                }
                treeView.Nodes.Add(newNode);

            }

            Controls.Add(treeView);

        }


        void AddBookButton_Click(object sender, EventArgs e)
        {
            Form createBook = new CreateBook();

            createBook.ShowDialog();
            Book book = DBManager.GetNewBook();

            TreeNode newNode = new TreeNode();

            newNode.Text = "\"" + book.Name + "\"  " + book.Author;
            newNode.Name = book.Name;

            BookExemplar exemplar = DBManager.GetNewExemplar();

            TreeNode newNode1 = new TreeNode();

            newNode1.Text = string.Format("Инв. № {0}, Год издания: {1}, в наличии: {2}",
                exemplar.InventoryNumber.ToString(),
                exemplar.PublicationDate.ToString(),
                exemplar.Presence.ToString());

            newNode1.Name = exemplar.InventoryNumber.ToString();

            newNode.Nodes.Add(newNode1);

            treeView.Nodes.Add(newNode);

            Controls.Add(treeView);

        }

        void deleteBookButton_Click(object sender, EventArgs e)
        {
            string name = treeView.SelectedNode.Name.ToString();

            DBManager.DeleteBook(name);

            treeView.SelectedNode.Remove();

        }

        private void AddExemplarBookButton_Click(object sender, EventArgs e)
        {
            string name = treeView.SelectedNode.Name.ToString();

            Form createBookExamplar = new CreateBookExemplar(name);

            createBookExamplar.ShowDialog();

            BookExemplar exemplar = DBManager.GetNewExemplar();

            TreeNode newNode1 = new TreeNode();

            newNode1.Text = string.Format("Инв. № {0}, Год издания: {1}, в наличии: {2}",
                exemplar.InventoryNumber.ToString(),
                exemplar.PublicationDate.ToString(),
                exemplar.Presence.ToString());

            newNode1.Name = exemplar.InventoryNumber.ToString();

            treeView.SelectedNode.Nodes.Add(newNode1);

            Controls.Add(treeView);
        }

        private void DeleteExemplarBookButton_Click(object sender, EventArgs e)
        {
            string inventoryNumber = treeView.SelectedNode.Name.ToString();

            DBManager.DeleteBookExemplar(inventoryNumber); 

            treeView.SelectedNode.Remove();
        }




    }
}
