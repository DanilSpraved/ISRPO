using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        // Базовые переменные
        private double firstOperand = 0;
        private string pendingOperation = "";
        private bool isNewInput = true;

        // Научные функции
        private double lastResult = 0;
        private List<double> memoryForSum = new List<double>(); // не используется напрямую, но можно расширить

        public Form1()
        {
            InitializeComponent();
            txtDisplay.Text = "0";
        }

        // === Общие вспомогательные методы ===

        private void SetDisplayText(string text)
        {
            txtDisplay.Text = text;
            isNewInput = true;
        }

        private bool TryGetOperand(out double value)
        {
            if (double.TryParse(txtDisplay.Text, out value))
                return true;
            SetDisplayText("Ошибка");
            return false;
        }

        // === Цифры и точка ===

        private void btnDigit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (isNewInput || txtDisplay.Text == "0" || txtDisplay.Text == "Ошибка")
            {
                txtDisplay.Text = btn.Text;
                isNewInput = false;
            }
            else
            {
                txtDisplay.Text += btn.Text;
            }
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (isNewInput || txtDisplay.Text == "Ошибка")
            {
                txtDisplay.Text = "0.";
                isNewInput = false;
            }
            else if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        // === Очистка ===

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            firstOperand = 0;
            pendingOperation = "";
            isNewInput = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "Ошибка") return;
            if (txtDisplay.Text.Length > 1)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            else
            {
                txtDisplay.Text = "0";
            }
        }

        // === Базовые операции ===

        private void btnOperation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!TryGetOperand(out firstOperand)) return;

            pendingOperation = btn.Text;
            isNewInput = true;
        }

        // === Возведение в степень — отдельно, т.к. не бинарный в стандартном виде ===

        private void btnPower_Click(object sender, EventArgs e)
        {
            if (!TryGetOperand(out firstOperand)) return;
            pendingOperation = "^";
            isNewInput = true;
        }

        // === Равно ===

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (!TryGetOperand(out double secondOperand)) return;

            double result = 0;
            bool success = true;

            switch (pendingOperation)
            {
                case "+": result = firstOperand + secondOperand; break;
                case "-": result = firstOperand - secondOperand; break;
                case "*": result = firstOperand * secondOperand; break;
                case "/":
                    if (secondOperand == 0)
                    {
                        SetDisplayText("Деление на 0");
                        return;
                    }
                    result = firstOperand / secondOperand;
                    break;
                case "^": result = Math.Pow(firstOperand, secondOperand); break;
                default:
                    // Если нет операции — просто сохраняем как число
                    result = secondOperand;
                    break;
            }

            // Форматируем результат
            if (double.IsInfinity(result) || double.IsNaN(result))
            {
                SetDisplayText("Ошибка");
            }
            else
            {
                // Убираем лишние нули
                string formatted = result.ToString("G15");
                SetDisplayText(formatted);
                lastResult = result;
            }

            pendingOperation = "";
        }

        // === Научные функции (работают с текущим значением) ===

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (!TryGetOperand(out double x)) return;
            if (x < 0)
            {
                SetDisplayText("√ из отриц.");
                return;
            }
            SetDisplayText(Math.Sqrt(x).ToString("G15"));
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            if (!TryGetOperand(out double x)) return;
            double rad = x * Math.PI / 180.0;
            SetDisplayText(Math.Sin(rad).ToString("G15"));
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            if (!TryGetOperand(out double x)) return;
            double rad = x * Math.PI / 180.0;
            SetDisplayText(Math.Cos(rad).ToString("G15"));
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            if (!TryGetOperand(out double x)) return;
            double rad = x * Math.PI / 180.0;
            double cos = Math.Cos(rad);
            if (Math.Abs(cos) < 1e-10)
            {
                SetDisplayText("Ошибка tan");
                return;
            }
            SetDisplayText(Math.Tan(rad).ToString("G15"));
        }

        private void btnLn_Click(object sender, EventArgs e)
        {
            if (!TryGetOperand(out double x)) return;
            if (x <= 0)
            {
                SetDisplayText("ln ≤ 0");
                return;
            }
            SetDisplayText(Math.Log(x).ToString("G15"));
        }

        private void btnLog10_Click(object sender, EventArgs e)
        {
            if (!TryGetOperand(out double x)) return;
            if (x <= 0)
            {
                SetDisplayText("log ≤ 0");
                return;
            }
            SetDisplayText(Math.Log10(x).ToString("G15"));
        }

        private void btnAbs_Click(object sender, EventArgs e)
        {
            if (!TryGetOperand(out double x)) return;
            SetDisplayText(Math.Abs(x).ToString("G15"));
        }

        private void btnNegate_Click(object sender, EventArgs e)
        {
            if (!TryGetOperand(out double x)) return;
            SetDisplayText((-x).ToString("G15"));
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            SetDisplayText(Math.PI.ToString("G15"));
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            SetDisplayText(Math.E.ToString("G15"));
        }

        private void btnAns_Click(object sender, EventArgs e)
        {
            SetDisplayText(lastResult.ToString("G15"));
        }

        // === Скобки — пока только ввод (без парсинга выражения) ===

        private void btnOpenBracket_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0" || isNewInput)
                txtDisplay.Text = "(";
            else
                txtDisplay.Text += "(";
            isNewInput = false;
        }

        private void btnCloseBracket_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += ")";
            isNewInput = false;
        }
    }
}