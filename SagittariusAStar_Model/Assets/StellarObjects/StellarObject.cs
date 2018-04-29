using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StellarObject : MonoBehaviour
{
    [SerializeField]
    public ExponentialNotation Mass;
    public ExponentialNotation Radius;
    public ExponentialNotation IntenstityAtSurface;

	// Use this for initialization
	void Start ()
    {
        this.Mass = null;
        this.Radius = null;
        this.IntenstityAtSurface = null;
	}

    public void Initialize(ExponentialNotation mass, ExponentialNotation radius)
    {
        this.Mass = mass;
        this.Radius = radius;
        this.IntenstityAtSurface = IntensityCalculator.IntensityAtSurface(this.Mass, this.Radius);

        ExponentialNotation radiusAsAU = DistanceConverter.Convert(this.Radius, SIUnit.AstronomicalUnits);

        float scaledValue = radiusAsAU.GetNormalizedValue();

        this.gameObject.transform.localScale = new Vector3(
                x: scaledValue,
                y: scaledValue,
                z: scaledValue
            );
    }

    public ExponentialNotation GetIntensityAtDistance(Vector3 orbitingObjectPosition)
    {
        //todo convert Vector3 into real distance
        ExponentialNotation actualDistance = ConvertVector3ToAU(orbitingObjectPosition);

        return IntensityCalculator.IntensityAtDistance(this.IntenstityAtSurface, this.Radius, actualDistance);
    }

    private ExponentialNotation ConvertVector3ToAU(Vector3 vectorToConvert)
    {
        return new ExponentialNotation(
                value: Vector3.Distance(this.transform.position, vectorToConvert),
                exponent: 0,
                unit: SIUnit.AstronomicalUnits
            );
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void Spin()
    {
        //this.gameObject.transform.Rotate()
    }
}
