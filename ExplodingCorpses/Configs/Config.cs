using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;
using PlayerRoles;
namespace ExplodingCorpses.Configs
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("List of classes whose bodies will explode")]
        public List<RoleTypeId> BoomClasses { get; set; } = new List<RoleTypeId>()
        {
            RoleTypeId.ClassD,
            RoleTypeId.ChaosConscript,
            RoleTypeId.ChaosMarauder,
            RoleTypeId.ChaosRepressor,
            RoleTypeId.ChaosRifleman,
            RoleTypeId.NtfCaptain,
            RoleTypeId.NtfPrivate,
            RoleTypeId.NtfSergeant,
            RoleTypeId.NtfSpecialist,
            RoleTypeId.Scientist,
            RoleTypeId.FacilityGuard,
            RoleTypeId.Scp173,
            RoleTypeId.Scp0492,
            RoleTypeId.Scp049
        };
        [Description("How soon the grenade explodes")]
        public float TickTack { get; set; } = 1f;
        [Description("Damage Multiplier to SCP - (default - 3)")]
        public float ScpDamageMultiplier { get; set; } = 3f;
        [Description("Radius of explosion - (default - 9)")]
        public float MaxRadius { get; set; } = 9f;
        [Description("Explousion chance")]
        public int ExpChance { get; set; } = 20;
    }
}