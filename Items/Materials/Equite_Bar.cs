using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Materials
{
    public class Equite_Bar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Equite Bar");
            Tooltip.SetDefault("It's not moldy cheese");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.rare = ItemRarityID.White;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(0, 0, 0, 15);
        }
    }
}
