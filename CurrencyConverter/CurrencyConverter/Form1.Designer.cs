namespace CurrencyConverter
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblResultValue = new System.Windows.Forms.Label();
            this.lblRatesTitle = new System.Windows.Forms.Label();
            this.lblRateUSD = new System.Windows.Forms.Label();
            this.lblRateEUR = new System.Windows.Forms.Label();
            this.lblRateCNY = new System.Windows.Forms.Label();
            this.lblRateKRW = new System.Windows.Forms.Label();
            this.cmbFrom = new System.Windows.Forms.ComboBox();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnSwap = new System.Windows.Forms.Button();
            this.btnUpdateRates = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(129, 108);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(24, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Из:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(129, 153);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(17, 13);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "В:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(123, 193);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(44, 13);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "Сумма:";
            // 
            // lblResultValue
            // 
            this.lblResultValue.AutoSize = true;
            this.lblResultValue.Location = new System.Drawing.Point(123, 227);
            this.lblResultValue.Name = "lblResultValue";
            this.lblResultValue.Size = new System.Drawing.Size(62, 13);
            this.lblResultValue.TabIndex = 3;
            this.lblResultValue.Text = "Результат:";
            // 
            // lblRatesTitle
            // 
            this.lblRatesTitle.AutoSize = true;
            this.lblRatesTitle.Location = new System.Drawing.Point(123, 264);
            this.lblRatesTitle.Name = "lblRatesTitle";
            this.lblRatesTitle.Size = new System.Drawing.Size(108, 13);
            this.lblRatesTitle.TabIndex = 4;
            this.lblRatesTitle.Text = "Курсы валют к RUB";
            // 
            // lblRateUSD
            // 
            this.lblRateUSD.AutoSize = true;
            this.lblRateUSD.Location = new System.Drawing.Point(141, 318);
            this.lblRateUSD.Name = "lblRateUSD";
            this.lblRateUSD.Size = new System.Drawing.Size(48, 13);
            this.lblRateUSD.TabIndex = 5;
            this.lblRateUSD.Text = "1 USD =";
            // 
            // lblRateEUR
            // 
            this.lblRateEUR.AutoSize = true;
            this.lblRateEUR.Location = new System.Drawing.Point(138, 346);
            this.lblRateEUR.Name = "lblRateEUR";
            this.lblRateEUR.Size = new System.Drawing.Size(51, 13);
            this.lblRateEUR.TabIndex = 6;
            this.lblRateEUR.Text = "1 EUR = ";
            // 
            // lblRateCNY
            // 
            this.lblRateCNY.AutoSize = true;
            this.lblRateCNY.Location = new System.Drawing.Point(138, 372);
            this.lblRateCNY.Name = "lblRateCNY";
            this.lblRateCNY.Size = new System.Drawing.Size(47, 13);
            this.lblRateCNY.TabIndex = 7;
            this.lblRateCNY.Text = "1 CNY =";
            // 
            // lblRateKRW
            // 
            this.lblRateKRW.AutoSize = true;
            this.lblRateKRW.Location = new System.Drawing.Point(138, 397);
            this.lblRateKRW.Name = "lblRateKRW";
            this.lblRateKRW.Size = new System.Drawing.Size(51, 13);
            this.lblRateKRW.TabIndex = 8;
            this.lblRateKRW.Text = "1 KRW =";
            // 
            // cmbFrom
            // 
            this.cmbFrom.FormattingEnabled = true;
            this.cmbFrom.Location = new System.Drawing.Point(234, 105);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(121, 21);
            this.cmbFrom.TabIndex = 9;
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(234, 145);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(121, 21);
            this.cmbTo.TabIndex = 10;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(234, 185);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(121, 20);
            this.txtAmount.TabIndex = 11;
            // 
            // btnSwap
            // 
            this.btnSwap.Location = new System.Drawing.Point(383, 124);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(75, 23);
            this.btnSwap.TabIndex = 12;
            this.btnSwap.Text = "↔";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // btnUpdateRates
            // 
            this.btnUpdateRates.Location = new System.Drawing.Point(615, 397);
            this.btnUpdateRates.Name = "btnUpdateRates";
            this.btnUpdateRates.Size = new System.Drawing.Size(109, 23);
            this.btnUpdateRates.TabIndex = 13;
            this.btnUpdateRates.Text = "Обновить курсы";
            this.btnUpdateRates.UseVisualStyleBackColor = true;
            this.btnUpdateRates.Click += new System.EventHandler(this.btnUpdateRates_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdateRates);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.cmbFrom);
            this.Controls.Add(this.lblRateKRW);
            this.Controls.Add(this.lblRateCNY);
            this.Controls.Add(this.lblRateEUR);
            this.Controls.Add(this.lblRateUSD);
            this.Controls.Add(this.lblRatesTitle);
            this.Controls.Add(this.lblResultValue);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Name = "Form1";
            this.Text = "Конвертор валют";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblResultValue;
        private System.Windows.Forms.Label lblRatesTitle;
        private System.Windows.Forms.Label lblRateUSD;
        private System.Windows.Forms.Label lblRateEUR;
        private System.Windows.Forms.Label lblRateCNY;
        private System.Windows.Forms.Label lblRateKRW;
        private System.Windows.Forms.ComboBox cmbFrom;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.Button btnUpdateRates;
    }
}

