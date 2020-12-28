using System;
using System.Collections.Generic;
using System.Text;
using XRL.Core;
using XRL.Language;
using XRL.Rules;
using XRL.UI;
using XRL.World;


public class Wormingdead_EasyRecruitingMod_RecruitChoice : XRL.World.ConversationChoice
{
  public GameObject Player => XRLCore.Core.Game.Player.Body;

  public override XRL.World.ConversationNode Goto(XRL.World.GameObject speaker, bool peekOnly = false)
  {
    Text = "{{O|Easy Recruiting:}} Let us travel together.";
    GotoID = "End";

    return base.Goto(speaker, peekOnly);
  }

  public override bool Visit(XRL.World.GameObject speaker, XRL.World.GameObject player, out bool terminateConversation)
  {
    terminateConversation = true;

    XRL.World.Parts.Brain pBrain = speaker.pBrain;
    pBrain.BecomeCompanionOf(this.Player);

    if (pBrain.GetFeeling(this.Player) < 0)
      pBrain.SetFeeling(this.Player, 5);

    XRL.UI.Popup.Show(speaker.DisplayName + speaker.GetVerb("join") + " you!");

    return base.Visit(speaker, player, out terminateConversation);
  }
}