namespace SkladApp
{
    partial class Sklad
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
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbExistingProduct = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudStillage = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudCell = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSearchByName = new System.Windows.Forms.TextBox();
            this.btnSearchByName = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudSearchStillage = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nudSearchCell = new System.Windows.Forms.NumericUpDown();
            this.btnSearchByCoords = new System.Windows.Forms.Button();
            this.btnAddFromFields = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStillage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSearchStillage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSearchCell)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 45);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(492, 451);
            this.dgvProducts.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(517, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Новое наименование";
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(644, 42);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(126, 20);
            this.txtNewName.TabIndex = 2;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(790, 42);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "Добавить";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(517, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Наименование товара";
            // 
            // cmbExistingProduct
            // 
            this.cmbExistingProduct.FormattingEnabled = true;
            this.cmbExistingProduct.Location = new System.Drawing.Point(644, 77);
            this.cmbExistingProduct.Name = "cmbExistingProduct";
            this.cmbExistingProduct.Size = new System.Drawing.Size(121, 21);
            this.cmbExistingProduct.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(517, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Номер стеллажа";
            // 
            // nudStillage
            // 
            this.nudStillage.Location = new System.Drawing.Point(644, 116);
            this.nudStillage.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudStillage.Name = "nudStillage";
            this.nudStillage.Size = new System.Drawing.Size(120, 20);
            this.nudStillage.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(520, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Номер ячейки";
            // 
            // nudCell
            // 
            this.nudCell.Location = new System.Drawing.Point(644, 151);
            this.nudCell.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudCell.Name = "nudCell";
            this.nudCell.Size = new System.Drawing.Size(120, 20);
            this.nudCell.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(520, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Количество";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(644, 182);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 20);
            this.nudQuantity.TabIndex = 11;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(790, 182);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 12;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(515, 216);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(118, 23);
            this.btnDeleteSelected.TabIndex = 13;
            this.btnDeleteSelected.Text = "Удалить выбранное";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(767, 215);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(98, 23);
            this.btnSaveAs.TabIndex = 14;
            this.btnSaveAs.Text = "Сохранить как";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Добавить";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Товар";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(518, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Поиск по названию";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(520, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Имя товара для поиска";
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.Location = new System.Drawing.Point(664, 280);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.Size = new System.Drawing.Size(100, 20);
            this.txtSearchByName.TabIndex = 19;
            // 
            // btnSearchByName
            // 
            this.btnSearchByName.Location = new System.Drawing.Point(780, 280);
            this.btnSearchByName.Name = "btnSearchByName";
            this.btnSearchByName.Size = new System.Drawing.Size(75, 23);
            this.btnSearchByName.TabIndex = 20;
            this.btnSearchByName.Text = "Поиск";
            this.btnSearchByName.UseVisualStyleBackColor = true;
            this.btnSearchByName.Click += new System.EventHandler(this.btnSearchByName_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(518, 318);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Поиск по координатам";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(518, 342);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Стеллаж";
            // 
            // nudSearchStillage
            // 
            this.nudSearchStillage.Location = new System.Drawing.Point(518, 359);
            this.nudSearchStillage.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudSearchStillage.Name = "nudSearchStillage";
            this.nudSearchStillage.Size = new System.Drawing.Size(120, 20);
            this.nudSearchStillage.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(664, 342);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Ячейка";
            // 
            // nudSearchCell
            // 
            this.nudSearchCell.Location = new System.Drawing.Point(664, 359);
            this.nudSearchCell.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudSearchCell.Name = "nudSearchCell";
            this.nudSearchCell.Size = new System.Drawing.Size(120, 20);
            this.nudSearchCell.TabIndex = 25;
            // 
            // btnSearchByCoords
            // 
            this.btnSearchByCoords.Location = new System.Drawing.Point(802, 359);
            this.btnSearchByCoords.Name = "btnSearchByCoords";
            this.btnSearchByCoords.Size = new System.Drawing.Size(75, 23);
            this.btnSearchByCoords.TabIndex = 26;
            this.btnSearchByCoords.Text = "Поиск";
            this.btnSearchByCoords.UseVisualStyleBackColor = true;
            this.btnSearchByCoords.Click += new System.EventHandler(this.btnSearchByCoords_Click);
            // 
            // btnAddFromFields
            // 
            this.btnAddFromFields.Location = new System.Drawing.Point(654, 216);
            this.btnAddFromFields.Name = "btnAddFromFields";
            this.btnAddFromFields.Size = new System.Drawing.Size(75, 23);
            this.btnAddFromFields.TabIndex = 27;
            this.btnAddFromFields.Text = "Добавить";
            this.btnAddFromFields.UseVisualStyleBackColor = true;
            this.btnAddFromFields.Click += new System.EventHandler(this.btnAddFromFields_Click);
            // 
            // Sklad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 527);
            this.Controls.Add(this.btnAddFromFields);
            this.Controls.Add(this.btnSearchByCoords);
            this.Controls.Add(this.nudSearchCell);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nudSearchStillage);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSearchByName);
            this.Controls.Add(this.txtSearchByName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudCell);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudStillage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbExistingProduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProducts);
            this.Name = "Sklad";
            this.Text = "Складской учёт";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStillage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSearchStillage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSearchCell)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbExistingProduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudStillage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudCell;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSearchByName;
        private System.Windows.Forms.Button btnSearchByName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudSearchStillage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudSearchCell;
        private System.Windows.Forms.Button btnSearchByCoords;
        private System.Windows.Forms.Button btnAddFromFields;
    }
}

