using Terraria;
using Terraria.ModLoader;

namespace TestMod.Core.Buffs {
    public class WOKKED : ModBuff {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("WOKKED");
            Description.SetDefault("You smell what the Rock is cooking");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}