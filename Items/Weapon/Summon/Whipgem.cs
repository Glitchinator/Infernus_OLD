using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Summon
{
	public class Whipgem : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Gem Tremor");
			Tooltip.SetDefault("Your minions will attack struck foes"
				+ "\n + 5 summon tag damage");
        }

		public override void SetDefaults()
		{
			Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Whipgem>(), 23, 3, 7);
			Item.value = Item.buyPrice(0, 9, 50, 0);

			Item.shootSpeed = 4;
			Item.rare = ItemRarityID.Green;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Sapphire, 3);
			recipe.AddIngredient(ItemID.Emerald, 3);
			recipe.AddIngredient(ItemID.Ruby, 3);
			recipe.AddIngredient(ItemID.Amethyst, 3);
			recipe.AddIngredient(ItemID.Topaz, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
		public override bool MeleePrefix()
		{
			return true;
		}
	}
}