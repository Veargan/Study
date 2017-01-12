using PainterV;

namespace Painter
{
    partial class MiniPaintV
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
            cmd = new XCommand();
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.mainMenu = new PainterV.UserControls.Menu.MainMenuVector(cmd);
            this.toolBar = new PainterV.UserControls.Menu.ToolBarVector(cmd);
            this.toolBox = new PainterV.UserControls.Menu.ToolBoxVector(cmd);
            this.canvasVector = new Painter.UserControls.VectorElements.CanvasVector();
            this.statusBar = new PainterV.UserControls.Menu.StatusBarVector();
            this.TLP_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 2;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Controls.Add(this.mainMenu, 0, 0);
            this.TLP_Main.Controls.Add(this.toolBar, 0, 1);
            this.TLP_Main.Controls.Add(this.toolBox, 0, 2);
            this.TLP_Main.Controls.Add(this.canvasVector, 1, 2);
            this.TLP_Main.Controls.Add(this.statusBar, 0, 3);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 4;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.Size = new System.Drawing.Size(1438, 768);
            this.TLP_Main.TabIndex = 0;
            // 
            // mainMenu
            // 
            this.TLP_Main.SetColumnSpan(this.mainMenu, 2);
            this.mainMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Margin = new System.Windows.Forms.Padding(0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1438, 29);
            this.mainMenu.TabIndex = 0;
            // 
            // toolBar
            // 
            this.TLP_Main.SetColumnSpan(this.toolBar, 2);
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBar.Location = new System.Drawing.Point(0, 29);
            this.toolBar.Margin = new System.Windows.Forms.Padding(0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1438, 30);
            this.toolBar.TabIndex = 1;
            // 
            // toolBox
            // 
            this.toolBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBox.Location = new System.Drawing.Point(3, 62);
            this.toolBox.Name = "toolBox";
            this.toolBox.Size = new System.Drawing.Size(131, 133);
            this.toolBox.TabIndex = 2;
            // 
            // canvasVector
            // 
            this.canvasVector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvasVector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasVector.Location = new System.Drawing.Point(140, 62);
            this.canvasVector.Name = "canvasVector";
            this.canvasVector.Size = new System.Drawing.Size(1295, 671);
            this.canvasVector.TabIndex = 3;
            this.canvasVector.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // statusBar
            // 
            this.TLP_Main.SetColumnSpan(this.statusBar, 2);
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar.Location = new System.Drawing.Point(3, 739);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1432, 26);
            this.statusBar.TabIndex = 4;
            // 
            // MiniPaintV
            // 
            this.ClientSize = new System.Drawing.Size(1438, 768);
            this.Controls.Add(this.TLP_Main);
            this.Name = "MiniPaintV";
            this.TLP_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        public XCommand cmd;
        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private PainterV.UserControls.Menu.MainMenuVector mainMenu;
        private PainterV.UserControls.Menu.ToolBarVector toolBar;
        private UserControls.VectorElements.CanvasVector canvasVector;
        private PainterV.UserControls.Menu.ToolBoxVector toolBox;
        private PainterV.UserControls.Menu.StatusBarVector statusBar;
    }
}

