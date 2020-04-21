using InternalForcesCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace InternalForcesCalculator.ViewModel
{
    public class ViewModel
    {
        public List<ShearForce> ShearForceData { get; set; }
        public List<BendingMoment> BendingMomentData { get; set; }

        public ViewModel()
        {
            ShearForceData = CreateShearForceModel();
            BendingMomentData = CreateBendingMomentModel();
        }

        public List<ShearForce> CreateShearForceModel()
        {
            List<ShearForce> Result = new List<ShearForce>()
            {
                new ShearForce { XCoord = 0, YCoord = 0 },
            };

            return Result;
        }

        public List<BendingMoment> CreateBendingMomentModel()
        {
            List<BendingMoment> Result = new List<BendingMoment>()
            {
                new BendingMoment { XCoord = 0, YCoord = 0 },
            };

            return Result;
        }
    }
}
