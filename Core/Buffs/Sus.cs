using Terraria;
using Terraria.ModLoader;

namespace TestMod.Core.Buffs {
    public class Sus : ModBuff {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Suspicious");
            Description.SetDefault("Sussy bakas are summoned");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("SussyBaka")] > 0) {
                player.buffTime[buffIndex] = 18000;
            }
            else {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}