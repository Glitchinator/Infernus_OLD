using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.HardMode.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class DoomChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Praetor Suit");
			Tooltip.SetDefault("Heals on enemy strike"
							 + "\n + 32% Damage"
							 + "\n + 13% Damage reduction");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 20;
			Item.value = Item.buyPrice(0, 11, 50, 0);
			Item.rare = ItemRarityID.Cyan;
			Item.defense = 20;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) += .32f;
			player.onHitRegen = true;
			player.endurance = .13f - (0.1f * (1f - player.endurance));
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MartianUniformTorso, 1);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddIngredient(ItemID.SpectreBar, 12);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.SoulofFright, 16);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}