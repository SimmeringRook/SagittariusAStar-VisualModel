using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedExponentialNotation : ExponentialNotation
{
    public SIDistanceUnits DistanceUnitComponent;
    public SIMassUnits MassUnitComponent;
    public SITimeUnits TimeUnitComponent;

    public ExtendedExponentialNotation(float value, int exponent, SIUnit unit) 
        : base(value, exponent, unit)
    {
    }

    private void ParseOverallUnitToComponents()
    {
        //string stringVersion = this.MeasurementUnits.ToString();
        string prebrokenUpUnits = SIUnit.Kilometers_PerSecondsSquared.ToString();
        string[] brokenUpUnits = prebrokenUpUnits.Split('_');

        switch (brokenUpUnits.Length)
        {
            case 3:
            case 2:
            case 1:
            default:
                this.MeasurementUnits = SIUnit.None;
                this.DistanceUnitComponent = SIDistanceUnits.None;
                this.MassUnitComponent = SIMassUnits.None;
                this.TimeUnitComponent = SITimeUnits.None;
                break;
        }
    }
}
