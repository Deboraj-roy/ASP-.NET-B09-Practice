﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.BMW
{
    public class BMWFactory : CarFactory
    {
        public override IEngine CreateEngine()
        {
            throw new NotImplementedException();
        }

        public override IHeadLight CreateHeadLight()
        {
            throw new NotImplementedException();
        }

        public override ITire CreateTire()
        {
            throw new NotImplementedException();
        }
    }
}
