﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items
{
    public class Key : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Construction Key");
            Tooltip.SetDefault("Why you always chasing me? (Why me)");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 46;
            Item.height = 46;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 0, 85, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item79;
            Item.noMelee = true;
            Item.mountType = ModContent.MountType<ConstructionMount>();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Materials.Gaming>(), 30)
            .AddRecipeGroup(RecipeGroupID.IronBar, 16)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}