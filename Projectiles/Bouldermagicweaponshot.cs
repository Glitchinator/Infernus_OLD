using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Projectiles
{

    public class Bouldermagicweaponshot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mahic boulder stuff");
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
            if (Main.rand.NextBool(1))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Stone, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }
        }
        public override void Kill(int timeLeft)
        {
            int a = Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 8f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ModContent.ProjectileType<Boulder>(), (int)(Projectile.damage * 1f), 0, Projectile.owner);
            Main.projectile[a].tileCollide = false;
            Main.projectile[a].friendly = true;
            int b = Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 8f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ModContent.ProjectileType<Boulder>(), (int)(Projectile.damage * 1f), 0, Projectile.owner);
            Main.projectile[b].tileCollide = false;
            Main.projectile[b].friendly = true;
            int c = Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 8f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ModContent.ProjectileType<Boulder>(), (int)(Projectile.damage * 1f), 0, Projectile.owner);
            Main.projectile[c].tileCollide = false;
            Main.projectile[c].friendly = true;
            int d = Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 8f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ModContent.ProjectileType<Boulder>(), (int)(Projectile.damage * 1f), 0, Projectile.owner);
            Main.projectile[d].tileCollide = false;
            Main.projectile[d].friendly = true;
        }
    }
}