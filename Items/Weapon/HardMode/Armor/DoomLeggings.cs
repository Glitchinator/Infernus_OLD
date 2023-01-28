using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class DoomLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Praetor Stompers");
            Tooltip.SetDefault("+ 15% Movement Speed"
                + "\n + 14% Crit Chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.buyPrice(0, 11, 50, 0);
            Item.rare = ItemRarityID.Cyan;
            Item.defense = 14;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += .15f;
            player.GetCritChance(DamageClass.Generic) += 14;
        }


        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MartianUniformPants, 1)
            .AddIngredient(ItemID.ChlorophyteBar, 10)
            .AddIngredient(ItemID.SpectreBar, 10)
            .AddIngredient(ItemID.HallowedBar, 10)
            .AddIngredient(ItemID.SoulofMight, 14)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}