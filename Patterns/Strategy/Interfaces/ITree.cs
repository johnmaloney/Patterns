﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Strategy.Interfaces
{
    public interface ITree : IStrategy
    {
        string Navigate(As version = As.Default);
    }

    public interface IBranch : IStrategy
    {
        string Navigate(As version = As.Default);
    }

    public interface ILeaf : IStrategy
    {
        string Read(As version = As.Default);
    }
}
