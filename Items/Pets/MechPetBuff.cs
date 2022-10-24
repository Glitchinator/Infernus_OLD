using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Infernus.Items.Pets
{
	public class MechPetBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Eye");
			Description.SetDefault("A confused Eye is following you");

			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;

			int projType = ModContent.ProjectileType<MechPet>();

			if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0)
			{
				var entitySource = player.GetSource_Buff(buffIndex);

				Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
			}
		}
	}
}
