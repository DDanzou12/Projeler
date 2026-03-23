namespace DrawingToolWinForms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing && _canvasBitmap != null)
            {
                _canvasBitmap.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.lblPenSizeValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbThickness = new System.Windows.Forms.ComboBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.lblColorValue = new System.Windows.Forms.Label();
            this.pnlSelectedColor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxTools = new System.Windows.Forms.GroupBox();
            this.toolsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPen = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.btnEraser = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.canvasContainerPanel = new System.Windows.Forms.Panel();
            this.canvasPictureBox = new System.Windows.Forms.PictureBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.lblActiveToolValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.leftPanel.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.groupBoxTools.SuspendLayout();
            this.toolsPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.canvasContainerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasPictureBox)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.leftPanel.Controls.Add(this.groupBoxActions);
            this.leftPanel.Controls.Add(this.groupBoxSettings);
            this.leftPanel.Controls.Add(this.groupBoxTools);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Padding = new System.Windows.Forms.Padding(12);
            this.leftPanel.Size = new System.Drawing.Size(240, 761);
            this.leftPanel.TabIndex = 0;
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.btnSave);
            this.groupBoxActions.Controls.Add(this.btnClear);
            this.groupBoxActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxActions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxActions.Location = new System.Drawing.Point(12, 491);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxActions.Size = new System.Drawing.Size(216, 128);
            this.groupBoxActions.TabIndex = 2;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "İşlemler";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(13, 73);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(188, 38);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Kaydet";
            this.toolTip1.SetToolTip(this.btnSave, "Çizimi dosya olarak kaydet");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(13, 29);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(188, 38);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Tuvali Temizle";
            this.toolTip1.SetToolTip(this.btnClear, "Tuvaldeki tüm çizimleri sil");
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.lblPenSizeValue);
            this.groupBoxSettings.Controls.Add(this.label4);
            this.groupBoxSettings.Controls.Add(this.cmbThickness);
            this.groupBoxSettings.Controls.Add(this.btnColor);
            this.groupBoxSettings.Controls.Add(this.lblColorValue);
            this.groupBoxSettings.Controls.Add(this.pnlSelectedColor);
            this.groupBoxSettings.Controls.Add(this.label3);
            this.groupBoxSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 262);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxSettings.Size = new System.Drawing.Size(216, 229);
            this.groupBoxSettings.TabIndex = 1;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Ayarlar";
            // 
            // lblPenSizeValue
            // 
            this.lblPenSizeValue.AutoSize = true;
            this.lblPenSizeValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPenSizeValue.Location = new System.Drawing.Point(13, 188);
            this.lblPenSizeValue.Name = "lblPenSizeValue";
            this.lblPenSizeValue.Size = new System.Drawing.Size(39, 19);
            this.lblPenSizeValue.TabIndex = 6;
            this.lblPenSizeValue.Text = "3 px";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label4.Location = new System.Drawing.Point(13, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Kalem Kalınlığı Seç";
            // 
            // cmbThickness
            // 
            this.cmbThickness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThickness.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbThickness.FormattingEnabled = true;
            this.cmbThickness.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "8",
            "10",
            "12"});
            this.cmbThickness.Location = new System.Drawing.Point(13, 153);
            this.cmbThickness.Name = "cmbThickness";
            this.cmbThickness.Size = new System.Drawing.Size(188, 25);
            this.cmbThickness.TabIndex = 4;
            this.cmbThickness.SelectedIndexChanged += new System.EventHandler(this.cmbThickness_SelectedIndexChanged);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.White;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnColor.Location = new System.Drawing.Point(13, 80);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(188, 32);
            this.btnColor.TabIndex = 3;
            this.btnColor.Text = "Renk Seç";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // lblColorValue
            // 
            this.lblColorValue.AutoSize = true;
            this.lblColorValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblColorValue.Location = new System.Drawing.Point(53, 42);
            this.lblColorValue.Name = "lblColorValue";
            this.lblColorValue.Size = new System.Drawing.Size(90, 19);
            this.lblColorValue.TabIndex = 2;
            this.lblColorValue.Text = "RGB(0, 0, 0)";
            // 
            // pnlSelectedColor
            // 
            this.pnlSelectedColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectedColor.Location = new System.Drawing.Point(13, 37);
            this.pnlSelectedColor.Name = "pnlSelectedColor";
            this.pnlSelectedColor.Size = new System.Drawing.Size(30, 30);
            this.pnlSelectedColor.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label3.Location = new System.Drawing.Point(13, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Seçili Renk";
            // 
            // groupBoxTools
            // 
            this.groupBoxTools.Controls.Add(this.toolsPanel);
            this.groupBoxTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTools.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxTools.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTools.Name = "groupBoxTools";
            this.groupBoxTools.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxTools.Size = new System.Drawing.Size(216, 250);
            this.groupBoxTools.TabIndex = 0;
            this.groupBoxTools.TabStop = false;
            this.groupBoxTools.Text = "Çizim Araçları";
            // 
            // toolsPanel
            // 
            this.toolsPanel.Controls.Add(this.btnPen);
            this.toolsPanel.Controls.Add(this.btnLine);
            this.toolsPanel.Controls.Add(this.btnRectangle);
            this.toolsPanel.Controls.Add(this.btnEllipse);
            this.toolsPanel.Controls.Add(this.btnEraser);
            this.toolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.toolsPanel.Location = new System.Drawing.Point(10, 28);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Size = new System.Drawing.Size(196, 212);
            this.toolsPanel.TabIndex = 0;
            this.toolsPanel.WrapContents = false;
            // 
            // btnPen
            // 
            this.btnPen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPen.Location = new System.Drawing.Point(3, 3);
            this.btnPen.Name = "btnPen";
            this.btnPen.Size = new System.Drawing.Size(188, 36);
            this.btnPen.TabIndex = 0;
            this.btnPen.Text = "Kalem";
            this.btnPen.UseVisualStyleBackColor = true;
            this.btnPen.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnLine
            // 
            this.btnLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLine.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLine.Location = new System.Drawing.Point(3, 45);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(188, 36);
            this.btnLine.TabIndex = 1;
            this.btnLine.Text = "Çizgi";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRectangle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRectangle.Location = new System.Drawing.Point(3, 87);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(188, 36);
            this.btnRectangle.TabIndex = 2;
            this.btnRectangle.Text = "Dikdörtgen";
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEllipse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEllipse.Location = new System.Drawing.Point(3, 129);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(188, 36);
            this.btnEllipse.TabIndex = 3;
            this.btnEllipse.Text = "Elips";
            this.btnEllipse.UseVisualStyleBackColor = true;
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnEraser
            // 
            this.btnEraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEraser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEraser.Location = new System.Drawing.Point(3, 171);
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(188, 36);
            this.btnEraser.TabIndex = 4;
            this.btnEraser.Text = "Silgi";
            this.btnEraser.UseVisualStyleBackColor = true;
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.topPanel.Controls.Add(this.lblSubtitle);
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(240, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(20, 16, 20, 12);
            this.topPanel.Size = new System.Drawing.Size(1044, 80);
            this.topPanel.TabIndex = 1;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSubtitle.Location = new System.Drawing.Point(23, 45);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(388, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Windows Forms (.NET Framework) ile hazırlanmış çizim aracı";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(21, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(213, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Drawing Tool Pro";
            // 
            // canvasContainerPanel
            // 
            this.canvasContainerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.canvasContainerPanel.Controls.Add(this.canvasPictureBox);
            this.canvasContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasContainerPanel.Location = new System.Drawing.Point(240, 80);
            this.canvasContainerPanel.Name = "canvasContainerPanel";
            this.canvasContainerPanel.Padding = new System.Windows.Forms.Padding(18);
            this.canvasContainerPanel.Size = new System.Drawing.Size(1044, 621);
            this.canvasContainerPanel.TabIndex = 2;
            // 
            // canvasPictureBox
            // 
            this.canvasPictureBox.BackColor = System.Drawing.Color.White;
            this.canvasPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvasPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPictureBox.Location = new System.Drawing.Point(18, 18);
            this.canvasPictureBox.Name = "canvasPictureBox";
            this.canvasPictureBox.Size = new System.Drawing.Size(1008, 585);
            this.canvasPictureBox.TabIndex = 0;
            this.canvasPictureBox.TabStop = false;
            this.canvasPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.canvasPictureBox_Paint);
            this.canvasPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvasPictureBox_MouseDown);
            this.canvasPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasPictureBox_MouseMove);
            this.canvasPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvasPictureBox_MouseUp);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bottomPanel.Controls.Add(this.lblCoordinates);
            this.bottomPanel.Controls.Add(this.lblActiveToolValue);
            this.bottomPanel.Controls.Add(this.label2);
            this.bottomPanel.Controls.Add(this.lblStatus);
            this.bottomPanel.Controls.Add(this.label1);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(240, 701);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.bottomPanel.Size = new System.Drawing.Size(1044, 60);
            this.bottomPanel.TabIndex = 3;
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCoordinates.AutoSize = true;
            this.lblCoordinates.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCoordinates.Location = new System.Drawing.Point(900, 20);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(73, 19);
            this.lblCoordinates.TabIndex = 4;
            this.lblCoordinates.Text = "X: 0  Y: 0";
            // 
            // lblActiveToolValue
            // 
            this.lblActiveToolValue.AutoSize = true;
            this.lblActiveToolValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblActiveToolValue.Location = new System.Drawing.Point(366, 20);
            this.lblActiveToolValue.Name = "lblActiveToolValue";
            this.lblActiveToolValue.Size = new System.Drawing.Size(50, 19);
            this.lblActiveToolValue.TabIndex = 3;
            this.lblActiveToolValue.Text = "Kalem";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(280, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aktif Araç:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(74, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 19);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Hazır";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Durum:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.canvasContainerPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.leftPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drawing Tool WinForms";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.leftPanel.ResumeLayout(false);
            this.groupBoxActions.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.groupBoxTools.ResumeLayout(false);
            this.toolsPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.canvasContainerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvasPictureBox)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.GroupBox groupBoxTools;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.FlowLayoutPanel toolsPanel;
        private System.Windows.Forms.Button btnPen;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.Button btnEraser;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbThickness;
        private System.Windows.Forms.Panel pnlSelectedColor;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel canvasContainerPanel;
        private System.Windows.Forms.PictureBox canvasPictureBox;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.Label lblActiveToolValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblColorValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPenSizeValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
