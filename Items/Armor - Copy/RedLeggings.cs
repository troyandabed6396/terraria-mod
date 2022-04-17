using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Items.Armor {
    [AutoloadEquip(EquipType.Legs)]
    public class RedLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Red Leggings");
            Tooltip.SetDefault("Quite the suspicious drip...");
        }

        public override void SetDefaults() {
            item.width = 40;
            item.height = 40;
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