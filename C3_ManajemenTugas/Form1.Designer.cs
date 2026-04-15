namespace C3_ManajemenTugas
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTugas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Deskripsi = new System.Windows.Forms.Label();
            this.txtJudul = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
            this.txtIDTugas = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTugas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTugas
            // 
            this.dgvTugas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTugas.Location = new System.Drawing.Point(129, 288);
            this.dgvTugas.Name = "dgvTugas";
            this.dgvTugas.RowHeadersWidth = 51;
            this.dgvTugas.RowTemplate.Height = 24;
            this.dgvTugas.Size = new System.Drawing.Size(495, 150);
            this.dgvTugas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Judul Tugas";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 3;
            // 
            // Deskripsi
            // 
            this.Deskripsi.AutoSize = true;
            this.Deskripsi.Location = new System.Drawing.Point(29, 88);
            this.Deskripsi.Name = "Deskripsi";
            this.Deskripsi.Size = new System.Drawing.Size(64, 16);
            this.Deskripsi.TabIndex = 4;
            this.Deskripsi.Text = "Deskripsi";
            // 
            // txtJudul
            // 
            this.txtJudul.Location = new System.Drawing.Point(116, 88);
            this.txtJudul.Multiline = true;
            this.txtJudul.Name = "txtJudul";
            this.txtJudul.Size = new System.Drawing.Size(151, 59);
            this.txtJudul.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Deadline";
            // 
            // dtpDeadline
            // 
            this.dtpDeadline.Location = new System.Drawing.Point(116, 164);
            this.dtpDeadline.Name = "dtpDeadline";
            this.dtpDeadline.Size = new System.Drawing.Size(200, 22);
            this.dtpDeadline.TabIndex = 7;
            // 
            // txtIDTugas
            // 
            this.txtIDTugas.Location = new System.Drawing.Point(116, 192);
            this.txtIDTugas.Name = "txtIDTugas";
            this.txtIDTugas.Size = new System.Drawing.Size(100, 22);
            this.txtIDTugas.TabIndex = 8;
            this.txtIDTugas.Visible = false;
            this.txtIDTugas.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtIDTugas);
            this.Controls.Add(this.dtpDeadline);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtJudul);
            this.Controls.Add(this.Deskripsi);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTugas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTugas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTugas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Deskripsi;
        private System.Windows.Forms.TextBox txtJudul;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDeadline;
        private System.Windows.Forms.TextBox txtIDTugas;
    }
}

