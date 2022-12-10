using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.BossSummon
{
	public class Boss1sum : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Meteor Shard");
			Tooltip.SetDefault("Summons Raiko"
                + "\n Must be night");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 2;
		}

		public override void SetDefaults() 
		{
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 4;
			Item.value = Item.buyPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.Blue;
			Item.consumable = true;
			Item.maxStack = 20;
		}
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(Mod.Find<ModNPC>("Raiko").Type) && (Main.dayTime == false);
		}

        public override bool? UseItem(Player player)
		{
			SoundEngine.PlaySound(SoundID.ForceRoar, player.position);
			if(Main.netMode != 1)

            {
				NPC.SpawnOnPlayer(player.whoAmI, Mod.Find<ModNPC>("Raiko").Type);
			}
			return true;
		}
		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.Gravel>(), 6);
			recipe.AddRecipeGroup("IronBar", 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}