using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Projectiles
{

    public class Bouldermagicweaponshot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magic boulder stuff");
        }
        public override void SetDefaults()
        {
            AIType = ProjectileID.Bullet;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.height = 16;
            Projectile.width = 16;
            Projectile.hostile = false;
            Projectile.timeLeft = 250;
            Projectile.netImportant = true;
        }
        public override void AI()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Stone, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }
        }
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y, Main.rand.Next(-10, 11), Main.rand.Next(-10, -5), ModContent.ProjectileType<Boulder>(), (int)(Projectile.damage * 1f), 0, Projectile.owner);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y, Main.rand.Next(-10, 11), Main.rand.Next(-10, -5), ModContent.ProjectileType<Boulder>(), (int)(Projectile.damage * 1f), 0, Projectile.owner);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y, Main.rand.Next(-10, 11), Main.rand.Next(-10, -5), ModContent.ProjectileType<Boulder>(), (int)(Projectile.damage * 1f), 0, Projectile.owner);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y, Main.rand.Next(-10, 11), Main.rand.Next(-10, -5), ModContent.ProjectileType<Boulder>(), (int)(Projectile.damage * 1f), 0, Projectile.owner);
        }
    }
}