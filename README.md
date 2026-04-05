# ⚔️ Elden Souls - 3D Action RPG Prototype

<p align="center">
  <img src="https://github.com/user-attachments/assets/d85f907c-54ce-42ad-be9c-8a71763cc482" alt="Gameplay with Goblins" width="48%" />
  <img src="https://github.com/user-attachments/assets/f269c3c7-ec32-49c2-a4df-d90b51693b9b" alt="Player Character Model" width="48%" />
</p>
<p align="center">
  <em>Combat against multiple enemies (A* & FSM AI) | Custom-made Player Character Model</em>
</p>

## 📖 About The Project
**Elden Souls** is a "souls-like" 3D action game developed as a collaborative student project. The main objective of the game is to navigate through challenging environments, defeat various enemies, and overcome a final boss. 

**90%** of the game's visual assets - including 3D models, textures, and animations - were custom-made by our team without relying on pre-made asset packs.

## 🛠️ Key Technical Features
* **Finite State Machine (FSM):** Implemented a robust AI system for enemies featuring three distinct states (`Patrol`, `Chase`, `Attack`) to create dynamic and challenging combat encounters.
* **Singleton Design Pattern:** Utilized the Singleton pattern for efficient global game state management (e.g., player stats, game progress), ensuring secure and optimized cross-script data access.
* **Core Combat Mechanics:** Programmed hitboxes, health management, and attack loops.
* **90% Custom Art & Assets:** All humanoid characters, environments, and animations were modeled and rigged entirely from scratch by our team, ensuring a unique and cohesive visual style.
* **Version Control:** Managed the codebase and collaborated with team members (artists/designers) using Git and GitHub.

## 💻 Built With
* **Game Engine:** Unity 3D
* **Language:** C#
* **Version Control:** Git, GitHub Desktop

## 🚀 How to Run the Project
1. Clone the repository: 
   ```bash
   git clone [https://github.com/Rudnikua/EldenSouls.git](https://github.com/Rudnikua/EldenSouls.git)
   ```
2. Open the project folder via Unity Hub (Recommended version: 6000.2.6f2).
3. Navigate to the `Scenes` folder and open the main scene.
4. Press the **Play** button in the Unity Editor to start the game.

## 🤝 Team
* **Myroslav Rudnik** – Lead Programmer (Core mechanics, combat system, AI, animations & UI integration)
* **Oleksandr Svietlychnyi** – Creative Director & Level Designer (Artistic vision, textures, GUI, level design)
* **Denys Maksymiv** – 3D Artist & Animator (Characters, weapons & enemy models, animations, UI design)
* **Yurii Fedorchuk** – Environment Artist (3D environmental assets, materials, lighting, world building)
* **Viktor Solomonov** – Sound Designer & Composer (Original soundtrack, SFX, audio architecture)
* **Mykyta Hubenko** – Gameplay & UI Programmer (Main menu systems, teleportation, roll mechanics)
