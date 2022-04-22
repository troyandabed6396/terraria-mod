using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using TestMod.Core.Tiles.Blocks;
using static Terraria.ModLoader.ModContent;

namespace TestMod.Core.WorldGeneration {
    public class Testicles : ModWorld {
        private void Cockonut(GenerationProgress progress) {
            progress.Message = "+[--------->++<]>+.+.+[->+++<]>++.+[--->+<]>+++.-[---->+<]>++.+[----->+<]>.------------.+++.";

            for (int k = 0; k < Main.maxTilesX * (WorldGen.worldSurfaceHigh - WorldGen.worldSurface); k++) {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int) WorldGen.worldSurface, (int) WorldGen.worldSurfaceHigh);
                if (Framing.GetTileSafely(x, y).active() && Framing.GetTileSafely(x, y).type == TileID.Grass) {
                    WorldGen.KillTile(x, y);
                    WorldGen.TileRunner(x, y, 10, 10, TileType<Cockonut>());
                    // WorldGen.PlaceTile(x, y, TileType<Cockonut>());
                }
            }
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
            if (tasks.FindIndex(genpass => genpass.Name.Equals("Shinies")) != -1)
                tasks.Insert(tasks.FindIndex(genpass => genpass.Name.Equals("Sunflowers")) + 1, new PassLegacy("Cockonut", Cockonut));
        }
    }
}