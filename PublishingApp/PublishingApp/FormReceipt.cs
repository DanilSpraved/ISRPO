using System;
using System.Windows.Forms;
using PublishingApp;

namespace PublishingApp
{
    public partial class FormReceipt : Form
    {
        private readonly int _orderId;
        private Button btnPrint;
        private Button btnClose;

        public FormReceipt(int orderId)
        {
            _orderId = orderId;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(162, 334);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(180, 30);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Печать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(373, 334);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormReceipt
            // 
            this.ClientSize = new System.Drawing.Size(771, 376);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Чек";
            this.Load += new System.EventHandler(this.FormReceipt_Load);
            this.ResumeLayout(false);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var dbHelper = new DatabaseHelper();
            var order = dbHelper.GetOrderDetails(_orderId);

            if (order == null)
            {
                MessageBox.Show("Не удалось загрузить данные заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string receipt = $@"
ЧЕК №{_orderId}
Дата: {DateTime.Now:dd.MM.yyyy}

Клиент: {order.CustomerName}
Книга: {order.BookTitle}
Офис: {order.OfficeName}
Сумма: {order.Price:C}

Спасибо за предзаказ!
".Trim();

            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Сохранить чек";
                dialog.FileName = $"Чек_заказ_{_orderId}.txt";
                dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                dialog.DefaultExt = "txt";
                dialog.AddExtension = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.WriteAllText(dialog.FileName, receipt);
                        MessageBox.Show($"Чек успешно сохранён:\n{dialog.FileName}",
                                        "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении:\n{ex.Message}",
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormReceipt_Load(object sender, EventArgs e)
        {

        }
    }
}