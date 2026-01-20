using BepInEx;
using HarmonyLib;
using System.Linq;
using UnityEngine;

namespace SprintAndThrow
{
    // TODO - adjust the plugin guid as needed
    [BepInAutoPlugin(id: "io.github.al3ks1s.sprintandthrow")]
    public partial class SprintAndThrowPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Put your initialization logic here
            Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");

            Harmony.CreateAndPatchAll( typeof( SprintAndThrowPlugin ) );
            
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(PlayMakerFSM), "Start")]
        private static void ModifyHornetSprintToolThrow(PlayMakerFSM __instance)
        {
            if (__instance.name == "Hero_Hornet(Clone)" && __instance.FsmName == "Sprint")
            {
                __instance.FsmVariables.BoolVariables.First(var => var.Name == "Can Throw Tool").Value = true;
            }
        }
    }
}
