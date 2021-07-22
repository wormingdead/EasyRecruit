using System;
using System.Collections.Generic;
using System.Text;
using XRL.Core;
using XRL.Language;
using XRL.Rules;
using XRL.UI;
using XRL.World;


[XRL.Wish.HasWishCommand]
public class Wormingdead_EasyRecruit_WishHandler
{
  public GameObject Player => XRLCore.Core.Game.Player.Body;

  [XRL.Wish.WishCommand(Command = "EasyRecruit")]
  public void WishToggle()
  {
    if (Player.HasPart("Wormingdead_EasyRecruit_PlayerPart"))
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
    Player.RequirePart<XRL.World.Parts.Wormingdead_EasyRecruit_PlayerPart>();

    Popup.Show("Easy Recruit {{Y|enabled}}. Remember to disable the mod before unloading it to restore base game save compatibility.");

  }

  public void DisableMod()
  {
    Player.RemovePart<XRL.World.Parts.Wormingdead_EasyRecruit_PlayerPart>();

    Popup.Show("Easy Recruit {{Y|disabled}}. It is now safe to unload the Easy Recruit Mod.");
  }
}