using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    private static ExponentialNotation MassOfSagittariusAStar = new ExponentialNotation(
            value: 8.6f,
            exponent: 36,
            unit: SIUnit.Kilograms
        );

    private static ExponentialNotation RadiusOfSagittariusAStar = new ExponentialNotation(
            value: 4.4f,
            exponent: 10,
            unit: SIUnit.Meters
        );

    private static ExponentialNotation MassOfUranus = new ExponentialNotation(
            value: 8.681f,
            exponent: 25,
            unit: SIUnit.Kilograms
        );

    private static ExponentialNotation RadiusOfUranus = new ExponentialNotation(
            value: 2.5362f,
            exponent: 7,
            unit: SIUnit.Meters
        );

    private static ExponentialNotation MassOfEarth = new ExponentialNotation(
            value: 5.972f,
            exponent: 24,
            unit: SIUnit.Kilograms
        );

    private static ExponentialNotation RadiusOfEarth = new ExponentialNotation(
            value: 6.371f,
            exponent: 6,
            unit: SIUnit.Meters
        );

    private static ExponentialNotation MassOfSun = new ExponentialNotation(
            value: 1.989f,
            exponent: 30,
            unit: SIUnit.Kilograms
        );

    private static ExponentialNotation RadiusOfSun = new ExponentialNotation(
            value: 6.95508f,
            exponent: 8,
            unit: SIUnit.Meters
        );

    List<GameObject> stellarObjects = new List<GameObject>();
    public GameObject stellarObject_BasePrefab;
    public Material SagittariusAStar_Material;
    public Material Sun_Material;
    // Use this for initialization
    void Start ()
    {
        CreateNewStellarObject(
                mass: MassOfSagittariusAStar,
                radius: RadiusOfSagittariusAStar,
                name: "Sagittarius A*",
                startingPosition: Vector3.zero
            );

        CreateNewStellarObject(
                mass: MassOfSun,
                radius: RadiusOfSun,
                name: "Sun",
                startingPosition: new Vector3(0f, 0f, 1f)
            );


        CreateNewStellarObject(
                mass: MassOfUranus,
                radius: RadiusOfUranus,
                name: "Uranus",
                startingPosition: new Vector3(19f, 0f, 0f)
            );

        CreateNewStellarObject(
                mass: MassOfEarth,
                radius: RadiusOfEarth,
                name: "Earth",
                startingPosition: new Vector3(1f, 0f, 0f)
            );

        GameObject aStar = stellarObjects[0];
        aStar.GetComponentInChildren<MeshRenderer>().material = SagittariusAStar_Material;

        GameObject sun = stellarObjects[1];
        sun.GetComponentInChildren<MeshRenderer>().material = Sun_Material;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateNewStellarObject(ExponentialNotation mass, ExponentialNotation radius,
        string name, Vector3 startingPosition)
    {
        GameObject newInstance = GameObject.Instantiate(stellarObject_BasePrefab, startingPosition, Quaternion.identity);

        newInstance.name = name;
        StellarObject newStellarObject = newInstance.GetComponentInChildren<StellarObject>();
        newStellarObject.Initialize(mass, radius);

        stellarObjects.Add(newInstance);
    }

}
