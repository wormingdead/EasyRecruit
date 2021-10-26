using System;
using System.Collections.Generic;
using System.Text;
using XRL.Core;
using XRL.Language;
using XRL.Rules;
using XRL.UI;
using XRL.World;


public class Wormingdead_EasyRecruit_RecruitChoice : XRL.World.ConversationChoice
{
  public GameObject Player => XRLCore.Core.Game.Player.Body;

  public override XRL.World.ConversationNode Goto(XRL.World.GameObject speaker, bool peekOnly = false, XRL.World.Conversation conversation = null)
  {
    Text = "{{O|Easy Recruit:}} Let us travel together.";
    GotoID = "End";

    return base.Goto(speaker, peekOnly, conversation);
  }

  public override bool Visit(XRL.World.GameObject speaker, XRL.World.GameObject player, out bool removeChoice, out bool terminateConversation)
  {
    removeChoice = false;
    terminateConversation = true;

    XRL.World.Parts.Brain pBrain = speaker.pBrain;
    pBrain.BecomeCompanionOf(this.Player);

    if (pBrain.GetFeeling(this.Player) < 0)
      pBrain.SetFeeling(this.Player, 5);

    XRL.UI.Popup.Show(speaker.DisplayName + speaker.GetVerb("join") + " you!");

    return base.Visit(speaker, player, out removeChoice, out terminateConversation);
  }
}