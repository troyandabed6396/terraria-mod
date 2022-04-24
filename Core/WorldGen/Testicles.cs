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
            progress.Message = "Mining Dogecoin (Chungus Wholesome)";
            Point islandCoords = new Point();
            if (Main.dungeonX > Main.spawnTileX)
                islandCoords.X =  WorldGen.genRand.Next(Main.maxTilesX - 150, Main.maxTilesX - 100);
            else 
                islandCoords.X = WorldGen.genRand.Next(100, 150);

            for (int y = (int) WorldGen.worldSurface - 100; y < (int) WorldGen.worldSurface + 50; y++) {
                if (Framing.GetTileSafely(islandCoords.X, y).liquid > 0) {
                    islandCoords.Y = y;
                    break;
                }
            }
            // islandCoords.Y = (int) WorldGen.worldSurface;
            int islandWidth = WorldGen.genRand.Next(50, 75);
            int topLayer = islandCoords.Y - WorldGen.genRand.Next(5, 10);
            int topLayerWidth = (int) (islandWidth * Math.Pow(islandWidth, Math.Abs(islandCoords.Y - topLayer) * -0.025));

            for (int depth = islandCoords.Y + WorldGen.genRand.Next(15, 20); depth > topLayer; depth--) {
                int tilesInRow = (int) (islandWidth * Math.Pow(islandWidth, Math.Abs(islandCoords.Y - depth) * -0.025));
                for (int width = WorldGen.genRand.Next(islandCoords.X - 2, islandCoords.X + 2) - tilesInRow/2; width < WorldGen.genRand.Next(islandCoords.X - 2, islandCoords.X + 2) + tilesInRow/2; width++) {
                    if (depth - topLayer > 1)
                        WorldGen.TileRunner(width, depth, WorldGen.genRand.Next(1, 4), 6, TileID.Sand, true, 0, 0, true, true); // doesnt work btw
                    WorldGen.PlaceTile(width, depth, TileID.Sand, false, true);
                }
            }
            
            for (int x = islandCoords.X - topLayerWidth/2; x < islandCoords.X + topLayerWidth/2; x++) {
                switch (WorldGen.genRand.Next(3)) {
                    case 1:
                        WorldGen.GrowPalmTree(x, topLayer + 1);
                        break;
                    case 2:
                        WorldGen.PlaceTile(x, topLayer + 1, TileID.Sand, false, true);
                        break;
                }
                WorldGen.PlaceWall(x, topLayer + 1, WallID.Sandstone);
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