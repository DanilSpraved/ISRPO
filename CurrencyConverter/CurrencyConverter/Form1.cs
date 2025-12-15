using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CurrencyConverter
{
    public partial class Form1 : Form
    {
        private Dictionary<string, double> rates = new Dictionary<string, double>
        {
            { "RUB", 1.0 },
            { "USD", 90.0 },
            { "EUR", 98.0 },
            { "CNY", 12.5 },
            { "KRW", 0.067 } // Примерный курс
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] currencies = { "RUB", "USD", "EUR", "CNY", "KRW" };

            cmbFrom.Items.AddRange(currencies);
            cmbTo.Items.AddRange(currencies);

            cmbFrom.SelectedIndex = 1; // USD
            cmbTo.SelectedIndex = 0;   // RUB

            UpdateRatesDisplay();
        }

        private void Recalculate()
        {
            if (cmbFrom.SelectedItem == null || cmbTo.SelectedItem == null)
            {
                lblResultValue.Text = "";
                return;
            }

            string input = txtAmount.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                lblResultValue.Text = "";
                return;
            }

            if (!double.TryParse(input, out double amount))
            {
                lblResultValue.Text = "Ошибка: введите число";
                return;
            }

            if (amount < 0)
            {
                lblResultValue.Text = "Сумма не может быть отрицательной";
                return;
            }

            string from = cmbFrom.SelectedItem.ToString();
            string to = cmbTo.SelectedItem.ToString();

            double fromRate = rates[from];
            double toRate = rates[to];

            double result = (amount * fromRate) / toRate;

            lblResultValue.Text = $"{result:F2} {to}";
        }

        private void UpdateRatesDisplay()
        {
            lblRateUSD.Text = $"1 USD = {rates["USD"]:#.###} RUB";
            lblRateEUR.Text = $"1 EUR = {rates["EUR"]:#.###} RUB";
            lblRateCNY.Text = $"1 CNY = {rates["CNY"]:#.###} RUB";
            lblRateKRW.Text = $"1 KRW = {rates["KRW"]:#.###} RUB";
        }

        // === Обработчики событий ===

        // ❌ УБРАЛИ: txtAmount_TextChanged, cmbFrom_SelectedIndexChanged, cmbTo_SelectedIndexChanged
        // Пересчёт теперь только по кнопке!

        private void btnSwap_Click(object sender, EventArgs e)
        {
            // Это НЕ кнопка "поменять местами"!
            // Это КНОПКА "Рассчитать" — просто с символом ↔
            Recalculate();
        }

        private void btnUpdateRates_Click(object sender, EventArgs e)
        {
            UpdateRatesDisplay();
        }
    }
}