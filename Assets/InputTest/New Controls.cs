// GENERATED AUTOMATICALLY FROM 'Assets/InputTest/New Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NewControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""CharacterContol"",
            ""id"": ""ae1bbc74-ddd4-4c04-adf0-5e2633b0131f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d0639c87-74f1-498a-80a9-959404c8e12c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""342ee9c3-4f16-4be7-88f3-f8c0e394afca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""48ec3212-fb18-42e2-b600-d3c264bf0f34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""fabc1900-41bf-4fbd-bd45-a9ab7de92ff1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""42ff8c24-3485-4ff3-89a2-745c89c01adf"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""0d35c6be-f58f-47d6-bd86-6f9baa28c279"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""22818310-e9d9-4cb8-9700-489a5ec6b4a8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f39dcf87-de04-41bc-b594-41c357c89219"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""19ab5d3b-b166-42d9-94ff-376ba87c69be"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""85e74dc5-054e-4b96-8b25-ee36cfa98eb5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""de0c15ab-7469-447e-a696-41dd5cccc2f6"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51a609f3-288c-46e8-b4c1-641755635483"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e737f162-3dfe-4f24-b843-40fa66142b36"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca5baec7-10ff-4d5e-ac95-57516af88007"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c3b1e2f-d323-4087-a4ff-4396113735c7"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c99d0cd-6136-4b77-ae09-e551affff8de"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterContol
        m_CharacterContol = asset.FindActionMap("CharacterContol", throwIfNotFound: true);
        m_CharacterContol_Move = m_CharacterContol.FindAction("Move", throwIfNotFound: true);
        m_CharacterContol_Run = m_CharacterContol.FindAction("Run", throwIfNotFound: true);
        m_CharacterContol_Jump = m_CharacterContol.FindAction("Jump", throwIfNotFound: true);
        m_CharacterContol_Look = m_CharacterContol.FindAction("Look", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // CharacterContol
    private readonly InputActionMap m_CharacterContol;
    private ICharacterContolActions m_CharacterContolActionsCallbackInterface;
    private readonly InputAction m_CharacterContol_Move;
    private readonly InputAction m_CharacterContol_Run;
    private readonly InputAction m_CharacterContol_Jump;
    private readonly InputAction m_CharacterContol_Look;
    public struct CharacterContolActions
    {
        private @NewControls m_Wrapper;
        public CharacterContolActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CharacterContol_Move;
        public InputAction @Run => m_Wrapper.m_CharacterContol_Run;
        public InputAction @Jump => m_Wrapper.m_CharacterContol_Jump;
        public InputAction @Look => m_Wrapper.m_CharacterContol_Look;
        public InputActionMap Get() { return m_Wrapper.m_CharacterContol; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterContolActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterContolActions instance)
        {
            if (m_Wrapper.m_CharacterContolActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharacterContolActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharacterContolActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharacterContolActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_CharacterContolActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_CharacterContolActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_CharacterContolActionsCallbackInterface.OnRun;
                @Jump.started -= m_Wrapper.m_CharacterContolActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterContolActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterContolActionsCallbackInterface.OnJump;
                @Look.started -= m_Wrapper.m_CharacterContolActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_CharacterContolActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_CharacterContolActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_CharacterContolActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public CharacterContolActions @CharacterContol => new CharacterContolActions(this);
    public interface ICharacterContolActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}
