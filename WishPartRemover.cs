using System;
using System.Collections.Generic;
using System.Text;
using XRL.Core;
using XRL.Language;
using XRL.Rules;
using XRL.UI;
using XRL.World;


public class Wormingdead_EasyRecruitingMod_Wish
{
  public GameObject Player => XRLCore.Core.Game.Player.Body;

  [XRL.Wish.WishCommand(Command = "EasyRecruitingCleanUp")]
  public void Wormingdead_EasyRecruitingMod_WishAction()
  {
    Player.RemovePart<XRL.World.Parts.Wormingdead_EasyRecruitingMod_PlayerPart>();

    Popup.Show("Easy Recruiting has finished cleaning up. It is now safe to disable Easy Recruiting.");
  }
}