using System;
using System.Drawing;
using System.Windows.Forms;
using Tekla.Structures.Drawing;
using Tekla.Structures.Geometry3d;

namespace TeklaOpenApiDrawing
{
    public partial class ModifyDrawing : Form
    {
        private DrawingHandler drawingHandler;

        private DrawingEnumerator drawsList;

        public ModifyDrawing()
        {
            InitializeComponent();
        }

        public ModifyDrawing(DrawingHandler dwHandler)
        {
            InitializeComponent();
            drawingHandler = dwHandler;
            if (drawingHandler == null && !drawingHandler.GetConnectionStatus())
            {
                MessageBox.Show("请保持连接状态下进行操作！");
                return;
            }
            drawsList = drawingHandler.GetDrawings();
        }
        /// <summary>
        /// 执行一些操作后，重新获取最新的图纸信息
        /// </summary>
        void GetNewDrawings() 
        {
            drawsList = drawingHandler.GetDrawings();
        }
        /// <summary>
        /// 修改标题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Title_Click(object sender, EventArgs e)
        {
            while (drawsList.MoveNext())
            {
                var drawing = drawsList.Current;
                drawing.Title1 = this.drawTitle.Text.Trim().ToString();
                var result = drawing.Modify();
                drawing.CommitChanges();
                if (result) 
                {
                    MessageBox.Show("修改成功！");
                    GetNewDrawings();
                    return;
                }
            }
        }

        /// <summary>
        /// 修改大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Size_Click(object sender, EventArgs e)
        {
            while (drawsList.MoveNext())
            {
                var drawing = drawsList.Current;
                if (string.IsNullOrEmpty(drawSize_w.Text.Trim().ToString()) || string.IsNullOrEmpty(drawSize_w.Text.Trim().ToString()))
                {
                    MessageBox.Show("图纸尺寸大小不能为空！");
                    return;
                }
                Tekla.Structures.Drawing.Size size = new Tekla.Structures.Drawing.Size();
                size.Width = Convert.ToDouble(drawSize_w.Text.Trim().ToString());
                size.Height = Convert.ToDouble(drawSize_h.Text.Trim().ToString());
                drawing.Layout.SheetSize = size;
                var result = drawing.Modify();
                drawing.CommitChanges();
                if (result)
                {
                    MessageBox.Show("修改成功！");
                    GetNewDrawings();
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (drawsList.MoveNext()) 
            {
                if (string.IsNullOrEmpty(drawingName.Text.Trim().ToString())) 
                {
                    MessageBox.Show("修改名称不能为空");
                    return;
                }
                var drawing = drawsList.Current;
                drawing.Name = drawingName.Text.Trim().ToString();
                var result = drawing.Modify();
                drawing.CommitChanges();
                if (result)
                {
                    MessageBox.Show("修改成功！");
                    GetNewDrawings();
                    return;
                }
            }
        }
    }
}