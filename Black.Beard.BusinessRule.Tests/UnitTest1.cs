using Bb.BusinessRule.Configurations;
using Bb.BusinessRule.Core.Configurations;
using Bb.BusinessRule.Models;
using Bb.BusinessRule.Parser;
using Bb.BusinessRule.Parser.Grammar;
using Bb.Compilers.Models;
using Bb.Compilers.Pocos;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bb.BusinessRule.Tests
{

    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethodTranslateIncomingModelInPoco()
        {

            var txt = new StringBuilder(@"
{
	""Key"" : ""event_key"",
	""Description"" : ""my description on incoming event"",
	""ModelName"" : ""model_name"",
	""Models"" : [
		{
			""Name"" : ""model_name"",
			""Description"" : ""my description on model"",
			""Properties"" : [
					{ 
						""Name"" : ""property1"",          
						""Type"" : ""System.String"",     
						""Description"" : ""Description of the property"", 
						""IsArray"" : false 
					},					
				]
		}
	]
}");
            var rep = new PocoModelRepository("t1");
            CompilerModelRoot.Load(txt)
                .Append(rep, "myDomain", "myVersion");

            var path = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetTempFileName()));

            var resultAssembly = rep.Generate(path);

            var ass = resultAssembly.LoadAssembly();

            var type = ass.DefinedTypes.FirstOrDefault();

            dynamic instance = Activator.CreateInstance(type);

            instance.Id = "test";

            Assert.AreEqual(instance.Id, "test");

        }

        [TestMethod]
        public void TestMethod1()
        {

            string rules = @"

    NAME test

    WHEN !lifecycle_in(50) && InAnomalie('Reception')
      RETURN DROP 'ANOMALIE' 'Reception'
";

            TypeReferential typeReferential = new TypeReferential();

            // Parse rule and build config
            var _converterVisitor = new ConfigConverterRuleBusinessVisitor();
            var parser = BusinessRuleConfigParser.ParseString(new System.Text.StringBuilder(rules), "test");
            var BusinessRuleConfig = (RuleRepository)parser.Visit(_converterVisitor);

            // Match config with method found in assemblies and build rules
            var visitor = new BuildBusinessRuleVisitor<Context>(typeReferential);
            LambdaExpression lambdaExpression = (LambdaExpression)BusinessRuleConfig.Accept(visitor);
            var methodCompiled = lambdaExpression.Compile() as Action<Context, List<ResultModel>>;

            // Test
            var c = new Context();
            var l = new List<ResultModel>();
            methodCompiled(c, l);

        }

    }

    [ExposeClass]
    public class Test1
    {

        [RegisterMethod("lifecycle_in")]
        public static bool EvaluateParcelLifeCycle(Context context, int currentStep)
        {

            return false;

        }

        [RegisterMethod("InAnomalie")]
        public static bool EvaluateInParcelAnomalie(Context context, string currentAnomalie)
        {

            return true;

        }


    }

    public class Context
    {

    }



}
