using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Accesories
{
    public class Throwing : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Drone Charger");
            Tooltip.SetDefault("+8% Summon damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.Size = new Vector2(20);
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 2, 45, 0);
            Item.rare = ItemRarityID.Green;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Summon) += .08f;
        }
    }
}
