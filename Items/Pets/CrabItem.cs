using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Infernus.Items.Pets
{
	public class CrabItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Murky Horseshoe");
			Tooltip.SetDefault("Summons a Horseshoe Crab to follow you");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToVanitypet(ModContent.ProjectileType<RudePet>(), ModContent.BuffType<CrabBuff>());

			Item.width = 20;
			Item.height = 20;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 12, 60, 0);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.AddBuff(Item.buffType, 2);

			return false;
		}
	}
}
