using System;
using System.Collections.Generic;
using System.Text;

namespace FileAnalyzer
{
    class FileDiscovery
    {
        //FileDiscovery(strin)
        //{
        //    l_nome
        //}
        private String l_Nomefile;
        public string _Nomefile
        {
            get
            {
                return l_Nomefile;
            }
            set
            {
                l_Nomefile = value;
            }
        }

        public bool l_Lock { get; set; }
        
    }
}
