﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Accesories
{
    public class Antlion_Fist : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Claw");
            Tooltip.SetDefault("Increases melee and mining speed.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 28;
            Item.accessory = true;
            Item.value = 45000;
            Item.rare = ItemRarityID.Blue;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Melee) += .10f;
            player.pickSpeed -= 3;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.AntlionMandible, 3)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
