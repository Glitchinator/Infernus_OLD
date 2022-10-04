﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Infernus
{
	public class DownedBoss : ModSystem
	{
		public static bool downedRaiko = false;
		public static bool downedRuderibus = false;
		public static bool downedTigerShark = false;
		public static bool downedSquid = false;

		public override void OnWorldLoad()
		{
			downedRaiko = false;
			downedRuderibus = false;
			downedTigerShark = false;
			downedSquid = false;
		}

		public override void OnWorldUnload()
		{
			downedRaiko = false;
			downedRuderibus = false;
			downedTigerShark = false;
			downedSquid = false;
		}
		public override void SaveWorldData(TagCompound tag)
		{
			if (downedRaiko)
			{
				tag["downedRaiko"] = true;
			}
			if (downedRuderibus)
			{
				tag["downedRuderibus"] = true;
			}
			if (downedTigerShark)
			{
				tag["downedTigerShark"] = true;
			}
			if (downedSquid)
			{
				tag["downedSquid"] = true;
			}
		}

		public override void LoadWorldData(TagCompound tag)
		{
			downedRaiko = tag.ContainsKey("downedRaiko");
			downedRuderibus = tag.ContainsKey("downedRuderibus");
			downedTigerShark = tag.ContainsKey("downedTigerShark");
			downedSquid = tag.ContainsKey("downedSquid");
		}

		public override void NetSend(BinaryWriter writer)
		{
			var flags = new BitsByte();
			flags[0] = downedRaiko;
			flags[1] = downedRuderibus;
			flags[2] = downedTigerShark;
			flags[3] = downedSquid;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedRaiko = flags[0];
			downedRuderibus = flags[1];
			downedTigerShark = flags[2];
			downedSquid = flags[3];
		}
	}
}