﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Infernus.Items.Pets
{
	public class RaikoPetBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mini Raiko");
			Description.SetDefault("A Baby Raiko is following you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[ModContent.ProjectileType<RaikoPet>()] <= 0)
			{
				Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center, Vector2.Zero, ModContent.ProjectileType<RaikoPet>(), 0, 0f, player.whoAmI);
			}
		}
	}
}
