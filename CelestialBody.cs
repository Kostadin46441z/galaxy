using System;

namespace GalaxyCatalogue
{
    abstract class CelestialBody
    {
        protected string name;

        public CelestialBody(string name)
        {
            this.name = name;
        }
    }
}