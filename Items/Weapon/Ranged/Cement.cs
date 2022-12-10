using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Ranged
{
    public class Cement : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rouge Ball");
            Tooltip.SetDefault("Bounces a lot");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 26;
            Item.height = 26;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 3;
            Item.value = Item.buyPrice(0, 8, 50, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item19;
            Item.shootSpeed = 15f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Cement>();
            Item.autoReuse = true;
            Item.noUseGraphic = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("IronBar", 3);
            recipe.AddIngredient(ModContent.ItemType<Materials.Gravel>(), 12);
            recipe.AddIngredient(ModContent.ItemType<Materials.Gaming>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}