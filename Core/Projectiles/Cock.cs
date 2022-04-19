using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Core.Projectiles {
    public class Cock : ModProjectile {
        public override string Texture => "TestMod/Sprites/Projectiles/Cock";
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cock");
        }

        public override void SetDefaults() {
            projectile.width = 56;
            projectile.height = 27;
            projectile.aiStyle = 8;
            projectile.timeLeft = 1800;
            projectile.light = 0.75f;
            projectile.hostile = true;
            projectile.maxPenetrate = 1;
            projectile.tileCollide = true;
        }
    }
}