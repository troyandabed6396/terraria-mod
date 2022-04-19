using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace TestMod.Core.NPCs
{
    public class TheRock : ModNPC
    {
        public override string Texture => "TestMod/Sprites/NPCs/TheRock";
        public override void SetDefaults()
        {
            npc.townNPC = false;
            npc.friendly = false;
            npc.aiStyle = 0;
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
    }
}
