using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Projectiles
{
    public class HomingBoss : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy BLAST");
        }

        public sealed override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.HallowBossRainbowStreak);
            AIType = ProjectileID.HallowBossRainbowStreak;
            Projectile.width = 60;
            Projectile.height = 60;
            Projectile.tileCollide = false;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = 2;
            Projectile.netImportant = true;
            Projectile.netUpdate = true;
        }
        public override bool? CanCutTiles()
        {
            return false;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.X * 0.02f;

            Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
            Dust dust = Dust.NewDustPerfect(dustPosition, DustID.Clentaminator_Red, null, 100, Color.Red, 1.4f);
            dust.velocity *= 0.3f;
            dust.noGravity = false;
        }
    }
}