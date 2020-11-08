namespace Lab6
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
            this.components = new System.ComponentModel.Container();
            this.IMG1 = new Emgu.CV.UI.ImageBox();
            this.load = new System.Windows.Forms.Button();
            this.vtimer = new System.Windows.Forms.Timer(this.components);
            this.backb = new System.Windows.Forms.Button();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.webcam = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IMG1)).BeginInit();
            this.SuspendLayout();
            // 
            // IMG1
            // 
            this.IMG1.Location = new System.Drawing.Point(12, 12);
            this.IMG1.Name = "IMG1";
            this.IMG1.Size = new System.Drawing.Size(640, 480);
            this.IMG1.TabIndex = 2;
            this.IMG1.TabStop = false;
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(658, 12);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(146, 23);
            this.load.TabIndex = 3;
            this.load.Text = "Load Video";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // vtimer
            // 
            this.vtimer.Interval = 30;
            this.vtimer.Tick += new System.EventHandler(this.vtimer_Tick);
            // 
            // backb
            // 
            this.backb.Location = new System.Drawing.Point(658, 70);
            this.backb.Name = "backb";
            this.backb.Size = new System.Drawing.Size(146, 23);
            this.backb.TabIndex = 4;
            this.backb.Text = "Background";
            this.backb.UseVisualStyleBackColor = true;
            this.backb.Click += new System.EventHandler(this.backb_Click);
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(658, 99);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(62, 17);
            this.rb1.TabIndex = 5;
            this.rb1.TabStop = true;
            this.rb1.Text = "Filter off";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(658, 122);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(88, 17);
            this.rb2.TabIndex = 6;
            this.rb2.Text = "Diffusual filter";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(658, 145);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(105, 17);
            this.rb3.TabIndex = 7;
            this.rb3.Text = "Background filter";
            this.rb3.UseVisualStyleBackColor = true;
            this.rb3.CheckedChanged += new System.EventHandler(this.rb3_CheckedChanged);
            // 
            // webcam
            // 
            this.webcam.Location = new System.Drawing.Point(658, 41);
            this.webcam.Name = "webcam";
            this.webcam.Size = new System.Drawing.Size(146, 23);
            this.webcam.TabIndex = 8;
            this.webcam.Text = "Web Camera";
            this.webcam.UseVisualStyleBackColor = true;
            this.webcam.Click += new System.EventHandler(this.webcam_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 503);
            this.Controls.Add(this.webcam);
            this.Controls.Add(this.rb3);
            this.Controls.Add(this.rb2);
            this.Controls.Add(this.rb1);
            this.Controls.Add(this.backb);
            this.Controls.Add(this.load);
            this.Controls.Add(this.IMG1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.IMG1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox IMG1;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Timer vtimer;
        private System.Windows.Forms.Button backb;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.Button webcam;
    }
}

