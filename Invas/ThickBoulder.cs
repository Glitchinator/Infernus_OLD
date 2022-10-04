using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Invas
{
    public class ThickBoulder : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thick Boulder");
			Tooltip.SetDefault("Don't throw it, the boulders are watching");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 2;
		}
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.scale = 1;
			Item.maxStack = 99;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.UseSound = SoundID.Item1;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Blue;
			Item.consumable = true;
			Item.noUseGraphic = true;
		}
		
		public override bool? UseItem(Player player)
		{
			if (Main.netMode == 0)
			{
				Main.NewText("Grey clouds begin to form overhead", 175, 75, 255);
			}
			if (Main.netMode == 1)
			{
				Main.NewText("Grey clouds begin to form overhead", 175, 75, 255);
			}
			DungeonInvasion.StartDungeonInvasion();
			return true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 99);
			recipe.Register();
		}
		
    }
}