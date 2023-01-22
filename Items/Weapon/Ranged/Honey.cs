using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.Ranged
{
    public class Honey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rough HoneyComb");
            Tooltip.SetDefault("Explodes into stingers");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(0, 7, 50, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.honey>();
            Item.noUseGraphic = true;
            Item.shootSpeed = 12f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Cement>(), 1);
            recipe.AddIngredient(ItemID.HoneyComb, 1);
            recipe.AddIngredient(ItemID.Grenade, 100);
            recipe.AddIngredient(ItemID.Stinger, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}