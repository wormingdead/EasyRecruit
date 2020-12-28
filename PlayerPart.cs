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
  public class Wormingdead_EasyRecruitingMod_PlayerPart : IPart
  {
    public Wormingdead_EasyRecruitingMod_PlayerPart()
    {
      this.Name = "Wormingdead_EasyRecruitingMod_PlayerPart";
    }

    public override bool AllowStaticRegistration() => true;
    public GameObject Player => XRLCore.Core.Game.Player.Body;

    public override void Register(XRL.World.GameObject obj)
    {
      obj.RegisterPartEvent((IPart)this, "PlayerBeginConversation");

      base.Register(obj);
    }

    public override bool FireEvent(XRL.World.Event E)
    {
      if (E.ID == "PlayerBeginConversation")
        this.HandleBeginConversation(E);

      return base.FireEvent(E);
    }

    public void HandleBeginConversation(XRL.World.Event E)
    {
      XRL.World.GameObject speaker = E.GetGameObjectParameter("Speaker");
      if (speaker == null
      || this.ParentObject.DistanceTo(speaker) > 1
      || speaker.pBrain.PartyLeader == Player
      || speaker.GetBlueprint().GetxTag("WaterRitual", "NoJoin") == "true")
        return;

      ConversationNode conversationNode = (E.GetParameter("Conversation") as Conversation).NodesByID["Start"];
      if (!conversationNode.bCloseable)
        return;

      var choice = new Wormingdead_EasyRecruitingMod_RecruitChoice();
      choice.Ordinal = 1111;

      conversationNode.Choices.Add(choice);
      conversationNode.SortEndChoicesToEnd();
    }
  }
}