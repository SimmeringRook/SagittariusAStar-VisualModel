public enum SIUnit
{
    None = 0,

    #region Distance
    Meters = 1,
    Kilometers = 2,
    AstronomicalUnits = 3,
    Lightyears = 4,
    #endregion

    #region Mass
    Kilograms,
    SolarMasses,
    #endregion

    KilogramsPerSolarMass,

    #region Velocity
    Meters_PerSecond,
    Kilometers_PerSecond,
    #endregion

    #region Acceleration
    Meters_PerSecondsSquared,
    Kilometers_PerSecondsSquared,
    #endregion

    MetersSquaredPerSecond,
    MetersSquaredPerSecondsSquared,
    MetersCubedPerSecond,
    MetersCubedPerSecondsSquared,
    MetersCubedPerSecondKilogram,
    MetersCubed_PerSecondsSquared_PerKilograms,

}

public enum SIDistanceUnits
{
    None = 0,
    Meters = 1,
    Kilometers = 2,
    AstronomicalUnits = 3,
    Lightyears = 4,
}

public enum SIMassUnits
{
    None = 0,
    Kilograms,
    SolarMasses
}

public enum SITimeUnits
{
    None = 0,
    PerSecond,
    PerSecondsSquared
}