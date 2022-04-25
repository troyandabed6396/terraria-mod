using Terraria.ModLoader;
using TestMod.Core;
using TestMod.Core.Items.Misc;
using Terraria;
using Terraria.GameContent.UI;

namespace TestMod
{
	public class TestMod : Mod {
		public static int dogecoin;
		public override void Load() {
			int dogecoin = CustomCurrencyManager.RegisterCurrency(new DogecoinCurrency(ModContent.ItemType<Dogecoin>(), 999L));
		}
	}
}