﻿using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.Interfaces;

namespace BorderControl.Models
{
    public class Pet : IBirthtable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
