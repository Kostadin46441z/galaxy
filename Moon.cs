using System;

namespace GalaxyCatalogue
{
    class Moon: CelestialBody
    {
        public string Name 
        { 
            get { return base.name; }
            set { base.name = value; }
        }
        public Moon (string name) : base (name) { }
    }
}