using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Cake.Genoise
{
    public static class Routine
    {
        public static Coroutine Start(IEnumerator p_method)
        {
            return RoutineRunner.Instance.StartRoutine(p_method);
        }

        public static void Stop(Coroutine p_coroutine)
        {
            RoutineRunner.Instance.StopRoutine(p_coroutine);
        }
    }
}