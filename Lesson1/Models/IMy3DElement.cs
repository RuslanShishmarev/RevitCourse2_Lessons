﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Models
{
    internal interface IMy3DElement : IMyElement
    {
        double GetVolume();

        double GetArea();
    }
}
