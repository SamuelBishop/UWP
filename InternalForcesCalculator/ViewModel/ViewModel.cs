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
        private float lengthOfBeam { get; set; } = 12;
        public float LengthOfBeam
        {
            get { return lengthOfBeam; }
            set
            {
                lengthOfBeam = value;
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
                FixedSupportLocation,
                LengthOfBeam
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
                FixedSupportLocation,
                LengthOfBeam
                );
            }
            set {
                bendingMomentData = value; 
            }
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
            float FixedSupportLocation,
            float LengthOfBeam
            )
        {
            // Step 0: Declare variables

            // Distributed Loading
            float TriangularDistForce = (float).5 * TriangularDistributedLoadingMagnitude * TriangularDistributedLoadingLocation;
            float TriangularDistForceLocation = (float)Math.Round((float)(.666666666666666666667 * TriangularDistributedLoadingLocation), 2);

            float RectangularDistForce = RectangularDistributedLoadingMagnitude * RectangularDistributedLoadingLocation;
            float RectangularDistForceLocation = (float).5 * RectangularDistributedLoadingLocation;

            // Support Reactions
            /* TODO: Not used
            float XPinReaction = 0;     // No moment reaction
            float YPinReaction = 0;

            float YRollerReaction = 0;  // No X reaction, No moment reaction

            float XFixedReaction = 0;   // Might not even need X reactions
            float YFixedReaction = 0;

            float TotalForceX = 0;
            float TotalForceY = 0;
            */

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
            float FixedSupportLocation,
            float LengthOfBeam
            )
        {
            
            // Declare and initialize all complex variables
            float PointLoadMoment = (float)Math.Round((PointLoadingLocation * PointLoadingMagnitude), 2);   // TODO: Not used

            float TriangularDistForce = (float).5 * TriangularDistributedLoadingMagnitude * TriangularDistributedLoadingLocation;
            float TriangularDistForceLocation = (float)Math.Round((float)(.666666666666666666667 * TriangularDistributedLoadingLocation), 2);
            float TrinagularMoment = TriangularDistForce * TriangularDistForceLocation;                     // TODO: Not used

            float RectangularDistForce = RectangularDistributedLoadingMagnitude * RectangularDistributedLoadingLocation;
            float RectangularDistForceLocation = (float).5 * RectangularDistributedLoadingLocation;
            float RectangularMoment = TrinagularMoment;                                                     // TODO: Not used

            // Support Reactions
            float MFixedReaction = 0;   // TODO: Not used
            float TotalMoment = 0;      // TODO: Not used

            // The exact same coordinate pairs as the Shear Force Diagram
            List<CoordPair> Result = new List<CoordPair>()
            {
                new CoordPair { XCoord = PointLoadingLocation, YCoord = PointLoadingMagnitude },
                new CoordPair { XCoord = TriangularDistForceLocation, YCoord = TriangularDistForce },
                new CoordPair { XCoord = RectangularDistForceLocation, YCoord = RectangularDistForce },
                new CoordPair { XCoord = LengthOfBeam, YCoord = 0 }
            };
                
            CoordPair zeroPair = new CoordPair { XCoord = 0, YCoord = 0 };
            Result.RemoveAll(pair => (pair.XCoord == 0 & pair.YCoord == 0));    // Removes all invalid entries that are generated on startup
            Result.Insert(0, zeroPair);                                         // Sets the inital coord point on the graph ALWAYS equal to (0,0)

            Result.Sort(delegate (CoordPair x, CoordPair y)                     // Sorts all of the coord pairs by x coordinate so lower x coordinate pairs display first
            {
                return x.XCoord.CompareTo(y.XCoord);
            });

            // Run through the list and add up the Y coordinates (Forces)
            float CurYCoord = 0;
            float PrevYCoord = 0;
            foreach (var CoordPair in Result)
            {
                PrevYCoord = CurYCoord;
                CoordPair.YCoord += PrevYCoord;
                CurYCoord = CoordPair.YCoord;
            }
            
            // Shift the X Coordinates to the right by one to connect plot the right points (connect the dots)
            for (int i = 1; i < (Result.Count - 1); i++)
            {
                Result[i].XCoord = Result[i + 1].XCoord;
            }
            Result.RemoveAt(Result.Count - 1);
            Result[Result.Count - 1].YCoord = 0;            // * CHECK WITH THE PROFESSOR Moment diagram will always return to the zero location?

            // Multiply the forces by the distances to get the moment y coordinates
            float LastXCoord = 0;
            for (int i = 1; i < (Result.Count - 1); i++)    // Moves the X coordinate over one to plot the right point
            {
                Result[i].YCoord = Result[i].YCoord * (Result[i].XCoord - LastXCoord);
                LastXCoord = Result[i].XCoord;
            }

            // Add free moment and sort it into the moment coordinate pairs
            CoordPair FreeMoment = new CoordPair { XCoord = FreeMomentLocation, YCoord = FreeMomentMagnitude };
            if(FreeMoment.XCoord != 0 & FreeMoment.YCoord != 0)
            {
                Result.Add(FreeMoment);
                Result.Sort(delegate (CoordPair x, CoordPair y)
                {
                    return x.XCoord.CompareTo(y.XCoord);
                });
            }

            // Do one last run through of the list and sum the moments for each point
            CurYCoord = 0;
            PrevYCoord = 0;
            for (int i = 1; i < (Result.Count - 1); i++)
            {
                PrevYCoord = CurYCoord;
                Result[i].YCoord += PrevYCoord;
                CurYCoord = Result[i].YCoord;
            }

            // Removes all invalid coordinate sets where the location is greater than the length of the beam
            CoordPair RectifyEndPoint = new CoordPair { XCoord = LengthOfBeam, YCoord = 0 };
            if (Result[Result.Count - 1].XCoord > LengthOfBeam) { 
                Result.RemoveAll(pair => (pair.XCoord > LengthOfBeam));
                Result[Result.Count - 1] = RectifyEndPoint;
            }

            return Result;
        }
    }
}
