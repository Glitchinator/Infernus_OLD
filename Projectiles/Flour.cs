using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Projectiles
{

    public class Flour : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloom Bomb");
        }
        public override void SetDefaults()
        {
            Projectile.width = 92;
            Projectile.height = 102;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 300;
            Projectile.extraUpdates = 1;
            Projectile.tileCollide = false;
            Projectile.aiStyle = 18;
            Projectile.netImportant = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            {
                SoundEngine.PlaySound(SoundID.DD2_KoboldExplosion, Projectile.position);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y, 0, 0, ProjectileID.DD2ExplosiveTrapT3Explosion, damage, 0, Projectile.owner);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), target.Center.X, target.Center.Y, 0, 0, ProjectileID.RainbowCrystalExplosion, (int)(damage * .80f), 0, Projectile.owner);
            }
        }
    }
}