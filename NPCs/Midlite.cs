using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.NPCs
{
	public class Midlite : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Midlite");
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 18;
			NPC.damage = 16;
			NPC.defense = 3;
			NPC.knockBackResist = 0.9f;
			NPC.width = 40;
			NPC.height = 40;
			NPC.aiStyle = 2;
			NPC.noGravity = false;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.Item62;
			NPC.DeathSound = SoundID.NPCDeath14;
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
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 4f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
				}
				int frontGoreType = Mod.Find<ModGore>("Shot").Type;

				var entitySource = NPC.GetSource_Death();
				for (int i = 0; i < 1; i++)
				{
					Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
				}
			}
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
				new FlavorTextBestiaryInfoElement("Strange to say that a Meteorite came to life, but its even stranger trying to figure out where the smaller ones come from.")
			});
		}
	}
}