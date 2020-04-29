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
using Accord;

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
            float TriangularDistForce = .5f * TriangularDistributedLoadingMagnitude * TriangularDistributedLoadingLocation;
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

            // Step 1: Create coordinate pairs with the desired attributes for graphing later

            List<CoordPair> NonDistribs = new List<CoordPair>()
            {
                new CoordPair { XCoord = PointLoadingLocation, YCoord = PointLoadingMagnitude },
            };

            bool NoSupportsApplied = !IncludePinSupport & !IncludeRollerSupport & !IncludeFixedSupport;
            CoordPair endPair = new CoordPair { XCoord = LengthOfBeam, YCoord = 0 };
            if ((NoSupportsApplied & !(pointLoadingLocation == lengthOfBeam || TriangularDistForceLocation == lengthOfBeam || RectangularDistForceLocation == lengthOfBeam)) || (!NoSupportsApplied & (pinSupportLocation != lengthOfBeam & rollerSupportLocation != lengthOfBeam & fixedSupportLocation != lengthOfBeam)))
            {
                NonDistribs.Add(endPair);
            }

            // Add point loads on every .1 interval
            int interval = 1;
            float tempXCoord = 0;
            float tempYCoord = 0;
            List<CoordPair> PointSet = new List<CoordPair>();
            for (float i = 0; i < lengthOfBeam; i += interval)
            {
                if (i >= PointLoadingLocation)
                {
                    PointSet.Add(new CoordPair { XCoord = tempXCoord-.001f, YCoord = 0 });
                    tempYCoord = PointLoadingMagnitude;
                }
                PointSet.Add(new CoordPair { XCoord = tempXCoord, YCoord = tempYCoord });
                tempXCoord += interval;
            }

            // Add tri force points every .1 on the interval
            tempXCoord = 0;
            tempYCoord = 0;
            List<CoordPair> TriangularSet = new List<CoordPair>();
            for (float i = 0; i < lengthOfBeam; i += interval)
            {
                tempYCoord = .5f * i * TriangularDistributedLoadingMagnitude;
                if (i > TriangularDistributedLoadingLocation)
                {
                    TriangularSet.Add(new CoordPair { XCoord = tempXCoord, YCoord = 0 });
                }
                else
                {
                    TriangularSet.Add(new CoordPair { XCoord = tempXCoord, YCoord = tempYCoord });
                }
                tempXCoord += interval;
            }
            //TriangularSet.Add(new CoordPair { XCoord = TriangularSet[TriangularSet.Count - 1].XCoord + .001f, YCoord = 0 });

            // Add Rect force points every .1 on the interval
            List<CoordPair> RectangularSet = new List<CoordPair>();
            tempXCoord = 0;
            tempYCoord = 0;
            for (float i = 0; i < lengthOfBeam; i += interval)
            {
                if (i > TriangularDistributedLoadingLocation)
                {
                    RectangularSet.Add(new CoordPair { XCoord = tempXCoord, YCoord = 0 });
                }
                else
                {
                    RectangularSet.Add(new CoordPair { XCoord = tempXCoord, YCoord = tempYCoord });
                }
                    tempYCoord = i * TriangularDistributedLoadingMagnitude;
                
                tempXCoord += interval;
            }
            //RectangularSet.Add(new CoordPair { XCoord = RectangularSet[RectangularSet.Count - 1].XCoord + .001f, YCoord = 0 });


            CoordPair PinSupportPair = new CoordPair { XCoord = PinSupportLocation, YCoord = YPinReaction };
            if (IncludePinSupport)
            {
                NonDistribs.Add(PinSupportPair);
            }
            CoordPair RollerSupportPair = new CoordPair { XCoord = RollerSupportLocation, YCoord = YRollerReaction };
            if (IncludeRollerSupport)
            {
                NonDistribs.Add(RollerSupportPair);
            }
            CoordPair FixedSupportPair = new CoordPair { XCoord = FixedSupportLocation, YCoord = YFixedReaction };
            if (IncludeFixedSupport)
            {
                NonDistribs.Add(FixedSupportPair);
            }

            

            // Finally run through the list and add the previous YCoord to the current YCoord

            // Needs to be changed to sum all in region
            //float CurYCoord = 0;
            //float PrevYCoord = 0;
            List<CoordPair> Result = new List<CoordPair>();
            List<float> triSetX = new List<float>();
            List<float> triSetY = new List<float>();
            List<float> rectSetX = new List<float>();
            List<float> rectSetY = new List<float>();
            List<float> pointSetX = new List<float>();
            List<float> pointSetY = new List<float>();

            foreach( var CoordPair in TriangularSet)
            {
                triSetX.Add(CoordPair.XCoord);
                triSetY.Add(CoordPair.YCoord);
            }
            foreach (var CoordPair in RectangularSet)
            {
                rectSetX.Add(CoordPair.XCoord);
                rectSetY.Add(CoordPair.YCoord);
            }
            foreach (var CoordPair in PointSet)
            {
                pointSetX.Add(CoordPair.XCoord);
                pointSetY.Add(CoordPair.YCoord);
            }

            var finalXSet = triSetX.Intersect(rectSetX.Intersect(pointSetX));

            var step1 = triSetY.Zip(rectSetY, (i, j) => i + j);
            var summedY = step1.Zip(pointSetY, (i, j) => i + j);
            int count = 0;
            foreach ( var entry in summedY)
            {
                Result.Add(new CoordPair { XCoord = PointSet[count].XCoord, YCoord = entry });
                count++;
            }

            CoordPair zeroPair = new CoordPair { XCoord = 0, YCoord = 0 };
            Result.RemoveAll(pair => (pair.XCoord == 0 & pair.YCoord == 0));    // Removes all invalid entries that are generated on startup
            Result.RemoveAll(pair => (pair.XCoord > LengthOfBeam));             // Removes all invalid coordinate sets where the location is greater than the length of the beam
            if (NoSupportsApplied & !NonDistribs.Exists(pair => (pair.XCoord == 0 & pair.YCoord != 0)))
            {
                Result.Insert(0, zeroPair);                                         // Sets the inital coord point on the graph ALWAYS equal to (0,0)
            }
            Result.Add(endPair);
            //Result.Sort(delegate (CoordPair x, CoordPair y)                     // Sorts all of the coord pairs by x coordinate so lower x coordinate pairs display first
            //{
            //    return x.XCoord.CompareTo(y.XCoord);
            //});



            //foreach (var CoordPair in PointSet)
            //{
            //    if (q! > PointSet.Count & q! > TriangularSet.Count & q! > RectangularSet.Count) {
            //        yResult = PointSet[q].YCoord + TriangularSet[q].YCoord + RectangularSet[q].YCoord;
            //        q++;
            //    }
            //}


            //if (RectangularSet.Count > TriangularSet.Count)
            //{
            //    foreach (var CoordPair in RectangularSet)
            //    {
            //        PrevYCoord = CurYCoord;
            //        CoordPair.YCoord += PrevYCoord;
            //        CurYCoord = CoordPair.YCoord;
            //    }
            //}
            //else
            //{
            //    foreach (var CoordPair in TriangularSet)
            //    {
            //        PrevYCoord = CurYCoord;
            //        CoordPair.YCoord += PrevYCoord;
            //        CurYCoord = CoordPair.YCoord;
            //    }
            //}


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
