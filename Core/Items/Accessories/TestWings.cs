using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace TestMod.Core.Items.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    public class TestWings : ModItem
    {
        public override string Texture => "TestMod/Sprites/Items/Accessories/TestWings";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Test Wings");
            Tooltip.SetDefault("Test test test");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.value = 100000;
            item.rare = 8;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 50;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 1.25f;
            ascentWhenRising = 0.3f;
            maxCanAscendMultiplier = 2f;
            maxAscentMultiplier = 5f;
            constantAscend = 0.5f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 20f;
            acceleration *= 1.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
