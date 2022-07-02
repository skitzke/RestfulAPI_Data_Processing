using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonValidator
{
    public class Validator
    {
        public static IList<string> Validate(JObject obj, string SchemaSource)
        {
            IList<string> ValidationErros = new List<string>();
            try
            {

                JSchema schema = JSchema.Parse(SchemaSource);
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
