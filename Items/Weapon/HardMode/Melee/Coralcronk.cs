using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Melee
{
    public class Coralcronk : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seashine Claymore");
            Tooltip.SetDefault("Shoots short ranged shells");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.DamageType = DamageClass.Melee;
            Item.width = 75;
            Item.height = 75;
            Item.useTime = 36;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5f;
            Item.value = Item.buyPrice(0, 16, 50, 0);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.StarAnise;
            Item.shootSpeed = 12;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.HallowedBar, 12)
            .AddIngredient(ModContent.ItemType<Weapon.Melee.Seashellsword>(), 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}