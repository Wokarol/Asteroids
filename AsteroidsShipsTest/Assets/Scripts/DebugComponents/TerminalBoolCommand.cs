using CommandTerminal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol
{
    public class TerminalBoolCommand : TerminalCommandGeneric
    {
        [SerializeField] CommandEvent onCommandEvent = new CommandEvent();
        protected override void Execute(CommandArg[] args)
        {
            onCommandEvent.Invoke(args[0].Bool);
        }
        [System.Serializable]
        private class CommandEvent : UnityEvent<bool>
        {
        }
    } 
}
