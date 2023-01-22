using Terraria;
using Terraria.ModLoader;

namespace Infernus.Buffs
{
    public class DungBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pile o' Bones");
            Description.SetDefault("\"The bones will fight for you\"");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Dunger>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
