namespace TeklaOpenApiDrawing
{
    partial class ModifyDrawing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyDrawing));
            this.drawTitle = new System.Windows.Forms.TextBox();
            this.btn_Title = new System.Windows.Forms.Button();
            this.btn_Size = new System.Windows.Forms.Button();
            this.drawSize_w = new System.Windows.Forms.TextBox();
            this.drawSize_h = new System.Windows.Forms.TextBox();
            this.drawingName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // drawTitle
            // 
            this.drawTitle.Location = new System.Drawing.Point(12, 12);
            this.drawTitle.Name = "drawTitle";
            this.drawTitle.Size = new System.Drawing.Size(152, 25);
            this.drawTitle.TabIndex = 0;
            // 
            // btn_Title
            // 
            this.btn_Title.Location = new System.Drawing.Point(170, 12);
            this.btn_Title.Name = "btn_Title";
            this.btn_Title.Size = new System.Drawing.Size(116, 25);
            this.btn_Title.TabIndex = 1;
            this.btn_Title.Text = "修改图纸标题";
            this.btn_Title.UseVisualStyleBackColor = true;
            this.btn_Title.Click += new System.EventHandler(this.btn_Title_Click);
            // 
            // btn_Size
            // 
            this.btn_Size.Location = new System.Drawing.Point(170, 41);
            this.btn_Size.Name = "btn_Size";
            this.btn_Size.Size = new System.Drawing.Size(116, 25);
            this.btn_Size.TabIndex = 2;
            this.btn_Size.Text = "修改图纸大小";
            this.btn_Size.UseVisualStyleBackColor = true;
            this.btn_Size.Click += new System.EventHandler(this.btn_Size_Click);
            // 
            // drawSize_w
            // 
            this.drawSize_w.Location = new System.Drawing.Point(12, 43);
            this.drawSize_w.Name = "drawSize_w";
            this.drawSize_w.Size = new System.Drawing.Size(73, 25);
            this.drawSize_w.TabIndex = 3;
            // 
            // drawSize_h
            // 
            this.drawSize_h.Location = new System.Drawing.Point(91, 43);
            this.drawSize_h.Name = "drawSize_h";
            this.drawSize_h.Size = new System.Drawing.Size(73, 25);
            this.drawSize_h.TabIndex = 4;
            // 
            // drawingName
            // 
            this.drawingName.Location = new System.Drawing.Point(12, 74);
            this.drawingName.Name = "drawingName";
            this.drawingName.Size = new System.Drawing.Size(152, 25);
            this.drawingName.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "修改图纸名称";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(170, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 25);
            this.button2.TabIndex = 2;
            this.button2.Text = "修改图纸大小";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_Size_Click);
            // 
            // ModifyDrawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 104);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.drawingName);
            this.Controls.Add(this.drawSize_h);
            this.Controls.Add(this.drawSize_w);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Size);
            this.Controls.Add(this.btn_Title);
            this.Controls.Add(this.drawTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyDrawing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改图纸";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox drawTitle;
        private System.Windows.Forms.Button btn_Title;
        private System.Windows.Forms.Button btn_Size;
        private System.Windows.Forms.TextBox drawSize_w;
        private System.Windows.Forms.TextBox drawSize_h;
        private System.Windows.Forms.TextBox drawingName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}