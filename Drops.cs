using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus
{
	public class Drops : GlobalNPC
	{

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.AngryBones)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.Melee.Murawhip>(), 20, 1, 1));
			}
		}
	}
}
