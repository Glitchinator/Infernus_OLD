using Terraria;
using Terraria.ModLoader;

namespace Infernus.Buffs
{
	public class IcyBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icy Defender");
			Description.SetDefault("\"The Icy Defender will beam things for you\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = false;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Ice_Arms>()] > 0)
			{
                if (Main.LocalPlayer.GetModPlayer<InfernusPlayer>().Tiara_Equipped == true)
                {
                    player.buffTime[buffIndex] = 18000;
                }
            }
			else
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Ice_Arms>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Ice_Arms>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}
