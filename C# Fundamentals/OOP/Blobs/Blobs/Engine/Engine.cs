using System;
using System.Collections.Generic;
using System.Linq;
using Blobs.Interfaces;

namespace Blobs.Engine
{
   public class Engine : IEngine
    {
       public Engine(IInputReader reader, IOutputWriter writer, IBlobFactory blobFactory, IBehaviourFactory behaviourFactory, IAttackFactory attackFactory, ICombatHandler combataHandler)
       {
           this.Reader = reader;
           this.Writer = writer;
           this.BlobFactory = blobFactory;
           this.BehaviourFactory = behaviourFactory;
           this.AttackFactory = attackFactory;
           this.CombatHandler = combataHandler;
           this.CommandExecutor = new CommandExecutor(this);
       }

       public ICombatHandler CombatHandler { get; }
       public IBlobFactory BlobFactory { get; }
       public IBehaviourFactory BehaviourFactory { get; }
       public IAttackFactory AttackFactory { get; }
       public IInputReader Reader { get; }
       public IOutputWriter Writer { get; }
       public ICommandExecutor CommandExecutor { get; }
       public ICollection<IBlob> Blobs { get; } = new List<IBlob>();

       public void Run()
       {
           while (true)
           {
               this.ResetUpdates(this.Blobs);
                
                string command = Reader.Read();
               try
               {
                    CommandExecutor.ExecuteCommand(command);
                }
               catch (Exception e)
               {
                    
                   this.Writer.Write(e.Message);
               }
                
                this.UpdateBlobs(this.Blobs);


            }
       }

       public void UpdateBlobs(ICollection<IBlob> blobs)
       {
            foreach (IBlob blob in Blobs.Where(b => !b.IsUpdated))
            {
                blob.UpdateBehaviour();
                if (blob.CurrentHealth <= 0)
                {
                    Writer.Write(String.Format("Blob {0} was killed", blob.Name));
                }
            }
       }

       public void ResetUpdates(ICollection<IBlob> blobs)
       {
            foreach (IBlob blob in Blobs)
            {
                blob.IsUpdated = false;
            }
        }
    }
}
