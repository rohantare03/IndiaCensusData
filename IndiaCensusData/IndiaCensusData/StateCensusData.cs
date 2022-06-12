using System;
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
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        public StateCensusData(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToInt32(population);
            this.area = Convert.ToInt32(area);
            this.density = Convert.ToInt32(density);
        }
        public StateCensusData(CensusCode censusCode)
        {
            this.serialNumber = censusCode.serialNumber;
            this.stateName = censusCode.stateName;
            this.tin = censusCode.tin;
            this.stateCode = censusCode.stateCode;
        }
    }
}
