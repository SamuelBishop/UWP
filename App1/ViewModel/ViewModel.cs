using InternalForcesCalculator.Models;
using Syncfusion.Olap.UWP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace InternalForcesCalculator.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Declaring all two-way data bindings that update the ShearForceData and BendingMomentData
        private float pointLoadingLocation { get; set; }
        public float PointLoadingLocation
        {
            get { return pointLoadingLocation; }
            set
            {
                pointLoadingLocation = value;
                OnPropertyChanged("PointLoadingLocation");
                OnPropertyChanged("ShearForceData");
                OnPropertyChanged("BendingMomentData");
            }
        }

        private float pointLoadingMagnitude { get; set; }
        public float PointLoadingMagnitude
        {
            get { return pointLoadingMagnitude; }
            set
            {
                pointLoadingMagnitude = value;
                OnPropertyChanged("PointLoadingMagnitude");
                OnPropertyChanged("ShearForceData");
                OnPropertyChanged("BendingMomentData");
            }
        }

        private float triangularDistributedLoadingLocation { get; set; }
        public float TriangularDistributedLoadingLocation
        {
            get { return triangularDistributedLoadingLocation; }
            set
            {
                triangularDistributedLoadingLocation = value;
                OnPropertyChanged("TriangularDistributedLoadingLocation");
                OnPropertyChanged("ShearForceData");
                OnPropertyChanged("BendingMomentData");
            }
        }

        private float triangularDistributedLoadingMagnitude { get; set; }
        public float TriangularDistributedLoadingMagnitude
        {
            get { return triangularDistributedLoadingMagnitude; }
            set
            {
                triangularDistributedLoadingMagnitude = value;
                OnPropertyChanged("TriangularDistributedLoadingMagnitude");
                OnPropertyChanged("ShearForceData");
                OnPropertyChanged("BendingMomentData");
            }
        }

        private float rectangularDistributedLoadingLocation { get; set; }
        public float RectangularDistributedLoadingLocation
        {
            get { return rectangularDistributedLoadingLocation; }
            set
            {
                rectangularDistributedLoadingLocation = value;
                OnPropertyChanged("RectangularDistributedLoadingLocation");
                OnPropertyChanged("ShearForceData");
                OnPropertyChanged("BendingMomentData");
            }
        }

        private float rectangularDistributedLoadingMagnitude { get; set; }
        public float RectangularDistributedLoadingMagnitude
        {
            get { return rectangularDistributedLoadingMagnitude; }
            set
            {
                rectangularDistributedLoadingMagnitude = value;
                OnPropertyChanged("RectangularDistributedLoadingMagnitude");
                OnPropertyChanged("ShearForceData");
                OnPropertyChanged("BendingMomentData");
            }
        }

        private float freeMomentLocation { get; set; }
        public float FreeMomentLocation
        {
            get { return freeMomentLocation; }
            set
            {
                freeMomentLocation = value;
                OnPropertyChanged("FreeMomentLocation");
                OnPropertyChanged("ShearForceData");
                OnPropertyChanged("BendingMomentData");
            }
        }

        private float freeMomentMagnitude { get; set; }
        public float FreeMomentMagnitude
        {
            get { return freeMomentMagnitude; }
            set
            {
                freeMomentMagnitude = value;
                OnPropertyChanged("FreeMomentMagnitude");
                OnPropertyChanged("ShearForceData");
                OnPropertyChanged("BendingMomentData");
            }
        }

        private float pinSupportLocation { get; set; }
        public float PinSupportLocation
        {
            get { return pinSupportLocation; }
            set
            {
                pinSupportLocation = value;
                OnPropertyChanged("PinSupportLocation");
                OnPropertyChanged("ShearForceData");
                OnPropertyChanged("BendingMomentData");
            }
        }

        private float rollerSupportLocation { get; set; }
        public float RollerSupportLocation
        {
            get { return rollerSupportLocation; }
            set
            {
                rollerSupportLocation = value;
                OnPropertyChanged("RollerSupportLocation");
                OnPropertyChanged("ShearForceData");
                OnPropertyChanged("BendingMomentData");
            }
        }

        private float fixedSupportLocation { get; set; }
        public float FixedSupportLocation
        {
            get { return fixedSupportLocation; }
            set
            {
                fixedSupportLocation = value;
                OnPropertyChanged("FixedSupportLocation");
                OnPropertyChanged("ShearForceData");
                OnPropertyChanged("BendingMomentData");
            }
        }

        // Setting the ShearForceData with the CreateShearForceModel function every time a binding is updated
        private List<CoordPair> shearForceData { get; set; }
        public List<CoordPair> ShearForceData
        {
            get { return CreateShearForceModel(
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
            set {
                shearForceData = value; 
            }
        }

        // Setting the BendingMomentData with the CreateBendingMomentModel function every time a binding is updated
        private List<CoordPair> bendingMomentData { get; set; }
        public List<CoordPair> BendingMomentData
        {
            get { return bendingMomentData; }
            set {
                bendingMomentData = value; 
            }
        }

        // Default Constructor
        public ViewModel()
        {
            ShearForceData = new List<CoordPair>()
            {
                new CoordPair { XCoord = 0, YCoord = 7 },
                new CoordPair { XCoord = 1, YCoord = -5 },
                new CoordPair { XCoord = 4, YCoord = 8 },
                new CoordPair { XCoord = 5, YCoord = 8 },
                new CoordPair { XCoord = 0, YCoord = 0 }
            };
            BendingMomentData = new List<CoordPair>()
            {
                new CoordPair { XCoord = 0, YCoord = 0 },
                new CoordPair { XCoord = 1, YCoord = 7 },
                new CoordPair { XCoord = 2.5F, YCoord = 0 },
                new CoordPair { XCoord = 4, YCoord = -8 },
                new CoordPair { XCoord = 5, YCoord = 0 }
            };
        }

        public List<CoordPair> CreateShearForceModel(
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
            List<CoordPair> Result = new List<CoordPair>()
            {
                new CoordPair { XCoord = PointLoadingLocation, YCoord = PointLoadingMagnitude },
                new CoordPair { XCoord = TriangularDistributedLoadingLocation, YCoord = TriangularDistributedLoadingMagnitude },
                new CoordPair { XCoord = RectangularDistributedLoadingLocation, YCoord = RectangularDistributedLoadingMagnitude },
                new CoordPair { XCoord = FreeMomentLocation, YCoord = FreeMomentMagnitude }
            };

            return Result;
        }

        public List<CoordPair> CreateBendingMomentModel(
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
            List<CoordPair> Result = new List<CoordPair>()
            {
                new CoordPair { XCoord = 0, YCoord = 0 },
            };

            return Result;
        }
    }
}
