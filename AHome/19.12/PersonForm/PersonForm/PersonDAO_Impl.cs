using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    class PersonDAO_Impl
    {
        public static IPersonDAO GetInstance(string type)
        {
            IPersonDAO pd = null;

            switch(type)
            {
                case "Mock":      pd = new PersonDAO_Mock(); break;                
                case "MySQL":     pd = new PersonDAO_MySQL(); break;
                case "MSSQL":     pd = new PersonDAO_MSSQL(); break;
                case "H2":        pd = new PersonDAO_H2(); break;
                case "MongoDB":   pd = new PersonDAO_MongoDB(); break;
                case "Redis":     pd = new PersonDAO_Redis(); break;
                case "Cassandra": pd = new PersonDAO_Cassandra(); break;
                case "Neo4j":     pd = new PersonDAO_Neo4j(); break;                
                case "NH":        pd = new PersonDAO_NH(); break;
                case "XML":       pd = new PersonDAO_XML(); break;
                case "JSON":      pd = new PersonDAO_JSON(); break;
                case "CSV":       pd = new PersonDAO_CSV(); break;
                case "Yaml":      pd = new PersonDAO_Yaml(); break;
                case "XMLAuto":   pd = new PersonDAO_XMLAuto(); break;
                case "JSONAuto":  pd = new PersonDAO_JSONAuto(); break;
                case "CSVAuto":   pd = new PersonDAO_CSVAuto(); break;
                case "YamlAuto":  pd = new PersonDAO_YamlAuto(); break;
                case "Entity":    pd = new PersonDAO_Entity(); break;
            }

            return pd;
        }
    }
}
