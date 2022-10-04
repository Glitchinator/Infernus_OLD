using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Infernus.Buffs;
using Microsoft.Xna.Framework;

namespace Infernus.Projectiles
{
	
	public class Boldsum : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 0;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.DeadlySphere);
			AIType = ProjectileID.DeadlySphere;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.tileCollide = true;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = -1;
		}
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];

            Vector2 withplayer = player.Center;
            withplayer.Y -= 48f;
            float notamongusX = (10 + Projectile.minionPos * 40) * -player.direction;
            withplayer.X += notamongusX;
            Vector2 vectorToplayer = withplayer - Projectile.Center;
            float distanceToplayer = vectorToplayer.Length();
            if (Main.myPlayer == player.whoAmI && distanceToplayer > 2000f)
            {
                Projectile.position = withplayer;
                Projectile.velocity *= 0.1f;
                Projectile.netUpdate = true;
            }

            if (player.dead || !player.active)
			{
				player.ClearBuff(ModContent.BuffType<boldBuff>());
			}
			if (player.HasBuff(ModContent.BuffType<boldBuff>()))
			{
				Projectile.timeLeft = 2;
			}
		}
		public override bool MinionContactDamage()
		{
			return true;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
          target.AddBuff(BuffID.OnFire, 300);
          target.AddBuff(BuffID.Frostburn, 300);
          target.AddBuff(BuffID.Poisoned, 300);
        }
    }
}