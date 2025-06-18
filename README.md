# MONCEF50G Plugin for SCP:SL 🧟‍♂️🎮

Welcome to **MONCEF50G**, a fun plugin that makes SCP-049-2 (zombies) in SCP: Secret Laboratory super exciting! When certain SCPs are in the game, zombies get cool new powers. Perfect for crazy rounds! 😎

## What Does It Do? 🚀

Zombies (SCP-049-2) gain special abilities based on which SCPs are active in the round:

- **SCP-106** 🕳️: Zombies slow players down (1%-10%) when they get close, making escapes harder!
- **SCP-049** 🩺: Zombies get 50 extra health (tougher to kill!).
- **SCP-173** 🗿: When a zombie infects someone, all zombies gain 10 Hume Shield (like a small shield).
- **SCP-079** 💻: Zombies decay (lose 2 HP per second), can’t heal from kills, stun players for 0.5s when hitting, and can only kill (no infecting).
- **SCP-939** 🐶: Zombies’ footsteps sound like Chaos Insurgency (needs extra server setup).
- **SCP-096** 😢: Zombies’ speed boost (Bloodlust) is 25% stronger when chasing.

## How to Install 🛠️

1. **Get the Files** 📂:
    - Download `BetterZombie.dll` from the [releases](https://github.com/dzarenafixers/BetterZombie/releases) or build it yourself.
    - Make sure you have EXILED 9.6.1 installed on your SCP:SL server.

2. **Copy to Server** 📦:
    - Put `Mayhem.dll` in `%appdata%\EXILED\Plugins`.
    - Ensure `Exiled.API.dll`, `Exiled.Events.dll`, and `MEC.dll` are in `Plugins\dependencies`.

3. **Start the Server** 🖥️:
    - Run your SCP:SL server.
    - Check the console for “MONCEF50G plugin enabled.” ✅

4. **Tweak Settings** ⚙️:
    - Find `BetterZombie.yml` in `%appdata%\EXILED\Configs`.
    - Edit values like slowness, health, or decay to balance the game.

## How to Use 🎮

- **Start a Round** 🌌:
    - Play a normal SCP:SL round with SCPs like 106, 049, or 173.
    - When SCP-049 makes zombies, they’ll have new powers based on the SCPs in the game.

- **Test It Out** 🧪:
    - Use Remote Admin commands like `spawn scp049` to add SCP-049.
    - Kill a player to make a zombie and watch their new abilities!
    - Example: With SCP-106, chase a player as a zombie—they’ll slow down when you’re near.

- **Debug Mode** 🕵️‍♂️:
    - Set `debug: true` in `BtterZombie.yml` to see logs in the console (helps find issues).

## Works With Your Plugins 🤝

- **CustomRolesPlugin** (like `ConArtist`): MONCEF50G works fine alongside your custom roles! Just make sure `ConArtist`’s `.pickpocket` skips zombies.
- If you notice weird behavior, check the console logs or ask for help.

## Need Help? ❓

- **Issues**: Check the console for errors. Share them on [GitHub Issues](https://github.com/dzarenafixer/BetterZombie/issues).
- **Ideas**: Want new zombie powers? Suggest them!
- **Community**: Join the EXILED Discord for SCP:SL plugin tips or join this server
- **https://discord.gg/czEeTkwe**
- **https://discord.gg/Nq36mJKx**

## Thanks! 🙌

Made with ❤️ for SCP:SL fans. Enjoy the chaos! 🧟‍♂️💥

---
*Built for EXILED 9.6.0 and SCP:SL v14.1.1*
