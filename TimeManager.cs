using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Manager;
using UMI;
using System;

namespace UMI.Manager.Period
{
    public class TimeManager : MonoBehaviour
    {
        internal protected bool Start;
        internal protected bool[] isTime;
        internal protected int index;
        internal protected float[] cooldown;
        internal protected float delay_0;
        internal protected float delay_1;
        internal protected float delay_2;
        internal protected float second;
        internal protected string displayText;
        internal protected string message;
        internal protected eTimeState eTimeState_0;
        public TimeManager()
        {
            this.cooldown = new float[3];
            this.isTime = new bool[3];
            eTimeState_0 = eTimeState.Init;
            this.Start = true;
            this.second = 0f;
            this.delay_0 = 1f;
            this.delay_1 = 1f;
            this.displayText = string.Empty;
            this.message = string.Empty;
        }
        public void getSkillCD(int nSkill , float CD)
        {
            this.cooldown[nSkill] = CD;
            this.isTime[nSkill] = true;
        }
        public bool nextTime(int nSkill)
        {
            if (this.cooldown[nSkill] <= this.delay_1)
            {
                return true;
            }
            else
            {
                return false;
            }

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
            return (this.second <= delay_0) ? "1" : this.second.ToString("0");
        }
        public string getTime(int nSkill)
        {
            return (this.cooldown[nSkill] <= delay_0) ? "1" : this.cooldown[nSkill].ToString("0");
        }
        public bool nextTime()
        {
            if (this.second <= this.delay_1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void Update()
        {
            this.cooldownTime();
        }
        private void cooldownTime()
        {
            if (!Start)
            {
                this.second -= 1 * Time.deltaTime;
                if (this.second <= 0)
                {
                    this.Start = false;
                    this.second = 0;
                }
            }
            if (this.isTime[1])
            {
                this.cooldown[1] -= 1 * Time.deltaTime;
                if (this.cooldown[1] <= 0)
                {
                    this.isTime[1] = false;
                    this.cooldown[1] = 0;
                }
            }
            if (this.isTime[2])
            {
                this.cooldown[2] -= 1 * Time.deltaTime;
                if (this.cooldown[2] <= 0)
                {
                    this.isTime[2] = false;
                    this.cooldown[2] = 0;
                }
            }
        }
        public string getMessage(out bool msg)
        {
            if(this.displayText.Length == this.message.Length )
            {
                this.second -= 1 * Time.deltaTime;
                if (this.second <= 0)
                {
                    msg = true;
                    this.second = 0;
                }
                else
                {
                    msg = false;
                }
             
            }
            else
            {
                msg = false;
            }
            return this.displayText; 
        }
        public  IEnumerator setMessage(string msg ,float second)
        {
            this.message = msg;
            this.second = second;
            while (this.index < this.message.Length)
            {
                this.displayText += this.message[this.index];
                this.index++;
                yield return new WaitForSeconds(0.06f);
            }
        }

    }
}