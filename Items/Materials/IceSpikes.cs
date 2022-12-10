using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Materials
{
    public class IceSpikes : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Spikes");
            Tooltip.SetDefault("A cold yet sharp Icicle");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;
        }
        public override void SetDefaults()
        {
            Item.Size = new Vector2(20);
            Item.value = Item.buyPrice(0, 1, 35, 0);
            Item.rare = ItemRarityID.White;
            Item.maxStack = 999;
        }

    }
}
