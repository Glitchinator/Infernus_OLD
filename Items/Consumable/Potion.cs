﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Consumable
{
    public class Potion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Calamari Rage");
            Tooltip.SetDefault("Gives a boost to most stats");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(0, 0, 0, 2);
            Item.buffType = ModContent.BuffType<Buffs.PotionBuff>();
            Item.buffTime = 32400;
        }
    }
}
