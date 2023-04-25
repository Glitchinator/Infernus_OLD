﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Accesories
{
    public class Drill_Bit : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shattered Drill");
            Tooltip.SetDefault("Increased mining speed."
                + "\n 'Did I hear a rock and stone?'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 26;
            Item.accessory = true;
            Item.value = 45000;
            Item.rare = ItemRarityID.Green;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.pickSpeed -= 7;
        }
    }
}
