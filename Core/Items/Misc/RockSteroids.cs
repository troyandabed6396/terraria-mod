using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace TestMod.Core.Items.Misc
{

    public class RockSteroids : ModItem
    {   
        public override string Texture => "TestMod/Sprites/Items/Misc/RockSteroids";
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("lmao");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = -12;
            item.value = 1000000;
            item.buffType = ModContent.BuffType<Buffs.RockSteroidsBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 36000;
        }
    }
}
