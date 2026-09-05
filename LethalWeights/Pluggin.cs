using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using LethalWeights.Patches;

namespace LethalWeights
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class LethalWeightsBase : BaseUnityPlugin 
    {
        private const string modGUID = "GStar.LethalWeights";
        private const string modName = "LethalWeights";
        private const string modVersion = "0.5.2";

        public static ConfigEntry<float> configBaseSpeed;

        private readonly Harmony harmony = new Harmony(modGUID);

        private static LethalWeightsBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("LethalWeights is running...");

            configBaseSpeed = Config.Bind("Base Speed",
                                                "Base float speed config",
                                                5f,
                                                "Changes the speed at which you fly upwards");

            harmony.PatchAll(typeof(LethalWeightsBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
            harmony.PatchAll(typeof(KickIfModNotInstalled));
        }
    }
}
