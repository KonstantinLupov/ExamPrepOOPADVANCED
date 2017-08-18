using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class RecipeCommand : AbstractCommand
    {
        public RecipeCommand(List<string> args, IManager manager) : base(args, manager)
        {
        }

        public override string Execute()
        {
            return this.Manager.AddRecipeToHero(Arguments);
        }
    }

