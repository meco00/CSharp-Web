﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSACA.Services
{
   public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}