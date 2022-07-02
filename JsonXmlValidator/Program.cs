namespace JsonXmlValidator
{
    internal class Program
    {
        private const string HdiJsonFile = "Json/HDI.json";
        private const string HdiJsonSchema = "Json/HDISchema.json";
        private const string SuicideStatsJsonFile = "Json/SuicideStatistics.json";
        private const string SuicideStatsJsonSchema = "Json/SuicideStatisticsSchema.json";
        private const string YouthUnemploymentJsonFile = "Json/YouthUnemploymentRates.json";
        private const string YouthUnemploymentRatesJsonSchema = "Json/YouthUnemploymentRatesSchema.json";


        private const string HdiXmlFile = "Xml/Hdi.xml";
        private const string HdiXmlSchema = "Xml/HdiSchema.xsd";
        private const string SuicideRatesXmlFile = "Xml/SuicideRates.xml";
        private const string SuicideRatesXmlSchema = "Xml/SuicideRatesSchema.xsd";
        private const string YouthUnemploymentXmlFile = "Xml/YouthUnemployment.xml";
        private const string YouthUnemploymentXmlSchema = "Xml/YouthUnemploymentSchema.xsd";

        private static void Main(string[] args)
        {
            // true
            //Newtonsoft.Json.JsonValidatingReader
            //IList<string> errorMessages = null;
            //if (!ValidateJson(HdiJsonFile, HdiJsonSchema, SuicideStatsJsonFile, SuicideStatsJsonSchema, YouthUnemploymentJsonFile, YouthUnemploymentRatesJsonSchema, out errorMessages))
            //    PrintJsonError(errorMessages);
            //ValidateXml(HdiXmlFile, HdiXmlSchema, SuicideRatesXmlFile, SuicideRatesXmlSchema, YouthUnemploymentXmlFile, YouthUnemploymentXmlSchema);
        }
    }
}