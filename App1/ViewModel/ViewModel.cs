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
                new ShearForce { XCoord = 10, YCoord = 10 },
                new ShearForce { XCoord = 20, YCoord = 20 },
                new ShearForce { XCoord = 30, YCoord = 30 },
                new ShearForce { XCoord = 40, YCoord = 40 }
            };

            BendingMomentData = new List<BendingMoment>()
            {
                new BendingMoment { XCoord = 10, YCoord = 10 },
                new BendingMoment { XCoord = 20, YCoord = 20 },
                new BendingMoment { XCoord = 30, YCoord = 30 },
                new BendingMoment { XCoord = 40, YCoord = 40 }
            };
        }
    }
}
