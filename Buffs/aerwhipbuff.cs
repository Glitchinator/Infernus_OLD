using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Buffs
{
    public class aerwhipbuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<aeriWhipDebuffNPC>().markedByaerWhip = true;
        }
    }

    public class aeriWhipDebuffNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool markedByaerWhip;

        public override void ResetEffects(NPC npc)
        {
            markedByaerWhip = false;
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (markedByaerWhip && !projectile.npcProj && !projectile.trap && (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type]))
            {
                damage += 4;
            }
        }
    }
}
