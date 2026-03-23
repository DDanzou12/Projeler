using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DrawingToolWinForms
{
    public partial class MainForm : Form
    {
        private enum ToolType
        {
            Pen,
            Line,
            Rectangle,
            Ellipse,
            Eraser
        }

        private Bitmap _canvasBitmap;
        private Point _startPoint;
        private Point _currentPoint;
        private bool _isDrawing;
        private ToolType _currentTool = ToolType.Pen;
        private Color _selectedColor = Color.Black;
        private int _penWidth = 3;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeCanvas();
            cmbThickness.SelectedIndex = 2;
            UpdateSelectedToolButton();
            UpdateColorPreview();
            lblStatus.Text = "Hazır";
        }

        private void InitializeCanvas()
        {
            if (canvasPictureBox.Width <= 0 || canvasPictureBox.Height <= 0)
            {
                return;
            }

            Bitmap previous = _canvasBitmap;
            _canvasBitmap = new Bitmap(canvasPictureBox.Width, canvasPictureBox.Height);

            using (Graphics g = Graphics.FromImage(_canvasBitmap))
            {
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                if (previous != null)
                {
                    g.DrawImageUnscaled(previous, Point.Empty);
                }
            }

            canvasPictureBox.Image = _canvasBitmap;

            if (previous != null)
            {
                previous.Dispose();
            }
        }

        private void canvasPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            _isDrawing = true;
            _startPoint = e.Location;
            _currentPoint = e.Location;

            if (_currentTool == ToolType.Pen || _currentTool == ToolType.Eraser)
            {
                DrawFreehandSegment(_startPoint, e.Location);
            }
        }

        private void canvasPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            lblCoordinates.Text = $"X: {e.X}  Y: {e.Y}";

            if (!_isDrawing)
            {
                return;
            }

            if (_currentTool == ToolType.Pen || _currentTool == ToolType.Eraser)
            {
                DrawFreehandSegment(_currentPoint, e.Location);
                _currentPoint = e.Location;
                canvasPictureBox.Invalidate();
            }
            else
            {
                _currentPoint = e.Location;
                canvasPictureBox.Invalidate();
            }
        }

        private void canvasPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_isDrawing)
            {
                return;
            }

            if (_currentTool == ToolType.Line || _currentTool == ToolType.Rectangle || _currentTool == ToolType.Ellipse)
            {
                using (Graphics g = Graphics.FromImage(_canvasBitmap))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    DrawShape(g, _startPoint, e.Location);
                }
            }

            _isDrawing = false;
            canvasPictureBox.Invalidate();
            lblStatus.Text = "Çizim tamamlandı";
        }

        private void canvasPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (!_isDrawing)
            {
                return;
            }

            if (_currentTool == ToolType.Line || _currentTool == ToolType.Rectangle || _currentTool == ToolType.Ellipse)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                DrawShape(e.Graphics, _startPoint, _currentPoint);
            }
        }

        private void DrawFreehandSegment(Point fromPoint, Point toPoint)
        {
            using (Graphics g = Graphics.FromImage(_canvasBitmap))
            using (Pen pen = CreateActivePen())
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawLine(pen, fromPoint, toPoint);
            }

            lblStatus.Text = _currentTool == ToolType.Eraser ? "Siliniyor" : "Serbest çizim";
        }

        private void DrawShape(Graphics graphics, Point start, Point end)
        {
            using (Pen pen = CreateActivePen())
            {
                Rectangle rect = GetRectangle(start, end);

                switch (_currentTool)
                {
                    case ToolType.Line:
                        graphics.DrawLine(pen, start, end);
                        lblStatus.Text = "Çizgi aracı";
                        break;
                    case ToolType.Rectangle:
                        graphics.DrawRectangle(pen, rect);
                        lblStatus.Text = "Dikdörtgen aracı";
                        break;
                    case ToolType.Ellipse:
                        graphics.DrawEllipse(pen, rect);
                        lblStatus.Text = "Elips aracı";
                        break;
                }
            }
        }

        private Pen CreateActivePen()
        {
            Color color = _currentTool == ToolType.Eraser ? Color.White : _selectedColor;
            Pen pen = new Pen(color, _penWidth)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };

            return pen;
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y));
        }

        private void SelectTool(ToolType tool)
        {
            _currentTool = tool;
            UpdateSelectedToolButton();
            lblActiveToolValue.Text = ToolName(tool);
            lblStatus.Text = $"Aktif araç: {ToolName(tool)}";
        }

        private string ToolName(ToolType tool)
        {
            switch (tool)
            {
                case ToolType.Pen:
                    return "Kalem";
                case ToolType.Line:
                    return "Çizgi";
                case ToolType.Rectangle:
                    return "Dikdörtgen";
                case ToolType.Ellipse:
                    return "Elips";
                case ToolType.Eraser:
                    return "Silgi";
                default:
                    return "Bilinmiyor";
            }
        }

        private void UpdateSelectedToolButton()
        {
            ResetToolButtonStyles();

            Button activeButton = btnPen;
            switch (_currentTool)
            {
                case ToolType.Pen:
                    activeButton = btnPen;
                    break;
                case ToolType.Line:
                    activeButton = btnLine;
                    break;
                case ToolType.Rectangle:
                    activeButton = btnRectangle;
                    break;
                case ToolType.Ellipse:
                    activeButton = btnEllipse;
                    break;
                case ToolType.Eraser:
                    activeButton = btnEraser;
                    break;
            }

            activeButton.BackColor = Color.FromArgb(52, 152, 219);
            activeButton.ForeColor = Color.White;
        }

        private void ResetToolButtonStyles()
        {
            foreach (Control control in toolsPanel.Controls)
            {
                Button button = control as Button;
                if (button != null)
                {
                    button.BackColor = Color.WhiteSmoke;
                    button.ForeColor = Color.Black;
                }
            }
        }

        private void UpdateColorPreview()
        {
            pnlSelectedColor.BackColor = _selectedColor;
            lblColorValue.Text = $"RGB({_selectedColor.R}, {_selectedColor.G}, {_selectedColor.B})";
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            SelectTool(ToolType.Pen);
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            SelectTool(ToolType.Line);
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            SelectTool(ToolType.Rectangle);
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            SelectTool(ToolType.Ellipse);
        }

        private void btnEraser_Click(object sender, EventArgs e)
        {
            SelectTool(ToolType.Eraser);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _selectedColor = colorDialog1.Color;
                UpdateColorPreview();
                lblStatus.Text = "Renk güncellendi";
            }
        }

        private void cmbThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            int thickness;
            if (int.TryParse(cmbThickness.Text, out thickness))
            {
                _penWidth = thickness;
                lblPenSizeValue.Text = thickness + " px";
                lblStatus.Text = "Kalınlık değiştirildi";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Tuvali temizlemek istediğine emin misin?",
                "Temizle",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (Graphics g = Graphics.FromImage(_canvasBitmap))
                {
                    g.Clear(Color.White);
                }

                canvasPictureBox.Invalidate();
                lblStatus.Text = "Tuval temizlendi";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PNG Dosyası (*.png)|*.png|JPEG Dosyası (*.jpg)|*.jpg|Bitmap Dosyası (*.bmp)|*.bmp";
                saveDialog.Title = "Çizimi Kaydet";
                saveDialog.FileName = "cizim";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat format = ImageFormat.Png;
                    if (saveDialog.FilterIndex == 2)
                    {
                        format = ImageFormat.Jpeg;
                    }
                    else if (saveDialog.FilterIndex == 3)
                    {
                        format = ImageFormat.Bmp;
                    }

                    _canvasBitmap.Save(saveDialog.FileName, format);
                    lblStatus.Text = "Dosya kaydedildi";
                }
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                InitializeCanvas();
            }
        }
    }
}
