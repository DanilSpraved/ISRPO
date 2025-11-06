using System;
using System.Linq;
using System.Windows.Forms;

namespace CaesarCipherApp
{
    public partial class Form1 : Form
    {
        private const string RUSSIAN = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private const string ENGLISH = "abcdefghijklmnopqrstuvwxyz";

        public Form1()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            comboBoxLang.Items.Add("Русский");
            comboBoxLang.Items.Add("Английский");
            comboBoxLang.SelectedIndex = 0; // По умолчанию — Русский

            textBoxShift.Text = "0"; // Сдвиг по умолчанию
        }

        private string GetAlphabet()
        {
            return comboBoxLang.SelectedItem?.ToString() == "Русский" ? RUSSIAN : ENGLISH;
        }

        private int GetShift()
        {
            if (!int.TryParse(textBoxShift.Text, out int shift))
                throw new ArgumentException("Сдвиг должен быть целым числом.");
            if (shift < 1 || shift > 10)
                throw new ArgumentException("Сдвиг должен быть от 1 до 10.");
            return shift;
        }

        private string Caesar(string text, int shift, string alphabet, bool decrypt = false)
        {
            if (string.IsNullOrEmpty(text)) return text;

            if (decrypt) shift = -shift;
            int n = alphabet.Length;
            char[] result = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                bool isUpper = char.IsUpper(c);
                char lower = char.ToLower(c);

                if (alphabet.Contains(lower))
                {
                    int idx = alphabet.IndexOf(lower);
                    int newIndex = (idx + shift) % n;
                    if (newIndex < 0) newIndex += n;
                    char newChar = alphabet[newIndex];
                    result[i] = isUpper ? char.ToUpper(newChar) : newChar;
                }
                else
                {
                    result[i] = c; // Остальное без изменений
                }
            }
            return new string(result);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            ProcessText(decrypt: false);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            ProcessText(decrypt: true);
        }

        private void ProcessText(bool decrypt)
        {
            string input = textBoxInput.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите текст для обработки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int shift = GetShift();
                string alphabet = GetAlphabet();
                string result = Caesar(input, shift, alphabet, decrypt);
                textBoxOutput.Text = result;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxInput.Clear();
            textBoxOutput.Clear();
            textBoxShift.Text = "3"; // Сбрасываем сдвиг на значение по умолчанию
        }
    }
}