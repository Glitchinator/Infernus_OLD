using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Accessories
{
    public class Mechboss : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Mind");
            Tooltip.SetDefault("Detection,Thorns,+20 life,+10 pickspeed,+1 speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 26;
            Item.value = Item.buyPrice(0, 14, 25, 0);
            Item.rare = ItemRarityID.Expert;
            Item.defense = 6;
            Item.expert = true;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.boneArmor = true;
            player.detectCreature = true;
            player.armorEffectDrawShadow = true;
            player.thorns = .4f;
            player.statLifeMax2 += 20;
            player.pickSpeed -= 10;
            player.accRunSpeed += 1;
            player.dangerSense = true;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MechanicalBatteryPiece, 1);
            recipe.AddIngredient(ItemID.MechanicalWagonPiece, 1);
            recipe.AddIngredient(ItemID.MechanicalWheelPiece, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}