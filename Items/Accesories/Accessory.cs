using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Buffs;
using Terraria.GameContent.Creative;

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
            Item.Size = new Vector2(20);
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
