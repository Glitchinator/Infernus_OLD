using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Infernus.Items.Pets
{
	public class RudeItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Shard");
			Tooltip.SetDefault("Summons a miniature Ruderibus to follow you");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToVanitypet(ModContent.ProjectileType<RudePet>(), ModContent.BuffType<RudeBuff>());

			Item.width = 20;
			Item.height = 20;
			Item.rare = ItemRarityID.Master;
			Item.master = true;
			Item.value = Item.buyPrice(0, 10, 60, 0);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.AddBuff(Item.buffType, 2);

			return false;
		}
	}
}
