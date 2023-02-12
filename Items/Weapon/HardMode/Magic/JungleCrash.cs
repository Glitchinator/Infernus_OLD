using Infernus.Projectiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Magic
{
    public class JungleCrash : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("JungleCrash");
            Item.staff[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 58;
            Item.DamageType = DamageClass.Magic;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6f;
            Item.value = Item.buyPrice(0, 15, 50, 0);
            Item.rare = ItemRarityID.Lime;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Gas>();
            Item.noUseGraphic = false;
            Item.shootSpeed = 22f;
            Item.mana = 12;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Weapon.Magic.Flower>(), 1)
            .AddIngredient(ItemID.JungleSpores, 18)
            .AddIngredient(ItemID.SoulofLight, 10)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}