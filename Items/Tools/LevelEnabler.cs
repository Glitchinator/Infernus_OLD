using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Tools
{
    public class LevelEnabler : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventure Mode");
            Tooltip.SetDefault("Your journey awaits, with fortune and fame..."
                + "\n Enables or Disables the Level System"
                + "\n The Level System adds levels and XP to Terraria"
                 + "\n when you reach the max xp you gain 1 level"
                 + "\n there are a max of 50 levels each give stat bonuses"
                  + "\n mobs drop xp usually, adventure mode allows the use of it"
                  + "\n updates to Adventure Mode will come later");
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