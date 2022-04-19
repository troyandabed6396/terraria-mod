using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TestMod.Core.Items.Misc {
    public class TheWok : ModItem {
        public override string Texture => "TestMod/Sprites/Items/Misc/TheWok";
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("The Wok");
        }

        public override void SetDefaults() {
            item.width = 32;
            item.height = 32;
            item.value = Item.buyPrice(69, 0, 0, 0);
			item.rare = ItemRarityID.Expert;
        }
    }
}