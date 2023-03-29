using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed
{
    internal interface IBrowser
    {
        void ClearSearchHistory();
        public void ChangeDefaultBrowserTo(ISearchEngine searchEngine);
        void Search(string query);
    }
}
