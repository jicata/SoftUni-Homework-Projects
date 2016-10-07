using System;
using System.Collections.Generic;
using System.Linq;
using Blobs.Interfaces;
using Blobs.Models;


namespace Blobs.Engine
{
    public class CommandExecutor : ICommandExecutor
    {
        public CommandExecutor(IEngine engine)
        {
            this.Engine = engine;
        }
        public IEngine Engine { get; }
        public void ExecuteCommand(string command)
        {
            string[] commandArgs = command.Split();
            switch (commandArgs[0])
            {
                
                case "create":
                    ExecuteCreateCommand(commandArgs.Skip(1).ToArray());
                    break;
                case "attack":
                    ExecuteAttackCommand(commandArgs.Skip(1).ToArray());
                    break;
                case "pass":
                    break;
                case "status":
                    ExecuteStatusCommand();
                    break;
                case "drop":
                    Environment.Exit(0);
                    break;
                case "report-events":
                    break;
                default:throw new ArgumentException("Command not recognized");

            }
        }

        private void ExecuteStatusCommand()
        {
            foreach (IBlob blob in this.Engine.Blobs)
            {
                this.Engine.Writer.Write(blob.ToString());
            }
        }

        private void ExecuteAttackCommand(string[] commandArgs)
        {
            string attackerName = commandArgs[0];
            string defenderName = commandArgs[1];

            IBlob attackingBlob = this.Engine.Blobs.FirstOrDefault(b => b.Name == attackerName);
            if (attackingBlob == null)
            {
                throw new KeyNotFoundException(String.Format(@"Blob {0} not present in the game, add it with the ""create"" command and try again", attackerName));
            }
            IBlob defendingBlob = this.Engine.Blobs.FirstOrDefault(b => b.Name == defenderName);
            if (defendingBlob == null)
            {
                throw new KeyNotFoundException(String.Format(@"Blob {0} not present in the game, add it with the ""create"" command and try again", defenderName));
            }
            if (attackingBlob.Health <= 0 || defendingBlob.Health <= 0)
            {
                throw new InvalidOperationException("Dead blobs cannot attack or be attacked");
            }
            this.Engine.CombatHandler.PerformAttack(attackingBlob, defendingBlob);
            

        }

        private void ExecuteCreateCommand(string[] commandArgs)
        {
            
            string BlobName = commandArgs[0];
            int BlobHealth = int.Parse(commandArgs[1]);
            int BlobDamage = int.Parse(commandArgs[2]);
            string behaviourName = commandArgs[3];
            string attackName = commandArgs[4];

            var BlobBehaviour = this.Engine.BehaviourFactory.CreateBehaviour(behaviourName);
            var BlobAttack = this.Engine.AttackFactory.ManufactureAttack(attackName);

            this.Engine.Blobs.Add(this.Engine.BlobFactory.CreateBlob(BlobName, BlobHealth, BlobDamage,BlobBehaviour, BlobAttack));

        }
    }
}
