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
            if (source == null || destination == null)
            {
                return;
            }

            var sourceType = source.GetType();
            var destinationType = destination.GetType();

            // Iterate through all properties of the source object
            foreach (var sourceProperty in sourceType.GetProperties())
            {
                var propertyName = sourceProperty.Name;

                // Check if the destination object has a matching property
                var destinationProperty = destinationType.GetProperty(propertyName);
                if (destinationProperty == null)
                {
                    continue;
                }

                // Check if the property types are the same
                if (sourceProperty.PropertyType == destinationProperty.PropertyType)
                {
                    // Get the value from the source property
                    var sourceValue = sourceProperty.GetValue(source);

                    // Copy the value to the destination property
                    destinationProperty.SetValue(destination, sourceValue);
                }
                else
                {
                    // Property types are not the same, check for nested objects or lists
                    if (IsNestedObject(sourceProperty.PropertyType) && IsNestedObject(destinationProperty.PropertyType))
                    {
                        var sourceNestedObject = sourceProperty.GetValue(source);
                        var destinationNestedObject = destinationProperty.GetValue(destination);

                        // Recursively copy nested objects
                        Copy(sourceNestedObject, destinationNestedObject);
                    }
                    else if (IsList(sourceProperty.PropertyType) && IsList(destinationProperty.PropertyType))
                    {
                        var sourceList = (IEnumerable)sourceProperty.GetValue(source);
                        var destinationList = (IList)Activator.CreateInstance(destinationProperty.PropertyType);

                        // Iterate through the list and copy each item
                        foreach (var sourceItem in sourceList)
                        {
                            var destinationItem = Activator.CreateInstance(destinationProperty.PropertyType.GenericTypeArguments[0]);
                            Copy(sourceItem, destinationItem);
                            destinationList.Add(destinationItem);
                        }

                        // Set the copied list to the destination property
                        destinationProperty.SetValue(destination, destinationList);
                    }
                }
            }
        }

        private bool IsNestedObject(Type type)
        {
            return type.IsClass && type != typeof(string);
        }

        private bool IsList(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }
    }
}
