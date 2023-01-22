﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Infernus.Items.Pets
{
	public class CrabBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Horseshoe Crab");
			Description.SetDefault("A Horseshoe Crab is following you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[ModContent.ProjectileType<CrabPet>()] <= 0)
			{
				Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center, Vector2.Zero, ModContent.ProjectileType<CrabPet>(), 0, 0f, player.whoAmI);
			}
		}
	}
}
