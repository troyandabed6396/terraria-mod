using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
// using Terraria.DataStructures;
// using Terraria.Localization;
using Terraria.ObjectData;


namespace TestMod.Core.Tiles.Blocks {
    public class CockonutCluster : ModTile {
        public override void SetDefaults() {
            Main.tileSolid[Type] = true;
            Main.tileSolidTop[Type] = true;

            Main.tileValue[Type] = 869;
            Main.tileShine[Type] = 975;
            Main.tileShine2[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
			name.SetDefault("Cockonut Cluster");
			AddMapEntry(new Color(255, 255, 255), name);

			dustType = DustID.CosmicCarKeys;
			drop = ModContent.ItemType<Core.Items.Placeables.CockonutCluster>();
            soundType = SoundID.Tink;
			soundStyle = 1;
        }
    }
}