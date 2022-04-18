using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace TestMod.Core.Items.Equipables.Mounts.DripMobile
{

    public class DripMobileMount : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.spawnDust = DustID.YellowTorch;
            mountData.buff = mod.BuffType("DripMobileMountBuff");
            mountData.heightBoost = 10;
            mountData.fallDamage = 1f;
            mountData.runSpeed = 15f;
            mountData.dashSpeed = 8f;
            mountData.flightTimeMax = 50;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 2;
            mountData.acceleration = 0.4f;
            mountData.jumpSpeed = 1.5f;
            mountData.blockExtraJumps = false;
            mountData.constantJump = true;
            mountData.totalFrames = 1;
            
            int[] offset = new int[1];
            offset[0] = 10;
            mountData.playerYOffsets = offset;
            mountData.xOffset = 0;
            mountData.bodyFrame = 0;
            mountData.yOffset = 5;
            mountData.playerHeadOffset = 20;

            mountData.standingFrameCount = 1;
            mountData.standingFrameDelay = 12;
            mountData.standingFrameStart = 0;

            mountData.runningFrameCount = 1;
            mountData.runningFrameDelay = 12;
            mountData.runningFrameStart = 0;

            mountData.flyingFrameCount = 1;
            mountData.flyingFrameDelay = 12;
            mountData.flyingFrameStart = 0;

            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 0;

            mountData.idleFrameCount = 0;
            mountData.idleFrameDelay = 0;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = false;

            mountData.swimFrameCount = 0;
            mountData.swimFrameDelay = 0;
            mountData.swimFrameStart = 0;


            if(Main.netMode!=2)
            {
                mountData.textureWidth = mountData.frontTexture.Width;
                mountData.textureHeight = mountData.frontTexture.Height;

                mountData.backTexture = null;
                mountData.backTextureExtra = null;
                mountData.frontTextureExtra = null;
            }

        }
    }
}
