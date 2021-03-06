﻿using Bb.Compilers;
using Bb.Compilers.Models;
using Bb.Compilers.Pocos;
using Bb.ComponentModel.Attributes;
using Bb.Core;

namespace Bb.BusinessRule.Configurations
{

    internal class IncomingCompilerVisitor : CompilerModelTranslatorVisitor
    {

        public IncomingCompilerVisitor(PocoModelRepository repository, string domain, string version)
            : base(repository)
        {
            _domain = domain;
            _version = version;
        }

        public override object Visit(CompilerModelRoot root)
        {

            root.BaseName = string.Empty;
            var result = (PocoModel)base.Visit(root);

            result.Interfaces.Add(nameof(ISourceEvent));

            result.Attributes.Add(
                new PocoModelAttribute("ExposeModel",
                    new PocoModelAttributeArgument() { Value = _domain, IsString = true },
                    new PocoModelAttributeArgument() { Value = _version, IsString = true },
                    new PocoModelAttributeArgument() { Value = root.Key, IsString = true },
                    new PocoModelAttributeArgument() { Value = "incomingSource", IsString = true }
            ));

            result.Properties.AddRange(
                new PocoProperty[]
                {

                    new PocoProperty() { Name = "Key",       Type = "System.String",            Description = "The key that must matching with config event key",   IsArray = false },
                    new PocoProperty() { Name = "Id",        Type = "System.String",            Description = "External id of the object embedded in the message",  IsArray = false },
                    new PocoProperty() { Name = "Uid",       Type = "System.Guid",              Description = "unique identity event",                              IsArray = false },
                    new PocoProperty() { Name = "PostDate",  Type = "System.DateTimeOffset",    Description = "Gets the date of the post.",                         IsArray = false },
                    new PocoProperty() { Name = "EventDate", Type = "System.DateTimeOffset",    Description = "Date of the event",                                  IsArray = false },
                }
             );


            base._repository.AddUsings(
                typeof(ISourceEvent),
                typeof(ExposeModel)
    );


            return result;

        }

        private readonly string _domain;
        private readonly string _version;

    }


}
