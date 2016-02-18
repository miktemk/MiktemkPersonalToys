using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Miktemk.Winforms;

namespace MeditationTools
{
    public class AnimationBreathWheel: AnimatedPaint
    {
        private const double ALPHA_FACTOR = 0.02;

        public AnimationBreathWheel()
        {
            
        }

        public override void DoPaint(Graphics g, int w, int h)
        {
            var radius = Math.Min(w, h)/2 - 100;
            var radiusDot = 50;
            var xC = w / 2;
            var yC = h / 2;

            g.FillBackground(w, h, PPP.brushWhite);
            g.FillCircle(PPP.brushLightGrayA, xC, yC, radius);
            g.FillCircle(PPP.brushWhite, xC, yC, radius-radiusDot*2);
            var alpha = Frame * ALPHA_FACTOR;
            var xClock = xC + Math.Cos(alpha) * (radius - radiusDot);
            var yClock = yC + Math.Sin(alpha) * (radius - radiusDot);
            var brushBreath = (xClock > xC)
                ? PPP.brushDefault
                : PPP.brushWhite;
            g.FillCircle(brushBreath, (int)xClock, (int)yClock, radiusDot);
            
        }
    }
}
