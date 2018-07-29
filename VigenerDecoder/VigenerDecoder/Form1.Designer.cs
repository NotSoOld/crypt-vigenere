namespace VigenerDecoder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox = new System.Windows.Forms.TextBox();
            this.letterCnt = new System.Windows.Forms.NumericUpDown();
            this.shifts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.letterCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shifts)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Consolas", 13F);
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(1284, 571);
            this.textBox.TabIndex = 0;
            // 
            // letterCnt
            // 
            this.letterCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.letterCnt.Location = new System.Drawing.Point(12, 589);
            this.letterCnt.Name = "letterCnt";
            this.letterCnt.Size = new System.Drawing.Size(72, 34);
            this.letterCnt.TabIndex = 1;
            this.letterCnt.ValueChanged += new System.EventHandler(this.letterCnt_ValueChanged);
            // 
            // shifts
            // 
            this.shifts.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.shifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shifts.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.shifts.DefaultCellStyle = dataGridViewCellStyle2;
            this.shifts.Location = new System.Drawing.Point(106, 608);
            this.shifts.Name = "shifts";
            this.shifts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.shifts.RowHeadersVisible = false;
            this.shifts.RowTemplate.Height = 24;
            this.shifts.Size = new System.Drawing.Size(1190, 118);
            this.shifts.TabIndex = 2;
            this.shifts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.shifts_CellValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1308, 738);
            this.Controls.Add(this.shifts);
            this.Controls.Add(this.letterCnt);
            this.Controls.Add(this.textBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.letterCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shifts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.NumericUpDown letterCnt;
        private System.Windows.Forms.DataGridView shifts;
    }
}

