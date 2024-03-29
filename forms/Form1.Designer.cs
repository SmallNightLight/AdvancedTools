namespace RuntimeScripting
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LuaCode = new TextBox();
            PythonCode = new TextBox();
            CSharpCode = new TextBox();
            CSharpLabel = new Label();
            LuaLabel = new Label();
            PythonLabel = new Label();
            CSharpCompile = new Button();
            LuaCompile = new Button();
            PythonCompile = new Button();
            CSharpRun = new Button();
            LuaRun = new Button();
            PythonRun = new Button();
            PythonConsole = new TextBox();
            LuaConsole = new TextBox();
            CSharpConsole = new TextBox();
            TestAllButton = new Button();
            SuspendLayout();
            // 
            // LuaCode
            // 
            LuaCode.Location = new Point(303, 57);
            LuaCode.Multiline = true;
            LuaCode.Name = "LuaCode";
            LuaCode.Size = new Size(200, 220);
            LuaCode.TabIndex = 0;
            // 
            // PythonCode
            // 
            PythonCode.Location = new Point(558, 57);
            PythonCode.Multiline = true;
            PythonCode.Name = "PythonCode";
            PythonCode.Size = new Size(200, 220);
            PythonCode.TabIndex = 1;
            // 
            // CSharpCode
            // 
            CSharpCode.Location = new Point(45, 57);
            CSharpCode.Multiline = true;
            CSharpCode.Name = "CSharpCode";
            CSharpCode.Size = new Size(200, 220);
            CSharpCode.TabIndex = 2;
            // 
            // CSharpLabel
            // 
            CSharpLabel.AutoSize = true;
            CSharpLabel.Location = new Point(131, 19);
            CSharpLabel.Name = "CSharpLabel";
            CSharpLabel.Size = new Size(22, 15);
            CSharpLabel.TabIndex = 3;
            CSharpLabel.Text = "C#";
            // 
            // LuaLabel
            // 
            LuaLabel.AutoSize = true;
            LuaLabel.Location = new Point(389, 19);
            LuaLabel.Name = "LuaLabel";
            LuaLabel.Size = new Size(26, 15);
            LuaLabel.TabIndex = 4;
            LuaLabel.Text = "Lua";
            // 
            // PythonLabel
            // 
            PythonLabel.AutoSize = true;
            PythonLabel.Location = new Point(638, 19);
            PythonLabel.Name = "PythonLabel";
            PythonLabel.Size = new Size(45, 15);
            PythonLabel.TabIndex = 5;
            PythonLabel.Text = "Python";
            // 
            // CSharpCompile
            // 
            CSharpCompile.Location = new Point(113, 283);
            CSharpCompile.Name = "CSharpCompile";
            CSharpCompile.Size = new Size(75, 23);
            CSharpCompile.TabIndex = 6;
            CSharpCompile.Text = "Compile";
            CSharpCompile.UseVisualStyleBackColor = true;
            CSharpCompile.Click += CSharpCompile_Click;
            // 
            // LuaCompile
            // 
            LuaCompile.Location = new Point(369, 283);
            LuaCompile.Name = "LuaCompile";
            LuaCompile.Size = new Size(75, 23);
            LuaCompile.TabIndex = 7;
            LuaCompile.Text = "Compile";
            LuaCompile.UseVisualStyleBackColor = true;
            LuaCompile.Click += LuaCompile_Click;
            // 
            // PythonCompile
            // 
            PythonCompile.Location = new Point(626, 283);
            PythonCompile.Name = "PythonCompile";
            PythonCompile.Size = new Size(75, 23);
            PythonCompile.TabIndex = 8;
            PythonCompile.Text = "Compile";
            PythonCompile.UseVisualStyleBackColor = true;
            PythonCompile.Click += PythonCompile_Click;
            // 
            // CSharpRun
            // 
            CSharpRun.Location = new Point(113, 312);
            CSharpRun.Name = "CSharpRun";
            CSharpRun.Size = new Size(75, 23);
            CSharpRun.TabIndex = 9;
            CSharpRun.Text = "Run";
            CSharpRun.UseVisualStyleBackColor = true;
            CSharpRun.Click += CSharpRun_Click;
            // 
            // LuaRun
            // 
            LuaRun.Location = new Point(369, 312);
            LuaRun.Name = "LuaRun";
            LuaRun.Size = new Size(75, 23);
            LuaRun.TabIndex = 10;
            LuaRun.Text = "Run";
            LuaRun.UseVisualStyleBackColor = true;
            LuaRun.Click += LuaRun_Click;
            // 
            // PythonRun
            // 
            PythonRun.Location = new Point(626, 312);
            PythonRun.Name = "PythonRun";
            PythonRun.Size = new Size(75, 23);
            PythonRun.TabIndex = 11;
            PythonRun.Text = "Run";
            PythonRun.UseVisualStyleBackColor = true;
            PythonRun.Click += PythonRun_Click;
            // 
            // PythonConsole
            // 
            PythonConsole.Location = new Point(558, 355);
            PythonConsole.Multiline = true;
            PythonConsole.Name = "PythonConsole";
            PythonConsole.Size = new Size(200, 83);
            PythonConsole.TabIndex = 12;
            // 
            // LuaConsole
            // 
            LuaConsole.Location = new Point(303, 355);
            LuaConsole.Multiline = true;
            LuaConsole.Name = "LuaConsole";
            LuaConsole.Size = new Size(200, 83);
            LuaConsole.TabIndex = 13;
            // 
            // CSharpConsole
            // 
            CSharpConsole.Location = new Point(45, 355);
            CSharpConsole.Multiline = true;
            CSharpConsole.Name = "CSharpConsole";
            CSharpConsole.Size = new Size(200, 83);
            CSharpConsole.TabIndex = 14;
            // 
            // TestAllButton
            // 
            TestAllButton.Location = new Point(1, 2);
            TestAllButton.Name = "TestAllButton";
            TestAllButton.Size = new Size(75, 23);
            TestAllButton.TabIndex = 15;
            TestAllButton.Text = "Test All";
            TestAllButton.UseVisualStyleBackColor = true;
            TestAllButton.Click += TestAllButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TestAllButton);
            Controls.Add(CSharpConsole);
            Controls.Add(LuaConsole);
            Controls.Add(PythonConsole);
            Controls.Add(PythonRun);
            Controls.Add(LuaRun);
            Controls.Add(CSharpRun);
            Controls.Add(PythonCompile);
            Controls.Add(LuaCompile);
            Controls.Add(CSharpCompile);
            Controls.Add(PythonLabel);
            Controls.Add(LuaLabel);
            Controls.Add(CSharpLabel);
            Controls.Add(CSharpCode);
            Controls.Add(PythonCode);
            Controls.Add(LuaCode);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LuaCode;
        private TextBox PythonCode;
        private TextBox CSharpCode;
        private Label CSharpLabel;
        private Label LuaLabel;
        private Label PythonLabel;
        private Button CSharpCompile;
        private Button LuaCompile;
        private Button PythonCompile;
        private Button CSharpRun;
        private Button LuaRun;
        private Button PythonRun;
        private TextBox PythonConsole;
        private TextBox LuaConsole;
        private TextBox CSharpConsole;
        private Button TestAllButton;
    }
}
