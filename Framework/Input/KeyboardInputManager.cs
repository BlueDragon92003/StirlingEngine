/*  Class Input Manager
 *  
 *  The input manager handles input
 *  and output from the mouse and
 *  keyboard.
 *  
 *  The input manager stores a list
 *  of keys and mouse inputs and
 *  how long they have been in one
 *  state.
 * 
 */

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace StirlingEngine.Framework.Input
{
    public sealed class KeyboardInputManager
    {
        //  Properties  -------------------------------------------------------------------------------------------------------
        private Dictionary<Keys, string> inputKeyMap;       //  Stores what keys are tied to which inputs
        private Dictionary<string, KeyState> inputState;    //  Stores which inputs are pressed/released
        private Dictionary<string, ushort> inputDuration;   //  Stores how long the button has been pressed/released

        public KeyboardInputManager()
        {
            inputKeyMap = new Dictionary<Keys, string>();
            inputState = new Dictionary<string, KeyState>();
            inputDuration = new Dictionary<string, ushort>();
        }

        //  Methods    ---------------------------------------------------------------------------------------------------
        public void Update()
        {
            Dictionary<string, KeyState> oldInputState = new Dictionary<string, KeyState>(inputState);
            List<string> inputStateKeys = new List<string>(inputState.Keys);

            foreach (string input in inputStateKeys)
            {
                inputState[input] = KeyState.Up;
                foreach (Keys key in inputKeyMap.Keys)
                {
                    if (inputKeyMap[key] == input && Keyboard.GetState().IsKeyDown(key)) inputState[input] = KeyState.Down;
                }
            }

            foreach(string input in inputStateKeys)
            {
                if (inputState[input] != oldInputState[input])
                {
                    inputDuration[input] = 0;
                }
                else
                {
                    inputDuration[input]++;
                }
            }
        }

        public void RegisterKeyInput(string input, Keys key)
        {
            inputKeyMap.Add(key, input);
            if (!inputState.ContainsKey(input)) inputState.Add(input, KeyState.Up);
            if (!inputDuration.ContainsKey(input)) inputDuration.Add(input, 0);
        }

        public KeyState GetInputState(string input)
        {
            return inputState[input];
        }
    }
}
