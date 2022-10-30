using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Buffs
{
    public class gemwhipbuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<gemWhipDebuffNPC>().markedBygemWhip = true;
        }
    }

    public class gemWhipDebuffNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool markedBygemWhip;

        public override void ResetEffects(NPC npc)
        {
            markedBygemWhip = false;
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (markedBygemWhip && !projectile.npcProj && !projectile.trap && (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type]))
            {
                damage += 5;
            }
        }
    }
}
