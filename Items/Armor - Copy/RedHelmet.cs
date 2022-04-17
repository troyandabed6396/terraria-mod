using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Items.Armor {
    [AutoloadEquip(EquipType.Head)]
    public class RedHelmet : ModItem {
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
            player.buffImmune[BuffID.Confused] = true;
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
}