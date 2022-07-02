using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonValidator
{
    public class Validator
    {
        public static IList<string> Validate(JObject obj, string SchemaSource)
        {
            IList<string> ValidationErros = new List<string>();
            try
            {
                var schema = JSchema.Parse(SchemaSource);
                var isValid = obj.IsValid(schema, out ValidationErros);
            }
            catch (Exception exc)
            {
                ValidationErros.Add("Error in validation process");
            }

            return ValidationErros;
        }
    }
}