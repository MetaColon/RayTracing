﻿using RayTracing.Misc;
using RayTracing.Types.Objects.Interfaces;
using RayTracing.Types.Properties;


namespace RayTracing.Types.Objects
{
    public class SphericalLightSource : Sphere, ILightSource
    {
        /// <inheritdoc />
        public SphericalLightSource (double radius, Vector center, Surface surface, double intensity = 1) :
            base (surface, radius, center) => Intensity = intensity;

        public SphericalLightSource (double radius, Vector center, Colour colour, double intensity = 1) :
            base (new Surface (0, colour), radius, center) => Intensity = intensity;

        /// <summary>
        /// Default value is 1
        /// </summary>
        public double Intensity { get; private set; }

        public Vector GetDirection (Vector point) => (Center - point).Unit ();

        public double GetDistance (Vector point) => (Center - point).Abs ();

        public double GetRemainingIntensity (Vector point) => GetRemainingIntensity (GetDistance (point));

        public double GetRemainingIntensity (double distance) => Intensity / (4 * Constants.PI * distance);
    }
}