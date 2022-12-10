using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Melee
{
    public class Light : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow's Reach");
            Tooltip.SetDefault("Inflicts bleeding and has a chance to spawn golden knifes on hit");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 5;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(0, 10, 50, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Light>();
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.crit = 6;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BoldnBash>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Murawhip>(), 1);
            recipe.AddIngredient(ModContent.ItemType<IvyWhip>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}