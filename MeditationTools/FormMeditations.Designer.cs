namespace MeditationTools
{
    partial class FormMeditations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMeditations));
            this.btnStopMed = new System.Windows.Forms.Button();
            this.btnStopQuicker = new System.Windows.Forms.Button();
            this.panelPaint = new System.Windows.Forms.Panel();
            this.btnBreathWheel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStopMed
            // 
            this.btnStopMed.Location = new System.Drawing.Point(12, 12);
            this.btnStopMed.Name = "btnStopMed";
            this.btnStopMed.Size = new System.Drawing.Size(301, 137);
            this.btnStopMed.TabIndex = 0;
            this.btnStopMed.Text = "\"Stop\"";
            this.btnStopMed.UseVisualStyleBackColor = true;
            this.btnStopMed.Click += new System.EventHandler(this.btnStopMed_Click);
            // 
            // btnStopQuicker
            // 
            this.btnStopQuicker.Location = new System.Drawing.Point(12, 169);
            this.btnStopQuicker.Name = "btnStopQuicker";
            this.btnStopQuicker.Size = new System.Drawing.Size(301, 147);
            this.btnStopQuicker.TabIndex = 1;
            this.btnStopQuicker.Text = "\"Stop\" quicker";
            this.btnStopQuicker.UseVisualStyleBackColor = true;
            this.btnStopQuicker.Click += new System.EventHandler(this.btnStopQuicker_Click);
            // 
            // panelPaint
            // 
            this.panelPaint.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelPaint.Location = new System.Drawing.Point(1556, 12);
            this.panelPaint.Name = "panelPaint";
            this.panelPaint.Size = new System.Drawing.Size(42, 39);
            this.panelPaint.TabIndex = 2;
            this.panelPaint.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPaint_Paint);
            // 
            // btnBreathWheel
            // 
            this.btnBreathWheel.Location = new System.Drawing.Point(12, 332);
            this.btnBreathWheel.Name = "btnBreathWheel";
            this.btnBreathWheel.Size = new System.Drawing.Size(301, 113);
            this.btnBreathWheel.TabIndex = 3;
            this.btnBreathWheel.Text = "Breath wheel";
            this.btnBreathWheel.UseVisualStyleBackColor = true;
            this.btnBreathWheel.Click += new System.EventHandler(this.btnBreathWheel_Click);
            // 
            // FormMeditations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1610, 981);
            this.Controls.Add(this.btnBreathWheel);
            this.Controls.Add(this.panelPaint);
            this.Controls.Add(this.btnStopQuicker);
            this.Controls.Add(this.btnStopMed);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormMeditations";
            this.Text = "Mikhail\'s meditation tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMeditations_FormClosing);
            this.Load += new System.EventHandler(this.FormMeditations_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMeditations_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStopMed;
        private System.Windows.Forms.Button btnStopQuicker;
        private System.Windows.Forms.Panel panelPaint;
        private System.Windows.Forms.Button btnBreathWheel;
    }
}

