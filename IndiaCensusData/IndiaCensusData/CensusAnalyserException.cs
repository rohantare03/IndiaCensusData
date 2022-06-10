using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaCensusData
{
    public class CensusAnalyserException : Exception
    {
        public Exceptiontype type;
        public enum Exceptiontype
        {
            FILE_NOT_EXISTS, IMPROPER_EXTENSION, DELIMETER_NOT_FOUND, INCORRECT_HEADER
        }       
        public CensusAnalyserException(Exceptiontype type, string name) : base(name)
        {
            this.type = type;
        }
    }
}
