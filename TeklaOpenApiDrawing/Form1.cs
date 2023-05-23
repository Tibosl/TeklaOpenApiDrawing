using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tekla.Structures;
using Tekla.Structures.Dialog;
using Tekla.Structures.Drawing;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.Operations;
using Tekla.Structures.Model.UI;
namespace TeklaOpenApiDrawing
{
    public partial class Form1 : Form
    {
        //模型
        private static Model _model => new Model();
        //图纸
        private static DrawingHandler drawingHandler => new DrawingHandler();
        Tekla.Structures.Model.Events ModelEvents = new Tekla.Structures.Model.Events();
        public Form1()
        {
            if (_model.GetConnectionStatus())
                InitializeComponent();
            InitTreeData();
            try
            {
                //事件
                ModelEvents.Interrupted += ModelEvents_Interrupted;
                ModelEvents.ModelSave += ModelEvents_ModelSave;
                //事件注册
                ModelEvents.Register();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ModelEvents_ModelSave()
        {
            //MessageBox.Show("模型保存！");
            //return;
        }

        /// <summary>
        /// 获取图纸数据
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void InitTreeData()
        {
            if (drawingHandler.GetConnectionStatus() && _model.GetConnectionStatus())
            {
                treeView1?.Nodes.Clear();
                DrawingEnumerator enumerator = drawingHandler.GetDrawings();
                while (enumerator.MoveNext())
                {
                    Drawing drawing = enumerator.Current as Drawing;
                    TreeNode node = new TreeNode();
                    node.Tag = drawing;
                    node.Text = drawing.Name + " " + GetDrawingTypeCharacter(drawing);
                    treeView1.Nodes.Add(node);
                }
            }
        }

        /// <summary>
        /// 获取图纸的Type类型
        /// </summary>
        /// <param name="DrawingInstance"></param>
        /// <returns></returns>
        private string GetDrawingTypeCharacter(Drawing DrawingInstance)
        {
            string Result = "U"; // Unknown drawing

            if (DrawingInstance is GADrawing)
            {
                Result = "G";
            }
            else if (DrawingInstance is AssemblyDrawing)
            {
                Result = "A";
            }
            else if (DrawingInstance is CastUnitDrawing)
            {
                Result = "C";
            }
            else if (DrawingInstance is MultiDrawing)
            {
                Result = "M";
            }
            else if (DrawingInstance is SinglePartDrawing)
            {
                Result = "W";
            }

            return Result;
        }

        /// <summary>
        /// 刷新图纸列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            InitTreeData();
        }

        private void DeleteDrawing()
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("当前没有选中图纸！");
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("是否要删除已选中的图纸？", "提示", MessageBoxButtons.YesNoCancel))
            {
                if (drawingHandler.GetActiveDrawing() != null)
                {
                    MessageBox.Show("请关闭图纸在进行删除");
                    return;
                }
                if (!drawingHandler.GetConnectionStatus())
                    return;
                if (treeView1.Nodes == null || treeView1.SelectedNode == null)
                    MessageBox.Show("当前没有图纸！");
                if (treeView1.Nodes != null && treeView1.SelectedNode?.Tag is DatabaseObject)
                {
                    if ((treeView1.SelectedNode.Tag as DatabaseObject).Delete())
                    {
                        treeView1.SelectedNode.Remove();
                        InitTreeData();
                    }
                }
            }
        }

        /// <summary>
        /// 删除图纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteDrawing();
        }

        private void CreateAssemblyDrarwing()
        {
            try
            {
                //获取选择的模型
                ModelObjectEnumerator modelObject = new Tekla.Structures.Model.UI.ModelObjectSelector().GetSelectedObjects();
                while (modelObject.MoveNext())
                {
                    var obj = modelObject.Current as Tekla.Structures.Model.Part;
                    if (obj == null) return;
                    Tekla.Structures.ModelInternal.Operation.dotStartAction("FullNumbering", (string)null);
                    //获取零件的identifier
                    Identifier identifier = obj.GetAssembly().Identifier;
                    AssemblyDrawing assembly = new AssemblyDrawing(identifier);
                    assembly.Insert();
                    if (checkBox1.Checked)
                        drawingHandler.SetActiveDrawing(assembly);
                    else
                        drawingHandler.SetActiveDrawing(assembly, false);
                    drawingHandler.CloseActiveDrawing();
                    if (checkBox1.Checked && assembly != null)
                        drawingHandler.SetActiveDrawing(assembly);
                    InitTreeData();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 创建构件图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Create_component_Click(object sender, EventArgs e)
        {
            CreateAssemblyDrarwing();
        }

        /// <summary>
        /// 创建GA图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Create_GA_Click(object sender, EventArgs e)
        {
            TransformationPlane current = _model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            _model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane());  // We use global transformation
            try
            {
                GADrawing gADrawing = new GADrawing("GA Drawing", "standard");
                //如果大小设置为0，边框不显示,设置尺寸为0的话，打印图纸会报错，显示文件损坏
                gADrawing.Title1 = "GA图";
                //gADrawing.Layout.SheetSize = new Tekla.Structures.Drawing.Size();
                gADrawing.PlaceViews();
                gADrawing.Insert();
                _model.GetWorkPlaneHandler().SetCurrentTransformationPlane(current); // return original transformation
                if (checkBox1.Checked)
                {
                    drawingHandler.SetActiveDrawing(gADrawing);
                }
                else
                {
                    drawingHandler.SetActiveDrawing(gADrawing, false);
                }
                //需要先使用CloseActiceDrawing来关闭，不然虽然能生成图纸但是打不开
                drawingHandler.CloseActiveDrawing(true);
                //在判断一次是否要打开图纸
                if (drawingHandler.GetConnectionStatus() && checkBox1.Checked)
                {
                    drawingHandler.SetActiveDrawing(gADrawing);
                }
                InitTreeData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 创建零件图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Create_Parts_Click(object sender, EventArgs e)
        {
            try
            {
                ModelObjectEnumerator modelObject = new Tekla.Structures.Model.UI.ModelObjectSelector().GetSelectedObjects();
                while (modelObject.MoveNext())
                {
                    var obj = modelObject.Current as Tekla.Structures.Model.Part;
                    if (obj == null) return;
                    Identifier identifier = obj.Identifier;
                    SinglePartDrawing singlePart = new SinglePartDrawing(identifier, "standard");
                    singlePart.Insert();
                    if (checkBox1.Checked)
                        drawingHandler.SetActiveDrawing(singlePart);
                    else
                        drawingHandler.SetActiveDrawing(singlePart, false);
                    drawingHandler.CloseActiveDrawing();
                    if (checkBox1.Checked && singlePart != null)
                        drawingHandler.SetActiveDrawing(singlePart);
                    InitTreeData();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 创建模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Create_Click(object sender, EventArgs e)
        {
            var cp1 = new ContourPlate();
            var cp2 = new ContourPlate();

            Contour contour1 = new Contour();
            contour1.AddContourPoint(new ContourPoint(new Tekla.Structures.Geometry3d.Point(2000, 0, 0), null));
            contour1.AddContourPoint(new ContourPoint(new Tekla.Structures.Geometry3d.Point(3000, 0, 0), null));
            contour1.AddContourPoint(new ContourPoint(new Tekla.Structures.Geometry3d.Point(3000, 2000, 0), null));
            contour1.AddContourPoint(new ContourPoint(new Tekla.Structures.Geometry3d.Point(2000, 2000, 0), null));

            Contour contour2 = new Contour();
            contour2.AddContourPoint(new ContourPoint(new Tekla.Structures.Geometry3d.Point(3000, 0, 0), null));
            contour2.AddContourPoint(new ContourPoint(new Tekla.Structures.Geometry3d.Point(3000, 2000, 0), null));
            contour2.AddContourPoint(new ContourPoint(new Tekla.Structures.Geometry3d.Point(4000, 2000, 0), null));
            contour2.AddContourPoint(new ContourPoint(new Tekla.Structures.Geometry3d.Point(4000, 0, 0), null));

            cp1.Contour = contour1;
            cp2.Contour = contour2;

            cp1.Profile.ProfileString = cp2.Profile.ProfileString = "PL100";

            cp1.Insert();
            cp2.Insert();

            var weld = new Tekla.Structures.Model.Weld();
            weld.MainObject = cp1;
            weld.SecondaryObject = cp2;
            weld.SizeAbove = 10;
            weld.Insert();

            double weldLength = -1;

            weld.GetReportProperty("LENGTH", ref weldLength);

            Tekla.Structures.ModelInternal.Operation.dotStartAction("FullNumbering", (string)null);

            _model.CommitChanges();
        }

        /// <summary>
        /// 打印图纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void btn_print_Click(object sender, EventArgs e)
        {
            //获取当前的图纸
            var drawings = drawingHandler.GetActiveDrawing();
            //如果不是ga图、零件图、构件图直接return掉
            if (!(drawings is GADrawing || drawings is AssemblyDrawing || drawings is SinglePartDrawing)) return;
            DPMPrinterAttributes printAttributes = new DPMPrinterAttributes();
            printAttributes.ColorMode = DotPrintColor.BlackAndWhite;
            printAttributes.NumberOfCopies = 1;
            printAttributes.OpenFileWhenFinished = false;
            printAttributes.Orientation = DotPrintOrientationType.Landscape;
            printAttributes.OutputType = DotPrintOutputType.PDF;
            printAttributes.PaperSize = DotPrintPaperSize.A4;
            printAttributes.PrinterName = "clawPDF"; // Must use local PDF printer name
            printAttributes.PrintToMultipleSheet = DotPrintToMultipleSheet.Off;
            printAttributes.ScaleFactor = 1.0;
            printAttributes.ScalingMethod = DotPrintScalingType.Auto;
            //保存对话框
            SaveFileDialog folderDlg = new SaveFileDialog();
            //设置保存的格式
            folderDlg.Filter = "PDF格式(*.pdf)|*.pdf";
            //设置名字和位置
            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
                //获取选择的路径
                var inputPath = folderDlg.FileName;
                printAttributes.OutputFileName = inputPath;
            }
            var result = drawingHandler.PrintDrawing(drawings, printAttributes);
            if (!result)
            {
                throw new Exception("打印失败！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawingHandler.CloseActiveDrawing(true);
        }

        /// <summary>
        /// 编辑图纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_editor_Click(object sender, EventArgs e)
        {
            if (drawingHandler.GetConnectionStatus())
            {
                var drawings = drawingHandler.GetActiveDrawing() as Drawing;
                if (!(drawings is GADrawing)) return;
                //获取图纸的工作表
                ContainerView Sheet = drawings.GetSheet();
                for (int i = 0; i < 400; i += 100)
                {
                    if (i == 0)
                    {
                        DrawLine(0, 0, 300, 0, drawings, Sheet);
                    }
                    else if (i == 100)
                    {
                        DrawLine(300, 0, 300, 100, drawings, Sheet);
                    }
                    else if (i == 200)
                    {
                        DrawLine(0, 0, 0, 100, drawings, Sheet);
                    }
                    else
                    {
                        DrawLine(0, 100, 300, 100, drawings, Sheet);
                    }
                }
                drawingHandler.SaveActiveDrawing();
            }
        }

        /// <summary>
        /// drawing--画线
        /// </summary>
        /// <param name="X1">开始的X</param>
        /// <param name="Y1">开始的Y</param>
        /// <param name="X2">结束的X</param>
        /// <param name="Y2">结束的Y</param>
        /// <param name="drawings">当前图纸</param>
        /// <param name="Sheet">当前视图</param>
        private void DrawLine(double X1, double Y1, double X2, double Y2, Drawing drawings, ContainerView Sheet)
        {
            Tekla.Structures.Geometry3d.Point point = new Tekla.Structures.Geometry3d.Point();
            Tekla.Structures.Geometry3d.Point point1 = new Tekla.Structures.Geometry3d.Point();
            point.X = X1;
            point.Y = Y1;
            point1.X = X2;
            point1.Y = Y2;
            Tekla.Structures.Drawing.Line line = new Tekla.Structures.Drawing.Line(Sheet, point, point1);
            line.Insert();
            drawings.CommitChanges();
        }

        private void ModelEvents_Interrupted()
        {
            //MessageBox.Show("事件中断");
            //return;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //取消事件注册
            ModelEvents.UnRegister();
        }

        private void btn_create_beam_Click(object sender, EventArgs e)
        {
            try
            {
                Picker picker = new Picker();
                //拾取多个点
                var pickedPoints = picker.PickPoints(Picker.PickPointEnum.PICK_POLYGON);
                bool result = false;
                if (pickedPoints.Count < 2)
                {
                    return;
                }
                else if (pickedPoints.Count == 2)
                {
                    Beam beam = new Beam(Beam.BeamTypeEnum.PANEL)
                    {
                        StartPoint = pickedPoints[0] as Point,
                        EndPoint = pickedPoints[1] as Point
                    };
                    beam.Profile.ProfileString = "4000*300";
                    beam.Material.MaterialString = "C50";
                    beam.Name = "PANEL";
                    beam.Position.Depth = Position.DepthEnum.FRONT;
                    result = beam.Insert();
                }
                else if (pickedPoints.Count > 2)
                {
                    PolyBeam beam = new PolyBeam(PolyBeam.PolyBeamTypeEnum.PANEL);
                    foreach (var pickedPoint in pickedPoints)
                    {
                        beam.AddContourPoint(new ContourPoint(pickedPoint as Point, null));
                    }
                    beam.Profile.ProfileString = "4000*300";
                    beam.Material.MaterialString = "C50";
                    beam.Name = "PANEL";
                    beam.Position.Depth = Position.DepthEnum.FRONT;
                    result = beam.Insert();
                }
                if (result == true)
                {
                    _model.CommitChanges();
                    MessageBox.Show("创建成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 创建钢筋图纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_create_rebar_Click(object sender, EventArgs e)
        {
            //使用世界坐标系
            TransformationPlane current = _model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            _model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane());
            try
            {
                ModelObjectEnumerator modelObject = _model.GetModelObjectSelector().GetAllObjects();
                while (modelObject.MoveNext())
                {
                    if (!((modelObject.Current is Assembly) || (modelObject.Current is PolyBeam))) return;
                    var drawings = drawingHandler.GetActiveDrawing();
                    if (drawings != null)
                    {
                        MessageBox.Show("请关闭图纸后再操作！");
                        return;
                    }
                    if (!Operation.IsNumberingUpToDate(modelObject.Current))
                    {
                        MessageBox.Show("请编号后操作！");
                        return;
                    }
                    var identifier = modelObject.Current.Identifier;
                    CastUnitDrawing castUnitDrawing = new CastUnitDrawing(identifier);
                    castUnitDrawing.PlaceViews();
                    castUnitDrawing.Title1 = "墙配筋案例";
                    castUnitDrawing.Name = "创智";
                    var isInsert = castUnitDrawing.Insert();
                    //改为局部坐标系
                    _model.GetWorkPlaneHandler().SetCurrentTransformationPlane(current);
                    var result = MessageBox.Show("是否立刻打开生成的图纸？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        drawingHandler.SetActiveDrawing(castUnitDrawing);
                    }
                    else
                    {
                        drawingHandler.SetActiveDrawing(castUnitDrawing, false);
                    }
                    InitTreeData();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 获取父类下面的所有子类
        /// </summary>
        /// <param name="db"></param>
        /// <param name="parentType"></param>
        /// <returns></returns>
        public static List<Type> GetChildTypes(Type parentType)
        {
            List<Type> lstType = new List<Type>();
            System.Reflection.Assembly assem = System.Reflection.Assembly.GetAssembly(parentType);
            foreach (Type tChild in assem.GetTypes())
            {
                if (tChild.BaseType == parentType)
                    lstType.Add(tChild);
            }
            return lstType;
        }
        /// <summary>
        /// 修改图纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_modify_Click(object sender, EventArgs e)
        {
            using (ModifyDrawing modifyDrawing = new ModifyDrawing(drawingHandler)) 
            {
                modifyDrawing.ShowDialog();
            }
        }
    }
}
