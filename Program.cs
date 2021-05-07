using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GalaxyCatalogue
{
    class Program
    {
        class Catalogue 
        {
            public Dictionary<string, Galaxy> galaxies = new Dictionary<string, Galaxy>();
            public void addGalaxy(Galaxy galaxie)
            {
                if (this.galaxies.ContainsKey(galaxie.Name)) 
                {
                    this.galaxies[galaxie.Name] = galaxie;
                } else {
                    this.galaxies.Add(galaxie.Name, galaxie);
                }
            }

            public void addStar(string galaxy, Star s)
            {
                if (this.galaxies.ContainsKey(galaxy)) {
                    this.galaxies[galaxy].addStar(s);
                }
            }

            public void addPlanet(string star, Planet p)
            {
                foreach(Galaxy g in this.galaxies.Values)
                {
                    if (g.stars.ContainsKey(star)) {
                        g.stars[star].addPlanet(p);
                        return;
                    }
                }
            }

            public void addMoon(string planet, Moon m)
            {
                foreach(Galaxy g in this.galaxies.Values)
                {
                    foreach(Star s in g.stars.Values)
                    {
                        if (s.planets.ContainsKey(planet)){
                            s.planets[planet].addMoon(m);
                            return;
                        }
                    }
                }
            }

            public void stats()
            {
                int starCount = 0;
                int planCount = 0;
                int moonCount = 0;

                Console.WriteLine($"--- Stats ---\nGalaxies: {this.galaxies.Count}");
                foreach(Galaxy g in galaxies.Values) 
                {
                    starCount += g.stars.Count;
                    foreach(Star s in g.stars.Values)
                    {
                        planCount += s.planets.Count;
                        foreach(Planet p in s.planets.Values)
                        {
                            moonCount += p.moons.Count;
                        }
                    }
                }
                Console.WriteLine($"Stars: {starCount}\nPlanets: {planCount}\nMoons: {moonCount}\n--- End of stats ---");
            }

            public void list(string query)
            {
                LinkedList<string> s = new LinkedList<string>();
                Console.WriteLine($"--- List of all researched {query} ---");
                if(query == "galaxies"){
                    foreach(var k in this.galaxies.Keys){
                        s.AddLast(k);
                    }
                } else if (query == "stars"){
                    foreach(Galaxy g in this.galaxies.Values) 
                    {
                        foreach(string st in g.stars.Keys) 
                        {
                            s.AddLast(st);
                        }
                    }
                } else if (query == "planets"){
                    foreach(Galaxy g in this.galaxies.Values) 
                    {
                        foreach(Star st in g.stars.Values) 
                        {
                            foreach (String p in st.planets.Keys) 
                            {
                                s.AddLast(p);
                            }
                        }
                    }
                } else {
                    foreach(Galaxy g in this.galaxies.Values) 
                    {
                        foreach(Star st in g.stars.Values) 
                        {
                            foreach (Planet p in st.planets.Values) 
                            {
                                foreach (String m in p.moons.Keys)
                                {
                                    s.AddLast(m);
                                }
                            }
                        }
                    }
                }
                String res = string.Join(", ", s);
                Console.WriteLine($"{res}\n--- End of {query} list ---");

            }
        }
        static void Main(string[] args)
        {
            Catalogue cat = new Catalogue();
           
            while(true) 
            {
                string pattern = @"\[\w+\s\w+\]|\[\w+\]|[a-zA-Z0-9.]+";
                string input = Console.ReadLine();
                Regex rgx = new Regex(pattern);
                string[] command = rgx.Matches(input)
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .ToArray();
                if (command[0] == "exit") {
                    break;
                }
                if (command[0] == "add") {
                    if (command[1] == "galaxy") {
                        Galaxy g = new Galaxy(command[2].Substring(1,command[2].Length - 2), command[3], command[4]);
                        cat.addGalaxy(g);
                    } else if (command[1] == "star") {
                        Star s = new Star(command[3].Substring(1,command[3].Length - 2), double.Parse(command[4]), double.Parse(command[5]), int.Parse(command[6]), double.Parse(command[7]));
                        cat.addStar(command[2].Substring(1,command[2].Length - 2), s);
                    } else if (command[1] == "planet") {
                        Planet p = new Planet(command[3].Substring(1,command[3].Length - 2), command[4], command[5] == "yes");
                        cat.addPlanet(command[2].Substring(1,command[2].Length - 2), p);
                    } else if (command[1] == "moon") {
                        Moon m = new Moon(command[3].Substring(1,command[3].Length - 2));
                        cat.addMoon(command[2].Substring(1,command[2].Length - 2), m);
                    }
                } else if (command[0] == "stats") {
                    cat.stats();
                } else if (command[0] == "list") {
                    cat.list(command[1]);
                } else if (command[0] == "print") {
                    Console.WriteLine(cat.galaxies[command[1].Substring(1, command[1].Length - 2)].ToString());
                }
            }
        }
    }
}
