using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Core.NPCs {
    public class DwayneTheCock : ModNPC {
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
    }
}