using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


public class HeroCommand : AbstractCommand
    {
        public HeroCommand(List<string> args, IManager manager) : base(args, manager)
        {
        }

        public override string Execute()
        {
            return this.Manager.AddHero(Arguments);
        }
    }

