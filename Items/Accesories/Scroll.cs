using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Accesories
{
    public class Scroll : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Scroll");
            Tooltip.SetDefault("Cold to the touch"
                + "\n 8% Reduced Mana Usage +20 Mana");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 6, 45, 0);
            Item.rare = ItemRarityID.Orange;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 40;
            player.manaCost -= .08f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.IceBlock, 26)
            .AddIngredient(ItemID.Bone, 16)
            .AddIngredient(ItemID.Cobweb, 16)
            .AddIngredient(ItemID.ManaCrystal, 4)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
