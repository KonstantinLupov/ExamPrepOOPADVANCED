using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public abstract class AbstractCommand : ICommand
   {
       private IManager manager;
       private List<string> arguments;

       public abstract string Execute();

       public AbstractCommand(List<string> args, IManager manager)
       {
           this.Arguments = args;
           this.Manager = manager;
       }

        public IManager Manager { get { return this.manager; } set { this.manager = value; } }
       public List<string> Arguments { get { return this.arguments; } set { this.arguments = value; } }
   }
