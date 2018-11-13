using Bb.ComponentModel;
using Bb.Mappings.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            var root = new MappingRepository();

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

            var root = new MappingRepository();

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

            var root = new MappingRepository();

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

            var root = new MappingRepository();

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

            var root = new MappingRepository();

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

            var root = new MappingRepository();

            MappingConfiguration[] models = MappingRepository.InitializeAndCollectByName((typeof(SourceModel3), typeof(TargetModel3)));

            var map = models.First().Mappings.First();

            Assert.AreEqual(map.SourcePath.Name, "Name");
            Assert.AreEqual(map.TargetPath.Name, "Name");

        }

        [TestMethod]
        public void TestCopy7()
        {

            MappingConfiguration[] models = MappingRepository.InitializeAndCollectByName((typeof(SourceModel4), typeof(TargetModel4)));

            var typeResolver = new TypeDiscovery();         // Type's repository
            var root = new MappingRepository();
            root.Append(typeResolver, models);

            var modelSource = new SourceModel4() { Name = new TargetModel3() { Name = "Test2" } };
            var target = (TargetModel4)root.ChangeType(modelSource, typeof(TargetModel4));
            Assert.AreEqual(modelSource.Name.Name, target.Name.Name);

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

    public class SourceModel3
    {

        public string Name { get; set; }

    }

    public class TargetModel3
    {

        public string Name { get; set; }

    }

    public class SourceModel4
    {

        public TargetModel3 Name { get; set; }

    }

    public class TargetModel4
    {

        public TargetModel3 Name { get; set; }

    }

}
