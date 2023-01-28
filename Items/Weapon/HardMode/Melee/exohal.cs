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
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.DamageType = DamageClass.Melee;
            Item.width = 75;
            Item.height = 75;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 7f;
            Item.value = Item.buyPrice(0, 24, 50, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Ectoplasm, 8)
            .AddIngredient(ModContent.ItemType<Coralcronk>(), 1)
            .AddIngredient(ItemID.ChlorophyteClaymore, 1)
            .AddIngredient(ItemID.BrokenHeroSword, 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), target.Right.X, target.Right.Y, 0, 0, ProjectileID.DD2ExplosiveTrapT1Explosion, damage, 0, player.whoAmI);
        }
    }
}