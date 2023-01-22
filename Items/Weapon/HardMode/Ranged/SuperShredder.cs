using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Ranged
{
    public class SuperShredder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Shredder");
            Tooltip.SetDefault("Doomguy's favorite"
                  + "\n Left click shoot, Right click hook");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 58;
            Item.height = 20;
            Item.useAnimation = 55;
            Item.useTime = 55;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 9;
            Item.value = Item.buyPrice(0, 27, 50, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item36;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 14f;
            Item.crit = 8;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            if (player.altFunctionUse == 2)
            {
                const int NumProjectiles = 1;

                for (int i = 0; i < NumProjectiles; i++)
                {
                    type = ProjectileID.SkeletronHand;
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(4));


                    newVelocity *= 1f - Main.rand.NextFloat(.1f);

                    Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                }
            }
            else
            {
                const int NumProjectiles = 6;

                for (int i = 0; i < NumProjectiles; i++)
                {

                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(4));


                    newVelocity *= 1f - Main.rand.NextFloat(.1f);

                    Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                }
            }

            return false;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {

            }
            else
            {
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.useTime = 40;
                Item.useAnimation = 40;
                Item.damage = 50;
                Item.shootSpeed = 70f;
                Item.shoot = ProjectileID.SkeletronHand;
            }
            return base.CanUseItem(player);
        }
    }
}