namespace HotelKyrsovaya
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_room = new System.Windows.Forms.Button();
            this.btn_visitor = new System.Windows.Forms.Button();
            this.btn_bron = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_room
            // 
            this.btn_room.BackColor = System.Drawing.Color.Tan;
            this.btn_room.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_room.FlatAppearance.BorderSize = 3;
            this.btn_room.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Peru;
            this.btn_room.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Peru;
            this.btn_room.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_room.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold);
            this.btn_room.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_room.Location = new System.Drawing.Point(45, 142);
            this.btn_room.Name = "btn_room";
            this.btn_room.Size = new System.Drawing.Size(153, 89);
            this.btn_room.TabIndex = 2;
            this.btn_room.Text = "Номера";
            this.btn_room.UseVisualStyleBackColor = false;
            this.btn_room.Click += new System.EventHandler(this.Btn_room_Click);
            // 
            // btn_visitor
            // 
            this.btn_visitor.BackColor = System.Drawing.Color.Tan;
            this.btn_visitor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_visitor.FlatAppearance.BorderSize = 3;
            this.btn_visitor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Peru;
            this.btn_visitor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Peru;
            this.btn_visitor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_visitor.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold);
            this.btn_visitor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_visitor.Location = new System.Drawing.Point(234, 142);
            this.btn_visitor.Name = "btn_visitor";
            this.btn_visitor.Size = new System.Drawing.Size(147, 89);
            this.btn_visitor.TabIndex = 5;
            this.btn_visitor.Text = "Посетители";
            this.btn_visitor.UseVisualStyleBackColor = false;
            this.btn_visitor.Click += new System.EventHandler(this.Btn_visitor_Click);
            // 
            // btn_bron
            // 
            this.btn_bron.BackColor = System.Drawing.Color.Tan;
            this.btn_bron.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_bron.FlatAppearance.BorderSize = 3;
            this.btn_bron.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Peru;
            this.btn_bron.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Peru;
            this.btn_bron.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_bron.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold);
            this.btn_bron.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_bron.Location = new System.Drawing.Point(418, 142);
            this.btn_bron.Name = "btn_bron";
            this.btn_bron.Size = new System.Drawing.Size(147, 89);
            this.btn_bron.TabIndex = 6;
            this.btn_bron.Text = "Заселение";
            this.btn_bron.UseVisualStyleBackColor = false;
            this.btn_bron.Click += new System.EventHandler(this.btn_bron_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(72)))), ((int)(((byte)(46)))));
            this.panel2.BackgroundImage = global::HotelKyrsovaya.Properties.Resources._1674528339_catherineasquithgallery_com_p_fon_derevo_korichnevoe_171;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(602, 99);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Tan;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 17F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(187, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Эко-отель «РИВЕР»";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HotelKyrsovaya.Properties.Resources._8;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1, 271);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(602, 249);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(121)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(602, 540);
            this.Controls.Add(this.btn_bron);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_visitor);
            this.Controls.Add(this.btn_room);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Эко-отель ";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_room;
        private System.Windows.Forms.Button btn_visitor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_bron;
    }
}

