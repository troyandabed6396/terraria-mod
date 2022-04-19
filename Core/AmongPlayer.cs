using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TestMod.Core.Buffs;

namespace TestMod.Core {
    public class AmongPlayer : ModPlayer {
        public bool wokked = false;
        public void isWokked() {
            if (wokked) {
                player.AddBuff(ModContent.BuffType<WOKKED>(), -1);
            } else if (player.HasBuff(ModContent.BuffType<WOKKED>()) && !wokked) {
                player.DelBuff(ModContent.BuffType<WOKKED>());
            }
        }
    }
}