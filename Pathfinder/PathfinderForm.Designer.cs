namespace Pathfinder {
    partial class PathfinderForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathfinderForm));
            this.ButtonBox = new System.Windows.Forms.GroupBox();
            this.SourceRadioButton = new System.Windows.Forms.RadioButton();
            this.DestinationRadioButton = new System.Windows.Forms.RadioButton();
            this.ObstacleRadioButton = new System.Windows.Forms.RadioButton();
            this.ClearRadioButton = new System.Windows.Forms.RadioButton();
            this.PathfinderButton = new System.Windows.Forms.Button();
            this.UtilitiesPanel = new System.Windows.Forms.Panel();
            this.MazeGeneratorButton = new System.Windows.Forms.Button();
            this.ModeTextLabel = new System.Windows.Forms.Label();
            this.AnimationSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.AnimationSpeedLabel = new System.Windows.Forms.Label();
            this.ClearAllButton = new System.Windows.Forms.Button();
            this.AlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.AlgorithmLabel = new System.Windows.Forms.Label();
            this.UtilitiesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonBox
            // 
            this.ButtonBox.BackColor = System.Drawing.Color.DarkGray;
            this.ButtonBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonBox.ForeColor = System.Drawing.Color.Transparent;
            this.ButtonBox.Location = new System.Drawing.Point(0, 100);
            this.ButtonBox.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonBox.MaximumSize = new System.Drawing.Size(1200, 1000);
            this.ButtonBox.Name = "ButtonBox";
            this.ButtonBox.Padding = new System.Windows.Forms.Padding(0);
            this.ButtonBox.Size = new System.Drawing.Size(1200, 880);
            this.ButtonBox.TabIndex = 0;
            this.ButtonBox.TabStop = false;
            // 
            // SourceRadioButton
            // 
            this.SourceRadioButton.AutoSize = true;
            this.SourceRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.SourceRadioButton.Checked = true;
            this.SourceRadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SourceRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceRadioButton.ForeColor = System.Drawing.Color.White;
            this.SourceRadioButton.Location = new System.Drawing.Point(465, 14);
            this.SourceRadioButton.Name = "SourceRadioButton";
            this.SourceRadioButton.Size = new System.Drawing.Size(75, 20);
            this.SourceRadioButton.TabIndex = 1;
            this.SourceRadioButton.TabStop = true;
            this.SourceRadioButton.Text = "Source";
            this.SourceRadioButton.UseVisualStyleBackColor = false;
            // 
            // DestinationRadioButton
            // 
            this.DestinationRadioButton.AutoSize = true;
            this.DestinationRadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DestinationRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestinationRadioButton.ForeColor = System.Drawing.Color.White;
            this.DestinationRadioButton.Location = new System.Drawing.Point(546, 14);
            this.DestinationRadioButton.Name = "DestinationRadioButton";
            this.DestinationRadioButton.Size = new System.Drawing.Size(104, 20);
            this.DestinationRadioButton.TabIndex = 2;
            this.DestinationRadioButton.Text = "Destination";
            this.DestinationRadioButton.UseVisualStyleBackColor = true;
            // 
            // ObstacleRadioButton
            // 
            this.ObstacleRadioButton.AutoSize = true;
            this.ObstacleRadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ObstacleRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObstacleRadioButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ObstacleRadioButton.Location = new System.Drawing.Point(650, 14);
            this.ObstacleRadioButton.Name = "ObstacleRadioButton";
            this.ObstacleRadioButton.Size = new System.Drawing.Size(88, 20);
            this.ObstacleRadioButton.TabIndex = 3;
            this.ObstacleRadioButton.Text = "Obstacle";
            this.ObstacleRadioButton.UseVisualStyleBackColor = true;
            // 
            // ClearRadioButton
            // 
            this.ClearRadioButton.AutoSize = true;
            this.ClearRadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearRadioButton.ForeColor = System.Drawing.Color.White;
            this.ClearRadioButton.Location = new System.Drawing.Point(748, 14);
            this.ClearRadioButton.Name = "ClearRadioButton";
            this.ClearRadioButton.Size = new System.Drawing.Size(63, 20);
            this.ClearRadioButton.TabIndex = 4;
            this.ClearRadioButton.Text = "Clear";
            this.ClearRadioButton.UseVisualStyleBackColor = true;
            this.ClearRadioButton.CheckedChanged += new System.EventHandler(this.ClearRadioButton_CheckedChanged);
            // 
            // PathfinderButton
            // 
            this.PathfinderButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.PathfinderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PathfinderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PathfinderButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.PathfinderButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.PathfinderButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.PathfinderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PathfinderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathfinderButton.ForeColor = System.Drawing.Color.White;
            this.PathfinderButton.Location = new System.Drawing.Point(267, 5);
            this.PathfinderButton.Name = "PathfinderButton";
            this.PathfinderButton.Size = new System.Drawing.Size(97, 35);
            this.PathfinderButton.TabIndex = 5;
            this.PathfinderButton.Text = "Find Path";
            this.PathfinderButton.UseVisualStyleBackColor = false;
            this.PathfinderButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PathfinderButton_MouseDown);
            // 
            // UtilitiesPanel
            // 
            this.UtilitiesPanel.BackColor = System.Drawing.Color.Indigo;
            this.UtilitiesPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.UtilitiesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UtilitiesPanel.Controls.Add(this.MazeGeneratorButton);
            this.UtilitiesPanel.Controls.Add(this.ModeTextLabel);
            this.UtilitiesPanel.Controls.Add(this.AnimationSpeedComboBox);
            this.UtilitiesPanel.Controls.Add(this.AnimationSpeedLabel);
            this.UtilitiesPanel.Controls.Add(this.ClearAllButton);
            this.UtilitiesPanel.Controls.Add(this.PathfinderButton);
            this.UtilitiesPanel.Controls.Add(this.AlgorithmComboBox);
            this.UtilitiesPanel.Controls.Add(this.ClearRadioButton);
            this.UtilitiesPanel.Controls.Add(this.AlgorithmLabel);
            this.UtilitiesPanel.Controls.Add(this.ObstacleRadioButton);
            this.UtilitiesPanel.Controls.Add(this.SourceRadioButton);
            this.UtilitiesPanel.Controls.Add(this.DestinationRadioButton);
            this.UtilitiesPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UtilitiesPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UtilitiesPanel.Location = new System.Drawing.Point(0, 0);
            this.UtilitiesPanel.Name = "UtilitiesPanel";
            this.UtilitiesPanel.Size = new System.Drawing.Size(1200, 100);
            this.UtilitiesPanel.TabIndex = 6;
            // 
            // MazeGeneratorButton
            // 
            this.MazeGeneratorButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.MazeGeneratorButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.MazeGeneratorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.MazeGeneratorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.MazeGeneratorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MazeGeneratorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MazeGeneratorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.MazeGeneratorButton.Location = new System.Drawing.Point(1066, 8);
            this.MazeGeneratorButton.Name = "MazeGeneratorButton";
            this.MazeGeneratorButton.Size = new System.Drawing.Size(120, 43);
            this.MazeGeneratorButton.TabIndex = 12;
            this.MazeGeneratorButton.Text = "Generate Maze";
            this.MazeGeneratorButton.UseVisualStyleBackColor = false;
            this.MazeGeneratorButton.Click += new System.EventHandler(this.MazeGeneratorButton_Click);
            // 
            // ModeTextLabel
            // 
            this.ModeTextLabel.BackColor = System.Drawing.Color.MidnightBlue;
            this.ModeTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModeTextLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ModeTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeTextLabel.ForeColor = System.Drawing.Color.White;
            this.ModeTextLabel.Location = new System.Drawing.Point(379, 5);
            this.ModeTextLabel.Name = "ModeTextLabel";
            this.ModeTextLabel.Size = new System.Drawing.Size(80, 35);
            this.ModeTextLabel.TabIndex = 11;
            this.ModeTextLabel.Text = "Mode";
            this.ModeTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AnimationSpeedComboBox
            // 
            this.AnimationSpeedComboBox.BackColor = System.Drawing.Color.MidnightBlue;
            this.AnimationSpeedComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimationSpeedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AnimationSpeedComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AnimationSpeedComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimationSpeedComboBox.ForeColor = System.Drawing.Color.White;
            this.AnimationSpeedComboBox.FormattingEnabled = true;
            this.AnimationSpeedComboBox.Items.AddRange(new object[] {
            "10",
            "20",
            "50"});
            this.AnimationSpeedComboBox.Location = new System.Drawing.Point(102, 56);
            this.AnimationSpeedComboBox.Name = "AnimationSpeedComboBox";
            this.AnimationSpeedComboBox.Size = new System.Drawing.Size(80, 24);
            this.AnimationSpeedComboBox.TabIndex = 8;
            this.AnimationSpeedComboBox.SelectedIndexChanged += new System.EventHandler(this.AnimationSpeedComboBox_SelectedIndexChanged);
            // 
            // AnimationSpeedLabel
            // 
            this.AnimationSpeedLabel.BackColor = System.Drawing.Color.MidnightBlue;
            this.AnimationSpeedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnimationSpeedLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.AnimationSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimationSpeedLabel.ForeColor = System.Drawing.Color.White;
            this.AnimationSpeedLabel.Location = new System.Drawing.Point(5, 43);
            this.AnimationSpeedLabel.Name = "AnimationSpeedLabel";
            this.AnimationSpeedLabel.Size = new System.Drawing.Size(91, 48);
            this.AnimationSpeedLabel.TabIndex = 7;
            this.AnimationSpeedLabel.Text = "Animation Speed (ms)";
            this.AnimationSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClearAllButton
            // 
            this.ClearAllButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClearAllButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearAllButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ClearAllButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.ClearAllButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.ClearAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearAllButton.ForeColor = System.Drawing.Color.White;
            this.ClearAllButton.Location = new System.Drawing.Point(817, 8);
            this.ClearAllButton.Name = "ClearAllButton";
            this.ClearAllButton.Size = new System.Drawing.Size(92, 35);
            this.ClearAllButton.TabIndex = 6;
            this.ClearAllButton.Text = "Clear All";
            this.ClearAllButton.UseVisualStyleBackColor = false;
            this.ClearAllButton.Click += new System.EventHandler(this.ClearAllButton_Click);
            // 
            // AlgorithmComboBox
            // 
            this.AlgorithmComboBox.BackColor = System.Drawing.Color.MidnightBlue;
            this.AlgorithmComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgorithmComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AlgorithmComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgorithmComboBox.ForeColor = System.Drawing.Color.White;
            this.AlgorithmComboBox.FormattingEnabled = true;
            this.AlgorithmComboBox.Items.AddRange(new object[] {
            "A*",
            "BFS",
            "DFS",
            "Greedy Search",
            "Uniform Cost Search"});
            this.AlgorithmComboBox.Location = new System.Drawing.Point(90, 10);
            this.AlgorithmComboBox.Name = "AlgorithmComboBox";
            this.AlgorithmComboBox.Size = new System.Drawing.Size(171, 24);
            this.AlgorithmComboBox.Sorted = true;
            this.AlgorithmComboBox.TabIndex = 1;
            // 
            // AlgorithmLabel
            // 
            this.AlgorithmLabel.BackColor = System.Drawing.Color.MidnightBlue;
            this.AlgorithmLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlgorithmLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.AlgorithmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgorithmLabel.ForeColor = System.Drawing.Color.White;
            this.AlgorithmLabel.Location = new System.Drawing.Point(5, 5);
            this.AlgorithmLabel.Name = "AlgorithmLabel";
            this.AlgorithmLabel.Size = new System.Drawing.Size(79, 35);
            this.AlgorithmLabel.TabIndex = 0;
            this.AlgorithmLabel.Text = "Algorithm";
            this.AlgorithmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PathfinderForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1199, 981);
            this.Controls.Add(this.UtilitiesPanel);
            this.Controls.Add(this.ButtonBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PathfinderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pathfinder";
            this.TransparencyKey = System.Drawing.Color.PaleGreen;
            this.UtilitiesPanel.ResumeLayout(false);
            this.UtilitiesPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox ButtonBox;
        private System.Windows.Forms.RadioButton SourceRadioButton;
        private System.Windows.Forms.RadioButton DestinationRadioButton;
        private System.Windows.Forms.RadioButton ObstacleRadioButton;
        private System.Windows.Forms.RadioButton ClearRadioButton;
        private System.Windows.Forms.Button PathfinderButton;
        private System.Windows.Forms.Panel UtilitiesPanel;
        private System.Windows.Forms.Label AlgorithmLabel;
        private System.Windows.Forms.ComboBox AlgorithmComboBox;
        private System.Windows.Forms.Button ClearAllButton;
        private System.Windows.Forms.Label AnimationSpeedLabel;
        private System.Windows.Forms.ComboBox AnimationSpeedComboBox;
        private System.Windows.Forms.Label ModeTextLabel;
        private System.Windows.Forms.Button MazeGeneratorButton;
    }
}

