using System;

namespace GameQuestLogic
{
    class Program
    {
        static bool CanFastAttack(bool isKnightAwake){
            return isKnightAwake;
        }
        static bool CanSpy(bool isKnightAwake, bool archerIsAwake){
            return isKnightAwake || archerIsAwake;
        }
        static bool CanSignal(bool IsPresenerAwake, bool archerIsAwake){
            return IsPresenerAwake && !archerIsAwake;
        }
        static bool CanFree(bool IsPresenerAwake, bool isKnightAwake, bool archerIsAwake, bool hasDog){
            return (IsPresenerAwake && !isKnightAwake && !archerIsAwake) || (IsPresenerAwake && !archerIsAwake && isKnightAwake && hasDog);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(CanFree(true,true,false,true));
        }
    }
}