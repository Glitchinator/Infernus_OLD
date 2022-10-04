using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Infernus.Items.Consumable
{
	public class Potion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Calamari Rage");
			Tooltip.SetDefault("Gives a boost to most stats");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(240, 240, 240),
				new Color(200, 200, 200),
				new Color(140, 140, 140)
			};
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 2, 35, 0);
			Item.buffType = ModContent.BuffType<Infernus.Buffs.PotionBuff>();
			Item.buffTime = 32400;
		}
	}
}
