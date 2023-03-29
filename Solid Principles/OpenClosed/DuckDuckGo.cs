﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed
{
    public class DuckDuckGo : ISearchEngine
    {
        public void Search(string query)
        {
            Console.WriteLine("DuckDuckGo");
            Console.WriteLine($"Sağlamış olduğunuz '{query}' query ile ilişkilendirilmiş sonuçlar aşağıda listelenmektedir.");
        }
    }
}
