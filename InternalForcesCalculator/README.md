# Internal Forces Calculator

This is the repository for the InternalForcesCalculator UWP application created for ENGINR 1200 (Statics and Elementary Strength of Materials). It contains C# as well as XAML code which compiles into a UWP application which can run on ARM, X64, and X86 debug builds.

## Functionality and Usage

A typical use of the InternalForcesCalculator project involves having variables related to graphing Shear Force and Bending Moment Diagrams including: Point load, triangular distributed load, rectangular distributed load, and free moment.

With the user provided inputs the program can generate and graph the SFD and BMD for pin, roller, and fixed supports.

The user interface is contained within the `MainPage.xaml` file and depends on the `Syncfusion SfChart` UWP resource to plot data points.
```c#
<syncfusion:AreaSeries Name="SFD" ShowTooltip="True" Interior="#5D9BD7" Label="Bending Moment Diagram" ItemsSource="{Binding ShearForceData}" XBindingPath="XCoord" YBindingPath="YCoord" /> // Bindings for the Shear Force Diagram

<syncfusion:AreaSeries Name="BMD" ShowTooltip="True" Interior="#5D9BD7" Label="Bending Moment Diagram" ItemsSource="{Binding BendingMomentData}" XBindingPath="XCoord" YBindingPath="YCoord" /> // Bindings for the Bending Moment Diagram
```

Generation of data is located within the 'ViewModel.cs' file. The variables `ShearForceData` and `BendingMomentData` are set by the functions `CreateShearForceModel` and `CreateBendingMomentModel` respectively.

```c#
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
```

After the problem is defined, the program will automatically invoke the CreateShearForceModel and CreateBendingMomentModel functions and plot the Beam's correcsponding load diagrams.

Example Figures:
[Example1](https://github.com/SamuelBishop/UWP/tree/master/InternalForcesCalculator/Assets/FinalExample2.png)

[Example2](https://github.com/SamuelBishop/UWP/tree/master/InternalForcesCalculator/Assets/FinalExample3.png)