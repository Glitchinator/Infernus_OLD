using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Tiles;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Accesories
{
    public class CHARD : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sentinel Battery");
            Tooltip.SetDefault("+12% Summon damage + 1 Minion");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.Size = new Vector2(20);
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 5, 65, 0);
            Item.rare = ItemRarityID.Orange;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Summon) += .12f;
            player.maxMinions++;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Accesories.Charge>(), 1);
            recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Materials.Hot>(), 7);
            recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Materials.IceSpikes>(), 7);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddTile(ModContent.TileType<Work>());
            recipe.Register();
        }
    }
}
