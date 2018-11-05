using Bb.Compilers.Pocos;
using Bb.ComponentModel.Attributes;
using Bb.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Black.Beard.Compilers.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCompile()
        {

            var path = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetTempFileName()));

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            PocoModelRepository repository = new PocoModelRepository("test1");

            repository.Add(new PocoModel()
            {
                Name = "t1",
                BaseName = null,
                Description = "model test",
                Interfaces = new PocoInterfaces() { "ISourceEvent" },
                Attributes = new PocoModelAttributes()
                {
                    new PocoModelAttribute("ExposeIncomingMessage",
                        new PocoModelAttributeArgument() { Value = "myDomain", IsString = true },
                        new PocoModelAttributeArgument() { Value = "myVersion", IsString = true },
                        new PocoModelAttributeArgument() { Value = "myKey", IsString = true }
                    )
                },
                Properties = new PocoProperties()
                {
                    new PocoProperty() { Name = "Key",          Type = "System.String",     Description = "The key that must matching with config event key", IsArray = false },
                    new PocoProperty() { Name = "Id",           Type = "System.String",     Description = "External id of the object embedded in the message", IsArray = false },
                    new PocoProperty() { Name = "Uid",          Type = "System.Guid",       Description = "unique identity event", IsArray = false },
                    new PocoProperty() { Name = "PostDate",     Type = "System.DateTime",   Description = "Gets the date of the post.", IsArray = false },
                    new PocoProperty() { Name = "EventDate",    Type = "System.DateTime",   Description = "Date of the event", IsArray = false },
                }
            });

            repository.AddUsings(
                typeof(ISourceEvent),
                typeof(ExposeIncomingMessage)
                );

            var result = repository.Generate(path);


            var ass = result.Load();

            var type = ass.DefinedTypes.FirstOrDefault();

            dynamic instance = Activator.CreateInstance(type) as ISourceEvent;

            instance.Id = "test";



        }
    }
}


