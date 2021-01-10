using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace severnmt
{
    class json

    {
        public int id { get; set; }
        public string NameFile { get; set; }
        public string Type { get; set; }

    }
    class commandjson

    {

        public int numbcommdan { get; set; }
        public List<string> array { get; set; }

    }
    partial class Save_paramter {

      

       public string namefollder { get; set; }
    
    public int port { get; set; }

        public bool Tow_Directory { get; set; }
        public bool Refresh { get; set; }
        public bool GallryAtudo { get; set; }
    }
}
