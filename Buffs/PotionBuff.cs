using Terraria;
using Terraria.ModLoader;

namespace Infernus.Buffs
{
	public class PotionBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Calamari Rage");
			Description.SetDefault("\"Boost to Defense, Regen, Damage, Crit and Damage Reduction\"");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense += 5;
			player.lifeRegen += 3;
			player.GetDamage(DamageClass.Generic) += .1f;
			player.GetCritChance(DamageClass.Generic) += 6;
			player.endurance = .06f - (0.1f * (1f - player.endurance));
		}
	}
}
