using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed
{
    public class Brave : IBrowser
    {
        public Brave(ISearchEngine searchEngine)
        {
            this.DefaultSearchEngine = searchEngine;
        }
        ISearchEngine DefaultSearchEngine;
        public void ClearSearchHistory()
        {
            Console.WriteLine("Arama geçmişiniz cihazınızdan kalıcı olarak silinmiştir.");
        }
        public void ChangeDefaultBrowserTo(ISearchEngine searchEngine)
        {
            this.DefaultSearchEngine = searchEngine;
        }
        public void Search(string query)
        {
            DefaultSearchEngine.Search(query);
        }
    }
}
