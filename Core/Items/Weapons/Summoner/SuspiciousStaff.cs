using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TestMod.Core.Buffs;
using TestMod.Core.Projectiles;
using Microsoft.Xna.Framework;

namespace TestMod.Core.Items.Weapons.Summoner {
    public class SuspiciousStaff : ModItem {
        public override string Texture => "TestMod/Sprites/Items/Weapons/Summoner/SuspiciousStaff";

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Suspicious Staff");
            Tooltip.SetDefault("Summons amongi (real)");
        }

        public override void SetDefaults() {
			item.damage = 69000;
			item.knockBack = 3f;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.buyPrice(0, 30, 0, 0);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item44;
			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<Sus>();
			item.shoot = ModContent.ProjectileType<SussyBaka>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			player.AddBuff(item.buffType, 2);

			// Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position.
			position = Main.MouseWorld;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}