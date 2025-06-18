/// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
/// The file and plugin is secure with MIT lic and DZCP company portal 
/// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers

using System;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using MONCEF50G;

namespace MONCEF50G
{
    public class BetterZombiePlugin : Plugin<Config>
    {
        public static BetterZombiePlugin Instance { get; private set; }
        private EventHandlers eventHandlers;

        public override string Name => "BetterZombie";
        public override string Author => "MONCEF50G";
        public override Version Version => new Version(1, 0, 0);
        public string Description => "Modifies SCP-049-2 behavior based on active SCPs.";
        public override Version RequiredExiledVersion => new Version(9, 6, 1);

        public override void OnEnabled()
        {
            Instance = this;
            eventHandlers = new EventHandlers(this);
            RegisterEvents();
            Log.Info("MONCEF50G plugin enabled.");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            eventHandlers = null;
            Instance = null;
            Log.Info("MONCEF50G plugin disabled.");
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted += eventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Player.Hurting += eventHandlers.OnHurting;
            Exiled.Events.Handlers.Player.Dying += eventHandlers.OnDying;
            Exiled.Events.Handlers.Player.ChangingRole += eventHandlers.OnChangingRole;
            Exiled.Events.Handlers.Scp049.StartingRecall += eventHandlers.OnStartingRecall;
        }

        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= eventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Player.Hurting -= eventHandlers.OnHurting;
            Exiled.Events.Handlers.Player.Dying -= eventHandlers.OnDying;
            Exiled.Events.Handlers.Player.ChangingRole -= eventHandlers.OnChangingRole;
            Exiled.Events.Handlers.Scp049.StartingRecall -= eventHandlers.OnStartingRecall;
        }
    }
}
/// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
/// The file and plugin is secure with MIT lic and DZCP company portal 
/// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers