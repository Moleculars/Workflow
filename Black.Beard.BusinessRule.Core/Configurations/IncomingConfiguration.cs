using Bb.BusinessRule.Models.Incomings;
using Bb.Compilers.Pocos;
using Bb.Core;
using Bb.Workflow.Configurations.IncomingMessages;
using Newtonsoft.Json;
using System.Text;

namespace Bb.BusinessRule.Configurations
{

    public static class IncomingConfiguration
    {

        /// <summary>
        /// Deserializes the payload in  <see cref="Models.Incomings.IncomingConfigurationModel"/>.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns></returns>
        public static IncomingConfigModel DeserializeIncomingConfigModel(this StringBuilder sb)
        {

            return JsonConvert.DeserializeObject<IncomingConfigModel>(sb.ToString());

        }

        public static void Convert(this IncomingConfigModel model, PocoModelRepository repository, string domain, string version)
        {


            var mdl1 = new PocoModel()
            {
                Name = model.Key,
                BaseName = "",
                Description = model.Description,
                Interfaces = new PocoInterfaces() { "ISourceEvent" },
                Attributes = new PocoModelAttributes()
                {
                    new PocoModelAttribute()
                    {
                        Name = "ExposeIncomingMessage",
                        Arguments = new PocoModelAttributeArguments()
                        {
                            new PocoModelAttributeArgument() { Value = domain, IsString = true },
                            new PocoModelAttributeArgument() { Value = version, IsString = true },
                            new PocoModelAttributeArgument() { Value = model.Key, IsString = true }
                        }
                    }
                },
                Properties = new PocoProperties()
                {
                    new PocoProperty() { Name = "Key",       Type = "System.String",    Description = "The key that must matching with config event key",   IsArray = false },
                    new PocoProperty() { Name = "Id",        Type = "System.String",    Description = "External id of the object embedded in the message",  IsArray = false },
                    new PocoProperty() { Name = "Uid",       Type = "System.Guid",      Description = "unique identity event",                              IsArray = false },
                    new PocoProperty() { Name = "PostDate",  Type = "System.DateTime",  Description = "Gets the date of the post.",                         IsArray = false },
                    new PocoProperty() { Name = "EventDate", Type = "System.DateTime",  Description = "Date of the event",                                  IsArray = false },
                    new PocoProperty() { Name = "Datas",     Type = model.ModelName,    Description = "The key that must matching with config event key",   IsArray = false },
                }
            };

            repository.Add(mdl1);

            foreach (var item in model.Models)
            {

                var mdl = new PocoModel()
                {
                    Name = item.Name,
                    Description = item.Description,
                };

                foreach (var property in item.Properties)
                    mdl.Properties.Add(new PocoProperty() { Description = property.Description, IsArray = property.IsArray, Name = property.Name, Type = property.Type, });

                repository.Add(mdl);

            }

            repository.Usings.Add("Bb.Workflow.Models");
            repository.Usings.Add("Bb.ComponentModel.Attributes");

        }

        public static AssemblyResult Compile(this PocoModelRepository repository, string path)
        {
            
               var result = repository.Generate(new PocoCodeGenerator(
                    typeof(ISourceEvent).Assembly,
                    typeof(ComponentModel.Attributes.ExposeIncomingMessage).Assembly
                ), path);

            return result;

        }

    }


}
