using System;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
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
            var grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE);
            grenade.FuseTime = Config.TickTack;
            grenade.MaxRadius = Config.MaxRadius;
            grenade.ScpDamageMultiplier = Config.ScpDamageMultiplier;
            grenade.SpawnActive(ev.Position);
        }
    }
}