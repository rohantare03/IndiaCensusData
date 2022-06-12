using NUnit.Framework;
using IndiaCensusData;

namespace IndiaCensusTestCases
{
    public class Tests
    {
        string folderPath = @"C:\Bridgelabz147\IndiaCensusData\IndiaCensusData\IndiaCensusData\CsvFile\";
        string validStateCensusFileState = "IndiaStateCensusData.csv";
        string invalideExtensionFileState = "IndiaStateCode.txt";
        string invalidDelimiterFileState = "DelimiterIndiaStateCensusData.csv";       
        string invalidHeaderState = "WrongIndiaStateCensusData.csv";
        string invalidDelimiterFileStateCode = "DelimiterIndiaStateCode.csv";
        string validCensusFileStateCode = "IndiaStateCode.csv";
        string invalidHeaderStateCode = "WrongIndiaStateCode.csv";
        CensusAnalyse censusAnalyse;
        [SetUp]
        public void Setup()
        {
            censusAnalyse = new CensusAnalyse();
        }
        /// <summary>
        /// TC1.1-All data in Indian state code is load in the file or not
        /// </summary>
        [Test]
        public void GivenCSVFile_TestIfRecordAreSame()
        {
            censusAnalyse.datamap = censusAnalyse.LoadCensusData(folderPath + validStateCensusFileState, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, censusAnalyse.datamap.Count);
        }
        ///<summary>
        ///TC1.2-check given file exists or not
        ///</summary>
        [Test]
        public void GivenIncorrectFileNmae_ReturnsCustomException()
        {
            CensusAnalyserException Exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyse.LoadCensusData(folderPath + validStateCensusFileState + "A", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.Exceptiontype.FILE_NOT_EXISTS, Exception.type);
        }
        ///<summary>
        ///TC1.3- check given filename contains proper extension or not
        ///</summary>
        [Test]
        public void GivenIncorrectType_ReturnsCustomException()
        {
            CensusAnalyserException Exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyse.LoadCensusData(folderPath + invalideExtensionFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.Exceptiontype.IMPROPER_EXTENSION, Exception.type);

        }
        ///<summary>
        ///TC1.4-Check if Proper Delimiter is used or not
        ///</summary>
        [Test]
        public void GivenIncorrectDelimiter_ReturnsCustomException()
        {
            CensusAnalyserException Exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyse.LoadCensusData(folderPath + invalidDelimiterFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.Exceptiontype.DELIMETER_NOT_FOUND, Exception.type);
        }
        ///<summary>
        ///TC1.5check if header is correct or not
        ///</summary>
        [Test]
        public void GivenIncorrectHeader_ReturnsCustomException()
        {
            CensusAnalyserException Exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyse.LoadCensusData(folderPath + invalidHeaderState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.Exceptiontype.INCORRECT_HEADER, Exception.type);
        }
        /// <summary>
        /// TC2.1-All data in Indian state code matches or not
        /// </summary>
        [Test]
        public void GivenCSVFile_TestIfRecordMatches()
        {
            censusAnalyse.datamap = censusAnalyse.LoadCensusData(folderPath + validCensusFileStateCode, "SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, censusAnalyse.datamap.Count);
        }
        ///<summary>
        ///TC2.2-check given file exists or not
        ///</summary>
        [Test]
        public void GivenIncorrectFileName_ReturnsCustomException()
        {
            CensusAnalyserException Exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyse.LoadCensusData(folderPath + validCensusFileStateCode + "A", "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusAnalyserException.Exceptiontype.FILE_NOT_EXISTS, Exception.type);
        }
        ///<summary>
        ///TC2.3- check given filename contains proper extension or not
        ///</summary>
        [Test]
        public void GivenIncorrectFileType_ReturnsCustomException()
        {
            CensusAnalyserException Exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyse.LoadCensusData(folderPath + invalideExtensionFileState, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusAnalyserException.Exceptiontype.IMPROPER_EXTENSION, Exception.type);
        }
        ///<summary>
        ///TC2.4-Check if Proper Delimiter is used or not
        ///</summary>
        [Test]
        public void GivenIncorrectDelimiter_Returns_CustomException()
        {
            CensusAnalyserException Exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyse.LoadCensusData(folderPath + invalidDelimiterFileStateCode, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusAnalyserException.Exceptiontype.DELIMETER_NOT_FOUND, Exception.type);
        }
        ///<summary>
        ///TC2.5check if header is correct or not
        ///</summary>
        [Test]
        public void GivenIncorrectHeader_Returns_CustomException()
        {
            CensusAnalyserException Exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyse.LoadCensusData(folderPath + invalidHeaderStateCode, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusAnalyserException.Exceptiontype.INCORRECT_HEADER, Exception.type);
        } 
    }
}