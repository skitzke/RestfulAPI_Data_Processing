using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace JsonXmlValidator
{
    class Program
    {
        const string HdiJsonFile = "Json/HDI.json";
        const string HdiJsonSchema = "Json/HDISchema.json";
        const string SuicideStatsJsonFile= "Json/SuicideStatistics.json";
        const string SuicideStatsJsonSchema = "Json/SuicideStatisticsSchema.json";
        const string YouthUnemploymentJsonFile = "Json/YouthUnemploymentRates.json";
        const string YouthUnemploymentRatesJsonSchema = "Json/YouthUnemploymentRatesSchema.json";


        const string HdiXmlFile = "Xml/Hdi.xml";
        const string HdiXmlSchema = "Xml/HdiSchema.xsd";
        const string SuicideRatesXmlFile = "Xml/SuicideRates.xml";
        const string SuicideRatesXmlSchema = "Xml/SuicideRatesSchema.xsd";
        const string YouthUnemploymentXmlFile = "Xml/YouthUnemployment.xml";
        const string YouthUnemploymentXmlSchema = "Xml/YouthUnemploymentSchema.xsd";

        static void Main(string[] args) 
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
