﻿using InternalForcesCalculator.Models;
using Syncfusion.Olap.UWP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Accord.Math;
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
        private bool includePinSupport { get; set; } = false;
        public bool IncludePinSupport
        {
            get { return includePinSupport; }
            set
            {
                includePinSupport = value;
                OnPropertyChanged("FixedSupportLocation");
                OnPropertyChanged("ShearForceData");
                OnPropertyChanged("BendingMomentData");
            }
        }
        private bool includeRollerSupport { get; set; } = false;
        public bool IncludeRollerSupport
        {
            get { return includeRollerSupport; }
            set
            {
                includeRollerSupport = value;
                OnPropertyChanged("FixedSupportLocation");
                OnPropertyChanged("ShearForceData");
                OnPropertyChanged("BendingMomentData");
            }
        }
        private bool includeFixedSupport { get; set; } = false;
        public bool IncludeFixedSupport
        {
            get { return includeFixedSupport; }
            set
            {
                includeFixedSupport = value;
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
                LengthOfBeam,
                IncludePinSupport,
                IncludeRollerSupport,
                IncludeFixedSupport
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
                LengthOfBeam,
                IncludePinSupport,
                IncludeRollerSupport,
                IncludeFixedSupport
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
            float LengthOfBeam,
            bool IncludePinSupport,
            bool IncludeRollerSupport,
            bool IncludeFixedSupport
            )
        {
            // Step 0: Declare variables
            float PointLoadMoment = (float)Math.Round((PointLoadingLocation * PointLoadingMagnitude), 2);

            // Distributed Loading
            float TriangularDistForce = (float).5 * TriangularDistributedLoadingMagnitude * TriangularDistributedLoadingLocation;
            float TriangularDistForceLocation = (float)Math.Round((float)(.666666666666666666667 * TriangularDistributedLoadingLocation), 2);
            float TrinagularMoment = TriangularDistForce * TriangularDistForceLocation;

            float RectangularDistForce = RectangularDistributedLoadingMagnitude * RectangularDistributedLoadingLocation;
            float RectangularDistForceLocation = (float).5 * RectangularDistributedLoadingLocation;
            float RectangularMoment = RectangularDistForce * RectangularDistForceLocation;

            // Do moment solving for one of the forces right here. Get ratio of pin force to other forces
            int UsePinSupport = IncludePinSupport ? 1 : 0;
            int UseRollerSupport = IncludeRollerSupport ? 1 : 0;
            int UseFixedSupport = IncludeFixedSupport ? 1 : 0;

            float[,] matrix =
            {
                { UsePinSupport, UseRollerSupport, UseFixedSupport },
                { PinSupportLocation, RollerSupportLocation, FixedSupportLocation}
            };

            float knownForceMag = -1 * (PointLoadingMagnitude + RectangularDistForce + TriangularDistForce);
            float knownMomentMag = -1 * (PointLoadMoment + RectangularMoment + TrinagularMoment);
            float[,] RightSideMoment = { { knownForceMag }, { knownMomentMag } };
            float[,] MomentReaction = Matrix.Solve(matrix, RightSideMoment, leastSquares: true);

            float YPinReaction = MomentReaction[0,0];
            float YRollerReaction = MomentReaction[1,0];  // No X reaction, No moment reaction
            float YFixedReaction = MomentReaction[2,0];

            // Add point loads on every .1 interval
            float interval = .1f;
            float tempXCoord = 0;
            float tempYCoord = 0;
            bool prePointCoordAdded = false;
            List<CoordPair> PointSet = new List<CoordPair>();
            for (float i = 0; i <= lengthOfBeam; i += interval)
            {
                if (i >= PointLoadingLocation)
                {
                    if (!prePointCoordAdded)
                    {
                        PointSet.Add(new CoordPair { XCoord = tempXCoord - .001f, YCoord = 0 });
                        prePointCoordAdded = true;
                    }
                    tempYCoord = PointLoadingMagnitude;
                }
                PointSet.Add(new CoordPair { XCoord = tempXCoord, YCoord = tempYCoord });
                tempXCoord += interval;
            }

            // Add tri force points every .1 on the interval
            tempXCoord = 0;
            tempYCoord = 0;
            bool postTriangleCoordAdded = false;
            List<CoordPair> TriangularSet = new List<CoordPair>();
            for (float i = 0; i <= lengthOfBeam; i += interval)
            {
                tempYCoord = .5f * i * TriangularDistributedLoadingMagnitude;
                if (i > TriangularDistributedLoadingLocation)
                {
                    if (!postTriangleCoordAdded)
                    {
                        TriangularSet.Add(new CoordPair { XCoord = TriangularSet[TriangularSet.Count - 1].XCoord + .001f, YCoord = 0 });
                        postTriangleCoordAdded = true;
                    }
                    TriangularSet.Add(new CoordPair { XCoord = tempXCoord, YCoord = 0 });
                }
                else
                {
                    TriangularSet.Add(new CoordPair { XCoord = tempXCoord, YCoord = tempYCoord });
                }
                tempXCoord += interval;
            }

            // Add Rect force points every .1 on the interval
            List<CoordPair> RectangularSet = new List<CoordPair>();
            tempXCoord = 0;
            tempYCoord = 0;
            bool postRectangleCoordAdded = false;
            for (float i = 0; i <= lengthOfBeam; i += interval)
            {
                tempYCoord = i * RectangularDistributedLoadingMagnitude;
                if (i > RectangularDistributedLoadingLocation)
                {
                    if (!postRectangleCoordAdded)
                    {
                        RectangularSet.Add(new CoordPair { XCoord = RectangularSet[RectangularSet.Count - 1].XCoord + .001f, YCoord = 0 });
                        postRectangleCoordAdded = true;
                    }
                    RectangularSet.Add(new CoordPair { XCoord = tempXCoord, YCoord = 0 });
                }
                else
                {
                    RectangularSet.Add(new CoordPair { XCoord = tempXCoord, YCoord = tempYCoord });
                }
                tempXCoord += interval;
            }

            List<CoordPair> PinSupportSet = new List<CoordPair>();
            tempXCoord = 0;
            tempYCoord = 0;
            bool prePinSupportAdded = false;
            if (IncludePinSupport)
            {
                for (float i = 0; i <= lengthOfBeam; i += interval)
                {
                    if (i >= PinSupportLocation)
                    {
                        if (!prePinSupportAdded)
                        {
                            PinSupportSet.Add(new CoordPair { XCoord = tempXCoord - .001f, YCoord = 0 });
                            prePinSupportAdded = true;
                        }
                        tempYCoord = YPinReaction;
                    }
                    PinSupportSet.Add(new CoordPair { XCoord = tempXCoord, YCoord = tempYCoord });
                    tempXCoord += interval;
                }
            }


            List<CoordPair> RollerSupportSet = new List<CoordPair>();
            tempXCoord = 0;
            tempYCoord = 0;
            bool preRollerSupportAdded = false;
            if (IncludeRollerSupport)
            {
                for (float i = 0; i <= lengthOfBeam; i += interval)
                {
                    if (i >= RollerSupportLocation)
                    {
                        if (!preRollerSupportAdded)
                        {
                            RollerSupportSet.Add(new CoordPair { XCoord = tempXCoord - .001f, YCoord = 0 });
                            preRollerSupportAdded = true;
                        }
                        tempYCoord = YRollerReaction;
                    }
                    RollerSupportSet.Add(new CoordPair { XCoord = tempXCoord, YCoord = tempYCoord });
                    tempXCoord += interval;
                }
            }

            List<CoordPair> FixedSupportSet = new List<CoordPair>();
            tempXCoord = 0;
            tempYCoord = 0;
            bool preFixedSupportAdded = false;
            if (IncludeFixedSupport)
            {
                for (float i = 0; i <= lengthOfBeam; i += interval)
                {
                    if (i >= FixedSupportLocation)
                    {
                        if (!preFixedSupportAdded)
                        {
                            FixedSupportSet.Add(new CoordPair { XCoord = tempXCoord - .001f, YCoord = 0 });
                            preFixedSupportAdded = true;
                        }
                        tempYCoord = YFixedReaction;
                    }
                    FixedSupportSet.Add(new CoordPair { XCoord = tempXCoord, YCoord = tempYCoord });
                    tempXCoord += interval;
                }
            }

            List<CoordPair> Result = new List<CoordPair>();
            for( int i = 0; i < TriangularSet.Count - 1; i++ )
            {
                Result.Add(new CoordPair { XCoord = RectangularSet[i].XCoord, YCoord = TriangularSet[i].YCoord + RectangularSet[i].YCoord + PointSet[i].YCoord});
            }

            for (int i = 0; i < TriangularSet.Count - 1; i++)
            {
                if (IncludePinSupport)
                {
                    Result[i].YCoord += PinSupportSet[i].YCoord;
                }
                if (IncludeRollerSupport)
                {
                    Result[i].YCoord += RollerSupportSet[i].YCoord;
                }
                if (IncludeFixedSupport)
                {
                    Result[i].YCoord += FixedSupportSet[i].YCoord;
                }
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
            float LengthOfBeam,
            bool IncludePinSupport,
            bool IncludeRollerSupport,
            bool IncludeFixedSupport
            )
        {
            
            // Declare and initialize all complex variables
            float PointLoadMoment = (float)Math.Round((PointLoadingLocation * PointLoadingMagnitude), 2);

            float TriangularDistForce = (float).5 * TriangularDistributedLoadingMagnitude * TriangularDistributedLoadingLocation;
            float TriangularDistForceLocation = (float)Math.Round((float)(.666666666666666666667 * TriangularDistributedLoadingLocation), 2);
            float TrinagularMoment = TriangularDistForce * TriangularDistForceLocation;

            float RectangularDistForce = RectangularDistributedLoadingMagnitude * RectangularDistributedLoadingLocation;
            float RectangularDistForceLocation = (float).5 * RectangularDistributedLoadingLocation;
            float RectangularMoment = RectangularDistForce * RectangularDistForceLocation;

            // Support Reactions
            // Do moment solving for one of the forces right here. Get ratio of pin force to other forces
            int UsePinSupport = IncludePinSupport ? 1 : 0;
            int UseRollerSupport = IncludeRollerSupport ? 1 : 0;
            int UseFixedSupport = IncludeFixedSupport ? 1 : 0;

            float[,] matrix =
            {
                { UsePinSupport, UseRollerSupport, UseFixedSupport },
                { PinSupportLocation, RollerSupportLocation, FixedSupportLocation}
            };

            float knownForceMag = -1 * (PointLoadingMagnitude + RectangularDistForce + TriangularDistForce);
            float knownMomentMag = -1 * (PointLoadMoment + RectangularMoment + TrinagularMoment);
            float[,] RightSideMoment = { { knownForceMag }, { knownMomentMag } };
            float[,] MomentReaction = Matrix.Solve(matrix, RightSideMoment, leastSquares: true);

            float YPinReaction = MomentReaction[0, 0];
            float YRollerReaction = MomentReaction[1, 0];  // No X reaction, No moment reaction
            float YFixedReaction = MomentReaction[2, 0];

            // The exact same coordinate pairs as the Shear Force Diagram
            List<CoordPair> Result = new List<CoordPair>()
            {
                new CoordPair { XCoord = PointLoadingLocation, YCoord = PointLoadingMagnitude },
                new CoordPair { XCoord = TriangularDistForceLocation, YCoord = TriangularDistForce },
                new CoordPair { XCoord = RectangularDistForceLocation, YCoord = RectangularDistForce },
                new CoordPair { XCoord = LengthOfBeam, YCoord = 0 }
            };

            CoordPair PinSupportPair = new CoordPair { XCoord = PinSupportLocation, YCoord = YPinReaction };
            if (IncludePinSupport)
            {
                Result.Add(PinSupportPair);
            }
            CoordPair RollerSupportPair = new CoordPair { XCoord = RollerSupportLocation, YCoord = YRollerReaction };
            if (IncludeRollerSupport)
            {
                Result.Add(RollerSupportPair);
            }
            CoordPair FixedSupportPair = new CoordPair { XCoord = FixedSupportLocation, YCoord = YFixedReaction };
            if (IncludeFixedSupport)
            {
                Result.Add(FixedSupportPair);
            }

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

            CoordPair zeroPair = new CoordPair { XCoord = 0, YCoord = 0 };
            CoordPair FreeMoment = new CoordPair { XCoord = FreeMomentLocation, YCoord = FreeMomentMagnitude };
            Result.RemoveAll(pair => (pair.XCoord == 0 & pair.YCoord == 0));    // Removes all invalid entries that are generated on startup
            if (freeMomentLocation != 0)
            {
                Result.Insert(0, zeroPair);                                         // Sets the inital coord point on the graph ALWAYS equal to (0,0)
            }
            else
            {
                Result.Insert(0, FreeMoment);
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
            if (FreeMoment.XCoord != 0 & FreeMoment.YCoord != 0)
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
            for (int i = 0; i < (Result.Count - 1); i++)
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
