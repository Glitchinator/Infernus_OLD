using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Accesories
{
    public class Charge : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Charger");
            Tooltip.SetDefault("+8% Summon damage + 1 Minion");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.Size = new Vector2(20);
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 4, 65, 0);
            Item.rare = ItemRarityID.Green;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Summon) += .08f;
            player.maxMinions++;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Accesories.Throwing>(), 1);
            recipe.AddIngredient(ItemID.Obsidian, 8);
            recipe.AddIngredient(ItemID.TissueSample, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
