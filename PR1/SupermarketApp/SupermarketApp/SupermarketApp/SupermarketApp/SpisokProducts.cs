using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SupermarketApp
{
    public partial class SpisokProducts : Form
    {
        // Строка подключения для SQL Server Express (самый частый случай)
        private string connectionString = @"Server=.\SQLEXPRESS;Database=supermarket;Trusted_Connection=True;";

        public SpisokProducts()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            cmbProducts.Items.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT id, name, price FROM products", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbProducts.Items.Add(new Product
                            {
                                Id = (int)reader["id"],
                                Name = reader["name"].ToString().Trim(),
                                Price = (decimal)reader["price"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem is Product p)
                lstSelectedProducts.Items.Add(p);
            else
                MessageBox.Show("Выберите продукт.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstSelectedProducts.Items.Clear();
            textBox1txtTotal.Text = "";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal sum = 0;
            foreach (Product p in lstSelectedProducts.Items)
                sum += p.Price;
            textBox1txtTotal.Text = sum.ToString("C");
        }
    }
}