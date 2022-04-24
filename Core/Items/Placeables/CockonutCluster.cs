using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace TestMod.Core.Items.Placeables
{
    public class CockonutCluster : ModItem
    {
        public override string Texture => "TestMod/Sprites/Items/Placeables/Cockonut";
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("SIR POOPERGY");
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
            item.createTile = ModContent.TileType<Core.Tiles.Blocks.CockonutCluster>();
        }
    }
}
