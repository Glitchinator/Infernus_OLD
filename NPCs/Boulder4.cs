using Infernus.Placeable;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.NPCs
{
    public class Boulder4 : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iron Mauler");
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 196;
            NPC.damage = 16;
            NPC.defense = 21;
            NPC.knockBackResist = 0.1f;
            NPC.width = 42;
            NPC.height = 40;
            NPC.aiStyle = 23;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit7;
            NPC.DeathSound = SoundID.NPCDeath41;
            Banner = Item.NPCtoBanner(NPCID.RockGolem);
            BannerItem = Item.BannerToItem(Banner);
            NPC.value = 35;
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
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Stone, 2.5f * hitDirection, -2.5f, 0, default, 1.2f);
                }
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.IronOre, 25, 7, 14));
            npcLoot.Add(ItemDropRule.Common(ItemID.LeadOre, 25, 7, 14));
            npcLoot.Add(ItemDropRule.Common(ItemID.StoneBlock, 1, 4, 6));
            npcLoot.Add(ItemDropRule.Common(ItemID.BoulderStatue, 95, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Rock>(), 4, 2, 3));
            if (NPC.downedBoss3)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.Ranged.July4th>(), 70, 1, 1));
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
                new FlavorTextBestiaryInfoElement("Spinning mass of iron and lead with too many eyes.")
            });
        }
        public override void OnKill()
        {
            DownedBoss.downedBoulderInvasionPHM = true;
        }
    }
}