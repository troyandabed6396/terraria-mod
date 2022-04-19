using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace TestMod.Core.Items.Placeables
{
    public class TestTile : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("WWWW");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
			item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = ModContent.TileType<Core.Tiles.Blocks.TestTile>();
        }
    }
}
