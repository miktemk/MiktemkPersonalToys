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
            // FormMeditations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1610, 981);
            this.Controls.Add(this.btnStopQuicker);
            this.Controls.Add(this.btnStopMed);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMeditations";
            this.Text = "Mikhail\'s meditation tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMeditations_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStopMed;
        private System.Windows.Forms.Button btnStopQuicker;
    }
}

