using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Projectiles
{

    public class SwordProjecilte : ModProjectile
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
            Projectile.penetrate = 3;
            Projectile.netImportant = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 80;
        }
        public override void AI()
        {
            Projectile.spriteDirection = Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();
            Projectile.rotation = Projectile.velocity.ToRotation() + (Projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);
            if (Main.rand.NextBool(5))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Firework_Yellow, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), target.Center.X, target.Center.Y, 0, 0, ProjectileID.DaybreakExplosion, (int)(damage * 1.20f), 0, Projectile.owner);
        }
    }
}