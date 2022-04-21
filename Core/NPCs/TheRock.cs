using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TestMod.Core.NPCs
{
    public class TheRock : ModNPC
    {
        public override string Texture => "TestMod/Sprites/NPCs/TheRock";

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("The Rock");
            Main.npcFrameCount[npc.type] = 3;
        }
        public override void SetDefaults()
        {   
            npc.aiStyle = 7;
            npc.defense = 0;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 1f;
            npc.height = 50;
            npc.width = 50;
        }
        public override bool? CanBeHitByItem(Player player, Item item) {
			return true;
        }
        public override bool? CanBeHitByProjectile(Projectile projectile) {
			return true;
        }

        public override bool PreNPCLoot()
        {
            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, (int)mod.NPCType("DwayneTheCock"));
            return true;
        }

        public override void FindFrame(int frameHeight) {
            Player player = Main.LocalPlayer;
            // if (true == true)
            //     Main.NewText("frame counter: " + npc.frameCounter);
            if (Vector2.Distance(npc.position, player.position) < 200 && !(npc.life < npc.lifeMax)) 
                npc.frameCounter = 1;
            else if (npc.life < npc.lifeMax) 
                npc.frameCounter = 2;
            else
                npc.frameCounter = 0;
            
            npc.frame.Y = (int) npc.frameCounter * npc.height;
        }
    }
}
