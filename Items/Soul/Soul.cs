using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Buffs;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Soul
{
    public class Soul : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stress");
            Tooltip.SetDefault("stress");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.Size = new Vector2(20);
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 6, 45, 0);
            Item.rare = ItemRarityID.Expert;
            Item.defense = 2;
            Item.expert = true;
        }
    }
}
