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

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) => true; //{
        //     if (Testicles.savedKeanu) {
        //         return true;
        //     }
        //     return true;
        // }


        public override string TownNPCName() {
			return "Keanu";
		}

        public override string GetChat() {
       
            return "None";
        }

        public override void SetChatButtons(ref string button, ref string button2) {
            button = "The WOK?!?";
            button2 = "The COCK ඞ";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            Player player = Main.LocalPlayer;
            AmongPlayer amongPlayer = player.GetModPlayer<AmongPlayer>();
            if (firstButton) {
                Main.npcChatText = "Already gave WOK, and you have been WOKKED.";

            } else {
                Main.npcChatText = "Already gave WOK, and you have been WOKKED.";
            }
        }
    }
}