using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Melee
{
    public class IvyWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ivy Clipper");
            Tooltip.SetDefault("Shoots leafs at max range");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 5;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(0, 6, 50, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Laserivy>();
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.crit = 8;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Vine, 4);
            recipe.AddIngredient(ItemID.Stinger, 16);
            recipe.AddIngredient(ItemID.JungleSpores, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}