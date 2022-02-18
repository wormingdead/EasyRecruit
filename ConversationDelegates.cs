using System;
using System.Collections.Generic;
using System.Text;
using XRL;
using XRL.Core;
using XRL.Language;
using XRL.Rules;
using XRL.UI;
using XRL.World;
using XRL.World.Conversations;
using XRL.World.Effects;
using XRL.World.Parts;

namespace Mods.Wormingdead.EasyRecruit
{
  [HasConversationDelegate] // This is required on the surrounding class to reduce the search complexity.
  public static class DelegateContainer
  {
    // A predicate that receives a DelegateContext object with our values assigned, this to protect mods from signature breaks.
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
      Brain pBrain = The.Speaker.pBrain;
      pBrain.BecomeCompanionOf(The.Player);
      if (pBrain.GetFeeling(The.Player) < 0)
        pBrain.SetFeeling(The.Player, 0);
      if (The.Speaker.GetEffect("Lovesick") is Lovesick effect)
        effect.PreviousLeader = The.Player;
      Popup.Show(The.Speaker.T() + The.Speaker.GetVerb("join") + " you!");
    }
  }
}
