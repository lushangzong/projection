namespace projection
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.center_radioButton = new System.Windows.Forms.RadioButton();
            this.parallel_radioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.auto_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.original_button = new System.Windows.Forms.Button();
            this.quit_button = new System.Windows.Forms.Button();
            this.x_textBox = new System.Windows.Forms.TextBox();
            this.y_textBox = new System.Windows.Forms.TextBox();
            this.z_textBox = new System.Windows.Forms.TextBox();
            this.alpha_textBox = new System.Windows.Forms.TextBox();
            this.projection_button = new System.Windows.Forms.Button();
            this.axis_checkBox = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // center_radioButton
            // 
            resources.ApplyResources(this.center_radioButton, "center_radioButton");
            this.center_radioButton.Name = "center_radioButton";
            this.center_radioButton.UseVisualStyleBackColor = true;
            // 
            // parallel_radioButton
            // 
            resources.ApplyResources(this.parallel_radioButton, "parallel_radioButton");
            this.parallel_radioButton.Name = "parallel_radioButton";
            this.parallel_radioButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.label6.UseCompatibleTextRendering = true;
            // 
            // auto_button
            // 
            resources.ApplyResources(this.auto_button, "auto_button");
            this.auto_button.Name = "auto_button";
            this.auto_button.UseVisualStyleBackColor = true;
            this.auto_button.Click += new System.EventHandler(this.auto_button_Click);
            // 
            // stop_button
            // 
            resources.ApplyResources(this.stop_button, "stop_button");
            this.stop_button.Name = "stop_button";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // original_button
            // 
            resources.ApplyResources(this.original_button, "original_button");
            this.original_button.Name = "original_button";
            this.original_button.UseVisualStyleBackColor = true;
            this.original_button.Click += new System.EventHandler(this.original_button_Click);
            // 
            // quit_button
            // 
            resources.ApplyResources(this.quit_button, "quit_button");
            this.quit_button.Name = "quit_button";
            this.quit_button.UseVisualStyleBackColor = true;
            this.quit_button.Click += new System.EventHandler(this.quit_button_Click);
            // 
            // x_textBox
            // 
            resources.ApplyResources(this.x_textBox, "x_textBox");
            this.x_textBox.Name = "x_textBox";
            // 
            // y_textBox
            // 
            resources.ApplyResources(this.y_textBox, "y_textBox");
            this.y_textBox.Name = "y_textBox";
            // 
            // z_textBox
            // 
            resources.ApplyResources(this.z_textBox, "z_textBox");
            this.z_textBox.Name = "z_textBox";
            // 
            // alpha_textBox
            // 
            resources.ApplyResources(this.alpha_textBox, "alpha_textBox");
            this.alpha_textBox.Name = "alpha_textBox";
            // 
            // projection_button
            // 
            resources.ApplyResources(this.projection_button, "projection_button");
            this.projection_button.Name = "projection_button";
            this.projection_button.UseVisualStyleBackColor = true;
            this.projection_button.Click += new System.EventHandler(this.projection_button_Click);
            // 
            // axis_checkBox
            // 
            resources.ApplyResources(this.axis_checkBox, "axis_checkBox");
            this.axis_checkBox.Name = "axis_checkBox";
            this.axis_checkBox.UseVisualStyleBackColor = true;
            this.axis_checkBox.CheckedChanged += new System.EventHandler(this.axis_checkBox_CheckedChanged);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_tick);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axis_checkBox);
            this.Controls.Add(this.projection_button);
            this.Controls.Add(this.alpha_textBox);
            this.Controls.Add(this.z_textBox);
            this.Controls.Add(this.y_textBox);
            this.Controls.Add(this.x_textBox);
            this.Controls.Add(this.quit_button);
            this.Controls.Add(this.original_button);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.auto_button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.parallel_radioButton);
            this.Controls.Add(this.center_radioButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton center_radioButton;
        private System.Windows.Forms.RadioButton parallel_radioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button auto_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Button original_button;
        private System.Windows.Forms.Button quit_button;
        private System.Windows.Forms.TextBox x_textBox;
        private System.Windows.Forms.TextBox y_textBox;
        private System.Windows.Forms.TextBox z_textBox;
        private System.Windows.Forms.TextBox alpha_textBox;
        private System.Windows.Forms.Button projection_button;
        private System.Windows.Forms.CheckBox axis_checkBox;
        private System.Windows.Forms.Timer timer;
    }
}

