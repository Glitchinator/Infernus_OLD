using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class Raiko2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flamico");
			Tooltip.SetDefault("+ 9% Damage");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.buyPrice(0, 3, 25, 0);
			Item.rare = ItemRarityID.Green;
			Item.defense = 9;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) += .09f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<RaikoChest>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Heavy Duty" + "\n Knockback immune + Thorns ";
			player.noKnockback = true;
			player.thorns += 1f;

		}

		public override void AddRecipes()
		{

			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Armor.Helmetmagic>());
			recipe.AddIngredient(ModContent.ItemType<Materials.Hot>(), 68);
			recipe.AddTile(ModContent.TileType<Tiles.Work>());
			recipe.Register();
		}
	}
}