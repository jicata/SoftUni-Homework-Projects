﻿namespace PhotoShare.Client.Core.Commands
{
    using Data;
    using Interfaces;
    using Attributes;

    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public abstract string Execute();
    }
}
