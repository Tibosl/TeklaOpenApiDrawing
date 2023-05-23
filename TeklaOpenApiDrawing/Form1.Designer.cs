namespace TeklaOpenApiDrawing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_Create = new System.Windows.Forms.Button();
            this.btn_Create_GA = new System.Windows.Forms.Button();
            this.btn_Create_component = new System.Windows.Forms.Button();
            this.btn_Create_Parts = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_editor = new System.Windows.Forms.Button();
            this.btn_create_beam = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_modify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(140, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(311, 366);
            this.treeView1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(13, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 25);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "打开图纸";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(12, 73);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(122, 25);
            this.btn_Delete.TabIndex = 15;
            this.btn_Delete.Text = "删除图纸";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(12, 43);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(122, 25);
            this.btn_refresh.TabIndex = 14;
            this.btn_refresh.Text = "刷新列表";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(12, 197);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(122, 25);
            this.btn_Create.TabIndex = 17;
            this.btn_Create.Text = "创建";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // btn_Create_GA
            // 
            this.btn_Create_GA.Location = new System.Drawing.Point(12, 166);
            this.btn_Create_GA.Name = "btn_Create_GA";
            this.btn_Create_GA.Size = new System.Drawing.Size(122, 25);
            this.btn_Create_GA.TabIndex = 18;
            this.btn_Create_GA.Text = "创建GA图";
            this.btn_Create_GA.UseVisualStyleBackColor = true;
            this.btn_Create_GA.Click += new System.EventHandler(this.btn_Create_GA_Click);
            // 
            // btn_Create_component
            // 
            this.btn_Create_component.Location = new System.Drawing.Point(12, 104);
            this.btn_Create_component.Name = "btn_Create_component";
            this.btn_Create_component.Size = new System.Drawing.Size(122, 25);
            this.btn_Create_component.TabIndex = 19;
            this.btn_Create_component.Text = "创建构件图";
            this.btn_Create_component.UseVisualStyleBackColor = true;
            this.btn_Create_component.Click += new System.EventHandler(this.btn_Create_component_Click);
            // 
            // btn_Create_Parts
            // 
            this.btn_Create_Parts.Location = new System.Drawing.Point(12, 135);
            this.btn_Create_Parts.Name = "btn_Create_Parts";
            this.btn_Create_Parts.Size = new System.Drawing.Size(122, 25);
            this.btn_Create_Parts.TabIndex = 16;
            this.btn_Create_Parts.Text = "创建零件图";
            this.btn_Create_Parts.UseVisualStyleBackColor = true;
            this.btn_Create_Parts.Click += new System.EventHandler(this.btn_Create_Parts_Click);
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(13, 229);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(121, 25);
            this.btn_print.TabIndex = 20;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 25);
            this.button1.TabIndex = 21;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_editor
            // 
            this.btn_editor.Location = new System.Drawing.Point(12, 260);
            this.btn_editor.Name = "btn_editor";
            this.btn_editor.Size = new System.Drawing.Size(121, 25);
            this.btn_editor.TabIndex = 21;
            this.btn_editor.Text = "编辑";
            this.btn_editor.UseVisualStyleBackColor = true;
            this.btn_editor.Click += new System.EventHandler(this.btn_editor_Click);
            // 
            // btn_create_beam
            // 
            this.btn_create_beam.Location = new System.Drawing.Point(13, 322);
            this.btn_create_beam.Name = "btn_create_beam";
            this.btn_create_beam.Size = new System.Drawing.Size(121, 25);
            this.btn_create_beam.TabIndex = 21;
            this.btn_create_beam.Text = "创建墙";
            this.btn_create_beam.UseVisualStyleBackColor = true;
            this.btn_create_beam.Click += new System.EventHandler(this.btn_create_beam_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 25);
            this.button2.TabIndex = 21;
            this.button2.Text = "创建钢筋";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_create_rebar_Click);
            // 
            // btn_modify
            // 
            this.btn_modify.Location = new System.Drawing.Point(457, 12);
            this.btn_modify.Name = "btn_modify";
            this.btn_modify.Size = new System.Drawing.Size(103, 25);
            this.btn_modify.TabIndex = 22;
            this.btn_modify.Text = "修改";
            this.btn_modify.UseVisualStyleBackColor = true;
            this.btn_modify.Click += new System.EventHandler(this.btn_modify_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 383);
            this.Controls.Add(this.btn_modify);
            this.Controls.Add(this.btn_editor);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_create_beam);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.btn_Create_GA);
            this.Controls.Add(this.btn_Create_component);
            this.Controls.Add(this.btn_Create_Parts);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tekla";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Button btn_Create_GA;
        private System.Windows.Forms.Button btn_Create_component;
        private System.Windows.Forms.Button btn_Create_Parts;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_editor;
        private System.Windows.Forms.Button btn_create_beam;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_modify;
    }
}

