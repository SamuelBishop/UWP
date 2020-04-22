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
        
        public float PointLoadingLocation { get; set; }
        public float PointLoadingMagnitude { get; set; }
        public float TriangularDistributedLoadingLocation { get; set; }
        public float TriangularDistributedLoadingMagnitude { get; set; }
        public float RectangularDistributedLoadingLocation { get; set; }
        public float RectangularDistributedLoadingMagnitude { get; set; }
        public float FreeMomentLocation { get; set; }
        public float FreeMomentMagnitude { get; set; }
        public float PinSupportLocation { get; set; }
        public float RollerSupportLocation { get; set; }
        public float FixedSupportLocation { get; set; }

        public ViewModel()
        {
            ShearForceData = CreateShearForceModel(
                PointLoadingLocation, 
                PointLoadingMagnitude, 
                TriangularDistributedLoadingLocation, 
                TriangularDistributedLoadingMagnitude, 
                RectangularDistributedLoadingLocation, 
                RectangularDistributedLoadingMagnitude, 
                FreeMomentLocation, 
                FreeMomentMagnitude,
                PinSupportLocation,
                RollerSupportLocation,
                FixedSupportLocation
                );
            BendingMomentData = CreateBendingMomentModel(
                PointLoadingLocation,
                PointLoadingMagnitude,
                TriangularDistributedLoadingLocation,
                TriangularDistributedLoadingMagnitude,
                RectangularDistributedLoadingLocation,
                RectangularDistributedLoadingMagnitude,
                FreeMomentLocation,
                FreeMomentMagnitude,
                PinSupportLocation,
                RollerSupportLocation,
                FixedSupportLocation
                );
        }

        public List<ShearForce> CreateShearForceModel(
            float PointLoadingLocation,
            float PointLoadingMagnitude,
            float TriangularDistributedLoadingLocation,
            float TriangularDistributedLoadingMagnitude,
            float RectangularDistributedLoadingLocation,
            float RectangularDistributedLoadingMagnitude,
            float FreeMomentLocation,
            float FreeMomentMagnitude,
            float PinSupportLocation,
            float RollerSupportLocation,
            float FixedSupportLocation
            )
        {
            List<ShearForce> Result = new List<ShearForce>()
            {
                new ShearForce { XCoord = PointLoadingLocation, YCoord = PointLoadingMagnitude },
                new ShearForce { XCoord = TriangularDistributedLoadingLocation, YCoord = TriangularDistributedLoadingMagnitude }
            };

            return Result;
        }

        public List<BendingMoment> CreateBendingMomentModel(
            float PointLoadingLocation,
            float PointLoadingMagnitude,
            float TriangularDistributedLoadingLocation,
            float TriangularDistributedLoadingMagnitude,
            float RectangularDistributedLoadingLocation,
            float RectangularDistributedLoadingMagnitude,
            float FreeMomentLocation,
            float FreeMomentMagnitude,
            float PinSupportLocation,
            float RollerSupportLocation,
            float FixedSupportLocation
            )
        {
            List<BendingMoment> Result = new List<BendingMoment>()
            {
                new BendingMoment { XCoord = 0, YCoord = 0 },
            };

            return Result;
        }
    }
}
