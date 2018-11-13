namespace Bb.Mappings.Models
{
    public class MappingConfigurationVerbatimItem
    {

        public MappedPropertyPath Source { get; internal set; }
        public MappedPropertyPath Target { get; internal set; }
        public MappingRepository Parent { get; internal set; }
        public MappingConfigurationVerbatim Mapper { get; internal set; }

        internal void Map(object source, object target)
        {

            if (source != null)
            {

                if (Mapper != null)
                {
                    if (source != null)
                    {
                        var valueSource = Source.Property.GetValue(source); // collect source value
                        if (valueSource != null)
                        {
                            var valueTarget = Target.Property.GetValue(target); // collect target value
                            bool setValue = valueTarget == null;
                            valueTarget = Mapper.Map(valueSource, valueTarget);
                            if (setValue)
                                Target.Property.SetValue(target, valueTarget);
                        }
                    }
                }
                else
                {

                    var s = Source;
                    object valueSource = source;

                    valueSource = s.Property.GetValue(source); // collect source value

                    var t = Target;
                    object valueTarget = target;

                    while (s.Sub != null) // source and target goes together for detect source null value
                    {

                        if (valueSource == null) // null before end of the path. out without copy
                            return;

                        if (t.Sub != null)
                        {

                            var valueTarget2 = t.Property.GetValue(valueTarget); // collect target value
                            if (valueTarget2 == null)
                                t.Property.SetValue(valueTarget, valueTarget2 = t.Create());

                            t = t.Sub;
                            valueTarget = valueTarget2;
                        }

                        s = s.Sub;
                        valueSource = s.Property.GetValue(valueSource); // collect source value

                    }

                    while (t.Sub != null)
                    {
                        var valueTarget2 = t.Property.GetValue(valueTarget); // collect target value
                        if (valueTarget2 == null)
                            t.Property.SetValue(valueTarget, valueTarget2 = t.Create());

                        t = t.Sub;
                        valueTarget = valueTarget2;
                    }

                    if (valueSource != null)
                        t.Property.SetValue(valueTarget, valueSource);

                }

            }

        }

    }


}

