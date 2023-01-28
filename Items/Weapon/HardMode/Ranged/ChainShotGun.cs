using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Ranged
{
    public class ChainShotGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bullet Launcher v2");
            Tooltip.SetDefault("Shoots many bullets");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 70;
            Item.height = 22;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 3f;
            Item.value = Item.buyPrice(0, 15, 50, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item36;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 14f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 8; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(35));

                newVelocity *= 1f - Main.rand.NextFloat(.6f);

                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Weapon.Ranged.Launcher>(), 1)
            .AddIngredient(ItemID.Shotgun, 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}