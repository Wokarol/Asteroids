using CommandTerminal;
using UnityEngine;

namespace Wokarol
{
    public abstract class TerminalCommandGeneric : MonoBehaviour
    {
        [Tooltip("{name} is replaced by object name, {parent_name} is replaced by name of the parent")]
        [SerializeField] string commandName = "Noname_Command";
        [SerializeField] string help = "";

        private void Start()
        {
            var formattedCommand = commandName
                .Replace("{name}", name)
                .Replace("{parent_name}", (transform.parent != null) ? transform.parent.name : name);

            Terminal.Shell.AddCommand(formattedCommand, Execute, 0, 0, help);
#if !UNITY_EDITOR
            Terminal.Autocomplete.Register(formattedCommand); 
#endif
        }

        protected abstract void Execute(CommandArg[] args);
    }
}