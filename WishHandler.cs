using System;
using System.Collections.Generic;
using System.Text;
using XRL;
using XRL.Core;
using XRL.Language;
using XRL.Rules;
using XRL.UI;
using XRL.World;

namespace Mods.Wormingdead.EasyRecruit
{
  [XRL.Wish.HasWishCommand]
  public class Wormingdead_EasyRecruit_WishHandler
  {
    public GameObject Player => XRLCore.Core.Game.Player.Body;
    private string globalName = "WormingdeadEasyRecruitActive";

    [XRL.Wish.WishCommand(Command = "EasyRecruit")]
    public void WishToggle()
    {
      if (The.Game.GetBooleanGameState(globalName))
        DisableMod();
      else
        EnableMod();
    }

    [XRL.Wish.WishCommand(Command = "EasyRecruit", Regex = @"(enable)|(up)|(true)|(yes)|(on)")]
    public void WishEnable()
    {
      EnableMod();
    }

    [XRL.Wish.WishCommand(Command = "EasyRecruit", Regex = @"(disable)|(down)|(false)|(no)|(off)")]
    public void WishDisable()
    {
      DisableMod();
    }

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
