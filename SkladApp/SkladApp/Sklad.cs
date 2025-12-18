using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SkladApp
{
    public partial class Sklad : Form
    {
        private string connectionString = @"Server=.\SQLEXPRESS;Database=sklad;Trusted_Connection=True;";
               

        public Sklad()
        {
            InitializeComponent();
            InitializeDataGridViewColumns(); // 👈 Обязательно!
            LoadProductsToGrid();
            LoadProductNamesIntoComboBox();
        }

        private void InitializeDataGridViewColumns()
        {
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add("NameColumn", "Наименование товара");
            dgvProducts.Columns.Add("StillageColumn", "Номер стеллажа");
            dgvProducts.Columns.Add("CellColumn", "Номер ячейки");
            dgvProducts.Columns.Add("QuantityColumn", "Количество");

            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.AllowUserToAddRows = false;

           
            dgvProducts.Dock = DockStyle.None;

          
            dgvProducts.Width = 450;
            dgvProducts.Height = 300;

          
            dgvProducts.Location = new System.Drawing.Point(12, 12);
        }

        private void LoadProductsToGrid()
        {
            dgvProducts.Rows.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT id, name, stillage, cell, quantity FROM products", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idx = dgvProducts.Rows.Add(
                                reader["name"].ToString().Trim(),
                                reader["stillage"],
                                reader["cell"],
                                reader["quantity"]
                            );
                            dgvProducts.Rows[idx].Tag = reader["id"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductNamesIntoComboBox()
        {
            cmbExistingProduct.Items.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT name FROM products", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbExistingProduct.Items.Add(reader["name"].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка товаров:\n{ex.Message}");
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            string name = txtNewName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите название товара.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO products (name, stillage, cell, quantity) VALUES (@name, @s, @c, @q)", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@s", (int)nudStillage.Value);
                        cmd.Parameters.AddWithValue("@c", (int)nudCell.Value);
                        cmd.Parameters.AddWithValue("@q", (int)nudQuantity.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Товар добавлен!");
                LoadProductsToGrid();
                txtNewName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        private void btnAddFromFields_Click(object sender, EventArgs e)
        {
            string name = cmbExistingProduct.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Выберите или введите название товара.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO products (name, stillage, cell, quantity) VALUES (@name, @s, @c, @q)", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@s", (int)nudStillage.Value);
                        cmd.Parameters.AddWithValue("@c", (int)nudCell.Value);
                        cmd.Parameters.AddWithValue("@q", (int)nudQuantity.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Запись добавлена!");
                LoadProductsToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку.");
                return;
            }

            var row = dgvProducts.SelectedRows[0];
            cmbExistingProduct.Text = row.Cells[0].Value?.ToString() ?? "";
            nudStillage.Value = Convert.ToDecimal(row.Cells[1].Value);
            nudCell.Value = Convert.ToDecimal(row.Cells[2].Value);
            nudQuantity.Value = Convert.ToDecimal(row.Cells[3].Value);
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для удаления.");
                return;
            }

            var row = dgvProducts.SelectedRows[0];
            int id = (int)row.Tag;

            if (MessageBox.Show($"Удалить запись?\nТовар: {row.Cells[0].Value}", "Подтверждение",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM products WHERE id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Удалено!");
                    LoadProductsToGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message);
                }
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Текстовые файлы (*.txt)|*.txt";
                sfd.FileName = "sklad.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var sw = new StreamWriter(sfd.FileName))
                    {
                        foreach (DataGridViewRow r in dgvProducts.Rows)
                        {
                            sw.WriteLine($"{r.Cells[0].Value}\t{r.Cells[1].Value}\t{r.Cells[2].Value}\t{r.Cells[3].Value}");
                        }
                    }
                    MessageBox.Show("Сохранено!");
                }
            }
        }

        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            string term = txtSearchByName.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(term)) return;

            foreach (DataGridViewRow r in dgvProducts.Rows)
            {
                if (r.Cells[0].Value?.ToString().ToLower().Contains(term) == true)
                {
                    dgvProducts.ClearSelection();
                    r.Selected = true;
                    dgvProducts.FirstDisplayedScrollingRowIndex = r.Index;
                    return;
                }
            }
            MessageBox.Show("Не найдено.");
        }

        private void btnSearchByCoords_Click(object sender, EventArgs e)
        {
            int s = (int)nudSearchStillage.Value;
            int c = (int)nudSearchCell.Value;

            foreach (DataGridViewRow r in dgvProducts.Rows)
            {
                if (Convert.ToInt32(r.Cells[1].Value) == s && Convert.ToInt32(r.Cells[2].Value) == c)
                {
                    dgvProducts.ClearSelection();
                    r.Selected = true;
                    dgvProducts.FirstDisplayedScrollingRowIndex = r.Index;
                    return;
                }
            }
            MessageBox.Show("Не найдено.");
        }
    }
}