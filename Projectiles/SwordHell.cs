using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Projectiles
{

    public class SwordHell : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sword Slash");
        }
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.width = 60;
            Projectile.height = 124;
            Projectile.netImportant = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 70;
        }
        public override void AI()
        {
            Projectile.spriteDirection = Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();
            Projectile.rotation = Projectile.velocity.ToRotation() + (Projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);
            if (Main.rand.NextBool(2))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), target.Center.X, target.Center.Y, Main.rand.Next(-5, 6), Main.rand.Next(-5, -5), ProjectileID.Flames, damage, 0, Projectile.owner);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), target.Center.X, target.Center.Y, Main.rand.Next(-5, 6), Main.rand.Next(-5, -5), ProjectileID.Flames, damage, 0, Projectile.owner);
        }
    }
}