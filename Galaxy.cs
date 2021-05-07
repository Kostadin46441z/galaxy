using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyCatalogue
{
    class Galaxy
    {
        private string name;

        public string Name 
        {
            get { return this.name; }
            set { this.name = value; }
        }
        private string type;

        public string Type 
        {
            get { return this.type; }
            set { this.type = value; }
        }
        
        private string age;

        public string Age 
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Dictionary<String, Star> stars;

        public Galaxy(string name, string type, string age)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
            this.stars = new Dictionary<string, Star>();
        }

        public void addStar(Star star) 
        {
            if (this.stars.ContainsKey(star.Name)) 
            {
                this.stars[star.Name] = star;
            } else {
                this.stars.Add(star.Name, star);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"--- Data for {this.Name} galaxy ---\nType: {this.Type}\nAge: {this.Age}\nStars:\n");
            foreach(Star s in this.stars.Values) 
            {
                sb.Append($"    -    Name:{s.Name}\n         Class: s.Class\n         Planets:\n");
                foreach(Planet p in s.planets.Values)
                {
                    sb.Append($"           o    Name: {p.Name}\n                Type: {p.PlanetType}\n                Support life: {(p.Habitable ? "yes" : "no")}\n                Moons:\n");
                    foreach(Moon m in p.moons.Values)
                    {
                        sb.Append($"                   *    {m.Name}\n");
                    }
                }
            }
            sb.Append($"--- End of data for Milky way galaxy ---");
            return sb.ToString();
        }        
    }
}