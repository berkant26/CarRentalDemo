﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
   public  interface IResult
    {
         string Message { get; }
         bool Success { get;}
    }
}
