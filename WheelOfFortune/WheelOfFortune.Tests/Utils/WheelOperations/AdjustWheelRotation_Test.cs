using System;
using System.Collections.Generic;
using WheelOfFortune.Shared.Utils.MathUtils;
using WheelOfFortune.Shared.Utils.WheelOperations;

namespace WheelOfFortune.Tests.Utils.WheelOperationsTests;

public class AdjustWheelRotationTests
{
    [DatapointSource]
    public (int Segments, double RotationOffset)[] values =
    {
        (4, 45.0), (5, 18.0), (6, 0.0), (7, -12.9), (8, 22.5), (9, 10.0), (10, 0), (11, -8.2)
    };
    [Theory]
    public void AdjustWheelRotation_ReturnsHalfOfArcLength((int Segments, double RotationOffset) value)
    {
        var roundedOutput = Math.Round(WheelOperations.AdjustWheelRotation(value.Segments) * 10) / 10 ;
        Assert.That(roundedOutput == value.RotationOffset);

    }
}
