using InternalForcesCalculator.Models;
using Syncfusion.Olap.UWP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
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
            get { return CreateBendingMomentModel(
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
            // Step 0: Declare variables
            int LengthOfBeam = 12;

            // Distributed Loading
            float TriangularDistForce = (float).5 * TriangularDistributedLoadingMagnitude * TriangularDistributedLoadingLocation;
            float TriangularDistForceLocation = (float)Math.Round((float)(.666666666666666666667 * TriangularDistributedLoadingLocation), 2);

            float RectangularDistForce = RectangularDistributedLoadingMagnitude * RectangularDistributedLoadingLocation;
            float RectangularDistForceLocation = (float).5 * RectangularDistributedLoadingLocation;

            // Support Reactions
            float XPinReaction = 0;     // No moment reaction
            float YPinReaction = 0;

            float YRollerReaction = 0;  // No X reaction, No moment reaction

            float XFixedReaction = 0;   // Might not even need X reactions
            float YFixedReaction = 0;

            float TotalForceX = 0;
            float TotalForceY = 0;

            // Step 1: Create coordinate pairs with the desired attributes for graphing later

            List<CoordPair> Result = new List<CoordPair>()
            {
                new CoordPair { XCoord = PointLoadingLocation, YCoord = PointLoadingMagnitude },
                new CoordPair { XCoord = TriangularDistForceLocation, YCoord = TriangularDistForce },
                new CoordPair { XCoord = RectangularDistForceLocation, YCoord = RectangularDistForce },
                new CoordPair { XCoord = LengthOfBeam, YCoord = 0 }
            };

            // Sort all of the points based off of their x coordinate (makes sure the graph is in order)
            CoordPair zeroPair = new CoordPair { XCoord = 0, YCoord = 0 };

            Result.RemoveAll(pair => (pair.XCoord == 0 & pair.YCoord == 0));    // Removes all invalid entries that are generated on startup
            Result.RemoveAll(pair => (pair.XCoord > LengthOfBeam));             // Removes all invalid coordinate sets where the location is greater than the length of the beam
            if (!Result.Exists(pair => (pair.XCoord == 0 & pair.YCoord != 0)))  // Adds a coordinate pair at (0,0) if a coordinate pair a (0,something) doesn't exist
            {
                Result.Add(zeroPair);
            }
            Result.Sort(delegate (CoordPair x, CoordPair y)                     // Sorts all of the coord pairs by x coordinate so lower x coordinate pairs display first
            {
                return x.XCoord.CompareTo(y.XCoord);
            });

            // Finally run through the list and add the previous YCoord to the current YCoord
            float CurYCoord = 0;
            float PrevYCoord = 0;
            foreach (var CoordPair in Result)
            {
                    PrevYCoord = CurYCoord;
                    CoordPair.YCoord += PrevYCoord;
                    CurYCoord = CoordPair.YCoord;
            }

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
            // Think of a new way to do this probably requires line graph and not area graph

            // Step 0: Declare variables
            int LengthOfBeam = 12;

            // Point Loading
            float PointLoadMoment = (float)Math.Round((PointLoadingLocation * PointLoadingMagnitude), 2);

            float TriangularDistForce = (float).5 * TriangularDistributedLoadingMagnitude * TriangularDistributedLoadingLocation;
            float TriangularDistForceLocation = (float)Math.Round((float)(.666666666666666666667 * TriangularDistributedLoadingLocation), 2);
            float TrinagularMoment = TriangularDistForce * TriangularDistForceLocation;

            float RectangularDistForce = RectangularDistributedLoadingMagnitude * RectangularDistributedLoadingLocation;
            float RectangularDistForceLocation = (float).5 * RectangularDistributedLoadingLocation;
            float RectangularMoment = TrinagularMoment;

            // Support Reactions
            float MFixedReaction = 0;

            float TotalMoment = 0;

            List<CoordPair> Result = new List<CoordPair>()
            {
                new CoordPair { XCoord = PointLoadingLocation, YCoord = PointLoadMoment },
                new CoordPair { XCoord = TriangularDistForceLocation, YCoord = TrinagularMoment },
                new CoordPair { XCoord = RectangularDistForceLocation, YCoord = RectangularMoment },
                new CoordPair { XCoord = FreeMomentLocation, YCoord = FreeMomentMagnitude },
            };

            CoordPair zeroPair = new CoordPair { XCoord = 0, YCoord = 0 };

            Result.RemoveAll(pair => (pair.XCoord == 0 & pair.YCoord == 0));    // Removes all invalid entries that are generated on startup
            Result.RemoveAll(pair => (pair.XCoord > LengthOfBeam));             // Removes all invalid coordinate sets where the location is greater than the length of the beam
            if (!Result.Exists(pair => (pair.XCoord == 0 & pair.YCoord != 0)))  // Adds a coordinate pair at (0,0) if a coordinate pair a (0,something) doesn't exist
            {
                Result.Add(zeroPair);
            }
            Result.Sort(delegate (CoordPair x, CoordPair y)                     // Sorts all of the coord pairs by x coordinate so lower x coordinate pairs display first
            {
                return x.XCoord.CompareTo(y.XCoord);
            });

            // Finally run through the list and add the previous YCoord to the current YCoord
            float CurYCoord = 0;
            float PrevYCoord = 0;
            foreach (var CoordPair in Result)
            {
                PrevYCoord = CurYCoord;
                CoordPair.YCoord += PrevYCoord;
                CurYCoord = CoordPair.YCoord;
            }

            return Result;
        }
    }
}
