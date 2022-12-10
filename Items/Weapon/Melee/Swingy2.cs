using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Melee
{
	public class Swingy2 : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Thiriscus");
			Tooltip.SetDefault("Cursed by the dungeon, the blade turns blue. Showing a thousand souls a fight.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 7;
			Item.useAnimation = 25;
			Item.useStyle = 5;
			Item.knockBack = 2;
			Item.value = Item.buyPrice(0, 11, 50, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swingy2>();
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.shootSpeed = 40f;
			Item.crit = 6;
		}
		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Weapon.Melee.Swingy>(), 1);
			recipe.AddIngredient(ItemID.Muramasa, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}