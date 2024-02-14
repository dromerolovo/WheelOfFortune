using System;
using System.Collections.Generic;
using WheelOfFortune.Shared.Utils.MathUtils;
using WheelOfFortune.Shared.Utils.WheelOperations;

namespace WheelOfFortune.Tests.Utils.WheelOperationsTests;

//Scenario where the top section closest to 270 degrees (clockwise) is the same as the selected to 
//calculate the rotation of the image.
public class CalculateSectionImgRotationTestScenarioA
{
    [DatapointSource]
    public (int Sections, int Section, double ExpectedOutput)[] values =
    {
        (4, 4, 45.0), (5, 4, -18.0), (6, 5, 0.0), (7, 6, 12.9), (8, 6, -22.5), (9, 7, -10.0), (10, 8, 0.0), (11, 9, 8.2)
    };
    [Theory]
    public void WhenSectionIsEqualToSectionCentered_ReturnNegativeOffset
    (
        (int Sections, int Section, double ExpectedOutput) value
    )
    {
        var angleOffset = WheelOperations.AdjustWheelRotation(value.Sections);
        var output = WheelOperations.CalculateSectionImgRotation(value.Sections, value.Section, angleOffset);
        Assert.That(Math.Round(output * 10) / 10 == value.ExpectedOutput);
    }
}

//Scenario where the selected section is greater(in order) than the closest section to 270 degrees (clockwise).
public class CalculateSectionImgRotationTestScenarioB
{
    [DatapointSource]
    public (int Sections, int Section, double ExpectedOutput)[] values =
    {
        (5, 5, 54), (6, 6, 60), (7, 7, 64.3), (8, 8, 67.5), (9, 9, 70.0), (10, 10, 72.0), (11, 11, 73.6)
    };
    [Theory]
    public void WhenSectionIsGreaterToSectionCentered_ReturnCalculatedOffset
    (
        (int Sections, int Section, double ExpectedOutput) value
    )
    {
        var angleOffset = WheelOperations.AdjustWheelRotation(value.Sections);
        var output = WheelOperations.CalculateSectionImgRotation(value.Sections, value.Section, angleOffset);
        Assert.That(Math.Round(output * 10) / 10 == value.ExpectedOutput);
    }
}

//Scenario where the selected section is lower(in order) than the closest section to 270 degrees (clockwise).
public class CalculateSectionImgRotationTestScenarioC
{
    [DatapointSource]
    public (int Sections, int Section, double ExpectedOutput)[] values =
    {
        (5, 1, 126.0), (6, 1, 120.0), (7, 1, 115.7), (8, 1, 112.5), (9, 1, 110.0), (10, 1, 108.0), (11, 1, 106.4)
    };
    [Theory]
    public void WhenSectionIsLowerToSectionCentered_ReturnCalculatedOffset
    (
        (int Sections, int Section, double ExpectedOutput) value
    )
    {
        var angleOffset = WheelOperations.AdjustWheelRotation(value.Sections);
        var output = WheelOperations.CalculateSectionImgRotation(value.Sections, value.Section, angleOffset);
        Assert.That(Math.Round(output * 10) / 10 == value.ExpectedOutput);
    }
}
