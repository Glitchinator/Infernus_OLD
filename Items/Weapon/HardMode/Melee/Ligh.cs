using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.HardMode.Melee
{
    public class Ligh : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Javelin");
            Tooltip.SetDefault("Strike them down");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 56;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 28;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 0;
            Item.value = Item.buyPrice(0, 14, 50, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.crit = 6;
            Item.shoot = ModContent.ProjectileType<Projectiles.Prism>();
            Item.shoot = ModContent.ProjectileType<Projectiles.Prism>();
            Item.shootSpeed = 20f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddIngredient(ItemID.SoulofLight, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
