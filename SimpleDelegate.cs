namespace WordEngineering
{
 public class SimpleDelegate
 {
  delegate void DelegateSignature();
  public static void Main() {
   DelegateSignature delegateSignature = new DelegateSignature(DelegateFunction);
   delegateSignature();
  }
  public static void DelegateFunction() {
   System.Console.WriteLine("DelegateFunction()");
  }
 }
}