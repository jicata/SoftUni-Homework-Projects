using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLib
{
    class peeras
    {
        private bool hasAIDS;
        private string name;

        public peeras(string name)
        {
            this.Name = name;
        }

        public peeras() 
            : this(null)
        {
            
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public bool HasAids
        {
            get { return this.hasAIDS; }
            private set
            {
                if (Name == null)
                {
                    hasAIDS = true;
                }
                else
                {
                    hasAIDS = false;
                }
            }
        }
    }
}
