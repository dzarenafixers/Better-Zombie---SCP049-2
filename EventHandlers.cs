/// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
/// The file and plugin is secure with MIT lic and DZCP company portal 
/// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers
using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp049;
using MEC;
using PlayerRoles;
using UnityEngine;

namespace MONCEF50G
{
    public class EventHandlers
    {
        private readonly BetterZombiePlugin plugin;
        private readonly HashSet<RoleTypeId> activeScps = new HashSet<RoleTypeId>();
        private readonly Dictionary<Player, float> lastDecayTimes = new Dictionary<Player, float>();
        /// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
        /// The file and plugin is secure with MIT lic and DZCP company portal 
        /// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers
        public EventHandlers(BetterZombiePlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnRoundStarted()
        {
            activeScps.Clear();
            lastDecayTimes.Clear();

            // Detect active SCPs
            foreach (Player player in Player.List.Where(p => p.IsScp))
            {
                activeScps.Add(player.Role.Type);
            }
       
            Log.Debug($"Active SCPs: {string.Join(", ", activeScps)}");

            // Start decay coroutine for SCP-079 zombies
            if (activeScps.Contains(RoleTypeId.Scp079))
                Timing.RunCoroutine(ApplyDecay());

            // Apply initial zombie modifications
            foreach (Player zombie in Player.List.Where(p => p.Role.Type == RoleTypeId.Scp0492))
            {
                ApplyZombieModifications(zombie);
            }
        }
        /// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
        /// The file and plugin is secure with MIT lic and DZCP company portal 
        /// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.NewRole == RoleTypeId.Scp0492)
            {
                Timing.CallDelayed(0.1f, () =>
                {
                    if (ev.Player == null || !ev.Player.IsAlive) return;
                    ApplyZombieModifications(ev.Player);
                });
            }
            else if (ev.Player != null && lastDecayTimes.ContainsKey(ev.Player))
            {
                lastDecayTimes.Remove(ev.Player);
            }
        }
        /// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
        /// The file and plugin is secure with MIT lic and DZCP company portal 
        /// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers
        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Attacker == null || ev.Player == null || ev.Attacker.Role.Type != RoleTypeId.Scp0492) return;

            // SCP-106: Slowness effect
            if (activeScps.Contains(RoleTypeId.Scp106))
            {
                float distance = Vector3.Distance(ev.Attacker.Position, ev.Player.Position);
                float slownessPercent = Mathf.Lerp(
                    plugin.Config.Scp106Config.MaxSlowness,
                    plugin.Config.Scp106Config.MinSlowness,
                    distance / plugin.Config.Scp106Config.MaxDistance
                );
                ev.Player.EnableEffect(EffectType.MovementBoost, -slownessPercent / 100f, true); // Fixed overload
                Log.Debug($"Applied {slownessPercent}% slowness to {ev.Player.Nickname} at {distance}m");
            }

            // SCP-079: Tazed effect (replaced with Concussed)
            if (activeScps.Contains(RoleTypeId.Scp079))
            {
                ev.Player.EnableEffect(EffectType.Concussed, plugin.Config.Scp079Config.TazedDuration, true); // Changed to Concussed
                Log.Debug($"Applied {plugin.Config.Scp079Config.TazedDuration}s concussed to {ev.Player.Nickname}");
            }

            // SCP-096: Boost bloodlust speed
            if (activeScps.Contains(RoleTypeId.Scp096))
            {
                var bloodlustEffect = ev.Attacker.GetEffect(EffectType.MovementBoost);
                if (bloodlustEffect != null && bloodlustEffect.IsEnabled)
                {
                    float baseSpeed = bloodlustEffect.Intensity * 100f;
                    float boostedSpeed = baseSpeed * plugin.Config.Scp096Config.BloodlustMultiplier;
                    ev.Attacker.EnableEffect(EffectType.MovementBoost, boostedSpeed / 100f, true); // Fixed overload
                    Log.Debug($"Boosted zombie {ev.Attacker.Nickname}'s bloodlust to {boostedSpeed}%");
                }
            }
        }
        /// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
        /// The file and plugin is secure with MIT lic and DZCP company portal 
        /// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers
        public void OnDying(DyingEventArgs ev)
        {
            if (ev.Attacker == null || ev.Player == null || ev.Attacker.Role.Type != RoleTypeId.Scp0492) return;

            // SCP-079: Prevent HP regen from kills
            if (activeScps.Contains(RoleTypeId.Scp079))
            {
                ev.Attacker.Health = Mathf.Min(ev.Attacker.Health, ev.Attacker.MaxHealth);
                Log.Debug($"Blocked HP regen for zombie {ev.Attacker.Nickname} on kill");
            }
        }

        public void OnStartingRecall(StartingRecallEventArgs ev) // Changed from OnResurrecting
        {
            // SCP-079: Prevent infection
            if (activeScps.Contains(RoleTypeId.Scp079))
            {
                ev.IsAllowed = false;
                ev.Target.Kill(DamageType.Scp0492);
                Log.Debug($"Blocked zombie infection by {ev.Player.Nickname} on {ev.Target.Nickname}");
            }

            // SCP-173: Grant Hume Shield on infection
            if (activeScps.Contains(RoleTypeId.Scp173))
            {
                Timing.CallDelayed(0.1f, () =>
                {
                    foreach (Player zombie in Player.List.Where(p => p.Role.Type == RoleTypeId.Scp0492))
                    {
                        zombie.HumeShield = Mathf.Min(
                            zombie.HumeShield + plugin.Config.Scp173Config.HumeShieldBonus,
                            zombie.MaxHumeShield
                        );
                        Log.Debug($"Added {plugin.Config.Scp173Config.HumeShieldBonus} HS to zombie {zombie.Nickname}");
                    }
                });
            }
        }
        /// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
        /// The file and plugin is secure with MIT lic and DZCP company portal 
        /// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers
        private void ApplyZombieModifications(Player zombie)
        {
            if (zombie.Role.Type != RoleTypeId.Scp0492) return;

            // SCP-049: Health bonus
            if (activeScps.Contains(RoleTypeId.Scp049))
            {
                zombie.MaxHealth += plugin.Config.Scp049Config.HealthBonus;
                zombie.Health += plugin.Config.Scp049Config.HealthBonus;
                Log.Debug($"Applied {plugin.Config.Scp049Config.HealthBonus} health bonus to zombie {zombie.Nickname}");
            }

            // SCP-939: Chaos footstep sound
            if (activeScps.Contains(RoleTypeId.Scp939) && plugin.Config.Scp939Config.UseChaosFootsteps)
            {
                Log.Warn("SCP-939 zombie footstep sound requires server-side audio modding outside EXILED API.");
            }

            // SCP-079: Track for decay
            if (activeScps.Contains(RoleTypeId.Scp079))
            {
                lastDecayTimes[zombie] = Time.time;
            }
        }
        /// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
        /// The file and plugin is secure with MIT lic and DZCP company portal 
        /// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers
        private IEnumerator<float> ApplyDecay()
        {
            while (activeScps.Contains(RoleTypeId.Scp079))
            {
                foreach (var zombie in Player.List.Where(p => p.Role.Type == RoleTypeId.Scp0492))
                {
                    if (!lastDecayTimes.ContainsKey(zombie))
                        lastDecayTimes[zombie] = Time.time;

                    float elapsed = Time.time - lastDecayTimes[zombie];
                    if (elapsed >= 1f)
                    {
                        zombie.Health = Mathf.Max(1f, zombie.Health - plugin.Config.Scp079Config.DecayRate);
                        lastDecayTimes[zombie] = Time.time;
                        Log.Debug($"Decayed zombie {zombie.Nickname} by {plugin.Config.Scp079Config.DecayRate} HP");
                    }
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }
    }
}
/// This file <BetterZombiePlugin.cs> its Privet just for GankMalp to Borksussy Owmer server
/// The file and plugin is secure with MIT lic and DZCP company portal 
/// For that you cant take the codes or get the plugin files with out tell MONCEF50G and dzarenafixers