using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;

namespace Infernus.Items.Weapon.HardMode.Accessories
	{
	[AutoloadEquip(EquipType.Wings)]
	public class Mechwings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angelic Wings");
			Tooltip.SetDefault("Allows flight, and slow falling"
                 + "\n + 4 defense + 8% damage + 6% crit");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

			ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(220, 7.2f, 3.2f);
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 28;
			Item.value = Item.buyPrice(0, 36, 25, 0);
			Item.rare = ItemRarityID.Expert;
			Item.accessory = true;
			Item.expert = true;
			Item.defense = 4;
		}
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(DamageClass.Generic) += 6;
            player.GetDamage(DamageClass.Generic) += .8f;
        }
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.95f;
			ascentWhenRising = 0.35f;
			maxCanAscendMultiplier = 1.4f;
			maxAscentMultiplier = 3.3f;
			constantAscend = 0.335f;
		}
	}
}