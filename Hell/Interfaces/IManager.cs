using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IManager
{
    string Quit(List<string> argsList);

    string Inspect(List<string> argsList);

    string AddHero(List<string> argsList);

    string AddItemToHero(List<string> argsList);

    string AddRecipeToHero(List<string> argsList);
}