using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Accesories
{
    [AutoloadEquip(EquipType.Back)]
    public class Shiny : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Raiko's Toothpaste");
            Tooltip.SetDefault("Make your teeth shine like his smile"
                + "\n Faster movement and better jump");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.Size = new Vector2(40);
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 4, 45, 0);
            Item.rare = ItemRarityID.Expert;
            Item.expert = true;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.jumpBoost = true;
            player.moveSpeed += .10f;
        }
    }
}
