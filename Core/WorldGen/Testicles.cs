using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using TestMod.Core.Tiles.Blocks;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace TestMod.Core.WorldGeneration {
    public class Testicles : ModWorld {
        private void TestTile(GenerationProgress progress) {
            progress.Message = "+[--------->++<]>+.+.+[->+++<]>++.+[--->+<]>+++.-[---->+<]>++.+[----->+<]>.------------.+++.";

            for (int k = 0; k < Main.maxTilesX * (WorldGen.worldSurfaceHigh - WorldGen.worldSurface); k++) {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int) WorldGen.worldSurface, (int) WorldGen.worldSurfaceHigh);
                if (Framing.GetTileSafely(x, y).active() && Framing.GetTileSafely(x, y).type == TileID.Grass) {
                    WorldGen.KillTile(x, y);
                    WorldGen.TileRunner(x, y, 10, 10, TileType<TestTile>());
                    // WorldGen.PlaceTile(x, y, TileType<Cockonut>());
                }
            }
        }

        private void RedditIsland(GenerationProgress progress) {
            progress.Message = "Mining Dogecoin (Chungus Wholesome)...";
            Point islandCoords = new Point();
            if (Main.dungeonX > Main.spawnTileX)
                islandCoords.X =  WorldGen.genRand.Next(Main.maxTilesX - 150, Main.maxTilesX - 100);
            else 
                islandCoords.X = WorldGen.genRand.Next(100, 150);

            islandCoords.Y = (int) WorldGen.worldSurface - 10;
            int islandWidth = WorldGen.genRand.Next(32, 64);

            for (int depth = islandCoords.Y - WorldGen.genRand.Next(10, 20); depth < islandCoords.Y + WorldGen.genRand.Next(5, 10); depth++) {
                for (int width = islandCoords.X - islandWidth/2; width < islandCoords.X + islandWidth/2; width++) {
                    WorldGen.TileRunner(width, depth, WorldGen.genRand.Next(1, 4), 8, TileType<Cockonut>());
                }
            }
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
            if (tasks.FindIndex(genpass => genpass.Name.Equals("Shinies")) != -1) {
                tasks.Insert(tasks.FindIndex(genpass => genpass.Name.Equals("Sunflowers")) + 1, new PassLegacy("TestTile", TestTile));
                tasks.Insert(tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes")) + 1, new PassLegacy("Reddit Island", RedditIsland));
            }
        }
    }
}