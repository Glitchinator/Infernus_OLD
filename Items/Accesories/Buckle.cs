using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Accesories
{
    public class Buckle : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Burning Buckle");
            Tooltip.SetDefault("Warmth pulses from it"
                + "\n +10% Melee Speed +5 Melee Crit");
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
            player.GetAttackSpeed(DamageClass.Melee) += .10f;
            player.GetCritChance(DamageClass.Melee) += 5;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 16);
            recipe.AddIngredient(ItemID.Bone, 26);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
