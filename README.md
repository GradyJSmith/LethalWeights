# LethalWeights
This is a Lethal Company mod that makes it so any items you have subtract weight instead of adding it, making you float.

## Features

* **Anti-Gravity Scraps:** Holding any item in your hands overrides standard gravity and causes you to float upward.
* **Dynamic Weight Physics:** Float speed scales dynamically based on total carried mass. Lighter items float faster, while heavier scrap slows down your ascension.
* **Fall Damage Intact:** Standard falling physics resume as soon as you drop or switch your held item. Keep an eye on your height!
* **Client-Side Physics:** Applied locally to active players via Harmony patches on `PlayerControllerB`.

---

## Configuration & Formula

Float speed is calculated frame-by-frame using the total carried mass:

$$\text{Float Speed} = \max\left(0.5,\, 5.0 - (\text{Total Mass (kg)} \times 0.03)\right)$$

* **Base Speed:** `5.0 m/s`
* **Minimum Float Speed:** `0.5 m/s` (Heavy items will still float slowly)
* **Base Player Mass:** Assumed at `70 kg`

---

## Requirements

* [BepInEx Pack for Lethal Company](https://thunderstore.io/c/lethal-company/p/BepInEx/BepInExPack/)
* .NET Framework 4.7.2 / .NET Standard 2.1

---

## Installation

1. Download the latest release from the Releases tab or Thunderstore.
2. Extract the archive and place `LethalWeights.dll` inside your `BepInEx/plugins` folder.
3. Launch Lethal Company via BepInEx.

---

## Known Issues & FAQ

* **Why am I taking fall damage when I drop my item?**
  * Gravity immediately resumes when you stop holding an item. If you release a heavy item high in the air, your fall distance will accumulate normally on the way down.
