using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Buffs
{
    public class drillwhipbuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<drillWhipDebuffNPC>().markedBydrillWhip = true;
        }
    }

    public class drillWhipDebuffNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool markedBydrillWhip;

        public override void ResetEffects(NPC npc)
        {
            markedBydrillWhip = false;
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (markedBydrillWhip && !projectile.npcProj && !projectile.trap && (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type]))
            {
                damage += 18;
            }
        }
    }
}
