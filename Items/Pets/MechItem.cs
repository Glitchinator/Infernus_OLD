using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Infernus.Items.Pets
{
	public class MechItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Eye");
			Tooltip.SetDefault("Summons a Confused Eye to follow you");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToVanitypet(ModContent.ProjectileType<MechPet>(), ModContent.BuffType<MechPetBuff>());

			Item.width = 20;
			Item.height = 20;
			Item.rare = ItemRarityID.Master;
			Item.master = true;
			Item.value = Item.buyPrice(0, 32, 60, 0);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.AddBuff(Item.buffType, 2);

			return false;
		}
	}
}
