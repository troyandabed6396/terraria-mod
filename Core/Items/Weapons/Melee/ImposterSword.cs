using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace TestMod.Core.Items.Weapons.Melee
{
	public class ImposterSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sussy Stabber"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("impasta");
		}

		public override void SetDefaults() 
		{
			item.damage = 100;
			item.melee = true;
			item.width = 60;
			item.height = 40;
			item.useTime = 50;
			item.useAnimation = 30;
			item.useStyle = 3;
			item.knockBack = 0;
			item.value = 10000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

        public override void MeleeEffects(Player player, Rectangle hitbox)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y+15), hitbox.Width, hitbox.Height-10, DustID.Blood, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust].velocity *= 0;
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