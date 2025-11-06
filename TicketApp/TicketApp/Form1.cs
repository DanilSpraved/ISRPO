using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicketApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int ticketNumber = random.Next(100000, 1000000); // Генерируем 6-значное число
            string ticketStr = ticketNumber.ToString();

            labelTicket.Text = ticketStr;

            // Вычисляем сумму первых и последних трёх цифр
            int sum1 = (ticketStr[0] - '0') + (ticketStr[1] - '0') + (ticketStr[2] - '0');
            int sum2 = (ticketStr[3] - '0') + (ticketStr[4] - '0') + (ticketStr[5] - '0');

            if (sum1 == sum2)
            {
                labelResult.Text = "Счастливый билет";
                labelResult.ForeColor = Color.Green;
            }
            else
            {
                labelResult.Text = "Обычный билет";
                labelResult.ForeColor = Color.Red;
            }
        }
    }
}