using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Core.Items.Armor {
    class RedArmor {
        [AutoloadEquip(EquipType.Head)]
        public class RedHelmet : ModItem {
            public override string Texture => "TestMod/Sprites/Items/Armor/Red/RedHelmet";
            public override void SetStaticDefaults() {
                DisplayName.SetDefault("Red Helmet");
                Tooltip.SetDefault("Quite the suspicious helmet...\n15% increased critical strike chance");
            }

            public override void SetDefaults() {
                item.width = 18;
                item.height = 18;
                item.value = 69;
                item.rare = ItemRarityID.Blue;
                item.defense = 5;
            }

            public override void UpdateEquip(Player player) {
                // player.confused = true;
                // player.AddBuff(BuffID.Confused, 0, true);
                player.meleeCrit += 15;
                player.rangedCrit += 15;
                player.magicCrit += 15;
            }

            public override bool IsArmorSet(Item head, Item body, Item legs) {
			    return body.type == ModContent.ItemType<RedChestplate>() && legs.type == ModContent.ItemType<RedLeggings>();
            }

            public override void UpdateArmorSet(Player player) {
			    player.setBonus = "MAD DRIP COMPLETE. INITIALIZING GAMER EB";
			    player.statLifeMax2 += 300;
                player.wingTimeMax += 300;
                            
                player.meleeDamage *= 2f;
                player.rangedDamage *= 2f;
                player.magicDamage *= 2f;
                player.minionDamage *= 2f;

                player.statDefense += 50;
            }

            public override void AddRecipes() 
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.DirtBlock, 10);
                recipe.AddTile(TileID.WorkBenches);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }

        [AutoloadEquip(EquipType.Body)]
        public class RedChestplate : ModItem {
            public override string Texture => "TestMod/Sprites/Items/Armor/Red/RedChestplate";

            public override void SetStaticDefaults() {
                DisplayName.SetDefault("Red Chestplate");
                Tooltip.SetDefault("Quite the suspicious kit...\n20% increased damage");
            }

            public override void SetDefaults() {
                item.width = 18;
                item.height = 18;
                item.value = 69420;
                item.rare = 3;
                item.defense = 8;
            }

            public override void UpdateEquip(Player player) {
                player.meleeDamage *= 1.2f;
                player.rangedDamage *= 1.2f;
                player.magicDamage *= 1.2f;
                player.minionDamage *= 1.2f;
            }
        }

        [AutoloadEquip(EquipType.Legs)]
        public class RedLeggings : ModItem {
            public override string Texture => "TestMod/Sprites/Items/Armor/Red/RedLeggings";
            public override void SetStaticDefaults() {
                DisplayName.SetDefault("Red Leggings");
                Tooltip.SetDefault("Quite the suspicious drip...\n50% increased movement speed");
            }

            public override void SetDefaults() {
                item.width = 18;
                item.height = 18;
                item.value = 420;
                item.rare = 3;
                item.defense = 6;
            }

            public override void UpdateEquip(Player player) {
                player.moveSpeed += 0.50f; 
            }

            public override void AddRecipes() 
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.DirtBlock, 10);
                recipe.AddIngredient(ItemID.Acorn, 1);
                recipe.AddTile(TileID.WorkBenches);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}