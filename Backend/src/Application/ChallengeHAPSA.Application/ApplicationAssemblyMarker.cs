namespace ChallengeHAPSA.Application
{
    /// <summary>
    /// Ancla para el escaneo de assemblies (MediatR, AutoMapper, etc.), para no depender
    /// de una clase concreta que puede renombrarse o moverse.
    /// </summary>
    public sealed class ApplicationAssemblyMarker
    {
    }
}
