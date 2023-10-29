using XRL;
using XRL.Core;
using XRL.UI;
using XRL.Wish;
using XRL.World;


namespace Mods.Wormingdead.EasyRecruit
{
  [HasWishCommand]
  public class Wormingdead_EasyRecruit_WishHandler
  {
    public GameObject Player => XRLCore.Core.Game.Player.Body;
    private static string globalName = "WormingdeadEasyRecruitActive";

    [WishCommand(Command = "EasyRecruit")]
    public static bool WishToggle()
    {
      if (The.Game.GetBooleanGameState(globalName))
      { DisableMod(); }
      else
      { EnableMod(); }

      return true;
    }

    [WishCommand(Regex = @"EasyRecruit(:| )((enable)|(up)|(true)|(yes)|(on)|(1))")]
    public static bool WishEnable()
    {
      EnableMod();

      return true;
    }

    [WishCommand(Regex = @"EasyRecruit(:| )((disable)|(down)|(false)|(no)|(off)|(0))")]
    public static bool WishDisable()
    {
      DisableMod();

      return true;
    }

    public static void EnableMod()
    {
      The.Game.SetBooleanGameState(globalName, true);

      Popup.Show("Easy Recruit {{Y|enabled}}.");
    }

    public static void DisableMod()
    {
      The.Game.RemoveBooleanGameState(globalName);

      Popup.Show("Easy Recruit {{Y|disabled}}.");
    }
  }
}
