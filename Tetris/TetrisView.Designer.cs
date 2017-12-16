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
            this.blockPanel = new System.Windows.Forms.Panel();
            this.nextPanel = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.secTimer = new System.Windows.Forms.Timer(this.components);
            this.stopButton = new Tetris.NonSelectableButton();
            this.pauseButton = new Tetris.NonSelectableButton();
            this.startButton = new Tetris.NonSelectableButton();
            this.SuspendLayout();
            // 
            // levelLabel
            // 
            this.levelLabel.Font = new System.Drawing.Font("新細明體", 30F);
            this.levelLabel.Location = new System.Drawing.Point(233, 241);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(300, 50);
            this.levelLabel.TabIndex = 14;
            this.levelLabel.Text = "Level:";
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("新細明體", 30F);
            this.scoreLabel.Location = new System.Drawing.Point(233, 179);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(300, 50);
            this.scoreLabel.TabIndex = 13;
            this.scoreLabel.Text = "Score:";
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("新細明體", 30F);
            this.timeLabel.Location = new System.Drawing.Point(233, 117);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(300, 50);
            this.timeLabel.TabIndex = 12;
            this.timeLabel.Text = "Time:";
            // 
            // blockPanel
            // 
            this.blockPanel.Location = new System.Drawing.Point(4, 4);
            this.blockPanel.Margin = new System.Windows.Forms.Padding(4);
            this.blockPanel.Name = "blockPanel";
            this.blockPanel.Size = new System.Drawing.Size(200, 400);
            this.blockPanel.TabIndex = 16;
            // 
            // nextPanel
            // 
            this.nextPanel.Location = new System.Drawing.Point(237, 4);
            this.nextPanel.Margin = new System.Windows.Forms.Padding(4);
            this.nextPanel.Name = "nextPanel";
            this.nextPanel.Size = new System.Drawing.Size(80, 80);
            this.nextPanel.TabIndex = 17;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 30;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // secTimer
            // 
            this.secTimer.Enabled = true;
            this.secTimer.Interval = 1000;
            this.secTimer.Tick += new System.EventHandler(this.secTimer_Tick);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(433, 310);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(100, 94);
            this.stopButton.TabIndex = 20;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(325, 310);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(4);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(100, 94);
            this.pauseButton.TabIndex = 19;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(217, 310);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 94);
            this.startButton.TabIndex = 18;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // TetrisView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(553, 420);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.nextPanel);
            this.Controls.Add(this.blockPanel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timeLabel);
            this.KeyPreview = true;
            this.Name = "TetrisView";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TetrisView_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label levelLabel;
        protected System.Windows.Forms.Label scoreLabel;
        protected System.Windows.Forms.Label timeLabel;
        protected System.Windows.Forms.Panel blockPanel;
        protected System.Windows.Forms.Panel nextPanel;
        protected System.Windows.Forms.Timer timer;
        protected NonSelectableButton startButton;
        protected NonSelectableButton pauseButton;
        protected NonSelectableButton stopButton;
        protected System.Windows.Forms.Timer secTimer;
    }
}