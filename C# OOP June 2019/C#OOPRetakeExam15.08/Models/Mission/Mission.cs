﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (planet.Items.Any() && astronaut.CanBreath)
                {
                    var item = planet.Items.First();

                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);

                    planet.Items.Remove(item);
                }

            }
        }
    }
}
