using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Infernus.Projectiles
{

    public class Lightning : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ligtning Bolt");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.FrostburnArrow);
            AIType = ProjectileID.FrostburnArrow;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.netImportant = true;
        }

        public override bool PreKill(int timeLeft)
        {
            Projectile.type = ProjectileID.FrostburnArrow;
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.NextBool(2))
            {
                target.AddBuff(BuffID.Frostburn2, 300);
            }

            {
                for (int i = 0; i < 2; i++)
                {
                    int a = Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * 1f, Main.rand.Next(-10, -5) * .25f, ProjectileID.ThunderSpearShot, (int)(Projectile.damage * .25f), 0, Projectile.owner);
                    Main.projectile[a].aiStyle = 1;
                    Main.projectile[a].tileCollide = true;
                }
            }
            Projectile.Kill();
        }
    }
}