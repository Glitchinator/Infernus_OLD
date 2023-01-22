using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.Summon
{
    public class Whipice : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Iceicle Snap");
            Tooltip.SetDefault("Your minions will attack struck foes"
                                + "\n + Frostburn"
                                + "\n + 8 summon tag damage");
        }

        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Whipice>(), 32, 3, 7);
            Item.value = Item.buyPrice(0, 10, 50, 0);

            Item.shootSpeed = 5;
            Item.rare = ItemRarityID.Orange;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Materials.IceSpikes>(), 25);
            recipe.AddIngredient(ItemID.IceBlock, 36);
            recipe.AddIngredient(ModContent.ItemType<Summon.Whipaer>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override bool MeleePrefix()
        {
            return true;
        }
    }
}