﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo.Services
{
    public class CountService
    {
        private int _count;

        public int GetLatesCount()
        {
            return _count++;
        }
    }
}
