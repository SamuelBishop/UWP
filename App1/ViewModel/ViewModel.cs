using InternalForcesCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternalForcesCalculator.ViewModel
{
    public class ViewModel
    {
        public List<ShearForce> ShearForceData { get; set; }
        public List<BendingMoment> BendingMomentData { get; set; }

        public ViewModel()
        {
            ShearForceData = new List<ShearForce>()
            {
                new ShearForce { XCoord = 0, YCoord = 7 },
                new ShearForce { XCoord = 1, YCoord = 7 },
                new ShearForce { XCoord = 1.01F, YCoord = -5 },
                new ShearForce { XCoord = 4, YCoord = -5 },
                new ShearForce { XCoord = 4.01F, YCoord = 8 },
                new ShearForce { XCoord = 5, YCoord = 8 }
            };

            BendingMomentData = new List<BendingMoment>()
            {
                new BendingMoment { XCoord = 0, YCoord = 0 },
                new BendingMoment { XCoord = 1, YCoord = 7 },
                new BendingMoment { XCoord = 2.5F, YCoord = 0 },
                new BendingMoment { XCoord = 4, YCoord = -8 },
                new BendingMoment { XCoord = 5, YCoord = 0 }
            };
        }
    }
}
