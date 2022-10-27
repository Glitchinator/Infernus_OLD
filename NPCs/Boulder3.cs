using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.NPCs
{
	public class Boulder3 : ModNPC
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crumbling Boulder");
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 204;
			NPC.damage = 16;
			NPC.defense = 19;
			NPC.knockBackResist = 0.0f;
			NPC.width = 100;
			NPC.height = 80;
			NPC.aiStyle = 49;
			NPC.noGravity = true;
			NPC.noTileCollide = false;
			NPC.HitSound = SoundID.NPCHit7;
			NPC.DeathSound = SoundID.NPCDeath41;
            Banner = Item.NPCtoBanner(NPCID.RockGolem);
            BannerItem = Item.BannerToItem(Banner);
            NPC.value = Item.buyPrice(0, 0, 3, 0);
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.netMode == NetmodeID.Server)
			{
				return;
			}
			if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 1, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.2f);
				}
				{
					for (int k = 0; k < damage / NPC.lifeMax * 50.0; k++)
					{
						Dust.NewDust(NPC.position, NPC.width, NPC.height, 1, (float)hitDirection, -1f, 0, default(Color), 1.2f);
					}
				}
			}
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.Rock>(), 4, 1, 2));
			if (NPC.downedBoss3)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.Ranged.July4th>(), 70, 1, 1));
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
				new FlavorTextBestiaryInfoElement("A boulder mad that you killed Raiko, now rains rocks on you")
			});
		}
        public override void OnKill()
        {
            DownedBoss.downedBoulderInvasionPHM = true;
        }
    }
}