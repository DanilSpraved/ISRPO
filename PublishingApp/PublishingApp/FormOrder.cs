using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PublishingApp.Models;
using PublishingApp;

namespace PublishingApp
{
    public partial class FormOrder : Form
    {
        private readonly Book _selectedBook;
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public FormOrder(Book book)
        {
            InitializeComponent();
            _selectedBook = book;
            LoadOffices();
            InitializeBookInfo();
        }

        // Инициализация информации о книге
        private void InitializeBookInfo()
        {
            textBoxBookTitle.Text = _selectedBook.Title;
            textBoxAuthor.Text = _selectedBook.AuthorName;
        }

        // Загрузка офисов в ComboBox
        private void LoadOffices()
        {
            var offices = _dbHelper.GetOffices();
            comboBoxOffice.DataSource = offices;
            comboBoxOffice.DisplayMember = "Name"; // Что показывать пользователю
            comboBoxOffice.ValueMember = "Id";     // Какое значение хранить (Id_Office)
        }

        // Кнопка «Рассчитать»
        // Исправлено: заменено "NumericUpDown.Value" на "numericUpDownQuantity.Value"
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (_selectedBook == null) return;

            // Пример: 1 лист = 2 рубля, количество = 1 (фиксировано для ЛР)
            decimal price = _selectedBook.Pages * 2.0m;
            if (price > numericUpDownPrice.Maximum)
                numericUpDownPrice.Maximum = price;
            numericUpDownPrice.Value = price;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCustomerName.Text))
            {
                MessageBox.Show("Укажите ФИО клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxOffice.SelectedItem == null)
            {
                MessageBox.Show("Выберите офис получения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаём клиента
            var customer = new Customer
            {
                Name = textBoxCustomerName.Text,
                Address = textBoxAddress.Text,
                Phone = textBoxPhone.Text,
                Type = "Частное лицо"
            };

            int customerId = _dbHelper.CreateCustomer(customer);

            // Создаём заказ
            var order = new Order
            {
                OrderName = $"Предзаказ: {_selectedBook.Title}",
                Type = "Книга",
                BookTitle = _selectedBook.Title,
                CustomerName = customer.Name,
                OfficeName = ((Office)comboBoxOffice.SelectedItem).Name,
                OrderDate = DateTime.Now,
                CompletionDate = DateTime.Now.AddDays(30),
                Price = (decimal)numericUpDownPrice.Value
            };

            int orderId = _dbHelper.CreateOrder(order);

            // Открываем чек
            var receiptForm = new FormReceipt(orderId);
            receiptForm.Show();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {

        }
    }
}