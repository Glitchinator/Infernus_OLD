using Infernus.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Summon
{
	public class Whipaer : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Aeritite Whip");
			Tooltip.SetDefault("Your minions will attack struck foes"
				+ "\n + 4 summon tag damage");
        }

		public override void SetDefaults()
		{
			Item.DefaultToWhip(ModContent.ProjectileType<Whip>(), 12, 3, 4);
			Item.value = Item.buyPrice(0, 8, 50, 0);

			Item.shootSpeed = 3;
			Item.rare = ItemRarityID.Blue;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.Gaming>(), 5);
			recipe.AddIngredient(ModContent.ItemType<Materials.Gravel>(), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
		public override bool MeleePrefix()
		{
			return true;
		}
	}
}