﻿using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IMotorcycle> motorcycleRepository;
        private IRepository<IRace> raceRepository;
        private IRepository<IRider> riderRepository;

        public ChampionshipController()
        {
            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();
            this.riderRepository = new RiderRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (this.riderRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            if (this.motorcycleRepository.GetByName(motorcycleModel) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            IRider rider = riderRepository.GetByName(riderName);
            IMotorcycle motorcycle = motorcycleRepository.GetByName(motorcycleModel);

            rider.AddMotorcycle(motorcycle);
            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            if (this.raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (this.riderRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            IRider rider = riderRepository.GetByName(riderName);
            IRace race = raceRepository.GetByName(raceName);

            race.AddRider(rider);
            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = null;

            if (this.motorcycleRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }
            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
                this.motorcycleRepository.Add(motorcycle);
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
                this.motorcycleRepository.Add(motorcycle);
            }

            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, motorcycle.Model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name);

            this.raceRepository.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (this.riderRepository.GetByName(riderName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            IRider rider = new Rider(riderName);

            this.riderRepository.Add(rider);
            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            if (this.raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRace race = raceRepository.GetByName(raceName);

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            List<IRider> result = race.Riders.OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps)).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition, result[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition, result[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition, result[2].Name, raceName));

            result[0].WinRace();
            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
