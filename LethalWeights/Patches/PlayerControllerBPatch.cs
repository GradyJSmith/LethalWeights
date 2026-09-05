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
        [HarmonyPrefix]
        static void LethalWeightsPatch(PlayerControllerB __instance)
        {
            // Only apply movement logic for the local player
            if (!__instance.IsOwner || !__instance.isPlayerControlled) return;

            //Set bool to check if holding item
            bool isHoldingItem = __instance.currentlyHeldObjectServer != null;

            //If not holding item, revert to regualr game physics
            if (!isHoldingItem) return;

            //Calculate mass in kg
            float weightInLbs = (__instance.carryWeight - 1.0f) * 105f;
            float massInKg = weightInLbs / 2.20462f;
            //Assuming base player weighs 70kg, this finds total mass
            float totalMass = 70f + massInKg;

            //Change float speed by item weight
            float baseSpeed = 5.0f;
            float massPenalty = totalMass * 0.03f;
            float dynamicFloatSpeed = Mathf.Max(0.5f, baseSpeed - massPenalty);

            //Set fall value to 0.15
            __instance.fallValue = dynamicFloatSpeed;

            //This is all old logic, may be reused in the future. It was only a concept
            //Set vertical movement vector
            //Vector3 verticalMove = Vector3.up * targetFloatSpeed;

            // Move the CharacterController smoothly upward
            //__instance.thisController.Move(verticalMove * Time.deltaTime);
        }
    }
}
