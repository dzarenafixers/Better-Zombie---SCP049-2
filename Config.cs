/// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
/// The file and plugin is secure with MIT lic and DZCP company portal 
/// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace MONCEF50G
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Settings for SCP-106's zombie slowness effect")]
        public Scp106Config Scp106Config { get; set; } = new Scp106Config();

        [Description("Settings for SCP-049's zombie health bonus")]
        public Scp049Config Scp049Config { get; set; } = new Scp049Config();

        [Description("Settings for SCP-173's zombie Hume Shield bonus")]
        public Scp173Config Scp173Config { get; set; } = new Scp173Config();

        [Description("Settings for SCP-079's zombie decay and tazed effect")]
        public Scp079Config Scp079Config { get; set; } = new Scp079Config();

        [Description("Settings for SCP-939's zombie footsteps")]
        public Scp939Config Scp939Config { get; set; } = new Scp939Config();

        [Description("Settings for SCP-096's zombie bloodlust boost")]
        public Scp096Config Scp096Config { get; set; } = new Scp096Config();
    }
    /// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
    /// The file and plugin is secure with MIT lic and DZCP company portal 
    /// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers
    public class Scp106Config
    {
        [Description("Minimum slowness percentage (1-100)")]
        public float MinSlowness { get; set; } = 1f;

        [Description("Maximum slowness percentage (1-100)")]
        public float MaxSlowness { get; set; } = 10f;

        [Description("Maximum distance (meters) for slowness scaling")]
        public float MaxDistance { get; set; } = 10f;
    }

    public class Scp049Config
    {
        [Description("Additional max health for zombies")]
        public float HealthBonus { get; set; } = 50f;
    }

    public class Scp173Config
    {
        [Description("Hume Shield gained per infection")]
        public float HumeShieldBonus { get; set; } = 10f;
    }

    public class Scp079Config
    {
        [Description("HP decay per second")]
        public float DecayRate { get; set; } = 2f;

        [Description("Tazed effect duration (seconds) per hit")]
        public float TazedDuration { get; set; } = 0.5f;
    }
    /// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
    /// The file and plugin is secure with MIT lic and DZCP company portal 
    /// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers
    public class Scp939Config
    {
        [Description("Enable Chaos Insurgency footstep sounds (requires server-side audio modding)")]
        public bool UseChaosFootsteps { get; set; } = true;
    }

    public class Scp096Config
    {
        [Description("Bloodlust speed boost multiplier (1.25 = 25% increase)")]
        public float BloodlustMultiplier { get; set; } = 1.25f;
    }
}
/// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
/// The file and plugin is secure with MIT lic and DZCP company portal 
/// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers