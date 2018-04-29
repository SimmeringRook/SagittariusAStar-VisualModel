using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DistanceConverter
{
    /// <summary>
    /// 1 LY = 63241.1
    /// </summary>
    private static ExponentialNotation LightYear_To_AstronomicalUnitsRatio = new ExponentialNotation(
            value: 6.32411f,
            exponent: 4,
            unit: SIUnit.AstronomicalUnits
        );

    private static ExponentialNotation AstronomicalUnit_To_KilometersRatio = new ExponentialNotation(
            value: 1.496f,
            exponent: 8,
            unit: SIUnit.Kilometers
        );

    private static ExponentialNotation Kilometers_To_MetersRatio = new ExponentialNotation(
            value: 1f,
            exponent: 3,
            unit: SIUnit.Meters
        );

    public static ExponentialNotation Convert(ExponentialNotation distanceToConvert, SIUnit unitToConvertTo)
    {
        ExponentialNotation convertedDistance = distanceToConvert;

        if (distanceToConvert.MeasurementUnits > unitToConvertTo)
        {
            convertedDistance = ConvertDown(distanceToConvert, unitToConvertTo);
        }
        else if (distanceToConvert.MeasurementUnits < unitToConvertTo)
        {
            convertedDistance = ConvertUp(distanceToConvert, unitToConvertTo);
        }

        return convertedDistance;
    }

    private static ExponentialNotation ConvertDown(ExponentialNotation distanceToConvert, SIUnit desiredMeasurementUnit)
    {
        ExponentialNotation convertedDistance = distanceToConvert;
        while (convertedDistance.MeasurementUnits > desiredMeasurementUnit)
        {
            switch (convertedDistance.MeasurementUnits)
            {
                case SIUnit.Lightyears:
                    convertedDistance = convertedDistance * LightYear_To_AstronomicalUnitsRatio;
                    convertedDistance.MeasurementUnits = SIUnit.AstronomicalUnits;
                    break;
                case SIUnit.AstronomicalUnits:
                    convertedDistance = convertedDistance * AstronomicalUnit_To_KilometersRatio;
                    convertedDistance.MeasurementUnits = SIUnit.Kilometers;
                    break;
                case SIUnit.Kilometers:
                    convertedDistance = convertedDistance * Kilometers_To_MetersRatio;
                    convertedDistance.MeasurementUnits = SIUnit.Meters;
                    break;
                default:
                    return convertedDistance;
            }
        }

        return convertedDistance;
    }

    private static ExponentialNotation ConvertUp(ExponentialNotation distanceToConvert, SIUnit desiredMeasurementUnit)
    {
        ExponentialNotation convertedDistance = distanceToConvert;
        while (convertedDistance.MeasurementUnits < desiredMeasurementUnit)
        {
            switch (convertedDistance.MeasurementUnits)
            {
                case SIUnit.AstronomicalUnits:
                    convertedDistance = convertedDistance / LightYear_To_AstronomicalUnitsRatio;
                    convertedDistance.MeasurementUnits = SIUnit.Lightyears;
                    break;
                case SIUnit.Kilometers:
                    convertedDistance = convertedDistance / AstronomicalUnit_To_KilometersRatio;
                    convertedDistance.MeasurementUnits = SIUnit.AstronomicalUnits;
                    break;
                case SIUnit.Meters:
                    convertedDistance = convertedDistance / Kilometers_To_MetersRatio;
                    convertedDistance.MeasurementUnits = SIUnit.Kilometers;
                    break;
                default:
                    return convertedDistance;
            }
        }

        return convertedDistance;
    }
}