namespace Tetris
{
    partial class TetrisView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.levelLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.stopButton = new Tetris.NonSelectableButton();
            this.pauseButton = new Tetris.NonSelectableButton();
            this.startButton = new Tetris.NonSelectableButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.secTimer = new System.Windows.Forms.Timer(this.components);
            this.blockPanel = new System.Windows.Forms.Panel();
            this.nextPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // levelLabel
            // 
            this.levelLabel.Font = new System.Drawing.Font("新細明體", 30F);
            this.levelLabel.Location = new System.Drawing.Point(317, 234);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(300, 50);
            this.levelLabel.TabIndex = 14;
            this.levelLabel.Text = "Level:";
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("新細明體", 30F);
            this.scoreLabel.Location = new System.Drawing.Point(317, 284);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(300, 50);
            this.scoreLabel.TabIndex = 13;
            this.scoreLabel.Text = "Score:";
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("新細明體", 30F);
            this.timeLabel.Location = new System.Drawing.Point(317, 184);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(300, 50);
            this.timeLabel.TabIndex = 12;
            this.timeLabel.Text = "Time:";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(531, 391);
            this.stopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(100, 100);
            this.stopButton.TabIndex = 11;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(425, 391);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(100, 100);
            this.pauseButton.TabIndex = 10;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(319, 391);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 100);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // secTimer
            // 
            this.secTimer.Enabled = true;
            this.secTimer.Interval = 1000;
            this.secTimer.Tick += new System.EventHandler(this.secTimer_Tick);
            // 
            // blockPanel
            // 
            this.blockPanel.Location = new System.Drawing.Point(16, 15);
            this.blockPanel.Margin = new System.Windows.Forms.Padding(4);
            this.blockPanel.Name = "blockPanel";
            this.blockPanel.Size = new System.Drawing.Size(267, 500);
            this.blockPanel.TabIndex = 16;
            // 
            // nextPanel
            // 
            this.nextPanel.Location = new System.Drawing.Point(291, 15);
            this.nextPanel.Margin = new System.Windows.Forms.Padding(4);
            this.nextPanel.Name = "nextPanel";
            this.nextPanel.Size = new System.Drawing.Size(107, 100);
            this.nextPanel.TabIndex = 17;
            // 
            // TetrisView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 525);
            this.Controls.Add(this.nextPanel);
            this.Controls.Add(this.blockPanel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TetrisView";
            this.Text = "TetrisView";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TetrisView_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Label levelLabel;
        protected System.Windows.Forms.Label scoreLabel;
        protected System.Windows.Forms.Label timeLabel;
        protected NonSelectableButton stopButton;
        protected NonSelectableButton pauseButton;
        protected NonSelectableButton startButton;
        protected System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel blockPanel;
        private System.Windows.Forms.Panel nextPanel;
        protected System.Windows.Forms.Timer secTimer;
    }
}