﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Projectiles
{

    public class EqualSword : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magic Sword");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Bullet);
            AIType = ProjectileID.Bullet;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.height = 18;
            Projectile.width = 102;
            Projectile.hostile = false;
            Projectile.netImportant = true;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
    }
}