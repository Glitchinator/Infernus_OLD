using Terraria;
using Terraria.ModLoader;

namespace Infernus.Buffs
{
	public class RaikoBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Raiko's Flames");
			Description.SetDefault("\"The fire burns brightly\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = false;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minion2>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
			}
			else
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}
