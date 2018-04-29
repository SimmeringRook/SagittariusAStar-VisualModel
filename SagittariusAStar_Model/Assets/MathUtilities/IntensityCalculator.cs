using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntensityCalculator
{
    public static ExponentialNotation GravitationalConstantOfTheUniverse = new ExponentialNotation(
            value: 6.674f,
            exponent: -11,
            unit: SIUnit.MetersCubedPerSecondsSquaredKilograms
        );

    private static ExponentialNotation SOLARMASS_TO_KILOGRAM = new ExponentialNotation(
            value: 2f,
            exponent: 30,
            unit: SIUnit.KilogramsPerSolarMass
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
        ExponentialNotation massOfObjectInKilograms = ConvertMassToKilograms(massOfObject);
        intensity = GravitationalConstantOfTheUniverse.MultipliedBy(massOfObjectInKilograms);

        //Square the radius
        ExponentialNotation radiusOfObjectInMeters = DistanceConverter.ConvertDistance(radiusOfObject, SIUnit.Meters);
        radiusOfObjectInMeters = radiusOfObjectInMeters.Squared();

        //Divide the numerator by the radius squared
        intensity = intensity.DividedBy(radiusOfObjectInMeters);

        //I = (G*M)/(r^2)
        return intensity;
    }
	
    private static ExponentialNotation ConvertMassToKilograms(ExponentialNotation massOfObject)
    {
        ExponentialNotation massOfObjectInKilograms;
        switch(massOfObject.MeasurementUnits)
        {
            case SIUnit.SolarMasses:
                massOfObjectInKilograms = massOfObject.MultipliedBy(SOLARMASS_TO_KILOGRAM);
                break;
            default:
                massOfObjectInKilograms = massOfObject;
                break;
        }

        return massOfObjectInKilograms;
    }


}
