using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace TestMod.Core.Items.Equipables.Mounts.DripMobile
{
    public class DripMobileMountBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Drip Mobile");
            Description.SetDefault("hecka drip");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(mod.MountType("DripMobileMount"), player);
            player.buffTime[buffIndex] = 10;
        }
    }
}
