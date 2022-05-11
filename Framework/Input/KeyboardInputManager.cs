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
        private Dictionary<string, ushort> inputDuration;   //  Stores how long the 

        //  Singleton Pattern (Thread Safe) -----------------------------------------------------------------------------------
        private static readonly object padlock = new object();
        private static KeyboardInputManager instance = null;
        public static KeyboardInputManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance is null)
                    {
                        instance = new KeyboardInputManager();
                    }
                    return instance;
                }
            }
        }
        private KeyboardInputManager()
        {
            inputKeyMap = new Dictionary<Keys, string>();
            inputState = new Dictionary<string, KeyState>();
            inputDuration = new Dictionary<string, ushort>();
        }

        //  Methods    ---------------------------------------------------------------------------------------------------
        public void Update()
        {
            Dictionary<string, KeyState> oldInputState = new Dictionary<string, KeyState>(inputState);

            foreach (string input in inputState.Keys)
            {
                inputState[input] = KeyState.Up;
                foreach (Keys key in inputKeyMap.Keys)
                {
                    if (inputKeyMap[key] == input && Keyboard.GetState().IsKeyDown(key)) inputState[input] = KeyState.Down;
                }
            }

            foreach(string input in inputState.Keys)
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

        public void registerKeyInput(string input, Keys key)
        {
            inputKeyMap.Add(key, input);
            if (!inputState.ContainsKey(input))     inputState.Add(     input,  KeyState.Up);
            if (!inputDuration.ContainsKey(input))  inputDuration.Add(  input,  0);
        }

        public void resetKeyMap()
        {
            inputKeyMap.Clear();
        }

        public KeyState getInputState(string input)
        {
            return inputState[input];
        }
    }
}
