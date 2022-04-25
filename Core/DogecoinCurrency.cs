using Terraria;
using Terraria.GameContent.UI;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace TestMod.Core {
    public class DogecoinCurrency : CustomCurrencySingleCoin {
        public Color coinTextColor = Color.Gold;
        public DogecoinCurrency(int coinItemID, long currencyCap) : base(coinItemID, currencyCap) {}

        public override void GetPriceText(string[] lines, ref int currentLine, int price) {
			Color color = coinTextColor * ((float)Main.mouseTextColor / 255f);
			lines[currentLine++] = string.Format("[c/{0:X2}{1:X2}{2:X2}:{3} {4} {5}]", new object[]
				{
					color.R,
					color.G,
					color.B,
					Language.GetTextValue("LegacyTooltip.50"),
					price,
					"Dogecoin"
				});
		}
    }
}