using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Projectiles
{
	public class Mechhands : ModProjectile
	{
		public override void SetStaticDefaults()
		{

			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
		}
		public override void SetDefaults()
		{
			Projectile.width = 24;
			Projectile.height = 22;

			Projectile.aiStyle = 0;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 600;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int a = Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.SuperStarSlash, (int)(Projectile.damage * 1.4f), 0, Projectile.owner);
            Main.projectile[a].aiStyle = 1;
            Main.projectile[a].tileCollide = true;
        }

        public override void AI()
		{
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            float maxDetectRadius = 1000f;
			float projSpeed = 27f;

			NPC closestNPC = FindClosestNPC(maxDetectRadius);
			if (closestNPC == null)
				return;

			Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
			Projectile.rotation = Projectile.velocity.ToRotation();

			Projectile.velocity.Y += Projectile.ai[0];
		}

		public NPC FindClosestNPC(float maxDetectDistance)
		{
			NPC closestNPC = null;

			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			for (int k = 0; k < Main.maxNPCs; k++)
			{
				NPC target = Main.npc[k];
				if (target.CanBeChasedBy())
				{
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					if (sqrDistanceToTarget < sqrMaxDetectDistance)
					{
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}
	}
}