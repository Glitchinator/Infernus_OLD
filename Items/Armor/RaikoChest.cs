using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class RaikoChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Meteorite Platemail");
			Tooltip.SetDefault("+9% Crit");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.buyPrice(0, 3, 25, 0);
			Item.rare = ItemRarityID.Green;
			Item.defense = 10;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Generic) += 9;
		}

		public override void AddRecipes()
		{

			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ChestPLate>());
			recipe.AddIngredient(ModContent.ItemType<Materials.Hot>(), 76);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}