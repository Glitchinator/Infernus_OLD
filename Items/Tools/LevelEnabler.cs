using log4net.Core;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Humanizer.On;

namespace Infernus.Items.Tools
{
    public class LevelEnabler : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventure Mode");
            Tooltip.SetDefault("Your journey awaits, with fortune and fame..."
                 + "\n 40% Increase Health and 40% Increased Damage of Bosses"
                + "\n Adds custom AI to these bosses (Temporal Glow Squid, Raiko, Ruderibus)"
                + "\n Enables or Disables the Level System"
                + "\n The Level System adds levels and XP to Terraria"
                 + "\n You gain XP by killing enemies"
                 + "\n When you reach the max XP you gain 1 level"
                 + "\n There are a max of 50 levels each give stat bonuses"
                  + "\n Updates to Adventure Mode will come later"
                  + "\n Version 1.1 (Boss AI changes, No more XP item to collect and bug Fixes)");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 2;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 36;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = 0;
            Item.rare = ItemRarityID.Master;
        }
        public override bool? UseItem(Player player)
        {
            if (DownedBoss.Level_systemON == true)
            {
                DownedBoss.Level_systemON = false;
                Main.NewText("Adventure Mode disabled, don't want the fun?", InfernusPlayer.GainXP_Resource);
                return true;
            }
            else if (DownedBoss.Level_systemON == false)
            {
                DownedBoss.Level_systemON = true;
                Main.NewText("Adventure Mode activated, let it begin!", InfernusPlayer.GainXP_Resource);
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .Register();
        }
    }
}