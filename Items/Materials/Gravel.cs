using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Materials
{
    public class Gravel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Metal Scrap");
            Tooltip.SetDefault("Reinforced plates");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;
        }
        public override void SetDefaults()
        {
            Item.Size = new Vector2(20);
            Item.value = Item.buyPrice(0, 0, 15, 0);
            Item.rare = ItemRarityID.White;
            Item.maxStack = 999;
        }

    }
}