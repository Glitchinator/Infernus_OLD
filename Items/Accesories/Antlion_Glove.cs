﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Accesories
{
    public class Antlion_Glove : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Glove");
            Tooltip.SetDefault("12% increased melee speed." + "\n Enables autoswing for melee weapons." + "\n Increases mining speed." );
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 22;
            Item.accessory = true;
            Item.value = 45000;
            Item.rare = ItemRarityID.Green;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Melee) += .12f;
            player.pickSpeed -= 5;
            player.autoReuseGlove = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.FeralClaws, 1)
             .AddIngredient(ModContent.ItemType<Antlion_Fist>(), 1)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}
