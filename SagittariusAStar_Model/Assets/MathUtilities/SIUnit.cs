public enum SIUnit
{
    Error = 0,

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
    MetersPerSecond,
    KilometersPerSecond,
    #endregion

    #region Acceleration
    MetersPerSecondsSquared,
    KilometersPerSecondsSquared,
    #endregion

    MetersSquaredPerSecond,
    MetersSquaredPerSecondsSquared,
    MetersCubedPerSecond,
    MetersCubedPerSecondsSquared,
    MetersCubedPerSecondKilogram,
    MetersCubedPerSecondsSquaredKilograms,


}
