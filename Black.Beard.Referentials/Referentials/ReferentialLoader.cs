using Bb.ComponentModel.Accessors;
using Bb.ComponentModel.Factories;
using Bb.Sdk.Csv;
using System;
using System.IO;

namespace Bb.Referentiels
{

    internal static class ReferentialLoader
    {

        public static Referential Load(ConfigJson config)
        {

            var properties = AccessorItem.Get(config.Type, true);
            var factory = new FactoryProvider().CreateFrom<object>(config.Type);

            var _file = new FileInfo(config.Filename);

            var referential = new Referential() { Name = Path.GetFileNameWithoutExtension(_file.Name) };

            if (_file.Exists)
                using (var _streamReader = _file.OpenText())
                {
                    while (!_streamReader.EndOfStream)
                    {

                        var instance = factory.Create();
                        var row = new ReferentialRow(instance);
                        var line = _streamReader.ReadLine();
                        Newtonsoft.Json.JsonConvert.PopulateObject(line, instance);
                        referential.Add(row);

                    }

                }

            referential.Index(properties);
            return referential;

        }

        /// <summary>
        /// Loads the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        public static Referential Load(ConfigCsv config)
        {

            var properties = AccessorItem.Get(config.Type, true);
            var factory = new FactoryProvider().CreateFrom<object>(config.Type);

            var _file = new FileInfo(config.Filename);

            var referential = new Referential() { Name = Path.GetFileNameWithoutExtension(_file.Name) };

            if (_file.Exists)
                using (var _streamReader = _file.OpenText())
                using (System.Data.IDataReader csv = new CsvReader(_streamReader, config.HasHeaders, config.DelimiterChar, config.Quote, config.Escape, config.Comment, config.TrimmingOptions, (int)_file.Length))
                    while (csv.Read())
                    {

                        var instance = factory.Create();
                        var row = new ReferentialRow(instance);

                        for (int index = 0; index < csv.FieldCount; index++)
                        {
                            string name = csv.GetName(index);
                            var property = properties[name];
                            if (property == null)
                                throw new PropertyNotFoundException(name);

                            property.SetValue(instance, csv.GetString(index));

                        }

                        referential.Add(row);

                    }

            referential.Index(properties);
            return referential;

        }

    }
}
