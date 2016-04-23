using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlServerDataAdapter
{
    public class Config_SqlServerDataFactory
    {
        private static int _CommandTimeout = 60;
        public static int CommandTimeout
        {
            get
            {
                return _CommandTimeout;
            }
            set
            {
                _CommandTimeout = value;
            }
        }

    }
}
