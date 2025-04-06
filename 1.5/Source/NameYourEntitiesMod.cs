using HarmonyLib;
using Verse;

namespace NameYourEntities
{
    public class NameYourEntitiesMod : Mod
    {
        public NameYourEntitiesMod(ModContentPack pack) : base(pack)
        {
            new Harmony("NameYourEntitiesMod").PatchAll();
        }
    }
}
