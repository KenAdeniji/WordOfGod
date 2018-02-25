using System.Web.Security;

namespace WordEngineering
{
 public class ChangePassword
 {
  public static void Main(string[] argv)
  {
   MembershipUser user = Membership.GetUser(argv[0]);
   user.ChangePassword(user.GetPassword(), argv[1]);
  }
 }
}