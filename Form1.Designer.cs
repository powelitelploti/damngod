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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabEquations = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSaveSystem = new System.Windows.Forms.Button();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.btnRandomize = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.nudSystemSize = new System.Windows.Forms.NumericUpDown();
            this.dgvEquations = new System.Windows.Forms.DataGridView();
            this.tabSolution = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSaveSolution = new System.Windows.Forms.Button();
            this.btnCopySolution = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.rtbSolution = new System.Windows.Forms.RichTextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
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
            this.tabControlMain.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1265, 787);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabEquations
            // 
            this.tabEquations.BackColor = System.Drawing.Color.AliceBlue;
            this.tabEquations.Controls.Add(this.button3);
            this.tabEquations.Controls.Add(this.btnClear);
            this.tabEquations.Controls.Add(this.btnSaveSystem);
            this.tabEquations.Controls.Add(this.btnLoadFromFile);
            this.tabEquations.Controls.Add(this.btnRandomize);
            this.tabEquations.Controls.Add(this.btnSolve);
            this.tabEquations.Controls.Add(this.richTextBox1);
            this.tabEquations.Controls.Add(this.nudSystemSize);
            this.tabEquations.Controls.Add(this.dgvEquations);
            this.tabEquations.Location = new System.Drawing.Point(4, 25);
            this.tabEquations.Name = "tabEquations";
            this.tabEquations.Padding = new System.Windows.Forms.Padding(3);
            this.tabEquations.Size = new System.Drawing.Size(1257, 758);
            this.tabEquations.TabIndex = 1;
            this.tabEquations.Text = "Система уравнений";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.AliceBlue;
            this.button3.Location = new System.Drawing.Point(3, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 741);
            this.button3.TabIndex = 8;
            this.button3.Text = "Назад";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.AliceBlue;
            this.btnClear.Location = new System.Drawing.Point(482, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(82, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSaveSystem
            // 
            this.btnSaveSystem.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSaveSystem.Location = new System.Drawing.Point(392, 7);
            this.btnSaveSystem.Name = "btnSaveSystem";
            this.btnSaveSystem.Size = new System.Drawing.Size(82, 23);
            this.btnSaveSystem.TabIndex = 6;
            this.btnSaveSystem.Text = "Сохранить";
            this.btnSaveSystem.UseVisualStyleBackColor = false;
            this.btnSaveSystem.Click += new System.EventHandler(this.btnSaveMatrix_Click);
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.BackColor = System.Drawing.Color.AliceBlue;
            this.btnLoadFromFile.Location = new System.Drawing.Point(301, 7);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(82, 23);
            this.btnLoadFromFile.TabIndex = 5;
            this.btnLoadFromFile.Text = "Загрузить";
            this.btnLoadFromFile.UseVisualStyleBackColor = false;
            this.btnLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
            // 
            // btnRandomize
            // 
            this.btnRandomize.BackColor = System.Drawing.Color.AliceBlue;
            this.btnRandomize.Location = new System.Drawing.Point(159, 7);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(132, 23);
            this.btnRandomize.TabIndex = 4;
            this.btnRandomize.Text = "Заполнить случайно";
            this.btnRandomize.UseVisualStyleBackColor = false;
            this.btnRandomize.Click += new System.EventHandler(this.btnRandomize_Click_1);
            // 
            // btnSolve
            // 
            this.btnSolve.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSolve.Location = new System.Drawing.Point(904, 537);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(86, 41);
            this.btnSolve.TabIndex = 3;
            this.btnSolve.Text = "Решить";
            this.btnSolve.UseVisualStyleBackColor = false;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click_1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(63, 537);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(824, 194);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // nudSystemSize
            // 
            this.nudSystemSize.Location = new System.Drawing.Point(63, 9);
            this.nudSystemSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudSystemSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSystemSize.Name = "nudSystemSize";
            this.nudSystemSize.Size = new System.Drawing.Size(75, 21);
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
            this.dgvEquations.AllowUserToAddRows = false;
            this.dgvEquations.AllowUserToResizeColumns = false;
            this.dgvEquations.AllowUserToResizeRows = false;
            this.dgvEquations.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvEquations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquations.Location = new System.Drawing.Point(63, 36);
            this.dgvEquations.Name = "dgvEquations";
            this.dgvEquations.RowHeadersWidth = 80;
            this.dgvEquations.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvEquations.ShowCellToolTips = false;
            this.dgvEquations.ShowEditingIcon = false;
            this.dgvEquations.Size = new System.Drawing.Size(1163, 484);
            this.dgvEquations.TabIndex = 0;
            this.dgvEquations.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquations_CellValueChanged);
            // 
            // tabSolution
            // 
            this.tabSolution.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabSolution.Controls.Add(this.button2);
            this.tabSolution.Controls.Add(this.button1);
            this.tabSolution.Controls.Add(this.btnSaveSolution);
            this.tabSolution.Controls.Add(this.btnCopySolution);
            this.tabSolution.Controls.Add(this.btnBack);
            this.tabSolution.Controls.Add(this.rtbSolution);
            this.tabSolution.Location = new System.Drawing.Point(4, 25);
            this.tabSolution.Name = "tabSolution";
            this.tabSolution.Size = new System.Drawing.Size(1257, 758);
            this.tabSolution.TabIndex = 2;
            this.tabSolution.Text = "Решение";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.AliceBlue;
            this.button2.Location = new System.Drawing.Point(866, 705);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(383, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Выбрать шрифт";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.AliceBlue;
            this.button1.Location = new System.Drawing.Point(58, 705);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(383, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Распечатать решение";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSaveSolution
            // 
            this.btnSaveSolution.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSaveSolution.Location = new System.Drawing.Point(461, 705);
            this.btnSaveSolution.Name = "btnSaveSolution";
            this.btnSaveSolution.Size = new System.Drawing.Size(383, 23);
            this.btnSaveSolution.TabIndex = 3;
            this.btnSaveSolution.Text = "Сохранить решение";
            this.btnSaveSolution.UseVisualStyleBackColor = false;
            this.btnSaveSolution.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCopySolution
            // 
            this.btnCopySolution.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCopySolution.Location = new System.Drawing.Point(58, 734);
            this.btnCopySolution.Name = "btnCopySolution";
            this.btnCopySolution.Size = new System.Drawing.Size(1197, 23);
            this.btnCopySolution.TabIndex = 2;
            this.btnCopySolution.Text = "Копировать решение";
            this.btnCopySolution.UseVisualStyleBackColor = false;
            this.btnCopySolution.Click += new System.EventHandler(this.btnCopySolution_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.AliceBlue;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(52, 758);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // rtbSolution
            // 
            this.rtbSolution.BackColor = System.Drawing.Color.White;
            this.rtbSolution.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbSolution.Location = new System.Drawing.Point(58, 3);
            this.rtbSolution.Name = "rtbSolution";
            this.rtbSolution.ReadOnly = true;
            this.rtbSolution.Size = new System.Drawing.Size(1195, 696);
            this.rtbSolution.TabIndex = 0;
            this.rtbSolution.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 787);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1285, 830);
            this.MinimumSize = new System.Drawing.Size(1285, 804);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Решение систем линейных алгебраических уравнений методом Крамера";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button button3;
    }
}

