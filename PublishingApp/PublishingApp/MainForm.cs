using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PublishingApp.Models;
using PublishingApp;

namespace PublishingApp
{
    public partial class MainForm : Form
    {
        private DatabaseHelper _dbHelper;

        public MainForm()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            LoadBooks();
            dataGridViewBooks.SelectionChanged += dataGridViewBooks_SelectionChanged;
        }

        private void LoadBooks()
        {
            var dbHelper = new DatabaseHelper();
            var books = dbHelper.GetBooks();
            dataGridViewBooks.DataSource = books;
        }

        private void dataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow?.DataBoundItem is Book book)
            {
                textBoxTitle.Text = book.Title;
                textBoxAuthor.Text = book.AuthorName;
                textBoxYear.Text = book.ReleaseYear.ToString();
            }
            else
            {
                textBoxTitle.Clear();
                textBoxAuthor.Clear();
                textBoxYear.Clear();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow?.DataBoundItem is Book selectedBook)
            {
                using (var formOrder = new FormOrder(selectedBook))
                {
                    formOrder.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите книгу для предзаказа.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}