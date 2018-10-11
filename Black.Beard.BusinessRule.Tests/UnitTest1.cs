using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.BusinessRule.Core.Configurations;
using Bb.BusinessRule.Models;
using Bb.BusinessRule.Parser;
using Bb.BusinessRule.Parser.Grammar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.BusinessRule.Tests
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            string rules = @"

    NAME test

    WHEN !lifecycle_in(50) && InAnomalie('Reception')
      RETURN DROP 'ANOMALIE' 'Reception'
";

            // Parse rule and build config
            var _converterVisitor = new ConfigConverterRuleBusinessVisitor();
            var parser = BusinessRuleConfigParser.ParseString(new System.Text.StringBuilder(rules), "test");
            var BusinessRuleConfig = (RuleRepository)parser.Visit(_converterVisitor);

            // Match config with method found in assemblies and build rules
            var visitor = new BuildBusinessRuleVisitor<Context>();
            LambdaExpression lambdaExpression = (LambdaExpression)BusinessRuleConfig.Accept(visitor);
            var methodCompiled =  lambdaExpression.Compile() as Action<Context, List<ResultModel>>;

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
