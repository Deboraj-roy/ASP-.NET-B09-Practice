using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public enum ShapeType
    {
        Rectangle,
        Circle,
        Triangle
    }

    public class DrawingTool
    {
        public void DrawShape(ShapeType shapeType, string color)
        {
            if (shapeType == ShapeType.Rectangle)
            {
                //Code  To Draw Shape
            }
            else if (shapeType == ShapeType.Circle)
            {
                //Code  To Draw Shape
            }
            else
            {
                //Code  To Draw Shape
            }
        }
    }
}
