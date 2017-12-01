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
            this.stopButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.secTimer = new System.Windows.Forms.Timer(this.components);
            this.blockPanel = new System.Windows.Forms.Panel();
            this.nextPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // levelLabel
            // 
            this.levelLabel.Font = new System.Drawing.Font("新細明體", 30F);
            this.levelLabel.Location = new System.Drawing.Point(238, 187);
            this.levelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(225, 40);
            this.levelLabel.TabIndex = 14;
            this.levelLabel.Text = "Level:";
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("新細明體", 30F);
            this.scoreLabel.Location = new System.Drawing.Point(238, 227);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(225, 40);
            this.scoreLabel.TabIndex = 13;
            this.scoreLabel.Text = "Score:";
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("新細明體", 30F);
            this.timeLabel.Location = new System.Drawing.Point(238, 147);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(225, 40);
            this.timeLabel.TabIndex = 12;
            this.timeLabel.Text = "Time:";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(398, 313);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 80);
            this.stopButton.TabIndex = 11;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(319, 313);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 80);
            this.pauseButton.TabIndex = 10;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(239, 313);
            this.startButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 80);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // secTimer
            // 
            this.secTimer.Tick += new System.EventHandler(this.secTimer_Tick);
            // 
            // blockPanel
            // 
            this.blockPanel.Location = new System.Drawing.Point(12, 12);
            this.blockPanel.Name = "blockPanel";
            this.blockPanel.Size = new System.Drawing.Size(200, 400);
            this.blockPanel.TabIndex = 16;
            // 
            // nextPanel
            // 
            this.nextPanel.Location = new System.Drawing.Point(218, 12);
            this.nextPanel.Name = "nextPanel";
            this.nextPanel.Size = new System.Drawing.Size(80, 80);
            this.nextPanel.TabIndex = 17;
            // 
            // TetrisView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.Controls.Add(this.nextPanel);
            this.Controls.Add(this.blockPanel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TetrisView";
            this.Text = "TetrisView";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TetrisView_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Label levelLabel;
        protected System.Windows.Forms.Label scoreLabel;
        protected System.Windows.Forms.Label timeLabel;
        protected System.Windows.Forms.Button stopButton;
        protected System.Windows.Forms.Button pauseButton;
        protected System.Windows.Forms.Button startButton;
        protected System.Windows.Forms.Timer timer;
        protected System.Windows.Forms.Timer secTimer;
        private System.Windows.Forms.Panel blockPanel;
        private System.Windows.Forms.Panel nextPanel;
    }
}