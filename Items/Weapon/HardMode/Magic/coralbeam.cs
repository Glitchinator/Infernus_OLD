using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.HardMode.Magic
{
    public class coralbeam : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sea Prism");
            Tooltip.SetDefault("Shoots 4 beams, 2 from staff, 2 from sky");
            Item.staff[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 58;
            Item.DamageType = DamageClass.Magic;
            Item.width = 36;
            Item.height = 36;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.useStyle = 5;
            Item.knockBack = 3;
            Item.value = Item.buyPrice(0, 24, 50, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item9;
            Item.noMelee = true;
            Item.shoot = ProjectileID.HeatRay;
            Item.autoReuse = true;
            Item.shootSpeed = 26f;
            Item.mana = 12;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ShadowbeamStaff, 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapon.HardMode.Magic.coralst>(), 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 2;

            for (int i = 0; i < NumProjectiles; i++)
            {

                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(3));


                newVelocity *= 1f - Main.rand.NextFloat(.2f);

                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 2; i++)
            {
                type = ProjectileID.HeatRay;
                position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
                position.Y -= 100 * i;
                Vector2 heading = target - position;

                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }

                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }

                heading.Normalize();
                heading *= velocity.Length();
                heading.Y += Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, ceilingLimit);
            }

            return false;
        }
    }
}