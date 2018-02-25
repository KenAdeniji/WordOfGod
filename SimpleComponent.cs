using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyKeyFile("WordEngineering.snk")]
namespace WordEngineering
{
 public interface ISimpleComponent
 {
  String GetGreeting();
 }

 [HasDefaultInterface()]
 public class SimpleComponent : ISimpleComponent
 {
  public SimpleComponent() { }
  public string GetGreeting()
  {
   return "Hello from a .NET component!";
  }
 }
}