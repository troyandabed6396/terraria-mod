using Terraria.ModLoader;
using TestMod.Core;
using TestMod.Core.Items.Misc;
using Terraria;
using Terraria.GameContent.UI;

namespace TestMod
{
	public class TestMod : Mod {
		public static int dogecoin;
		public TestMod() {}
		public override void Load() {
			dogecoin = CustomCurrencyManager.RegisterCurrency(new DogecoinCurrency(ModContent.ItemType<Dogecoin>(), 999L));
		}
	}
}