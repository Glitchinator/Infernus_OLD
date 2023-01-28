using Infernus.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Magic
{
    public class gungolem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plantera's Pistol");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.DamageType = DamageClass.Magic;
            Item.width = 36;
            Item.height = 36;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5f;
            Item.value = Item.buyPrice(0, 19, 50, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item8;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<plant>();
            Item.autoReuse = true;
            Item.shootSpeed = 16f;
            Item.mana = 10;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.LeafBlower, 1)
            .AddIngredient(ItemID.ChlorophyteBar, 12)
            .AddIngredient(ItemID.BeetleHusk, 12)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}