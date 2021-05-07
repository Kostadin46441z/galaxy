using System;
using System.Collections.Generic;

namespace GalaxyCatalogue
{
    class Star: CelestialBody
    {
        public string Name 
        { 
            get { return base.name; }
            set { base.name = value; }
        }

        private char classType;

        public char ClassType
        {
            get { return this.classType; }            
        }
        private double mass;

        public double Mass 
        {
            get { return this.mass; }
            set { this.mass = value; }
        }
        private double size;

        public double Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
        private int temperature;

        public int Temperature
        {
            get { return this.temperature; }
            set { this.temperature = value; }
        }

        private double lumosity;

        public double Lumosity
        {
            get { return this.lumosity; }
            set { this.lumosity = value; }
        }
        public Dictionary<String, Planet> planets;
        public Star (string name, double mass, double size, int temperature, double lumosity) : base (name)
        {
            this.Mass = mass;
            this.Size = size;
            this.Temperature = temperature;
            this.Lumosity = lumosity;
            this.planets = new Dictionary<string, Planet>();
            this.setClass();
        }
        
        private void setClass() 
        {
            if (this.Temperature >= 30000 || this.Lumosity >= 30000 || this.Mass >= 16 || this.Size >= 6.6) {
                this.classType = 'O';
            } else if (this.Temperature >= 10000 || this.Lumosity >= 25 || this.Mass >= 2.1 || this.Size >= 1.8) {
                this.classType = 'B';
            } else if (this.Temperature >= 7500 || this.Lumosity >= 5 || this.Mass >= 1.4 || this.Size >= 1.4) {
                this.classType = 'A';
            } else if (this.Temperature >= 6000 || this.Lumosity >= 1.5 || this.Mass >= 1.04 || this.Size >= 1.15) {
                this.classType = 'F';
            } else if (this.Temperature >= 5200 || this.Lumosity >= 0.6 || this.Mass >= 0.8 || this.Size >= 0.96) {
                this.classType = 'G';
            } else if (this.Temperature >= 3700 || this.Lumosity >= 0.08 || this.Mass >= 0.45 || this.Size >= 0.7) {
                this.classType = 'K';
            } else {
                this.classType = 'M';
            }
        }

        public void addPlanet(Planet planet) 
        {
            if (planets.ContainsKey(planet.Name)) 
            {
                planets[planet.Name] = planet;
            } else {
                planets.Add(planet.Name, planet);
            }
        }

    }
}