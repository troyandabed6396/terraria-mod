using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using TestMod.Core.Items.Weapons.Melee;
using TestMod.Core.Buffs;
using TestMod.Core.Items.Misc;
using TestMod.Core;
using TestMod.Core.WorldGeneration;
using Terraria.Localization;
// using Terraria.NPC;


namespace TestMod.Core.NPCs {
    [AutoloadHead]
    public class Keanu : ModNPC {
        public override bool Autoload(ref string name)
        {
            name = "Keanu";
            return mod.Properties.Autoload;
        }
        public override string Texture => "TestMod/Sprites/NPCs/DwayneTheCock";
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("The President");
            Main.npcFrameCount[npc.type] = 1;
            // NPCID.Sets.DangerDetectRange[npc.type] = 700;
            
        }

        public override void SetDefaults()
        {
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

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (Testicles.savedKeanu) {
                return true;
            }
            return false;
        }


        public override string TownNPCName() {
			return "Keanu";
		}

        public override string GetChat() {
            switch (Main.rand.Next(4)) {
                case 0:
                    return "Updoot!";
                case 1:
                    return "Big chungus wholesome 100 if you know what I mean.";
                case 2: 
                    return "I'm not racist but I don't like black people.'";
                case 3:
                    return "dont care + didnt ask + cry about it + stay mad + get real + L + mald seethe cope harder.";
                default:
                    return "Got any Dogecoin you sussy 'mogus?";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2) {
            button = "Darude Sandstorm";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
        
        }
    }
}