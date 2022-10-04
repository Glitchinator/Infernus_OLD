using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Tiles;
using Terraria.GameContent.Creative;

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
            Item.Size = new Vector2(20);
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
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IceBlock, 26);
            recipe.AddIngredient(ItemID.Bone, 16);
            recipe.AddIngredient(ItemID.Cobweb, 16);
            recipe.AddIngredient(ItemID.ManaCrystal, 4);
            recipe.AddTile(ModContent.TileType<Work>());
            recipe.Register();
        }
    }
}
