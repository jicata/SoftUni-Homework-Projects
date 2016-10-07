using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Items
{
    public abstract class Bonus : Item, ITimeoutable
    {
        private int timeOut;
        private int countDown;
        private bool hasTimedOut;

        public Bonus(string id, int healthEffect, int defenseEffect, int attackEffect, int timeOut)
            :base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Timeout = timeOut;
            this.Countdown = timeOut;
            this.HasTimedOut = false;
        }
        public virtual int Timeout
        {
            get { return this.timeOut; }
            set { value = timeOut; }
        }

        public virtual int Countdown {
            get { return this.countDown; }
            set { this.countDown = value; }
        }

        public virtual bool HasTimedOut 
        {
            get { return this.HasTimedOut; }
            set { hasTimedOut = value; }
            
        }
    }
}
