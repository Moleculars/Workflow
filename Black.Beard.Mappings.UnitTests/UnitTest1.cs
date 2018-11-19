using Bb.Compilers.Pocos;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.Mappings.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Black.Beard.Mappings.UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestCopy1()
        {

            TypeReferential typeReferential = new TypeReferential();
            var root = new MappingRepository(typeReferential);

            var model = new MappingConfiguration()
            {
                SourceType = "SourceModel1",
                TargetType = "TargetModel1",
                Mappings = new System.Collections.Generic.List<MappingItemConfiguration>()
                {
                    new MappingItemConfiguration()
                    {
                        SourcePath = new PropertyPath() { Name = "PropertySource" },
                        TargetPath = new PropertyPath() { Name = "PropertyTarget" },
                    }
                }
            };

            root.Append(model, "test", typeof(SourceModel1), typeof(TargetModel1));

            var src = new SourceModel1() { PropertySource = "Test" };

            var mapper = root.GetMapper(typeof(SourceModel1), typeof(TargetModel1));

            var target = (TargetModel1)mapper.Map(src, null);

            Assert.AreEqual(src.PropertySource, target.PropertyTarget);

        }

        [TestMethod]
        public void TestCopy2()
        {

            TypeReferential typeReferential = new TypeReferential();
            var root = new MappingRepository(typeReferential);

            var model = new MappingConfiguration()
            {

                SourceType = "SourceModel2",
                TargetType = "TargetModel1",
                Mappings = new System.Collections.Generic.List<MappingItemConfiguration>()
                {
                    new MappingItemConfiguration()
                    {
                        SourcePath = new PropertyPath() { Name = "PropertySource", Sub = new PropertyPath{ Name = "PropertySource" } },
                        TargetPath = new PropertyPath() { Name = "PropertyTarget" },
                    }
                }
            };

            root.Append(model, "test", typeof(SourceModel2), typeof(TargetModel1));

            var src = new SourceModel2() { PropertySource = new SourceModel1() { PropertySource = "Test" } };

            var mapper = root.GetMapper(typeof(SourceModel2), typeof(TargetModel1));

            var target = (TargetModel1)mapper.Map(src, null);

            Assert.AreEqual(src.PropertySource.PropertySource, target.PropertyTarget);

        }

        [TestMethod]
        public void TestCopy3()
        {

            TypeReferential typeReferential = new TypeReferential();
            var root = new MappingRepository(typeReferential);

            var model = new MappingConfiguration()
            {

                SourceType = "SourceModel2",
                TargetType = "TargetModel2",
                Mappings = new System.Collections.Generic.List<MappingItemConfiguration>()
                {
                    new MappingItemConfiguration()
                    {
                        SourcePath = new PropertyPath() { Name = "PropertySource", Sub = new PropertyPath{ Name = "PropertySource" } },
                        TargetPath = new PropertyPath() { Name = "PropertyTarget", Sub = new PropertyPath{ Name = "PropertyTarget" } },
                    }
                }
            };

            root.Append(model, "test", typeof(SourceModel2), typeof(TargetModel2));

            var src = new SourceModel2() { PropertySource = new SourceModel1() { PropertySource = "Test" } };

            var mapper = root.GetMapper(typeof(SourceModel2), typeof(TargetModel2));

            var target = (TargetModel2)mapper.Map(src, null);

            Assert.AreEqual(src.PropertySource.PropertySource, target.PropertyTarget.PropertyTarget);

        }

        [TestMethod]
        public void TestCopy4()
        {
            TypeReferential typeReferential = new TypeReferential();
            var root = new MappingRepository(typeReferential);

            var model = new MappingConfiguration()
            {

                SourceType = "SourceModel2",
                TargetType = "TargetModel1",
                Mappings = new System.Collections.Generic.List<MappingItemConfiguration>()
                {
                    new MappingItemConfiguration()
                    {
                        SourcePath = new PropertyPath() { Name = "PropertySource", Sub = new PropertyPath{ Name = "PropertySource" } },
                        TargetPath = new PropertyPath() { Name = "PropertyTarget", Sub = new PropertyPath{ Name = "PropertyTarget" } },
                    }
                }
            };

            root.Append(model, "test", typeof(SourceModel2), typeof(TargetModel1));

            var src = new SourceModel2() { PropertySource = new SourceModel1() { PropertySource = "Test" } };

            var mapper = root.GetMapper(typeof(SourceModel2), typeof(TargetModel1));

            var target = (TargetModel1)mapper.Map(src, null);

            Assert.AreEqual(src.PropertySource.PropertySource, target.PropertyTarget);

        }

        [TestMethod]
        public void TestCopy5()
        {

            TypeReferential typeReferential = new TypeReferential();
            var root = new MappingRepository(typeReferential);

            var model = new MappingConfiguration()
            {
                SourceType = "SourceModel2",
                TargetType = "TargetModel2",
                Mappings = new List<MappingItemConfiguration>()
                {
                    new MappingItemConfiguration()
                    {
                        SourcePath = new PropertyPath() { Name = "PropertySource" },
                        TargetPath = new PropertyPath() { Name = "PropertyTarget" },
                    }
                }
            };
            root.Append(model, "test2", typeof(SourceModel2), typeof(TargetModel2));

            model = new MappingConfiguration()
            {
                SourceType = "SourceModel1",
                TargetType = "TargetModel1",
                Mappings = new List<MappingItemConfiguration>()
                {
                    new MappingItemConfiguration()
                    {
                        SourcePath = new PropertyPath() { Name = "PropertySource" },
                        TargetPath = new PropertyPath() { Name = "PropertyTarget" },
                    }
                }
            };
            root.Append(model, "test1", typeof(SourceModel1), typeof(TargetModel1));

            var src = new SourceModel2() { PropertySource = new SourceModel1() { PropertySource = "Test" } };

            var mapper = root.GetMapper(typeof(SourceModel2), typeof(TargetModel2));

            var target = (TargetModel2)mapper.Map(src, null);

            Assert.AreEqual(src.PropertySource.PropertySource, target.PropertyTarget.PropertyTarget);

        }

        [TestMethod]
        public void TestCopy6()
        {

            TypeReferential typeReferential = new TypeReferential();
            var root = new MappingRepository(typeReferential);

            MappingConfiguration[] models = MappingRepository.InitializeAndCollectByName((typeof(SourceModel3), typeof(TargetModel3)));

            var map = models.First().Mappings.First();

            Assert.AreEqual(map.SourcePath.Name, "Name");
            Assert.AreEqual(map.TargetPath.Name, "Name");

        }

        [TestMethod]
        public void TestCopy7()
        {

            TypeReferential typeReferential = new TypeReferential();
            var root = new MappingRepository(typeReferential);

            MappingConfiguration[] models = MappingRepository.InitializeAndCollectByName((typeof(SourceModel4), typeof(TargetModel4)));

            root.Append(models);              // add cofiguration

            var modelSource = new SourceModel4() { Name = new TargetModel3() { Name = "Test2" } };
            var target = (TargetModel4)root.ChangeType(modelSource, typeof(TargetModel4));
            Assert.AreEqual(modelSource.Name.Name, target.Name.Name);

        }

        [TestMethod]
        public void TestCopy8()
        {

            TypeReferential typeReferential = new TypeReferential();
            var root = new MappingRepository(typeReferential);

            PocoModel sourceModel = new PocoModel()
            {
                Properties = new PocoProperties()
                {
                    new PocoProperty() { Name = "Name" , Type = "System.String"}
                }
            };
            PocoModel targetModel = new PocoModel()
            {
                Properties = new PocoProperties()
                {
                    new PocoProperty() { Name = "Name" , Type = "System.String"}
                }
            };

            MappingConfiguration[] models = root.InitializeAndCollectByName((sourceModel, targetModel));

            var mapping = models.First().Mappings.First();

            Assert.AreEqual(mapping.SourcePath.Name, "Name");
            Assert.AreEqual(mapping.SourcePath.Name, mapping.TargetPath.Name);

        }

        [TestMethod]
        public void TestCopy9()
        {

            TypeReferential typeReferential = new TypeReferential();
            var root = new MappingRepository(typeReferential);

            PocoModel sourceModel = new PocoModel()
            {
                Properties = new PocoProperties()
                {
                    new PocoProperty() { Name = "Name" , Type = "keySource"}
                }
            };
            PocoModel targetModel = new PocoModel()
            {
                Properties = new PocoProperties()
                {
                    new PocoProperty() { Name = "Name" , Type = "keyTarget"}
                }
            };

            MappingConfiguration[] models = root.InitializeAndCollectByName((sourceModel, targetModel));
            var model = models.First();

            //model.EventSourceName = "keySource";
            //model.TargetState = "keyTarget";

            root.ResolveTypes(model);

            model.SourceType = ConvertToString(typeof(SourceModel4));
            model.TargetType = ConvertToString(typeof(TargetModel4));

            root.Append(models);



            //Assert.AreEqual(mapping.SourcePath.Name, "Name");
            //Assert.AreEqual(mapping.SourcePath.Name, mapping.TargetPath.Name);

        }

        private string ConvertToString(Type type)
        {
            return $"{type.Assembly.GetName().Name}, {type.Namespace}.{type.Name}";
        }

    }





    public class SourceModel1
    {

        public string PropertySource { get; set; }

    }

    public class SourceModel2
    {

        public SourceModel1 PropertySource { get; set; }

    }

    public class TargetModel1
    {
        public string PropertyTarget { get; set; }

    }

    public class TargetModel2
    {
        public TargetModel1 PropertyTarget { get; set; }

    }

    [ExposeModel("myDomain", "myVersion", "keySource2", "incomingSource")]
    public class SourceModel3
    {

        public string Name { get; set; }

    }

    [ExposeModel("myDomain", "myVersion", "keyTarget2", "Event")]
    public class TargetModel3
    {

        public string Name { get; set; }

    }

    [ExposeModel("myDomain", "myVersion", "keySource", "incomingSource")]
    public class SourceModel4
    {

        public TargetModel3 Name { get; set; }

    }

    [ExposeModel("myDomain", "myVersion", "keyTarget", "Event")]
    public class TargetModel4
    {

        public TargetModel3 Name { get; set; }

    }

}
