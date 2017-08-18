using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ItemCommand : AbstractCommand
{
    public ItemCommand(List<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.AddItemToHero(Arguments);
    }
}