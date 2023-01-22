using Infernus.Buffs;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Accesories
{
    [AutoloadEquip(EquipType.Neck)]
    public class Accessory : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snowfall Tiara");
            Tooltip.SetDefault("Summons an Ice Defender");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 6, 45, 0);
            Item.rare = ItemRarityID.Expert;
            Item.defense = 2;
            Item.buffType = ModContent.BuffType<IcyBuff>();
            Item.shoot = ModContent.ProjectileType<Projectiles.Icy>();
            Item.expert = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(Item.buffType, 2);
        }
    }
}
