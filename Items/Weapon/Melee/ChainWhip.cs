using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Tiles;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Melee
{
    public class ChainWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Metalic Flail");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 5;
            Item.knockBack = 2;
            Item.value = Item.buyPrice(0, 5, 50, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Laser>();
            Item.channel = true;
            Item.shootSpeed = 6f;
            Item.noUseGraphic = true;
            Item.crit = 4;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("IronBar", 3);
            recipe.AddIngredient(ModContent.ItemType<Infernus.Items.Materials.Gravel>(), 9);
            recipe.AddIngredient(ItemID.Chain, 9);
            recipe.AddTile(ModContent.TileType<Work>());
            recipe.Register();
        }
    }
}