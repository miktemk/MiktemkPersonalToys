using MeditationTools.Properties;
using Miktemk.Mp3;
using Miktemk.Winforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeditationTools
{
    public class MeditationToolbox
    {
        public InvokeAtRandomIntervals MeditateOnStop { get; private set; }
        public InvokeAtRandomIntervals MeditateOnStopQuicker { get; private set; }
        public AnimatedPaintThread CurAnimation { get; private set; }
        private AudioPlaya playa;

        public MeditationToolbox(AnimatedPaint_IContainer animatedPaint_iContainer)
        {
            var stopFilename = UtilsIO.GetFileFromThisAppDirectory(Settings.Default.StopMp3Filename);
            MeditateOnStop = new InvokeAtRandomIntervals(
                TimeSpan.FromSeconds(Settings.Default.StopMedMinSec),
                TimeSpan.FromSeconds(Settings.Default.StopMedMaxSec),
                () => {
                    playa = new AudioPlaya(stopFilename);
                    playa.Play();
                    playa.Finished += (playaDone) =>
                    {
                        playaDone.Dispose();
                        playaDone = null;
                    };
                });
            MeditateOnStopQuicker = new InvokeAtRandomIntervals(
                TimeSpan.FromSeconds(Settings.Default.StopMed2MinSec),
                TimeSpan.FromSeconds(Settings.Default.StopMed2MaxSec),
                () =>
                {
                    playa = new AudioPlaya(stopFilename);
                    playa.Play();
                    playa.Finished += (playaDone) =>
                    {
                        playaDone.Dispose();
                        playaDone = null;
                    };
                });
            CurAnimation = new AnimatedPaintThread(animatedPaint_iContainer) {
                DelayMs = Settings.Default.AnimationsDelay,
            };
        }

        public void StartBreathWheel()
        {
            CurAnimation.AnimatePainter = new AnimationBreathWheel();
            CurAnimation.Start();
        }

        internal void StopAll()
        {
            if (MeditateOnStop.IsRunning)
                MeditateOnStop.Stop();
            if (MeditateOnStopQuicker.IsRunning)
                MeditateOnStopQuicker.Stop();
            if (CurAnimation.IsRunning)
                CurAnimation.Stop();
        }
    }
}
