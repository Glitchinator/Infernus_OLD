using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Infernus.NPCs
{
	public class Ice : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ruderibus's Receivers");
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 55;
			NPC.damage = 16;
			NPC.defense = 6;
			NPC.knockBackResist = 0.9f;
			NPC.width = 44;
			NPC.height = 88;
			NPC.aiStyle = 14;
			NPC.noGravity = false;
			NPC.HitSound = SoundID.NPCHit42;
			NPC.DeathSound = SoundID.NPCDeath44;
			NPC.value = Item.buyPrice(0, 0, 10, 0);
			AnimationType = NPCID.DemonEye;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.netMode == NetmodeID.Server)
			{
				return;
			}

			if (NPC.life <= 0)
			{
				for (int k = 0; k < 1; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 16, 4f * (float)hitDirection, -2.5f, 0, default(Color), .6f);
				}
				int frontGoreType = Mod.Find<ModGore>("Ice1").Type;

				var entitySource = NPC.GetSource_Death();
				for (int i = 0; i < 2; i++)
				{
					Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType, .6f);
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OverworldDaySnowCritter.Chance * 100f;
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.BossSummon.BossSummon>(), 10, 1, 1));
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
				new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
				new FlavorTextBestiaryInfoElement("Some type of ice construct that flies around gathering information, alarmed when it sees you. But it seems it was too slow.")
			});
		}
	}
}