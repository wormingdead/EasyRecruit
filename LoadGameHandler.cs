using XRL; // for HasCallAfterGameLoadedAttribute and CallAfterGameLoadedAttribute
using XRL.Core; // for XRLCore
using XRL.World; // for GameObject


[HasCallAfterGameLoadedAttribute]
public class Wormingdead_EasyRecruitingMod_LoadGameHandler
{
  [CallAfterGameLoadedAttribute]
  public static void MyLoadGameCallback()
  {
    GameObject player = XRLCore.Core?.Game?.Player?.Body;
    if (player != null)
    {
      // RequirePart will add the part only if the player doesn't already have it.
      // This ensures your part only gets added once, even after multiple save loads.
      player.RequirePart<XRL.World.Parts.Wormingdead_EasyRecruitingMod_PlayerPart>();
    }
  }
}