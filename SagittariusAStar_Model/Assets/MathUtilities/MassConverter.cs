using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MassConverter
{
    private static ExponentialNotation SolarMass_To_KilogramsRatio = new ExponentialNotation(
            value: 2f,
            exponent: 30,
            unit: SIUnit.KilogramsPerSolarMass
        );

    public static ExponentialNotation Convert(ExponentialNotation massToConvert, SIUnit unitToConvertTo)
    {
        ExponentialNotation convertedMass = massToConvert;

        if (massToConvert.MeasurementUnits > unitToConvertTo)
        {
            convertedMass = ConvertDown(massToConvert, unitToConvertTo);
        }
        else if (massToConvert.MeasurementUnits < unitToConvertTo)
        {
            convertedMass = ConvertUp(massToConvert, unitToConvertTo);
        }

        return convertedMass;
    }

    private static ExponentialNotation ConvertDown(ExponentialNotation massToConvert, SIUnit desiredMeasurementUnit)
    {
        ExponentialNotation convertedMass = massToConvert;
        while (convertedMass.MeasurementUnits > desiredMeasurementUnit)
        {
            switch (convertedMass.MeasurementUnits)
            {
                case SIUnit.SolarMasses:
                    convertedMass = convertedMass * SolarMass_To_KilogramsRatio;
                    convertedMass.MeasurementUnits = SIUnit.Kilograms;
                    break;
                default:
                    return convertedMass;
            }
        }

        return convertedMass;
    }

    private static ExponentialNotation ConvertUp(ExponentialNotation massToConvert, SIUnit desiredMeasurementUnit)
    {
        ExponentialNotation convertedMass = massToConvert;
        while (convertedMass.MeasurementUnits < desiredMeasurementUnit)
        {
            switch (convertedMass.MeasurementUnits)
            {
                case SIUnit.Kilograms:
                    convertedMass = convertedMass / SolarMass_To_KilogramsRatio;
                    convertedMass.MeasurementUnits = SIUnit.SolarMasses;
                    break;
                default:
                    return convertedMass;
            }
        }

        return convertedMass;
    }
}
