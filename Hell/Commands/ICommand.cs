using System.Collections.Generic;
using System.Security.Policy;

public interface ICommand
{
    string Execute();
    IManager Manager { get; }
    List<string> Arguments{ get; }
}