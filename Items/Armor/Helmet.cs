using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class Helmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aeritite Helm");
			Tooltip.SetDefault("+ 6% Melee Damage");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.buyPrice(0, 1, 25, 0);
			Item.rare = ItemRarityID.Green;
			Item.defense = 5;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) += .06f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ChestPLate>() && legs.type == ModContent.ItemType<Leggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Melee's Speed" + "\n+ 12% Melee Speed";
			player.GetAttackSpeed(DamageClass.Melee)  += .12f;
			
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.Gravel>(), 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.Gaming>(), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}