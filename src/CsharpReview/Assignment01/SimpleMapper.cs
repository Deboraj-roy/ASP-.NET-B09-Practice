using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01
{
    public class SimpleMapper
    {
        public void Copy(object source, object destination)
        {
            if (source == null || destination == null) return;

            var sourceType = source.GetType();
            var destinationType = destination.GetType();

            // Check if the types are the same
            if (sourceType != destinationType)
            {
                throw new ArgumentException("Source and destination types must be the same.");
            }

            // Get all properties of the source type
            var properties = sourceType.GetProperties();

            foreach (var property in properties)
            {
                // Check if the property is a simple type or a complex type
                if (IsSimple(property.PropertyType))
                {
                    var value = property.GetValue(source);
                    var destinationProperty = destinationType.GetProperty(property.Name);
                    if (destinationProperty != null)
                    {
                        destinationProperty.SetValue(destination, value);
                    }
                }
                else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    var sourceList = (IEnumerable)property.GetValue(source);
                    var destinationList = (IList)Activator.CreateInstance(property.PropertyType);

                    if (sourceList != null)
                    {
                        foreach (var item in sourceList)
                        {
                            var itemType = item.GetType();
                            var destinationItem = Activator.CreateInstance(itemType);
                            Copy(item, destinationItem);
                            destinationList.Add(destinationItem);
                        }

                        var destinationProperty = destinationType.GetProperty(property.Name);
                        if (destinationProperty != null)
                        {
                            destinationProperty.SetValue(destination, destinationList);
                        }
                    }
                }
                else
                {
                    var sourceValue = property.GetValue(source);
                    var destinationValue = property.GetValue(destination) ?? Activator.CreateInstance(property.PropertyType);
                    Copy(sourceValue, destinationValue);
                    property.SetValue(destination, destinationValue);
                }
            }
        }

        private bool IsSimple(Type type)
        {
            return type.IsPrimitive || type.IsValueType || type == typeof(string);
        }
    }
}
