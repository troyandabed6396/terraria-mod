using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TestMod.Core.Projectiles;

namespace TestMod.Core.NPCs {
    public class DwayneTheCock : ModNPC {
        public override string Texture => "TestMod/Sprites/NPCs/DwayneTheCock";
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dwayne, The Cock, Johnson");
            Main.npcFrameCount[npc.type] = 1;
        }
        public override void SetDefaults()
        {
            npc.width = 36;
            npc.height = 56;
            npc.damage = 69;
            npc.defense = (int) 4.2;
            npc.lifeMax = 420;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.aiStyle = -1;
            npc.noGravity = false;
            npc.knockBackResist = 0.6f;
            npc.direction = Main.rand.Next(2)== 0 ? 1 : -1;
        }

        const float scanRange = 700f;
        const float walkSpeed = 1.5f;

        public override void AI() {
            npc.target = npc.FindClosestPlayer();
            Player playerTarget = Main.player[npc.target];

            float betweenX = playerTarget.Center.X - npc.Center.X;
            float between = Vector2.Distance(playerTarget.position, npc.position);
            float speed = 10;
            Vector2 projectileDirection = npc.DirectionTo(playerTarget.Center) * speed;
            int type = ModContent.ProjectileType<Cock>();
            int damage = npc.damage;

            //if (true == true) {
            //    Main.NewText("distance from player: " + between);
            //    Main.NewText("npc center x: " + npc.Center.X);
            //    Main.NewText("player center x: " + playerTarget.Center.X);
            //    Main.NewText("in range: " + (between <= scanRange));
            //    Main.NewText("in line of sight: " + Collision.CanHitLine(npc.Center, 10, 5, playerTarget.position, playerTarget.width, playerTarget.height));
            //}

            if (between <= scanRange && npc.HasValidTarget) {
                npc.direction = betweenX > 0 ? 1 : -1;
                npc.spriteDirection = npc.direction;
                if (Collision.CanHitLine(npc.Center, 56, 27, playerTarget.position, playerTarget.width, playerTarget.height)) {
                    shotTimer++;
                    if(shotTimer > 50) {
                        //Main.NewText("projectile should be spawning");
                        Projectile.NewProjectile(npc.Center, projectileDirection, type, damage, 1f, Main.myPlayer);
                        shotTimer = 0;
                    }
                }
            }
        }

        public float shotTimer {
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
        private void Move(float speed) {
        if (npc.velocity.X * npc.direction <= speed)//getting up to max speed
            npc.velocity.X += 0.1f * npc.direction;
        else if (npc.velocity.X * npc.direction >= speed + 0.1f)//slowdown if too fast
            npc.velocity.X -= 0.2f * npc.direction;
        }
    }
}