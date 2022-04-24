using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TestMod.Core.WorldGeneration;



namespace TestMod.Core.NPCs {
    public class KeanuGaming : ModNPC {

        public override string Texture => "TestMod/Sprites/NPCs/Dwayne";

        public override void SetStaticDefaults() {
            Main.npcFrameCount[npc.type] = 1;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
        }

        public override void SetDefaults() {
            npc.height = 40;
            npc.width = 18;
            npc.townNPC = true;
            npc.friendly = true;
            npc.aiStyle = 7;
            npc.defense = 42069;
            npc.lifeMax = 69000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
        }

        public override string TownNPCName() {
			return "Keanu";
        }
        public override string GetChat() {
            npc.Transform(ModContent.NPCType<Keanu>());
            Testicles.savedKeanu = true;
            return "";
            
        }
    }
}
