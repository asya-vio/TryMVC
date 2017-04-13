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
    public static class DBManager
    {
        private static void OpenConnection()
        {
            var con = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnect"];
            OleDbConnection myOleDbConnection = new OleDbConnection(con.ConnectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
        }

        public static void WriteBook(Book book)
        {

            var con = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnect"];
            OleDbConnection myOleDbConnection = new OleDbConnection(con.ConnectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            myOleDbCommand.CommandText = "INSERT INTO Book ([Name], [Authors]) values ('"
                + book.Name + "' , '" + book.Author + "')";

            myOleDbConnection.Open();

            myOleDbCommand.ExecuteNonQuery();
            myOleDbConnection.Close();
        }

        public static void DeleteBook(string name)
        {
            var con = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnect"];
            OleDbConnection myOleDbConnection = new OleDbConnection(con.ConnectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            myOleDbCommand.CommandText = string.Format("{0}'{1}'", "DELETE * FROM Book WHERE [Name] = ", name);

            myOleDbConnection.Open();

            myOleDbCommand.ExecuteNonQuery();

            myOleDbConnection.Close();

        }

        public static TreeNode GetNewBook()
        {
            TreeNode newNode = new TreeNode();

            var con = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnect"];
            OleDbConnection myOleDbConnection = new OleDbConnection(con.ConnectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            myOleDbCommand.CommandText = "SELECT top 1 [Name], [Authors] FROM Book order by [Код] desc";

            myOleDbConnection.Open();

            OleDbDataReader dr = myOleDbCommand.ExecuteReader();

            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    newNode.Text = dr["Name"].ToString() + " \"  " + dr["Authors"].ToString();
                    newNode.Name = dr["Name"].ToString();
                }

            }

            myOleDbConnection.Close();

            return newNode;
        }

        public static BookCatalog GetBookCatalog()
        {
            BookCatalog catalog = new BookCatalog();


            var con = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnect"];
            OleDbConnection myOleDbConnection = new OleDbConnection(con.ConnectionString);

            myOleDbConnection.Open();

            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            myOleDbCommand.CommandText = "SELECT [Name], [Authors] FROM Book";
            OleDbDataReader dr = myOleDbCommand.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Book book = new Book(dr["Name"].ToString(), dr["Authors"].ToString());

                    OleDbCommand myOleDbCommand2 = myOleDbConnection.CreateCommand();
                    myOleDbCommand2.CommandText = string.Format("{0}'{1}'",
                        "SELECT [PublicationDate], [Код], [Presence] FROM BookExemplar WHERE Name = ",
                        dr["Name"].ToString());
                    OleDbDataReader dr2 = myOleDbCommand2.ExecuteReader();

                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            BookExemplar exemplar = new BookExemplar(int.Parse(dr2["Код"].ToString()),
                                dr2["Presence"].ToString(),
                                int.Parse(dr2["PublicationDate"].ToString()));
                            book.AddExemplar(exemplar);

                        }
                    }
                    dr2.Close();

                    catalog.AddBook(book);

                }
            }
            dr.Close();
            myOleDbConnection.Close();

            return catalog;
        }


        public static void AddBookExemplar(string name, string inventoryNumber, string publicationDate, string presence)
        {
            var con = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnect"];
            OleDbConnection myOleDbConnection = new OleDbConnection(con.ConnectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            myOleDbCommand.CommandText = "INSERT INTO BookExemplar ([InventoryNumber], [PublicationDate], [Presence], [Name]) values ('"
                    + inventoryNumber + "' , '" + publicationDate + "' , '" + presence + "' , '" + name + "')"; // тут нужно как-то вписать имя книги, в которую записываем экземпляр

            myOleDbConnection.Open();

            myOleDbCommand.ExecuteNonQuery();
            myOleDbConnection.Close();
        }

        public static string GetNewExemplar()
        {
            string resultString = "";

            var con = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnect"];
            OleDbConnection myOleDbConnection = new OleDbConnection(con.ConnectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            myOleDbCommand.CommandText = "SELECT top 1 [InventoryNumber], [PublicationDate], [Presence] FROM BookExemplar order by [Код] desc";

            myOleDbConnection.Open();

            OleDbDataReader dr = myOleDbCommand.ExecuteReader();

            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    resultString += string.Format("Инв. № {0}, Год издания: {1}, в наличии: {2}",
                               dr["InventoryNumber"].ToString(),
                               dr["PublicationDate"].ToString(),
                               dr["Presence"].ToString());
                }

            }

            return resultString;
        }


        public static void WriteStudent(Student student)
        {

            var con = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnect"];
            OleDbConnection myOleDbConnection = new OleDbConnection(con.ConnectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();


            myOleDbCommand.CommandText = "INSERT INTO Student ([IDStudentCard], [LastName], [Name], [SecondName], [Address], [PhoneNumber], [Faculty], [Course]) values ('"
                + student.IDStudentCard + "' , '" + student.LastName + "','" + student.Name + "','" + student.SecondName
                + "','" + student.Address + "','" + student.PhoneNumber + "','" + student.Faculty + "','" + student.Course + "')";

            myOleDbConnection.Open();

            myOleDbCommand.ExecuteNonQuery();
        }

        public static void WriteStudentPass(StudentPass studentPass)
        {

            var con = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnect"];
            OleDbConnection myOleDbConnection = new OleDbConnection(con.ConnectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            myOleDbCommand.CommandText = "INSERT INTO StudentPass ([IDPass], [IDLender], [IDStudent]) values ('" + studentPass.IDPass +
                "' , '" + studentPass.IDLibrary + "','" + studentPass.StudentInfo.IDStudentCard + "')";
            myOleDbConnection.Open();

            myOleDbCommand.ExecuteNonQuery();
        }

        public static void WriteTeacher(Teacher teacher)
        {

            var con = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnect"];
            OleDbConnection myOleDbConnection = new OleDbConnection(con.ConnectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            myOleDbCommand.CommandText = "INSERT INTO Teacher ([TeacherNumber], [LastName], [Name], [SecondName], [Address], [PhoneNumber], [Faculty], [Job]) values ('"
                + teacher.TeacherNumber + "' , '" + teacher.LastName + "','" + teacher.Name + "','" + teacher.SecondName
                + "','" + teacher.Address + "','" + teacher.PhoneNumber + "','" + teacher.Faculty + "','" + teacher.Job + "')";

            myOleDbConnection.Open();

            myOleDbCommand.ExecuteNonQuery();
        }

        public static void WriteTeacherPass(TeacherPass teacherPass)
        {
            var con = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnect"];
            OleDbConnection myOleDbConnection = new OleDbConnection(con.ConnectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            myOleDbCommand.CommandText = "INSERT INTO TeacherPass ([IDPass], [IDLender], [IDTeacher]) values ('" 
                + teacherPass.IDPass + "' , '" + teacherPass.IDLibrary + "','" + teacherPass.TeacherInfo.TeacherNumber + "')";
            myOleDbConnection.Open();

            myOleDbCommand.ExecuteNonQuery();

            myOleDbConnection.Close();
        }

        public static void DeleteBookExemplar(string inventoryNumber)

        {
            var con = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnect"];
            OleDbConnection myOleDbConnection = new OleDbConnection(con.ConnectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            int invNumb = int.Parse(inventoryNumber);

            myOleDbCommand.CommandText = "DELETE * FROM BookExemplar WHERE [Код] = " + invNumb;

            myOleDbConnection.Open();

            myOleDbCommand.ExecuteNonQuery();

            myOleDbConnection.Close();

        }


    }
}
