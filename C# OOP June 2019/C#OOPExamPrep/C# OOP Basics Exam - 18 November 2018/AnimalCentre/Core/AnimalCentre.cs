﻿using AnimalCentre.Models;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private IHotel hotel;
        IProcedure procedure;
        IAnimal animal;
        private List<IProcedure> procedures;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.procedures = new List<IProcedure>();
            this.AdoptedAnimals = new SortedDictionary<string, List<IAnimal>>();
        }

        public SortedDictionary<string, List<IAnimal>> AdoptedAnimals { get; set; }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = null;

            switch (type)
            {
                case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;
            }

            this.hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            this.procedure = this.procedures.FirstOrDefault(x => x.GetType().Name == "Chip");

            if (procedure == null)
            {
                this.procedure = new Chip();
                this.procedures.Add(procedure);
            }

            this.animal = this.hotel.Animals.First(a => a.Key == name).Value;

            this.procedure.DoService(this.animal, procedureTime);

            return $"{this.animal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            this.procedure = this.procedures.FirstOrDefault(x => x.GetType().Name == "Vaccinate");

            if (procedure == null)
            {
                this.procedure = new Vaccinate();
                this.procedures.Add(procedure);
            }

            this.animal = this.hotel.Animals.First(a => a.Key == name).Value;

            this.procedure.DoService(this.animal, procedureTime);

            return $"{this.animal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            this.procedure = this.procedures.FirstOrDefault(x => x.GetType().Name == "Fitness");

            if (procedure == null)
            {
                this.procedure = new Fitness();
                this.procedures.Add(procedure);
            }

            this.animal = this.hotel.Animals.First(a => a.Key == name).Value;

            this.procedure.DoService(this.animal, procedureTime);

            return $"{this.animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            this.procedure = this.procedures.FirstOrDefault(x => x.GetType().Name == "Play");

            if (procedure == null)
            {
                this.procedure = new Play();
                this.procedures.Add(procedure);
            }

            this.animal = this.hotel.Animals.First(a => a.Key == name).Value;

            this.procedure.DoService(this.animal, procedureTime);

            return $"{this.animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            this.procedure = this.procedures.FirstOrDefault(x => x.GetType().Name == "DentalCare");

            if (procedure == null)
            {
                this.procedure = new DentalCare();
                this.procedures.Add(procedure);
            }

            this.animal = this.hotel.Animals.First(a => a.Key == name).Value;

            this.procedure.DoService(this.animal, procedureTime);

            return $"{this.animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            this.procedure = this.procedures.FirstOrDefault(x => x.GetType().Name == "NailTrim");

            if (procedure == null)
            {
                this.procedure = new NailTrim();
                this.procedures.Add(procedure);
            }

            this.animal = this.hotel.Animals.First(a => a.Key == name).Value;

            this.procedure.DoService(this.animal, procedureTime);

            return $"{this.animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            if (!this.hotel.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            this.animal = this.hotel.Animals.First(a => a.Key == animalName).Value;

            if (!this.AdoptedAnimals.ContainsKey(owner))
            {
                this.AdoptedAnimals.Add(owner, new List<IAnimal>());
                this.AdoptedAnimals[owner].Add(animal);
            }
            else
            {
                this.AdoptedAnimals[owner].Add(animal);
            }


            hotel.Adopt(this.animal.Name, owner);

            if (this.animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }

            return $"{owner} adopted animal without chip";

        }

        public string History(string type)
        {
            IProcedure currentProcedure = this.procedures.FirstOrDefault(p => p.GetType().Name == type);

            return currentProcedure.History();
        }
    }
}
