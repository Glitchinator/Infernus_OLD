using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.HardMode.Summon
{
	public class Drillxwhip : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Giant's Drill");
			Tooltip.SetDefault("Belonged to Drill-X"
				+ "\n Your minions will attack struck foes"
							+ "\n + Explosions"
							+ "\n + 18 summon tag damage");
        }

		public override void SetDefaults()
		{
			Item.DefaultToWhip(ModContent.ProjectileType<Infernus.Projectiles.Drillx>(), 160, 3, 7);
			Item.value = Item.buyPrice(0, 30, 50, 0);

			Item.shootSpeed = 10;
			Item.rare = ItemRarityID.Yellow;
		}
		public override bool MeleePrefix()
		{
			return true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Drax, 1);
			recipe.AddIngredient(ItemID.ChlorophyteDrill, 1);
			recipe.AddIngredient(ItemID.LaserDrill, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}