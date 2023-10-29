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
    private string globalName = "WormingdeadEasyRecruitActive";

    [WishCommand(Command = "EasyRecruit")]
    public void WishToggle()
    {
      if (The.Game.GetBooleanGameState(globalName))
        DisableMod();
      else
        EnableMod();
    }

    public void WishEnable() => EnableMod();
    [WishCommand(Regex = @"EasyRecruit(:| )((enable)|(up)|(true)|(yes)|(on)|(1))")]

    public void WishDisable() => DisableMod();
    [WishCommand(Regex = @"EasyRecruit(:| )((disable)|(down)|(false)|(no)|(off)|(0))")]

    public void EnableMod()
    {
      The.Game.SetBooleanGameState(globalName, true);

      Popup.Show("Easy Recruit {{Y|enabled}}.");
    }

    public void DisableMod()
    {
      The.Game.RemoveBooleanGameState(globalName);

      Popup.Show("Easy Recruit {{Y|disabled}}.");
    }
  }
}
