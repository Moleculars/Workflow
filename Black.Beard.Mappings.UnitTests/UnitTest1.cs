using Bb.Mappings.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

    }





    internal class SourceModel1
    {

        public string PropertySource { get; set; }

    }

    internal class SourceModel2
    {

        public SourceModel1 PropertySource { get; set; }

    }

    internal class TargetModel1
    {
        public string PropertyTarget { get; set; }

    }

    internal class TargetModel2
    {
        public TargetModel1 PropertyTarget { get; set; }

    }

}
