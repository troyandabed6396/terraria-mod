using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Core.Items.Misc {
    public class Dogecoin : ModItem {
        public override string Texture => "TestMod/Sprites/Items/Misc/Dogecoin";
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dogecoin");
            Tooltip.SetDefault("See the president of Reddit Island to buy some cool wares (wholesome chungus real)");
        }

        public override void SetDefaults() {
            item.width = 28;
            item.height = 28;
            item.rare = ItemRarityID.Expert;
            item.maxStack = 999;
            item.value = -1;
        }
    }
}