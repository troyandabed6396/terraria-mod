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
using TestMod.Core.NPCs;
using Terraria.ModLoader.IO;

namespace TestMod.Core.WorldGeneration {
    public class Testicles : ModWorld {
        public static bool savedKeanu;
        public override void Initialize() {
            savedKeanu = false;
        }

        public override void Load(TagCompound tag) {
		    savedKeanu = tag.GetBool("savedKeanu");
	    }

        public override TagCompound Save() {
		    return new TagCompound {
			    {"savedKeanu", savedKeanu}
		    };
	    }
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
            
            //GeneratePenis(Main.spawnTileX, Main.spawnTileY - 50);
            
        }

        int gamingKeanuSpawnX;
        int gamingKeanuSpawnY;
        private void RedditIsland(GenerationProgress progress) {
            progress.Message = "Mining Dogecoin (Chungus Wholesome)";
            Point islandCoords = new Point();
            if (Main.dungeonX > Main.spawnTileX)
                islandCoords.X =  WorldGen.genRand.Next(Main.maxTilesX - 150, Main.maxTilesX - 100);
            else 
                islandCoords.X = WorldGen.genRand.Next(100, 150);

            gamingKeanuSpawnX = islandCoords.X;
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
            gamingKeanuSpawnY = topLayer - 2;

            for (int depth = islandCoords.Y + WorldGen.genRand.Next(15, 20); depth > topLayer; depth--) {
                int tilesInRow = (int) (islandWidth * Math.Pow(islandWidth, Math.Abs(islandCoords.Y - depth) * -0.025));
                for (int width = WorldGen.genRand.Next(islandCoords.X - 2, islandCoords.X + 2) - tilesInRow/2; width < WorldGen.genRand.Next(islandCoords.X - 2, islandCoords.X + 2) + tilesInRow/2; width++) {
                    if (depth - topLayer > 3) {
                        WorldGen.TileRunner(width, depth, WorldGen.genRand.Next(1, 4), 6, TileID.Sand, true, 0, 0, true, true);
                    }
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
                WorldGen.PlaceWall(x, topLayer + 1, WallID.Dirt);
                WorldGen.PlaceWall(x, topLayer + 2, WallID.Dirt);
            }

            GeneratePenis(islandCoords.X, topLayer - 50);
        }

        private void GeneratePenis(int X, int Y) {
            int testicleLeftX = X - WorldGen.genRand.Next(3, 6);
            int testicleRightX = X + WorldGen.genRand.Next(3, 6);
            int radius = WorldGen.genRand.Next(5, 10);
            int length = WorldGen.genRand.Next(30, 40);
            for (int y = Y - radius; y <= Y + radius; y++) {
                int tilesInRow = (int) (2 * Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(Y - y, 2)));
                for (int x = testicleLeftX - tilesInRow/2; x < testicleLeftX + tilesInRow/2; x++) {
                    WorldGen.PlaceTile(x, y, TileID.Sand);
                }
                for (int x = testicleRightX - tilesInRow/2; x < testicleRightX + tilesInRow/2; x++) {
                    WorldGen.PlaceTile(x, y, TileID.Sand);
                }
            }

            for (int y = Y; y >= Y - length; y--) {
                for (int x = X - radius + radius/3; x < X + radius - radius/3; x++) {
                    WorldGen.PlaceTile(x, y, TileID.Sand);
                }
            }

            for (int y = Y - length - radius; y <= Y - length + 2; y++) {
                int tilesInRow = (int) (2 * Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(Y - length + 2 - y, 2)));
                if (tilesInRow == 0) 
                    tilesInRow = 2;
                for (int x = X - tilesInRow/2; x <= X + tilesInRow/2; x++) {
                    WorldGen.PlaceTile(x, y, TileID.Sand);
                }
            }

            for (int x = X - 1; x < X + 1; x++) {
                WorldGen.PlaceTile(x, Y - length - radius, TileType<Cockonut>());
            }
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
            if (tasks.FindIndex(genpass => genpass.Name.Equals("Shinies")) != -1) {
                tasks.Insert(tasks.FindIndex(genpass => genpass.Name.Equals("Sunflowers")) + 1, new PassLegacy("TestTile", TestTile));
                tasks.Insert(tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes")) + 1, new PassLegacy("Reddit Island", RedditIsland));
            }
        }

        public override void PostWorldGen() {
            // int gamingKeanu = NPC.NewNPC(gamingKeanuSpawnX, gamingKeanuSpawnY, NPCType<KeanuGaming>());
            int gamingKeanu = NPC.NewNPC(Main.spawnTileX, Main.spawnTileY - 5, NPCType<KeanuGaming>());
            // Main.npc[gamingKeanu].homeTileX = gamingKeanuSpawnX;
            // Main.npc[gamingKeanu].homeTileY = gamingKeanuSpawnY;
            Main.npc[gamingKeanu].direction = gamingKeanuSpawnX > Main.dungeonX ? -1 : 1;
            Main.npc[gamingKeanu].spriteDirection = Main.npc[gamingKeanu].direction;
            Main.npc[gamingKeanu].homeless = true;
        }
    }
}