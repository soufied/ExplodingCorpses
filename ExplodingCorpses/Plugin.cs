using System;
using System.Linq;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using UnityEngine;
using Random = System.Random;
namespace ExplodingCorpses
{
    public class Plugin : Plugin<Configs.Config>
    {
        public override string Name => "ExplodingCorpses";
        public override string Author => "_soufi";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(7, 1, 0);
        public static Plugin Singleton = new Plugin();
        public override void OnEnabled()
        {
            Singleton = this;
            Exiled.Events.Handlers.Player.SpawningRagdoll += OnSpawningRagdoll;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Singleton = null;
            Exiled.Events.Handlers.Player.SpawningRagdoll -= OnSpawningRagdoll;
            base.OnDisabled();
        }
        public void OnSpawningRagdoll(SpawningRagdollEventArgs ev)
        {
            if (!Config.BoomClasses.Contains(ev.Role)) return;
            if (!Player.Get(RoleTypeId.Spectator).Any()) return;
            Random rnd = new Random();
            if (rnd.Next(1,101) > Config.ExpChance) return;
            var grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE);
            grenade.Base.Owner = Player.Get(RoleTypeId.Spectator).FirstOrDefault()?.ReferenceHub;
            grenade.FuseTime = Config.TickTack;
            grenade.MaxRadius = Config.MaxRadius;
            grenade.ScpDamageMultiplier = Config.ScpDamageMultiplier;
            grenade.SpawnActive(new Vector3(ev.Position.x, ev.Position.y + 5, ev.Position.z));
        }
    }
}