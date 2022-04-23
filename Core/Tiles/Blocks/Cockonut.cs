using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;


namespace TestMod.Core.Tiles.Blocks {
    public class Cockonut : ModTile {
        public override void SetDefaults() {
            TileID.Sets.Ore[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileValue[Type] = 869;
            Main.tileShine[Type] = 975;
            Main.tileShine2[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileFrameImportant[Type] = true;

            ModTranslation name = CreateMapEntryName();
			name.SetDefault("Cockonut");
			AddMapEntry(new Color(255, 255, 255), name);

			dustType = DustID.CosmicCarKeys;
			drop = ModContent.ItemType<Core.Items.Placeables.Cockonut>();
            soundType = SoundID.Tink;
			soundStyle = 1;
        }
    }
}