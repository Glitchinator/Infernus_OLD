using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ChlorophyteHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorophyte Hat");
            Tooltip.SetDefault("+ 16% Summon Damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.buyPrice(0, 11, 50, 0);
            Item.rare = ItemRarityID.Lime;
            Item.defense = 6;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += .16f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.ChlorophytePlateMail && legs.type == ItemID.ChlorophyteGreaves;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Leaf Power" + "\n 2+ Summons + Leaf Crystal";
            player.maxMinions += 2;
            player.AddBuff(60, 60, true);

        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.ChlorophyteBar, 12)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}