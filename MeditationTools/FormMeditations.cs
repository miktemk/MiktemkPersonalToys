using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Miktemk.Winforms;

namespace MeditationTools
{
    public partial class FormMeditations : Form
    {
        private MeditationToolbox meditations;

        public FormMeditations()
        {
            InitializeComponent();
            CustomComponents();
            meditations = new MeditationToolbox(new AnimatedPaint_IContainer_WrapControl(panelPaint));
        }

        private void CustomComponents()
        {
            panelPaint.Dock = DockStyle.Fill;
            panelPaint.Visible = false;
            //var iii = Controls.GetChildIndex(btnBreathWheel);
            //Controls.SetChildIndex(panelPaint, -1);
            panelPaint.BringToFront();
            panelPaint.MakeDoubleBufferedHack();
        }

        private void FormMeditations_Load(object sender, EventArgs e) {}

        private void btnStopMed_Click(object sender, EventArgs e)
        {
            if (meditations.MeditateOnStop.IsRunning)
            {
                meditations.MeditateOnStop.Stop();
                btnStopMed.BackColor = SystemColors.Control;
            }
            else
            {
                meditations.MeditateOnStop.Start();
                btnStopMed.BackColor = Color.LightGreen;
            }
        }

        private void btnStopQuicker_Click(object sender, EventArgs e)
        {
            if (meditations.MeditateOnStopQuicker.IsRunning)
            {
                meditations.MeditateOnStopQuicker.Stop();
                btnStopQuicker.BackColor = SystemColors.Control;
            }
            else
            {
                meditations.MeditateOnStopQuicker.Start();
                btnStopQuicker.BackColor = Color.LightGreen;
            }
        }

        private void FormMeditations_FormClosing(object sender, FormClosingEventArgs e)
        {
            meditations.StopAll();
        }

        private void btnBreathWheel_Click(object sender, EventArgs e)
        {
            meditations.StartBreathWheel();
            panelPaint.Visible = true;
        }

        private void panelPaint_Paint(object sender, PaintEventArgs e)
        {
            meditations.CurAnimation.AnimatePainter.DoPaint(e.Graphics, panelPaint.Width, panelPaint.Height);
        }

        private void FormMeditations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                meditations.StopAll();
                panelPaint.Visible = false;
            }
        }


        
    }
}
