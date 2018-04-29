using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntensityCalculator
{
    public static ExponentialNotation GravitationalConstantOfTheUniverse = new ExponentialNotation(
            value: 6.674f,
            exponent: -11,
            unit: SIUnit.MetersCubed_PerSecondsSquared_PerKilograms
        );

    

    /// <summary>
    /// Calculate the Intensity of Gravity at the Surface of the object
    /// I = (G*M)/(r^2)
    /// </summary>
    /// <param name="massOfObject">The mass of the object</param>
    /// <param name="radiusOfObject">The radius of the object</param>
    /// <returns></returns>
    public static ExponentialNotation IntensityAtSurface(ExponentialNotation massOfObject, ExponentialNotation radiusOfObject)
    {
        ExponentialNotation intensity = null;

        //Calculate the numerator: Graviational Constant * Mass (in kg)
        ExponentialNotation massOfObjectInKilograms = MassConverter.Convert(massOfObject, SIUnit.Kilograms);
        intensity = GravitationalConstantOfTheUniverse * massOfObjectInKilograms;

        //Square the radius
        ExponentialNotation radiusOfObjectInMeters = DistanceConverter.Convert(radiusOfObject, SIUnit.Meters);
        radiusOfObjectInMeters = radiusOfObjectInMeters * radiusOfObjectInMeters;

        //Divide the numerator by the radius squared
        intensity = intensity / radiusOfObjectInMeters;
        intensity.MeasurementUnits = SIUnit.MetersCubed_PerSecondsSquared_PerKilograms;
        //I = (G*M)/(r^2)
        return intensity;
    }

    /// <summary>
    /// n = distanceFromSource / radiusOfSource
    /// I / (n^2) = Intensity at DistanceFromSource
    /// </summary>
    /// <param name="surfaceIntensity"></param>
    /// <param name="radiusOfSourceObject"></param>
    /// <param name="distanceAwayFromSource"></param>
    /// <returns></returns>
    public static ExponentialNotation IntensityAtDistance(ExponentialNotation surfaceIntensity, ExponentialNotation radiusOfSourceObject, ExponentialNotation distanceAwayFromSource)
    {
        ExponentialNotation intensityAtDistance = null;

        //Convert distances to meters

        //Calculate n: distanceFromSource / radiusOfSource
        ExponentialNotation multipleOfRadius = distanceAwayFromSource / radiusOfSourceObject;
        multipleOfRadius = (multipleOfRadius * multipleOfRadius);
        multipleOfRadius = DistanceConverter.Convert(multipleOfRadius, SIUnit.Meters);

        //Divide Surface Intensity by n^2
        intensityAtDistance = surfaceIntensity / multipleOfRadius;
        intensityAtDistance.MeasurementUnits = SIUnit.MetersCubed_PerSecondsSquared_PerKilograms;
        //I / (n^2)
        return intensityAtDistance;
    }
}
