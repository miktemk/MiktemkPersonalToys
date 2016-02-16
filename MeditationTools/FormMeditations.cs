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

namespace MeditationTools
{
    public partial class FormMeditations : Form
    {
        private MeditationToolbox meditations;

        public FormMeditations()
        {
            InitializeComponent();
            meditations = new MeditationToolbox();
        }

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
    }
}
