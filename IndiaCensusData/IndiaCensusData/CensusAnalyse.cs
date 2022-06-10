using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaCensusData
{
    public class CensusAnalyse
    {
        public Dictionary<string, StateCensusData> datamap;

        ///<summary>
        ///Loads the census data
        ///</summary>
        ///<param name="csvFilePath">The CSV file path.</param>
        ///<param name="dataHeaders">The data Headers.</param>
        ///<returns></returns>
        ///<exception cref="Dictionary<string, StateCensusData>"></exception>
        public Dictionary<string, StateCensusData> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            datamap = new Dictionary<string, StateCensusData>();
            //check file exists or not
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException(CensusAnalyserException.Exceptiontype.FILE_NOT_EXISTS, "File does not Exists");
            }
            //check file extension proper or not
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.Exceptiontype.IMPROPER_EXTENSION, "Improper File Extension");
            }
            //check data header correct or not
            string[] censusdata = File.ReadAllLines(csvFilePath);
            if (censusdata[0] != dataHeaders)
            {
                throw new CensusAnalyserException(CensusAnalyserException.Exceptiontype.INCORRECT_HEADER, " Incorrect Header");
            }
            //check for delimeter is avaiable or not for this skippping header check all the data
            foreach (string row in censusdata.Skip(1))
            {
                if (!row.Contains(","))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.Exceptiontype.DELIMETER_NOT_FOUND, "Delimeter Not Found");
                }
                string[] column = row.Split(',');
                datamap.Add(column[0], new StateCensusData(column[0], column[1], column[2], column[3]));
            }
            return datamap;
        }
    }
}
