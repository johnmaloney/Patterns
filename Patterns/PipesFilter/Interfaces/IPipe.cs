﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.PipesFilter.Interfaces
{
    public interface IPipe
    {
        IPipe NextPipe { get; }

        IPipe ExtendWith(IPipe pipe);

        Task Process(IPipeContext context);
    }
}
