using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Tools
{
    public class MechPole : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Pole");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.CanFishInLava[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 32;
            Item.value = Item.buyPrice(0, 10, 60, 0);
            Item.CloneDefaults(ItemID.ScarabFishingRod);
            Item.rare = ItemRarityID.Red;
            Item.shoot = ProjectileID.BobberHotline;
            Item.fishingPole = 68;
            Item.shootSpeed = 18f;
        }
        public override void HoldItem(Player player)
        {
            player.accFishingLine = true;
            player.accTackleBox = true;
        }
    }
}
