using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TestMod.Core.Buffs;

namespace TestMod.Core {
    public class AmongPlayer : ModPlayer {
        public bool gaveWok = false;
        public override TagCompound Save() {
            return new TagCompound {
                {"gaveWok", gaveWok}
            };
        }

        public override void Load(TagCompound tag) {
            gaveWok = tag.GetBool("gaveWok");
        }
    }
}