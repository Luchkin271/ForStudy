﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForStady.Structures
{
    internal class MyGraphNode
    {
        public string Name { get; }
        public MyGraphNode(string name){
            Name = name;
        }
        public void Print()
        {
            Console.WriteLine(Name);
        }
    }
}
