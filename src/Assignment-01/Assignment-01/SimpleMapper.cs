using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;
using System.Reflection.Metadata;

namespace Assignment1
{
    public static class SimpleMapper
    {
        public static void CopyObject<T,Q>(T source, Q destination)
        {
            var sourceType = source?.GetType();
            var destinationType = destination?.GetType();
            
            var sourceProperties = sourceType?.GetProperties(BindingFlag());

            if (sourceProperties != null)
            {
                foreach (var property in sourceProperties)
                {
                    var destinationProperties = destinationType?.GetProperty(property.Name, BindingFlag());
                    if (destinationProperties is not null && property.PropertyType == destinationProperties.PropertyType 
                        && destinationProperties.CanWrite)
                    {
                        if (property.PropertyType.GetInterfaces().Contains(typeof(IList)))
                        {
                            var items = property.GetValue(source) as IList;

                            if (items != null)
                            {
                                object? destPropertyInstance = new();
                                if (destinationProperties.PropertyType.IsArray)
                                {
                                    Type? arrayType = destinationProperties.PropertyType.GetElementType();
                                    destPropertyInstance = Array.CreateInstance(arrayType!, items.Count);
                                }
                                else
                                {
                                    ConstructorInfo? constructorInfo = destinationProperties.PropertyType.GetConstructors().FirstOrDefault();
                                    if (constructorInfo != null)
                                        destPropertyInstance = GetPropertyInstance(constructorInfo!);
                                }

                                for(int i = 0; i < items.Count; i++)
                                {
                                    if (items[i]!.GetType().IsPrimitive || items[i]!.GetType() == typeof(string))
                                    {
                                        AddValueToInstance(destPropertyInstance, items[i], i);
                                    }
                                    else
                                    {
                                        ConstructorInfo? constructorInfo = items[i]!.GetType().GetConstructors().FirstOrDefault();
                                        if(constructorInfo != null)
                                        {
                                            var obj = GetPropertyInstance(constructorInfo!);
                                            CopyObject(items[i], obj);
                                            AddValueToInstance(destPropertyInstance, obj, i);
                                        }
                                    }
                                }

                                destinationProperties.SetValue(destination, destPropertyInstance);
                            }
                        }
                        else
                        {
                            var sourcePropertyValue = property.GetValue(source);

                            if (sourcePropertyValue != null)
                            {
                                var constructorInfo = property.PropertyType.GetConstructors().FirstOrDefault();
                                if (!property.PropertyType.IsPrimitive && constructorInfo != null && property.PropertyType != typeof(string))
                                {
                                    var destPropertyInstance = GetPropertyInstance(constructorInfo);

                                    CopyObject(sourcePropertyValue, destPropertyInstance);
                                    destinationProperties.SetValue(destination, destPropertyInstance);
                                }
                                else
                                    destinationProperties.SetValue(destination, sourcePropertyValue);
                            } 
                        }
                    }
                }
            }
        }

        private static BindingFlags BindingFlag() =>
             BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        private static void AddValueToInstance<T, Q>(T instance, Q value, int index = 0)
        {
            Type instanceType = instance!.GetType();

            if(instanceType.IsArray)
            {
                (instance as object as Array)!.SetValue(value, index);
            }
            else
            {
                var addMethod = instanceType.GetMethod("Add");

                if (addMethod != null)
                {
                    addMethod.Invoke(instance, new object[] { value! });
                }
            }
        }

        private static object GetPropertyInstance(ConstructorInfo constructorInfo)
        {
            
            List<object> paramsDefaultValue = new List<object>();

            foreach (var paramInfo in constructorInfo!.GetParameters())
            {
                if (paramInfo.ParameterType.IsValueType)
                {
                    object? defaultValue = Activator.CreateInstance(paramInfo.ParameterType);
                    paramsDefaultValue.Add(defaultValue!);
                }
                else
                {
                    paramsDefaultValue.Add(null!);
                }
            }
            return constructorInfo.Invoke(paramsDefaultValue.ToArray());
        }
    }
}
