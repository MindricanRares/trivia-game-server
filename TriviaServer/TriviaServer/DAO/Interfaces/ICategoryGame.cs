﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.Models;

namespace TriviaServer.Controllers.API
{
    public interface ICategoryGame
    {
        void Create(CategoryGame c);
    }
}
