using HarmonyLib;
using RimWorld;
using System.Reflection;
using UnityEngine;
using Verse;

namespace NameYourEntities
{
    [HarmonyPatch]
    public static class Rimhud_Compatibility
    {
        public static MethodInfo rimHudMethod = null;
        public static bool Prepare()
        {
            if (ModsConfig.IsActive("Jaxe.RimHUD"))
            {
                rimHudMethod = AccessTools.Method("RimHUD.Interface.Screen.InspectPaneButtons:Draw");
                if (rimHudMethod is null)
                {
                    Log.Error("[Name Your Entities] Failed to do RimHUD compat: no method found to pach");
                    return false;
                }
                return true;
            }
            return false;
        }

        public static MethodBase TargetMethod() => rimHudMethod;

        public static void Postfix(Rect bounds, IInspectPane pane, ref float offset)
        {
            if (Find.Selector.SingleSelectedThing is Pawn pawn && pawn.IsEntity && pawn.IsOnHoldingPlatform)
            {
                MainTabWindow_Inspect_DoInspectPaneButtons_Patch.DrawRenameButton(GetRowRect(bounds, ref offset, 28f, 28f), pawn);
            }
        }

        private static Rect GetRowRect(Rect bounds, ref float offset, float width = 24f, float height = 24f)
        {
            offset += width;
            Rect result = new Rect(bounds.xMax - offset, bounds.GetCenteredY(height), width, height);
            offset += 4f;
            return result;
        }

        public static float GetCenteredY(this Rect self, float height)
        {
            return self.y + (self.height - height).Half();
        }

        public static float Half(this float self)
        {
            return self / 2f;
        }
    }
}
