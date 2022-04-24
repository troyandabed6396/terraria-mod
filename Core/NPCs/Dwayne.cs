using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using TestMod.Core.Items.Weapons.Melee;
using TestMod.Core.Buffs;
using TestMod.Core.Items.Misc;
using TestMod.Core;
using TestMod.Core.WorldGeneration;
using Terraria.Localization;


namespace TestMod.Core.NPCs {
    public class Dwayne : ModNPC {
        public override string Texture => "TestMod/Sprites/NPCs/Dwayne";
        public override void SetStaticDefaults() {
            Main.npcFrameCount[npc.type] = 1;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
        }

        public override void SetDefaults()
        {
            npc.height = 40;
            npc.width = 18;
            npc.townNPC = true;
            npc.friendly = true;
            npc.aiStyle = 7;
            npc.defense = 690;
            npc.lifeMax = 42069;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            for (int k = 0; k < 255; k++) {
                    Player player = Main.player[k];
                    if (!player.active) {
                        continue;
                    }

                    foreach (Item item in player.inventory) {
                        if (item.type == ModContent.ItemType<ImposterSword>()) {
                            return true;
                        }
                    }
                }
            return false;
        }
        public override bool CheckConditions(int left, int right, int top, int bottom) {
            return true;
        }

        public override string TownNPCName() {
			return "Dwayne, \"The Rock\", Johnson";
		}

        public override string GetChat() {
            switch (Main.rand.Next(4)) {
                case 0:
                    return "Just because you have muscles, doesn't mean you're not sus.";
                case 1:
                    return "You can be my rock, and I'll be your stone.";
                case 2: 
                    return "I wake up every morning and piss excellence.";
                case 3:
                    return "If you smell what the rock is cooking, then you know what time it is: time to get sus!";
                default:
                    return "You can smell what The Rock is cooking, and it's a big pot of SUS!";
            }
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
                if (!amongPlayer.gaveWok && !hasWok(player)) {
                    player.AddBuff(ModContent.BuffType<WOKKED>(), 18000);
                    player.QuickSpawnItem(ModContent.ItemType<TheWok>());
                    amongPlayer.gaveWok = true;
                } else {
                    if (!amongPlayer.gaveWok)
                        amongPlayer.gaveWok = true;
                    player.AddBuff(ModContent.BuffType<WOKKED>(), 18000);
                    Main.npcChatText = "Already gave WOK, and you have been WOKKED.";
                }
            } else {
                player.ClearBuff(ModContent.BuffType<WOKKED>());
            }
        }

        public bool hasWok(Player player) {
            foreach (Item item in player.inventory) {
                if (item.type == ModContent.ItemType<TheWok>()) {
                    return true;
                }
            }
            return false;
        }
    }
}