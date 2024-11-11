using System;
using System.Collections.Generic;
using System.Reflection;

using XRL;
using XRL.UI;
using XRL.World.AI;
using XRL.World.Conversations;
using XRL.World.Effects;
using XRL.World.Parts;


namespace Mods.Wormingdead.EasyRecruit
{
  [HasConversationDelegate]
  public static class DelegateContainer
  {
    [ConversationDelegate(Speaker = true)]
    public static bool IfHavexTagWormingdeadEasyRecruit(DelegateContext Context)
    {
      string[] xTagKV = Context.Value.Split(',');
      string key = xTagKV[0];
      string val = xTagKV[1];

      return Context.Target.GetxTag(key, val) == "true";
    }

    [ConversationDelegate]
    public static void RecruitWormingdeadEasyRecruit(DelegateContext Context)
    {
      // Copied from WaterRitualJoinParty.cs (beta:Spring Molting)
      The.Speaker.SetAlliedLeader<AllyProselytize>(The.Player);
      Lovesick Effect;
      if (The.Speaker.TryGetEffect<Lovesick>(out Effect))
        Effect.PreviousLeader = The.Player;
      Popup.Show(The.Speaker.Does("join", Stripped: true) + " you!");
    }
  }
}
