﻿using System;

namespace ConsoleApp1
{
    public class OverfillException : Exception
    {
        public OverfillException(string message) : base(message) { }
    }
}