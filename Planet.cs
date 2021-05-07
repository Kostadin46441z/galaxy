using System;
using System.Collections.Generic;

namespace GalaxyCatalogue
{
    class Planet: CelestialBody
    {
        public string Name 
        { 
            get { return base.name; }
            set { base.name = value; }
        }
        private string planetType;

        public string PlanetType
        {
            get { return this.planetType; }
            set { this.planetType = value; }
        }

        private bool habitable;

        public bool Habitable
        {
            get { return this.habitable; }
            set { this.habitable = value; }
        }

        public Dictionary<String, Moon> moons;

        public Planet (string name, string type, bool habitable) : base (name)
        {
            this.PlanetType = type;
            this.Habitable = habitable;
            this.moons = new Dictionary<string, Moon>();
        }

        public void addMoon(Moon moon) 
        {
            if (moons.ContainsKey(moon.Name)) 
            {
                moons[moon.Name] = moon;
            } else {
                moons.Add(moon.Name, moon);
            }
        }
    }
}