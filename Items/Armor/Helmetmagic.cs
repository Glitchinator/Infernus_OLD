using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class Helmetmagic : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aeritite Hood");
			Tooltip.SetDefault("+ 1 Max Summon");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.buyPrice(0, 1, 25, 0);
			Item.rare = ItemRarityID.Green;
			Item.defense = 4;
		}
		public override void UpdateEquip(Player player)
		{
			player.maxMinions++;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ChestPLate>() && legs.type == ModContent.ItemType<Leggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summoner's Pride" + "\n + 12% Melee Speed";
            player.GetAttackSpeed(DamageClass.Melee) += .12f;

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