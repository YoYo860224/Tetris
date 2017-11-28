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
            this.nextPanel = new System.Windows.Forms.GroupBox();
            this.levelLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.blockPanel = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // nextPanel
            // 
            this.nextPanel.Location = new System.Drawing.Point(275, 12);
            this.nextPanel.Name = "nextPanel";
            this.nextPanel.Size = new System.Drawing.Size(150, 150);
            this.nextPanel.TabIndex = 15;
            this.nextPanel.TabStop = false;
            // 
            // levelLabel
            // 
            this.levelLabel.Font = new System.Drawing.Font("新細明體", 30F);
            this.levelLabel.Location = new System.Drawing.Point(266, 249);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(300, 50);
            this.levelLabel.TabIndex = 14;
            this.levelLabel.Text = "Level:";
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("新細明體", 30F);
            this.scoreLabel.Location = new System.Drawing.Point(266, 299);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(300, 50);
            this.scoreLabel.TabIndex = 13;
            this.scoreLabel.Text = "Score:";
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("新細明體", 30F);
            this.timeLabel.Location = new System.Drawing.Point(266, 199);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(300, 50);
            this.timeLabel.TabIndex = 12;
            this.timeLabel.Text = "Time:";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(487, 367);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(100, 100);
            this.stopButton.TabIndex = 11;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(381, 367);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(100, 100);
            this.pauseButton.TabIndex = 10;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(275, 367);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 100);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // blockPanel
            // 
            this.blockPanel.Location = new System.Drawing.Point(19, 16);
            this.blockPanel.Name = "blockPanel";
            this.blockPanel.Size = new System.Drawing.Size(241, 455);
            this.blockPanel.TabIndex = 8;
            this.blockPanel.TabStop = false;
            // 
            // TetrisView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 483);
            this.Controls.Add(this.nextPanel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.blockPanel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
            this.Name = "TetrisView";
            this.Text = "TetrisView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox nextPanel;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.GroupBox blockPanel;
    }
}