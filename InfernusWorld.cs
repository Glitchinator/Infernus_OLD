using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Infernus.Invas;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Infernus
{
    public class InfernusWorld : ModSystem
    {
        public static bool BoulderInvasionUp = false;
        public static bool downedBoulderInvasion = false;

        public override void OnWorldLoad()
        {
            Main.invasionSize = 0;
            BoulderInvasionUp = false;
            downedBoulderInvasion = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();
            if (downedBoulderInvasion) downed.Add("BoulderInvasion");

            new TagCompound {
                {"downed", downed}
            };
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedBoulderInvasion = downed.Contains("BoulderInvasion");
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedBoulderInvasion;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedBoulderInvasion = flags[0];
        }

        public override void PostUpdateWorld()
        {
            if (BoulderInvasionUp)
            {
                if (Main.invasionX == Main.spawnTileX)
                {
                    BoulderInvasion.CheckInvasionProgress();
                }
                BoulderInvasion.UpdateDungeonInvasion();
            }
        }
		public override void PostSetupContent()
		{
			DoBossChecklistIntegration();
		}
		/// Boss Checklist bugs

		/// DONT put a tile of any sort in collection. It bugs and breaks, it only allows if it's loaded from a enemy. So have the item in the enemies loot pool,
		/// but don't let it be dropped. No tile, None. Boss Checklist hates it.

		/// DONT TOUCH THE VERSION. That is a kill switch if it fails to load. DONT TOUCH IT.
		private void DoBossChecklistIntegration()
		{

			if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklistMod))
			{
				return;
			}
			if (bossChecklistMod.Version < new Version(1, 3, 1))
			{
				return;
			}
			string bossName = "Raiko";

			int bossType = ModContent.NPCType<NPCs.Raiko>();

			float weight = 2.4f;

			Func<bool> downed = () => DownedBoss.downedRaiko;

			Func<bool> available = () => true;

			List<int> collection = new List<int>()
			{
				ModContent.ItemType<Placeable.RaikoRelic>(),
				ModContent.ItemType<Items.Pets.RaikoPetItem>(),
				ModContent.ItemType<Placeable.Trophy>(),
                ModContent.ItemType<Items.Weapon.Meteor>(),
                ModContent.ItemType<Items.Weapon.Ranged.Firebow>(),
                ModContent.ItemType<Items.Weapon.Magic.MeteorEater>(),
                ModContent.ItemType<Items.Weapon.Melee.BoldnBash>(),
                ModContent.ItemType<Items.Weapon.Summon.Minion>(),
				ModContent.ItemType<Items.Tools.Day>()
			};

			int summonItem = ModContent.ItemType<Items.BossSummon.Boss1sum>();

			string spawnInfo = $"Use a [i:{summonItem}]";

			string despawnInfo = null;

			var customBossPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Infernus/BossChecklist/Raiko").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};

			bossChecklistMod.Call(
				"AddBoss",
				Mod,
				bossName,
				bossType,
				weight,
				downed,
				available,
				collection,
				summonItem,
				spawnInfo,
				despawnInfo,
				customBossPortrait
			);


			string bossName1 = "Ruderibus";

			int bossType1 = ModContent.NPCType<NPCs.Ruderibus>();

			float weight1 = 5.8f;

			Func<bool> downed1 = () => DownedBoss.downedRuderibus;

			Func<bool> available1 = () => true;

			List<int> collection1 = new List<int>()
			{
				ModContent.ItemType<Placeable.RudeRelic>(),
				ModContent.ItemType<Items.Pets.RudeItem>(),
				ModContent.ItemType<Placeable.RudeTrophy>(),
				ModContent.ItemType<Items.Materials.IceSpikes>(),
				ItemID.FlurryBoots,
				ItemID.IceMirror,
				ItemID.IceBoomerang,
				ItemID.IceBlade,
				ItemID.BlizzardinaBottle,
				ItemID.SnowballCannon,
				ItemID.IceSkates,
				ItemID.IceMachine,
				ItemID.Fish,
			};

			int summonItem1 = ModContent.ItemType<Items.BossSummon.BossSummon>();

			string spawnInfo1 = $"Use a [i:{summonItem1}]";

			string despawnInfo1 = null;

			var customBossPortrait1 = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Infernus/BossChecklist/Ruderibus").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};

			bossChecklistMod.Call(
				"AddBoss",
				Mod,
				bossName1,
				bossType1,
				weight1,
				downed1,
				available1,
				collection1,
				summonItem1,
				spawnInfo1,
				despawnInfo1,
				customBossPortrait1
			);



			string bossName2 = "Serphious";

			int bossType2 = ModContent.NPCType<NPCs.Shark>();

			float weight2 = 16.9f;

			Func<bool> downed2 = () => DownedBoss.downedTigerShark;

			Func<bool> available2 = () => true;

			List<int> collection2 = new List<int>()
			{
				ModContent.ItemType<Placeable.SharkRelic>(),
				ModContent.ItemType<Placeable.SharkTrophy>(),
				ModContent.ItemType<Items.Weapon.HardMode.Accessories.eleScale>(),
				ModContent.ItemType<Items.Weapon.HardMode.Melee.Electricice>(),
				ModContent.ItemType<Items.Weapon.HardMode.Ranged.ElectricBow>(),
				ModContent.ItemType<Items.Weapon.HardMode.Magic.Lightning>(),
				ModContent.ItemType<Items.Weapon.HardMode.Summon.whiplight>(),
				ItemID.JellyfishDivingGear,
				ItemID.WaterWalkingBoots,
				ItemID.SharkFin,
				ItemID.FloatingTube
			};

			int summonItem2 = ModContent.ItemType<Items.BossSummon.BeetleBait>();

			string spawnInfo2 = $"Use a [i:{summonItem2}]";

			string despawnInfo2 = null;

			var customBossPortrait2 = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Infernus/BossChecklist/TigerShark").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};

			bossChecklistMod.Call(
				"AddBoss",
				Mod,
				bossName2,
				bossType2,
				weight2,
				downed2,
				available2,
				collection2,
				summonItem2,
				spawnInfo2,
				despawnInfo2,
				customBossPortrait2
			);

			string minibossName = "Temporal Glow Squid";

			int minibossType = ModContent.NPCType<NPCs.TemporalSquid>();

			float miniweight = 0.9f;

			Func<bool> minidowned = () => DownedBoss.downedSquid;

			Func<bool> miniavailable = () => true;

			List<int> minicollection = new List<int>()
			{
				ModContent.ItemType<Items.Consumable.Potion>(),
				ItemID.BlackInk,
				ItemID.PinkJellyfish
			};

			int minisummonItem = ItemID.WoodenChair;

			string minispawnInfo = "Randomly spawns in ocean biome";

			string minidespawnInfo = null;

			bossChecklistMod.Call(
				"AddMiniBoss",
				Mod,
				minibossName,
				minibossType,
				miniweight,
				minidowned,
				miniavailable,
				minicollection,
				minisummonItem,
				minispawnInfo,
				minidespawnInfo
			);
            string EventName = "Boulder Invasion Pre-HM";

            int EventType = ModContent.NPCType<NPCs.Boulder5>();

            float Eventweight = 5.8f;

            Func<bool> Eventdowned = () => DownedBoss.downedBoulderInvasionPHM;

            Func<bool> Eventavailable = () => true;

            List<int> Eventcollection = new List<int>()
            {
                ModContent.ItemType<Items.Weapon.Ranged.July4th>()
            };

            int EventsummonItem = ModContent.ItemType<Invas.ThickBoulder>();

            string EventspawnInfo = $"Use a [i:{summonItem}]";

            string EventdespawnInfo = null;

            var EventcustomBossPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
                Texture2D texture = ModContent.Request<Texture2D>("Infernus/BossChecklist/BIPHM").Value;
                Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                sb.Draw(texture, centered, color);
            };

            bossChecklistMod.Call(
                "AddBoss",
                Mod,
                EventName,
                EventType,
                Eventweight,
                Eventdowned,
                Eventavailable,
                Eventcollection,
                EventsummonItem,
                EventspawnInfo,
                EventdespawnInfo,
                EventcustomBossPortrait
            );

            string EventName2 = "Boulder Invasion HM";

            int EventType2 = ModContent.NPCType<NPCs.Boulder5>();

            float Eventweight2 = 12.4f;

            Func<bool> Eventdowned2 = () => DownedBoss.downedBoulderInvasionHM;

            Func<bool> Eventavailable2 = () => true;

            List<int> Eventcollection2 = new List<int>()
            {
                ModContent.ItemType<Items.Weapon.HardMode.Ranged.Bog>(),
                ModContent.ItemType<Items.Weapon.HardMode.Summon.Whiprock>(),
                ModContent.ItemType<Items.Weapon.HardMode.Melee.bould>(),
                ModContent.ItemType<Items.Weapon.HardMode.Magic.Venom>(),
                ModContent.ItemType<Items.Weapon.HardMode.Magic.Bouldermagicweapon>(),
                ModContent.ItemType<Items.Weapon.HardMode.Accessories.Wings>(),
                ModContent.ItemType<Items.Weapon.HardMode.Accessories.HiveHeart>()
            };

            int EventsummonItem2 = ModContent.ItemType<Invas.ThickBoulder>();

            string EventspawnInfo2 = $"Use a [i:{EventsummonItem}]";

            string EventdespawnInfo2 = null;

            var EventcustomBossPortrait2 = (SpriteBatch sb, Rectangle rect, Color color) => {
                Texture2D texture = ModContent.Request<Texture2D>("Infernus/BossChecklist/BIHM").Value;
                Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                sb.Draw(texture, centered, color);
            };

            bossChecklistMod.Call(
                "AddBoss",
                Mod,
                EventName2,
                EventType2,
                Eventweight2,
                Eventdowned2,
                Eventavailable2,
                Eventcollection2,
                EventsummonItem2,
                EventspawnInfo2,
                EventdespawnInfo2,
                EventcustomBossPortrait2
            );

            string bossName3 = "Calypsical";

            int bossType3 = ModContent.NPCType<NPCs.Calypsical>();

            float weight3 = 19.6f;

            Func<bool> downed3 = () => DownedBoss.downedCalypsical;

            Func<bool> available3 = () => true;

            List<int> collection3 = new List<int>()
            {
                ModContent.ItemType<Items.Weapon.HardMode.Ranged.miniholy>(),
                ModContent.ItemType<Items.Weapon.HardMode.Summon.Mecharmr>(),
                ModContent.ItemType<Items.Weapon.HardMode.Summon.MechWhip>(),
                ModContent.ItemType<Items.Weapon.HardMode.Melee.HolyRam>(),
                ModContent.ItemType<Items.Weapon.HardMode.Magic.Cyclone>(),
                ModContent.ItemType<Items.Weapon.HardMode.Accessories.Mechwings>()
            };

            int summonItem3 = ModContent.ItemType<Items.BossSummon.Mechsummon>();

            string spawnInfo3 = $"Use a [i:{summonItem3}] after Moonlord's defeat";

            string despawnInfo3 = null;

            var customBossPortrait3 = (SpriteBatch sb, Rectangle rect, Color color) => {
                Texture2D texture = ModContent.Request<Texture2D>("Infernus/BossChecklist/Calypsical").Value;
                Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                sb.Draw(texture, centered, color);
            };

            bossChecklistMod.Call(
                "AddBoss",
                Mod,
                bossName3,
                bossType3,
                weight3,
                downed3,
                available3,
                collection3,
                summonItem3,
                spawnInfo3,
                despawnInfo3,
                customBossPortrait3
            );
        }
	}
}

