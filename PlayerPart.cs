using System;
using System.Collections.Generic;
using System.Text;
using XRL.Core;
using XRL.Language;
using XRL.Rules;
using XRL.UI;


namespace XRL.World.Parts
{
  [Serializable]
  public class Wormingdead_EasyRecruit_PlayerPart : IPart
  {
    public Wormingdead_EasyRecruit_PlayerPart()
    {
      //this.Name = "Wormingdead_EasyRecruit_PlayerPart";
    }

    public override bool AllowStaticRegistration() => true;
    public GameObject Player => XRLCore.Core.Game.Player.Body;

    public override bool WantEvent(int ID, int cascade)
    => base.WantEvent(ID, cascade) || ID == BeginConversationEvent.ID;

    public override bool HandleEvent(BeginConversationEvent E) {
      XRL.World.GameObject speaker = E.Actor;
      XRL.World.GameObject listener = E.SpeakingWith;

      if (speaker == null
      || !speaker.IsPlayer()
      || listener == null
      || this.ParentObject.DistanceTo(listener) > 1
      || listener.pBrain.PartyLeader == Player
      || listener.GetBlueprint().GetxTag("WaterRitual", "NoJoin") == "true")
        return true;

      ConversationNode conversationNode = E.Conversation.NodesByID["Start"];
      if (!conversationNode.bCloseable)
        return true;

      var choice = new Wormingdead_EasyRecruit_RecruitChoice();
      choice.Ordinal = 1111;

      conversationNode.Choices.Add(choice);
      conversationNode.SortEndChoicesToEnd();

      return true;
    }
  }
}