using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Melee
{
    public class exohal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shining Gladius");
            Tooltip.SetDefault("Shoots a homing orb");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee;
            Item.width = 75;
            Item.height = 75;
            Item.useTime = 80;
            Item.useAnimation = 18;
            Item.useStyle = 1;
            Item.knockBack = 7;
            Item.value = Item.buyPrice(0, 24, 50, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.MagnetSphereBall;
            Item.crit = 10;
            Item.shootSpeed = 12;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Ectoplasm, 8);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapon.HardMode.Melee.Coralcronk>(), 1);
            recipe.AddIngredient(ItemID.ChlorophyteClaymore, 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}