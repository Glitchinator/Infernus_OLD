using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Melee
{
    public class Seashellsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seashell Sword");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 21;
            Item.DamageType = DamageClass.Melee;
            Item.width = 46;
            Item.height = 54;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(0, 5, 50, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 6;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Seashell, 12);
            recipe.AddIngredient(ItemID.TulipShell, 4);
            recipe.AddIngredient(ItemID.JunoniaShell, 4);
            recipe.AddIngredient(ItemID.LightningWhelkShell, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}