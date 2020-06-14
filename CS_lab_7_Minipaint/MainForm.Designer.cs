namespace CS_lab_7_Minipaint
{
    partial class MainForm
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
            this.panelPainting = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelColorText = new System.Windows.Forms.Label();
            this.labelColorImage = new System.Windows.Forms.Label();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.labelWidth = new System.Windows.Forms.Label();
            this.comboBoxFigure = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPainting
            // 
            this.panelPainting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPainting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPainting.Location = new System.Drawing.Point(122, 12);
            this.panelPainting.Name = "panelPainting";
            this.panelPainting.Size = new System.Drawing.Size(666, 426);
            this.panelPainting.TabIndex = 0;
            this.panelPainting.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPainting_Paint);
            this.panelPainting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelPainting_MouseDown);
            this.panelPainting.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelPainting_MouseMove);
            this.panelPainting.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelPainting_MouseUp);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(13, 351);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(103, 87);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelColorText
            // 
            this.labelColorText.AutoSize = true;
            this.labelColorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelColorText.Location = new System.Drawing.Point(40, 12);
            this.labelColorText.Name = "labelColorText";
            this.labelColorText.Size = new System.Drawing.Size(41, 17);
            this.labelColorText.TabIndex = 3;
            this.labelColorText.Text = "Цвет";
            // 
            // labelColorImage
            // 
            this.labelColorImage.BackColor = System.Drawing.Color.Black;
            this.labelColorImage.Location = new System.Drawing.Point(41, 51);
            this.labelColorImage.Name = "labelColorImage";
            this.labelColorImage.Size = new System.Drawing.Size(40, 40);
            this.labelColorImage.TabIndex = 4;
            this.labelColorImage.Click += new System.EventHandler(this.labelColorImage_Click);
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(32, 148);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownWidth.TabIndex = 5;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWidth.Location = new System.Drawing.Point(29, 118);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(68, 17);
            this.labelWidth.TabIndex = 6;
            this.labelWidth.Text = "Толщина";
            // 
            // comboBoxFigure
            // 
            this.comboBoxFigure.FormattingEnabled = true;
            this.comboBoxFigure.Location = new System.Drawing.Point(13, 184);
            this.comboBoxFigure.Name = "comboBoxFigure";
            this.comboBoxFigure.Size = new System.Drawing.Size(103, 21);
            this.comboBoxFigure.Sorted = true;
            this.comboBoxFigure.TabIndex = 7;
            this.comboBoxFigure.SelectedIndexChanged += new System.EventHandler(this.comboBoxFigure_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(13, 244);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(103, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(13, 273);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(103, 23);
            this.buttonLoad.TabIndex = 9;
            this.buttonLoad.Text = "Загрузить";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "(*.xml)|*.xml";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "(*.xml)|*.xml";
            // 
            // colorDialog
            // 
            this.colorDialog.AllowFullOpen = false;
            this.colorDialog.SolidColorOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxFigure);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.numericUpDownWidth);
            this.Controls.Add(this.labelColorImage);
            this.Controls.Add(this.labelColorText);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.panelPainting);
            this.MinimumSize = new System.Drawing.Size(816, 488);
            this.Name = "MainForm";
            this.Text = "Минипаинт";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPainting;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelColorText;
        private System.Windows.Forms.Label labelColorImage;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.ComboBox comboBoxFigure;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}

