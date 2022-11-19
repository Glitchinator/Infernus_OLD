using Terraria;
using Terraria.ModLoader;

namespace Infernus.Buffs
{
	public class GoblinBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow phantoms");
			Description.SetDefault("\"Wait... It's on my side\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = false;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.TGoblinM>()] > 0)
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
