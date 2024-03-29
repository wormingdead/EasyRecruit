using XRL;
using XRL.Core;
using XRL.World;
using XRL.World.Parts;


namespace Mods.Wormingdead.EasyRecruit
{
  [HasCallAfterGameLoadedAttribute]
  public class MyLoadGameHandler
  {
    // Remove any leftover Player parts from legacy EasyRecruit (v0.9.0 or earlier)
    [CallAfterGameLoadedAttribute]
    public static void MyLoadGameCallback()
    {
      GameObject player = XRLCore.Core?.Game?.Player?.Body;
      if (player != null)
        player.RemovePart<Wormingdead_EasyRecruit_PlayerPart>();
    }
  }
}
