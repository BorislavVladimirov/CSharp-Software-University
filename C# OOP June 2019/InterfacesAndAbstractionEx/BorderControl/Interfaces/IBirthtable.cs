﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Interfaces
{
    interface IBirthtable : INameable
    {
        string Name { get; }

        string Birthdate { get; }
    }
}
