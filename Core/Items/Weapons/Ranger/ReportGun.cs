using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace TestMod.Core.Items.Weapons.Ranger
{
	public class ReportGun : ModItem
	{	
		public override string Texture => "TestMod/Sprites/Items/Weapons/Ranger/ReportGun";
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("REPOT!!!!1"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("L impasta");
		}

		public override void SetDefaults() 
		{
			item.damage = 1000;
			item.ranged = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = 5;
			item.knockBack = 8;
			item.value = 100000;
			item.rare = -12;
			item.UseSound = SoundID.Item40;
			item.autoReuse = false;
            item.useAmmo = AmmoID.Bullet;
            item.shoot = AmmoID.Bullet;
            item.shootSpeed = 4.5f;
            item.noMelee = true;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 offset = new Vector2(speedX * 3, speedY * 3);
            position += offset;
            return true;
        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 15);
            recipe.AddIngredient(ItemID.DemoniteBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.IronBar, 15);
            recipe2.AddIngredient(ItemID.CrimtaneBar, 5);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();

            ModRecipe recipe3 = new ModRecipe(mod);
            recipe3.AddIngredient(ItemID.LeadBar, 15);
            recipe3.AddIngredient(ItemID.DemoniteBar, 5);
			recipe3.AddTile(TileID.Anvils);
			recipe3.SetResult(this);
			recipe3.AddRecipe();

            ModRecipe recipe4 = new ModRecipe(mod);
            recipe4.AddIngredient(ItemID.LeadBar, 15);
            recipe4.AddIngredient(ItemID.CrimtaneBar, 5);
			recipe4.AddTile(TileID.Anvils);
			recipe4.SetResult(this);
			recipe4.AddRecipe();
		}
	}
}