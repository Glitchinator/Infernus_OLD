﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Infernus.Projectiles
{

    public class honey : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Honey Grenade");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ThrowingKnife);
            AIType = ProjectileID.ThrowingKnife;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.netImportant = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            {
                for (int i = 0; i < 4; i++)
                {
                    Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.StyngerShrapnel, (int)(damage * .25f), 0, Projectile.owner);
                }
            }
            Projectile.Kill();
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            {
                for (int i = 0; i < 4; i++)
                {
                    Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.StyngerShrapnel, (int)(Projectile.damage * .25f), 0, Projectile.owner);
                }
            }
            Projectile.Kill();
            return true;
        }
    }
}