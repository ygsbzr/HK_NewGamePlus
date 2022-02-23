using System.Collections.Generic;
using HutongGames.PlayMaker;
using UnityEngine;
using Satchel;
namespace HealthScale
{
    static class ManualChanges
    {
        // For those horrible bosses that set health in FSM

        public static void PV(GameObject go, float scale)
        {
            PlayMakerFSM val = FSMUtility.LocateMyFSM(go, "Control");
            HealthManager component = go.GetComponent<HealthManager>();
            component.hp = (int)((float)component.hp * scale);
            val.Fsm.GetFsmInt("Half HP").Value = (int)(component.hp * 2 / 3f);
            val.Fsm.GetFsmInt("Quarter HP").Value = (int)(component.hp / 3f);
        }

        public static void Grimms(GameObject go, float scale)
        {
            PlayMakerFSM val = FSMUtility.LocateMyFSM(go, "Control");
            HealthManager component = go.GetComponent<HealthManager>();
            component.hp = (int)((float)component.hp * scale);
            val.Fsm.GetFsmInt("Rage HP 1").Value = (int)(component.hp * 3 / 4f);
            val.Fsm.GetFsmInt("Rage HP 2").Value = (int)(component.hp * 2 / 4f);
            val.Fsm.GetFsmInt("Rage HP 3").Value = (int)(component.hp / 4f);
        }

        public static void NailMasters(GameObject go, float scale)
        {
            PlayMakerFSM val = FSMUtility.LocateMyFSM(go, "nailmaster");
            HealthManager component = go.GetComponent<HealthManager>();
            component.hp = (int)((float)component.hp * scale);
            val.Fsm.GetFsmInt("P2 HP").Value = (int)(1.2f * component.hp);
        }

        public static void DungDefender(GameObject go, float scale)
        {
            PlayMakerFSM val = FSMUtility.LocateMyFSM(go, "Dung Defender");
            HealthManager component = go.GetComponent<HealthManager>();
            component.hp = (int)(component.hp * scale);
            val.Fsm.GetFsmInt("Rage HP").Value = (int)(component.hp / 2f);
        }

        // FK health, called on "False Knight New"
        public static void ChangeFKHealth(GameObject go, float scale)
        {
            PlayMakerFSM FKfsm = go.LocateMyFSM("Check Health");
            FsmInt fkHP = FKfsm.FsmVariables.FindFsmInt("Recover HP");
            fkHP.Value = (int)(fkHP.Value * scale);
            // Set initial health
            var hm = go.GetComponent<HealthManager>();
            hm.hp = (int)(hm.hp * scale);
        }

        public static void ChangeTHKHealth(GameObject go, float scale)
        {
            PlayMakerFSM fsm = go.LocateMyFSM("Phase Control");
            List<FsmInt> hpInts = new List<FsmInt>
            {
                fsm.FsmVariables.FindFsmInt("Phase2 HP"),
                fsm.FsmVariables.FindFsmInt("Phase3 HP")
            };
            foreach (FsmInt hpVal in hpInts) hpVal.Value = (int)(hpVal.Value * scale);

            SetHP healAction = fsm.GetAction<SetHP>("Set Phase 4", 5);
            healAction.hp.Value = (int)(healAction.hp.Value * scale);
            // Set initial health
            var hm = go.GetComponent<HealthManager>();
            hm.hp = (int)(hm.hp * scale);
        }

        public static void ChangeRadHealth(GameObject go, float scale)
        {
            PlayMakerFSM fsm = go.LocateMyFSM("Phase Control");
            List<FsmInt> hpInts = new List<FsmInt>
            {
                fsm.FsmVariables.FindFsmInt("P2 Spike Waves"),
                fsm.FsmVariables.FindFsmInt("P3 A1 Rage"),
                fsm.FsmVariables.FindFsmInt("P4 Stun1"),
                fsm.FsmVariables.FindFsmInt("P5 Acend")     // Do not question the spelling.
            };
            foreach (FsmInt hpVal in hpInts) hpVal.Value = (int)(hpVal.Value * scale);

            if (go.name == "Absolute Radiance")     // Set final phase hp
            {
                PlayMakerFSM absfsm = go.LocateMyFSM("Control");
                absfsm.GetAction<SetHP>("Scream", 7).hp = (int)(1000 * scale);
            }
            // Set initial health
            var hm = go.GetComponent<HealthManager>();
            hm.hp = (int)(hm.hp * scale);
        }
    }
}
