using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace TestMod.Core.Tiles.Blocks
{

    public class TestTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;

            dustType = DustID.Stone;
            drop = ModContent.ItemType<Core.Items.Placeables.TestTile>();
            AddMapEntry(new Color(200, 200, 200));
        }
    }
}

