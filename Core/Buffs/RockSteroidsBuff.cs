using Terraria;
using Terraria.ModLoader;


namespace TestMod.Core.Buffs
{
    public class RockSteroidsBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Stronk");
            Description.SetDefault("we stay hungry we devour");
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeDamage += 0.5f;
            player.rangedDamage += 0.5f;
            player.magicDamage += 0.5f;
            player.minionDamage += 0.5f;
            player.statLifeMax2 += 60;
        }
    }
}
