using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Tools
{
    public class FishingPole : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aeritite Pole");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 38;
            Item.value = Item.buyPrice(0, 0, 70, 0);
            Item.rare = ItemRarityID.Blue;
            Item.CloneDefaults(ItemID.ScarabFishingRod);
            Item.shoot = ProjectileID.BobberMechanics;
            Item.fishingPole = 18;
            Item.shootSpeed = 10f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Materials.Gaming>(), 8)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
