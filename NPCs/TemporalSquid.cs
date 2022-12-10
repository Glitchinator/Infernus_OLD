using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Infernus.NPCs
{
	public class TemporalSquid : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Temporal Glow Squid");
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 600;
			NPC.damage = 69;
			NPC.defense = 28;
			NPC.knockBackResist = 0.0f;
			NPC.width = 80;
			NPC.height = 56;
			NPC.aiStyle = 16;
			NPC.noGravity = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.breath = 999;
			NPC.breathCounter = 999;
			AnimationType = NPCID.DemonEye;
            Banner = Item.NPCtoBanner(NPCID.Squid);
            BannerItem = Item.BannerToItem(Banner);
            NPC.value = Item.buyPrice(0, 3, 25, 0);
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.netMode == NetmodeID.Server)
			{
				return;
			}

			if (NPC.life <= 0)
			{
				for (int k = 0; k < 44; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.RedsWingsRun, 4f * hitDirection, -2.5f, 0, default, 3f);
				}
			}
		}
		public override void OnKill()
		{
			DownedBoss.downedSquid = true;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OceanMonster.Chance * .4f;
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
				new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
				new FlavorTextBestiaryInfoElement("Don't get too indulged by it's fasinating looks, these squids might be small but pack a punch.")
			});
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.BlackInk, 1, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ItemID.PinkJellyfish, 1, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.Pizza, 25, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Consumable.Potion>(), 1, 5, 8));
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			NPC.damage = (int)(NPC.damage * 1f);
			NPC.lifeMax = (int)(NPC.lifeMax = 1069);
		}
	}
}