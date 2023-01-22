using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Infernus.Projectiles
{

    public class plant : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pistol Shot");
        }
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.netImportant = true;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.timeLeft = 240;
        }
        public override void AI()
        {

            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 30f)
            {
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, -7, 0, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, 7, 0, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, 0, 7, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, 0, -7, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, -7, -7, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, 7, -7, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, -7, 7, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, 7, 7, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.ai[0] = 0f;
                Projectile.netUpdate = true;
            }
            Projectile.velocity.X = Projectile.velocity.X * .98f;
            Projectile.velocity.Y = Projectile.velocity.Y * .98f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            {
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, -7, 0, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, 7, 0, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, 0, 7, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, 0, -7, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, -7, -7, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, 7, -7, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, -7, 7, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.position.X + 40, Projectile.position.Y + 40, 7, 7, 221, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
            }
            Projectile.Kill();
        }
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y, Main.rand.Next(0, 0) * 0f, Main.rand.Next(0, 0) * 0f, ProjectileID.PrincessWeapon, (int)(Projectile.damage * 2f), 0, Projectile.owner);
        }
    }
}