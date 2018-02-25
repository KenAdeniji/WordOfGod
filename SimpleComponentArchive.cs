using System;
using System.Runtime.InteropServices;

namespace WordEngineering
{
 public interface ISimpleComponent
 {
  String GetGreeting();
 }

 /* [HasDefaultInterface()] */
 public class SimpleComponent : ISimpleComponent
 {
  public SimpleComponent() { }
  public string GetGreeting()
  {
   return "Hello from a .NET component!";
  }
 }
}