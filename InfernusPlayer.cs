using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus
{
    internal class InfernusPlayer : ModPlayer
    {
		public const int DashRight = 2;
		public const int DashLeft = 3;

		public const int DashCooldown = 50;
		public const int DashDuration = 35;

		public const float DashVelocity = 16f;

		public int DashDir = -1;

		public bool DoomDash;
		public int DashDelay = 0;
		public int DashTimer = 0;

		public override void ResetEffects()
		{
			DoomDash = false;

			if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[DashRight] < 15)
			{
				DashDir = DashRight;
			}
			else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[DashLeft] < 15)
			{
				DashDir = DashLeft;
			}
			else
			{
				DashDir = -1;
			}
		}

		public override void PreUpdateMovement()
		{
			if (CanUseDash() && DashDir != -1 && DashDelay == 0)
			{
				Vector2 newVelocity = Player.velocity;

				switch (DashDir)
				{
					case DashLeft when Player.velocity.X > -DashVelocity:
					case DashRight when Player.velocity.X < DashVelocity:
						{
							float dashDirection = DashDir == DashRight ? 1 : -1;
							newVelocity.X = dashDirection * DashVelocity;
							break;
						}
					default:
						return;
				}

				DashDelay = DashCooldown;
				DashTimer = DashDuration;
				Player.velocity = newVelocity;

				SoundEngine.PlaySound(SoundID.NPCDeath14, Player.position);

			}

			if (DashDelay > 0)
				DashDelay--;

			if (DashTimer > 0)
			{
				DashTimer--;
			}
		}

		private bool CanUseDash()
		{
			return DoomDash
				&& !Player.mount.Active;
		}
	}
}