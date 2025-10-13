namespace kurs
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabEquations = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSaveSystem = new System.Windows.Forms.Button();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.btnRandomize = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.nudSystemSize = new System.Windows.Forms.NumericUpDown();
            this.dgvEquations = new System.Windows.Forms.DataGridView();
            this.tabSolution = new System.Windows.Forms.TabPage();
            this.btnSaveSolution = new System.Windows.Forms.Button();
            this.btnCopySolution = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.rtbSolution = new System.Windows.Forms.RichTextBox();
            this.tabControlMain.SuspendLayout();
            this.tabEquations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSystemSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquations)).BeginInit();
            this.tabSolution.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabEquations);
            this.tabControlMain.Controls.Add(this.tabSolution);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1140, 734);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabEquations
            // 
            this.tabEquations.Controls.Add(this.btnClear);
            this.tabEquations.Controls.Add(this.btnSaveSystem);
            this.tabEquations.Controls.Add(this.btnLoadFromFile);
            this.tabEquations.Controls.Add(this.btnRandomize);
            this.tabEquations.Controls.Add(this.btnSolve);
            this.tabEquations.Controls.Add(this.richTextBox1);
            this.tabEquations.Controls.Add(this.nudSystemSize);
            this.tabEquations.Controls.Add(this.dgvEquations);
            this.tabEquations.Location = new System.Drawing.Point(4, 22);
            this.tabEquations.Name = "tabEquations";
            this.tabEquations.Padding = new System.Windows.Forms.Padding(3);
            this.tabEquations.Size = new System.Drawing.Size(1132, 708);
            this.tabEquations.TabIndex = 1;
            this.tabEquations.Text = "Система уравнений";
            this.tabEquations.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(484, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSaveSystem
            // 
            this.btnSaveSystem.Location = new System.Drawing.Point(394, 7);
            this.btnSaveSystem.Name = "btnSaveSystem";
            this.btnSaveSystem.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSystem.TabIndex = 6;
            this.btnSaveSystem.Text = "Сохранить";
            this.btnSaveSystem.UseVisualStyleBackColor = true;
            this.btnSaveSystem.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.Location = new System.Drawing.Point(303, 7);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFromFile.TabIndex = 5;
            this.btnLoadFromFile.Text = "Загрузить";
            this.btnLoadFromFile.UseVisualStyleBackColor = true;
            this.btnLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
            // 
            // btnRandomize
            // 
            this.btnRandomize.Location = new System.Drawing.Point(161, 7);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(125, 23);
            this.btnRandomize.TabIndex = 4;
            this.btnRandomize.Text = "Заполнить случайно";
            this.btnRandomize.UseVisualStyleBackColor = true;
            this.btnRandomize.Click += new System.EventHandler(this.btnRandomize_Click_1);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(876, 484);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 3;
            this.btnSolve.Text = "Решить";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click_1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 486);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(824, 194);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // nudSystemSize
            // 
            this.nudSystemSize.Location = new System.Drawing.Point(18, 10);
            this.nudSystemSize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudSystemSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSystemSize.Name = "nudSystemSize";
            this.nudSystemSize.Size = new System.Drawing.Size(120, 20);
            this.nudSystemSize.TabIndex = 1;
            this.nudSystemSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSystemSize.ValueChanged += new System.EventHandler(this.nudSystemSize_ValueChange);
            // 
            // dgvEquations
            // 
            this.dgvEquations.AllowUserToResizeColumns = false;
            this.dgvEquations.AllowUserToResizeRows = false;
            this.dgvEquations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvEquations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquations.Location = new System.Drawing.Point(8, 45);
            this.dgvEquations.Name = "dgvEquations";
            this.dgvEquations.RowHeadersWidth = 80;
            this.dgvEquations.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvEquations.ShowCellToolTips = false;
            this.dgvEquations.ShowEditingIcon = false;
            this.dgvEquations.Size = new System.Drawing.Size(1086, 412);
            this.dgvEquations.TabIndex = 0;
            this.dgvEquations.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquations_CellValueChanged);
            // 
            // tabSolution
            // 
            this.tabSolution.Controls.Add(this.btnSaveSolution);
            this.tabSolution.Controls.Add(this.btnCopySolution);
            this.tabSolution.Controls.Add(this.btnBack);
            this.tabSolution.Controls.Add(this.rtbSolution);
            this.tabSolution.Location = new System.Drawing.Point(4, 22);
            this.tabSolution.Name = "tabSolution";
            this.tabSolution.Size = new System.Drawing.Size(1132, 708);
            this.tabSolution.TabIndex = 2;
            this.tabSolution.Text = "Решение";
            this.tabSolution.UseVisualStyleBackColor = true;
            // 
            // btnSaveSolution
            // 
            this.btnSaveSolution.Location = new System.Drawing.Point(571, 656);
            this.btnSaveSolution.Name = "btnSaveSolution";
            this.btnSaveSolution.Size = new System.Drawing.Size(558, 23);
            this.btnSaveSolution.TabIndex = 3;
            this.btnSaveSolution.Text = "Сохранить решение";
            this.btnSaveSolution.UseVisualStyleBackColor = true;
            this.btnSaveSolution.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCopySolution
            // 
            this.btnCopySolution.Location = new System.Drawing.Point(-4, 656);
            this.btnCopySolution.Name = "btnCopySolution";
            this.btnCopySolution.Size = new System.Drawing.Size(569, 23);
            this.btnCopySolution.TabIndex = 2;
            this.btnCopySolution.Text = "Копировать решение";
            this.btnCopySolution.UseVisualStyleBackColor = true;
            this.btnCopySolution.Click += new System.EventHandler(this.btnCopySolution_Click);
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBack.Location = new System.Drawing.Point(0, 685);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(1132, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // rtbSolution
            // 
            this.rtbSolution.Location = new System.Drawing.Point(19, 16);
            this.rtbSolution.Name = "rtbSolution";
            this.rtbSolution.Size = new System.Drawing.Size(1096, 611);
            this.rtbSolution.TabIndex = 0;
            this.rtbSolution.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 734);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControlMain.ResumeLayout(false);
            this.tabEquations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSystemSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquations)).EndInit();
            this.tabSolution.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabEquations;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NumericUpDown nudSystemSize;
        private System.Windows.Forms.DataGridView dgvEquations;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSaveSystem;
        private System.Windows.Forms.Button btnLoadFromFile;
        private System.Windows.Forms.Button btnRandomize;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.TabPage tabSolution;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RichTextBox rtbSolution;
        private System.Windows.Forms.Button btnSaveSolution;
        private System.Windows.Forms.Button btnCopySolution;
    }
}

