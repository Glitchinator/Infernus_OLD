using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Accesories
{
    public class Blindfold : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandy Blindfold");
            Tooltip.SetDefault("Sand gets in your eye when you put it on"
                + "\n +10% Acceleration + 5% RangedCrit");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.Size = new Vector2(20);
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 4, 45, 0);
            Item.rare = ItemRarityID.Orange;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed += .10f;
            player.GetCritChance(DamageClass.Ranged) += 5;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 26);
            recipe.AddIngredient(ItemID.AntlionMandible, 6);
            recipe.AddIngredient(ItemID.SandBlock, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
