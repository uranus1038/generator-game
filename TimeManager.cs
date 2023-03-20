using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Manager;
using UMI;
namespace UMI.Manager.Period
{
    public class TimeManager : MonoBehaviour
    {
        internal protected bool Start;
        internal protected float delay_0;
        internal protected float delay_1;
        internal protected float second;
        internal protected eTimeState eTimeState_0;
        public TimeManager()
        {
            eTimeState_0 = eTimeState.Init;
            this.Start = true;
            this.second = 0f;
            this.delay_0 = 1f;
            this.delay_1 = 0f;
    }
        private void Awake()
        {
            eTimeState_0 = eTimeState.Init;
        }
        public void OnStart(float second)
        {
            this.second = second;
            this.Start = false;
        }
        public string getTime()
        {
            return (this.second <= delay_0) ? "GO !" : this.second.ToString("0");
        }
        public bool nextTime()
        {
            if(this.second <= this.delay_1)
            {
                return true; 
            }else
            {
                return false;
            }
           
        }
        public void FixedUpdate()
        {
            this.cooldownTime();
        }
        private void cooldownTime()
        {
            if (!Start)
            {
                this.second -= 1 * Time.deltaTime;
                UMISystem.L0g(this.second.ToString("0"));
                if (this.second <= 0)
                {
                    this.Start = false;
                    this.second = 0; 
                }
            }
        }
    }

}