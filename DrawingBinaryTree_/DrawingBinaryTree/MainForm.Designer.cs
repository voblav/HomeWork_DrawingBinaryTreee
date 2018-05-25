namespace DrawingBinaryTree
{
    partial class MainForm
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
            this.TxtItem = new System.Windows.Forms.TextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtItem
            // 
            this.TxtItem.Location = new System.Drawing.Point(560, 30);
            this.TxtItem.Name = "TxtItem";
            this.TxtItem.Size = new System.Drawing.Size(100, 20);
            this.TxtItem.TabIndex = 0;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(570, 60);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.Location = new System.Drawing.Point(570, 89);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(75, 23);
            this.BtnDel.TabIndex = 2;
            this.BtnDel.Text = "Delete";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.RemoveItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 321);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.TxtItem);
            this.Name = "MainForm";
            this.Text = "Drawing a Binary Tree";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtItem;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnDel;
    }
}

