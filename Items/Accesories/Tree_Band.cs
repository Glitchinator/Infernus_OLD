﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Accesories
{
    public class Tree_Band : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Band of Terra");
            Tooltip.SetDefault("Increased life regen." + 
                "\n + 20 health.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 30;
            Item.accessory = true;
            Item.value = 53000;
            Item.rare = ItemRarityID.Green;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 1;
            player.statLifeMax2 += 20;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Tree_Branch>(), 1)
            .AddIngredient(ItemID.BandofRegeneration, 1)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}
