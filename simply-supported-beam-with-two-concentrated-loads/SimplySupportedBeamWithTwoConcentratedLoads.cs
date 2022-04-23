using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simply_supported_beam_with_two_concentrated_loads
{
    internal class SimplySupportedBeamWithTwoConcentratedLoads
    {
        private double L = 100, a1 = 20, a2 = 70, P1 = 100, P2 = 200, RL = 0, RR = 0;

        [Category("Length and Position")]
        [Description("The length of the beam must be postive")]
        public double Length
        {
            get  // getter
            {
                return L;

            }
            set  // setter
            {
                if (value > 0 && value >= a1 && value >= a2) L = value;
            }
        }

        [Category("Length and Position")]
        public double Position1
        {
            get => a1;
            set
            {
                if (value >= 0 && value <= L) a1 = value;
            }
        }

        [Category("Length and Position")]
        public double Position2
        {
            get => a2;
            set
            {
                if (value >= 0 && value <= L) a2 = value;
            }
        }

        [Category("Load")]
        public double Load1
        {
            get => P1;
            set
            {
                if (value >= 0) P1 = value;
            }
        }

        [Category("Load")]
        public double Load2
        {
            get => P2;
            set
            {
                if (value >= 0) P2 = value;
            }
        }

        [Category("Resaults")]
        public double Rleft
        {
            get => RL;
        }

        [Category("Resaults")]
        public double Rright
        {
            get => RR;
        }

        public double GetShearForce(double x)
        {
            double SF = 0;
            if (x >= 0 && x <= a1)
            {
                SF = RL;
            }
            else if (x >= a1 && x <= a2)
            {
                SF = (RL - P1);
            }
            else if (x >= a2 && x <= L)
            {
                SF = -RR;
            }
            return SF;
        }

        public double GetBendingMoment(double x)
        {
            double BM = 0;
            if (x >= 0 && x <= a1)
            {
                BM = RL * x;
            }
            else if (x >= a1 && x <= a2)
            {
                BM = (RL * x - P1 * (x - a1));
            }
            else if (x >= a2 && x <= L)
            {
                BM = RR * (L - x);
            }
            return BM;
        }

        public void CaculateR()
        {
            RL = (P1 * (L - a1) + P2 * (L - a2)) / L;
            RR = (P1 * a1 + P2 * a2) / L;
        }
    }
}
