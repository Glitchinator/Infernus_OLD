using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Ranged
{
    public class Electricbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shutter Bow");
            Tooltip.SetDefault("Shoots electric shots that get pulled by gravity");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 28;
            Item.height = 58;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4f;
            Item.value = Item.buyPrice(0, 23, 50, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 60f;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(3));

                newVelocity *= 1f - Main.rand.NextFloat(1f);

                Projectile.NewProjectileDirect(source, position, newVelocity, ProjectileID.MoonlordArrowTrail, damage, knockback, player.whoAmI);
            }

            return false;
        }
    }
}
