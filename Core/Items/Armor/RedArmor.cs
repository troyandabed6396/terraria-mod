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
                Tooltip.SetDefault("Quite the suspicious helmet...");
            }

            public override void SetDefaults() {
                item.width = 18;
                item.height = 18;
                item.value = 69;
                item.rare = ItemRarityID.Blue;
                item.defense = 4;
            }

            public override void UpdateEquip(Player player) {
                player.confused = true;
                player.AddBuff(BuffID.Confused, 0, true);
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
        [AutoloadEquip(EquipType.Legs)]
        public class RedLeggings : ModItem {
            public override string Texture => "TestMod/Sprites/Items/Armor/Red/RedLeggings";
            public override void SetStaticDefaults() {
                DisplayName.SetDefault("Red Leggings");
                Tooltip.SetDefault("Quite the suspicious drip...");
            }

            public override void SetDefaults() {
                item.width = 18;
                item.height = 18;
                item.value = 420;
                item.rare = 3;
                item.defense = 0;
            }

            public override void UpdateEquip(Player player) {
                player.meleeDamage *= 3.5f;
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