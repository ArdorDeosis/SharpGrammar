﻿using System;
using SharpGrammar.API;

namespace DwarfNameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 200; i++)
            {
                Console.Write(DwarfNameGrammar.DwarfName.Process() + ", ");
            }
        }
    }
}