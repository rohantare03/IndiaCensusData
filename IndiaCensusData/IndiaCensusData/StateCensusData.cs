﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaCensusData
{
    public class StateCensusData
    {
        string state;
        int population;
        int area;
        int density;
        public StateCensusData(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToInt32(population);
            this.area = Convert.ToInt32(area);
            this.density = Convert.ToInt32(density);
        }
    }
}
