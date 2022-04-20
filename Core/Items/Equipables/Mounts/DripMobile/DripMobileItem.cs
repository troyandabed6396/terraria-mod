using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace TestMod.Core.Items.Equipables.Mounts.DripMobile
{
    
    public class DripMobileKeys : ModItem
    {
        public override string Texture => "TestMod/Sprites/Items/Weapons/Ranger/ReportGun";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Drippy Keys");
            Tooltip.SetDefault("shesh big dripper");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 3.5f;
            item.value = 10001;
            item.useStyle = 25;
            item.noMelee = true;
            item.rare = -12;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/DababyLetsGo");

            item.mountType = mod.MountType("DripMobileMount");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
