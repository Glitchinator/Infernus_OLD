using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Ranged
{
    public class Rifle2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plasm Licked Rifle");
            Tooltip.SetDefault("Converts bullets into spectre bullets");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 160;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 70;
            Item.height = 24;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5f;
            Item.value = Item.buyPrice(0, 23, 50, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item40;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.MoonlordBullet;
            Item.shootSpeed = 15f;
            Item.crit = 26;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = new(velocity.X * 3, velocity.Y * 3);
            position += offset;
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), position, velocity, ProjectileID.MoonlordBullet, damage, knockback, player.whoAmI);
            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Ectoplasm, 12)
            .AddIngredient(ModContent.ItemType<Weapon.Ranged.Levercoin>(), 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}
