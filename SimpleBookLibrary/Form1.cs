using System.Text.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SimpleBookLibrary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Book> books = new List<Book>();
        private readonly string path = Path.Combine(Application.StartupPath, "books.json"); // Path to the JSON file with book data.



        private void button1_Click(object sender, EventArgs e)  // Add Book Button.
        {
            string title = textBox1.Text;
            string author = textBox2.Text;
            if (!int.TryParse(textBox3.Text, out int year))
            {
                MessageBox.Show("Невірний рік!");
                return;
            }

            Book book = new Book { Title = title, Author = author, Year = year };
            books.Add(book);
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.DataSource = books;
        }

        private void button3_Click(object sender, EventArgs e)  // Load Books Button.
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText("books.json");
                books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
                UpdateGrid();
                MessageBox.Show("Завантажено!");
            }
        }

        private void bookAuthor_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)   // Save Books Button.
        {
            string json = JsonSerializer.Serialize(books);
            File.WriteAllText(path, json);
            MessageBox.Show("Збережено!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxTitle_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow != null)
            {
                int index = dataGridViewBooks.CurrentRow.Index;
                if (index >= 0 && index < books.Count)
                {
                    var result = MessageBox.Show("Ви впевнені, що хочете видалити цю книгу?", "Підтвердження", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        books.RemoveAt(index);
                        UpdateGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть книгу для видалення.");
            }
        }
    }
    [Serializable]
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }

}
