using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Ranged
{
    public class Coral : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coral Knifes");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 32;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.value = Item.buyPrice(0, 0, 60, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.crit = 4;
            Item.shoot = ModContent.ProjectileType<Projectiles.Coral>();
            Item.shootSpeed = 16f;
            Item.maxStack = 999;
            Item.consumable = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.Coral, 2);
            recipe.Register();
        }
    }
}