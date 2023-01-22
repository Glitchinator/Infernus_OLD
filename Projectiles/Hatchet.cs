using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Infernus.Projectiles
{

    public class Hatchet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hatchet");
        }
        public override void SetDefaults()
        {
            Projectile.width = 38;
            Projectile.height = 32;
            Projectile.aiStyle = 39;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 300;
            Projectile.penetrate = 2;
            Projectile.light = 0.5f;
            Projectile.extraUpdates = 1;
            Projectile.tileCollide = false;
            Projectile.netImportant = true;


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int k = 0; k < 20; k++)
            {
                float hitDirection = 0;
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Blood, 2.5f * (float)hitDirection, -2.5f, 0, default, 1.2f);
            }
            if (Main.rand.Next(3) < 1)
            {
                if (Main.rand.Next(3) < 1)
                {
                    int a = Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 8f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.IceSickle, (int)(Projectile.damage * .50f), 0, Projectile.owner);
                    Main.projectile[a].tileCollide = false;
                    Main.projectile[a].friendly = true;
                }
            }
        }
    }
}