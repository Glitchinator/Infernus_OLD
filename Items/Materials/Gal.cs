using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Materials
{
    public class Gal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Super Plates");
            Tooltip.SetDefault("Once beared by the best mech");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;
        }
        public override void SetDefaults()
        {
            Item.Size = new Vector2(20);
            Item.value = Item.buyPrice(0, 5, 35, 0);
            Item.rare = ItemRarityID.White;
            Item.maxStack = 999;
        }

    }
}
