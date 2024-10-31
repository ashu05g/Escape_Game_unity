# 🧟 Escape - Stealth Survival Game 🎮

Welcome to **Escape**, an immersive stealth survival game developed in Unity. In a post-apocalyptic world infected with a zombie virus, you are stranded in an abandoned asylum. 🏚️ Your goal? Survive the zombies, find the antidote, and escape to freedom! 🗝️

## 🎥 Game Trailer

https://github.com/user-attachments/assets/1acee30a-f2ea-464b-a69e-8929bef03aae


---

## 📖 Storyline

In a world devastated by a terrifying zombie virus, you awaken in an **Abandoned Asylum** crawling with the undead. Your mission is simple, yet deadly: **find the antidote**, retrieve the key to unlock the asylum's gates, and escape unscathed.

But beware – the zombies are always watching, lurking in the shadows, waiting for you to make a wrong move. Should you encounter one, they’ll hunt you down mercilessly. Run, hide, and survive until you can make your way to freedom.

> "You can escape the asylum, but will you escape the infection?"

## 🕹️ Gameplay

### 🎯 Objectives
1. **Find the Antidote** - Hidden somewhere within the asylum. Avoid getting too close to zombies!
  
   Game Start:

   ![Screenshot 2024-10-31 022116](https://github.com/user-attachments/assets/ab2bb241-e7ff-469a-90c9-79a5966d7372)

   Zombie:

   ![Screenshot 2024-10-31 022146](https://github.com/user-attachments/assets/43d5bdc0-031b-4b96-955e-28675cf5e855)

   Antidote:

   ![Screenshot 2024-10-31 022252](https://github.com/user-attachments/assets/5139f0f6-3d7f-43e5-b480-7fbc9cd1d8d0)

3. **Find the Asylum Key** - After securing the antidote, locate the key that unlocks the main exit.

   ![Screenshot 2024-10-31 022322](https://github.com/user-attachments/assets/002e68b4-b676-4478-b133-d8a43d9d8104)

4. **Escape** - Reach the asylum gate with both the antidote and the key to survive and win!

   ![Screenshot 2024-10-31 022340](https://github.com/user-attachments/assets/897518c7-f62b-42af-8413-461672db6c4d)

   Win:

   ![Won](https://github.com/user-attachments/assets/3857d22a-283f-4862-b3db-f76987f4a273)

   Lost:

   ![GameOver](https://github.com/user-attachments/assets/eadf0e2f-c974-4761-9471-dd34010e8f05)
   
### 🧠 How to Play

- **Stealth & Patience** - Avoid detection by zombies. Stay out of their sight and sound range.
- **Run & Evade** - If spotted, quickly run to avoid capture. Zombies will chase you if they spot you.
- **Complete Objectives** - Collect the antidote and key to unlock the escape gate.

![You Have Escaped](./Won.png)

#### Zombie AI
- **Patrolling** - Zombies patrol set waypoints. Avoid crossing their paths.
- **Chasing** - When they spot you, zombies will switch to chase mode, speeding up their movement and focusing entirely on your position.
- **Attack** - If they catch you, it's game over. Zombies will attack if close enough, locking you in a deadly fight.

### Controls 🕹️
- **Move**: WASD
- **Look**: Mouse Movement
- **Run**: Shift + WASD

## 📂 Project Structure

- **Assets** - Contains the main folders for scenes, character assets, and sounds.
  - `Abandoned_Asylum` - The eerie environment where the game takes place.
  - `Zombie` - Contains AI for zombies, enabling them to patrol, chase, and attack.
  - `Scripts` - Houses all gameplay scripts, including:
    - **ZombieAI.cs** - Controls zombie patrol, chase, and attack behavior. Uses NavMesh for realistic pathfinding and sound cues to alert zombies【11†source】.
    - **Floater.cs** - Adds floating animation for objects like antidotes or keys, giving them a mystical look【12†source】.
    - **GameOver.cs** - Manages game-over behavior and displays a game-over screen upon zombie capture【13†source】.
    - **PlayerController.cs** - Handles player movement, interaction, and objectives, including securing the antidote and key【14†source】.

## 🔊 Sound Effects and Audio Assets

- **Classic Footstep SFX** - Adds realistic footstep sounds that vary depending on the surface. These sounds enhance the immersive experience as you tread cautiously through the asylum.
- **Horror Bundle 1** - Provides background music and ambient horror sounds to maintain an unsettling atmosphere, keeping players on edge.
- **Zombie Horror Package Free** - Contains zombie moans, growls, and chase sounds, which are triggered when zombies spot the player, adding to the fear factor.

## 🛠️ Tech Stack

- **Unity** - For game development and environment setup.
- **C#** - For scripting gameplay elements and character behavior.
- **NavMesh** - Used for zombie pathfinding to enhance the AI’s chase and patrol behavior.

## 🏆 Winning Condition

- **Escape the Asylum** - Once you've found both the antidote and key, navigate to the asylum’s main gate to unlock your freedom.

![Game Over](./GameOver.png)

### 🧟 Game Over Conditions
- **Zombie Contact** - If a zombie catches you, the game ends in a brutal encounter.

## 🏁 Final Words

Thank you for playing! Can you outwit the undead and make it out of the asylum alive? ⚔️💀

> Play to find out if you can survive the horrors lurking within...
