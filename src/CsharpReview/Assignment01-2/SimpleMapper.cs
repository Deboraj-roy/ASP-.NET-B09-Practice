using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01_2
{
    public class SimpleMapper
    {
        public void Copy(object source, object destination)
        {
            var sourceProps = source.GetType().GetProperties();
            var destProps = destination.GetType().GetProperties();

            foreach (var sourceProp in sourceProps)
            {
                foreach (var destProp in destProps)
                {
                    if (sourceProp.Name == destProp.Name && sourceProp.PropertyType == destProp.PropertyType)
                    {
                        if (sourceProp.PropertyType.IsArray)
                        {
                            var sourceArray = (Array)sourceProp.GetValue(source);
                            var destArray = Array.CreateInstance(destProp.PropertyType.GetElementType(), sourceArray.Length);

                            for (int i = 0; i < sourceArray.Length; i++)
                            {
                                var newObj = Activator.CreateInstance(destProp.PropertyType.GetElementType());
                                Copy(sourceArray.GetValue(i), newObj);
                                destArray.SetValue(newObj, i);
                            }

                            destProp.SetValue(destination, destArray);
                        }
                        else
                        {
                            destProp.SetValue(destination, sourceProp.GetValue(source));
                        }
                        break;
                    }
                }
            }
        }
    }
}
