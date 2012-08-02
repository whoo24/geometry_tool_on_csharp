using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryTool
{
    public class Global
    {
        static Global instance = new Global();
        public static Global Instance
        {
            get { return instance; }
        }
    }
}
