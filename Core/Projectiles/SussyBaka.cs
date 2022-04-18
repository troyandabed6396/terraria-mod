using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TestMod.Core.Buffs;
using Microsoft.Xna.Framework;
using System;

namespace TestMod.Core.Projectiles {
    public class SussyBaka : ModProjectile {
        public override string Texture => "TestMod/Sprites/Projectiles/AmongFard";
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("More suspicious than a suspicious looking eyeball"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Main.projFrames[projectile.type] = 1;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
			projectile.height = 30;
			projectile.maxPenetrate = -1;
            projectile.minion = true;
            projectile.netImportant = true;
            projectile.minionSlots = 1;
        }

        public override bool MinionContactDamage() {
			return true;
		}

        public override void AI() {
            Player player = Main.player[projectile.owner];

            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<Sus>());
            }
            if (player.HasBuff(ModContent.BuffType<Sus>()))
            {
                projectile.timeLeft = 2;
            }

            Vector2 idlePosition = player.Center;
            float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
            idlePosition.X += minionPositionOffsetX;

            Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 600f) {
				// Whenever you deal with non-regular events that change the behavior or position drastically, make sure to only run the code on the owner of the projectile,
				// and then set netUpdate to true
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}

            float overlapVelocity = 0.04f;
			for (int i = 0; i < Main.maxProjectiles; i++) {
				// Fix overlap with other minions
				Projectile other = Main.projectile[i];
				if (i != projectile.whoAmI && other.active && other.owner == projectile.owner && Math.Abs(projectile.position.X - other.position.X) + Math.Abs(projectile.position.Y - other.position.Y) < projectile.width) {
					if (projectile.position.X < other.position.X) projectile.velocity.X -= overlapVelocity;
					else projectile.velocity.X += overlapVelocity;

					if (projectile.position.Y < other.position.Y) projectile.velocity.Y -= overlapVelocity;
					else projectile.velocity.Y += overlapVelocity;
				}
			}

            float distanceFromTarget = 1000f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;

            if (player.HasMinionAttackTargetNPC) {
                NPC targetNPC = Main.npc[player.MinionAttackTargetNPC];
                if (Vector2.Distance(targetNPC.position, projectile.position) < 2000f) {
                    foundTarget = true;
                    targetCenter = targetNPC.Center;
                    distanceFromTarget = Vector2.Distance(targetNPC.position, projectile.position);
                }
            }

            if (!foundTarget) {
                for (int i = 0; i < Main.maxNPCs; i++) {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy()) {
                        float between = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						if (((closest && inRange) || (!foundTarget && inRange))) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
                    }
                }
            }
            
            projectile.friendly = foundTarget;

            float speed = 8f;
			float inertia = 20f;

            if (foundTarget) {
                CombatText.NewText(new Rectangle((int) player.Center.X - 100, (int) player.Center.Y - 75, 200, 50), Color.White, "There is an impostor among us...", true, false);
                projectile.position = targetCenter;
				projectile.netUpdate = true;
            }
            else {
                if (distanceToIdlePosition > 600f) {
                        // Speed up the minion if it's away from the player
                        speed = 12f;
                        inertia = 60f;
                    }
                    else {
                        // Slow down the minion if closer to the player
                        speed = 4f;
                        inertia = 80f;
                    }
                    if (distanceToIdlePosition > 20f) {
                        // The immediate range around the player (when it passively floats about)

                        // This is a simple movement formula using the two parameters and its desired direction to create a "homing" movement
                        vectorToIdlePosition.Normalize();
                        vectorToIdlePosition *= speed;
                        projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
                    }
                    else if (projectile.velocity == Vector2.Zero) {
                        // If there is a case where it's not moving at all, give it a little "poke"
                        projectile.velocity.X = -0.15f;
                    }
            }

            projectile.rotation = projectile.velocity.X * 0.05f;
            Lighting.AddLight(projectile.Center, Color.White.ToVector3() * 0.78f);
                
        }
    }
}