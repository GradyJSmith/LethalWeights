using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine; 

namespace LethalWeights.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void LethalWeightsPatch(PlayerControllerB __instance)
        {
            // Only apply movement logic for the local player
            if (!__instance.IsOwner || !__instance.isPlayerControlled) return;

            //Set target upward float speed in meters per second
            float targetFloatSpeed = 3.0f;

            //Calculate mass in kg
            float weightInLbs = (__instance.carryWeight - 1.0f) * 105f;
            float massInKg = weightInLbs / 2.20462f;
            //Assuming base player weighs 70kg, this finds total mass
            float totalMass = 70f + massInKg;

            //Set fall value to zero
            __instance.fallValue = 0.15f;

            //Set vertical movement vector
            Vector3 verticalMove = Vector3.up * targetFloatSpeed;

            // Move the CharacterController smoothly upward
            __instance.thisController.Move(verticalMove * Time.deltaTime);
        }
    }
}