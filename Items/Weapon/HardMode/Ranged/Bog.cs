using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Ranged
{
    public class Bog : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hero's Launcher");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 38;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 70;
            Item.height = 22;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6f;
            Item.value = Item.buyPrice(0, 22, 50, 0);
            Item.rare = ItemRarityID.Lime;
            Item.UseSound = SoundID.Item40;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = ProjectileID.EmeraldBolt;
            Item.shootSpeed = 20f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            for (int i = 0; i < 3; i++)
            {
                type = Main.rand.Next(new int[] { type, ProjectileID.EmeraldBolt, ProjectileID.ChlorophyteArrow, ProjectileID.Stake, ModContent.ProjectileType<Projectiles.Boulder>(), });

                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(2));


                newVelocity *= 1f - Main.rand.NextFloat(0.1f);

                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false;
        }
    }
}