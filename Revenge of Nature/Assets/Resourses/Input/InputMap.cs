//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Resourses/Input/InputMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputMap : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMap"",
    ""maps"": [
        {
            ""name"": ""PlayerInput"",
            ""id"": ""1203d7d7-69ad-4a9b-b87f-e26dc53463c1"",
            ""actions"": [
                {
                    ""name"": ""MovementHorizontal"",
                    ""type"": ""Value"",
                    ""id"": ""3e84b865-ba27-4974-b1c6-9077a6808722"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MovementVertical"",
                    ""type"": ""Value"",
                    ""id"": ""602697cf-d539-4d52-9dbd-7fd243705ce8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RotationDeltaHorizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8e8f319d-8005-4824-b542-dd326ca25b12"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotationDeltaVertical"",
                    ""type"": ""PassThrough"",
                    ""id"": ""58762fd6-f0c5-437e-8dab-bbbb699c33a4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""316423dd-264e-4567-999b-b4d1491f143c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard/AD"",
                    ""id"": ""c43fadc9-bd1c-478f-8ac3-ebe046af89e0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d06689bd-1efb-4c24-93fe-4884ead2b8c2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse + Keyboard"",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fefa089a-8b0e-4b19-a45a-3704bb59ae09"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse + Keyboard"",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard/SW"",
                    ""id"": ""041926b2-8190-474e-95ad-7e2453fd3687"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8fbafde5-ef3b-4fb2-acb5-cc9e5cc34f33"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse + Keyboard"",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9d0019bd-da94-4266-a2d2-816ac262dc5b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse + Keyboard"",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""40283b9c-8663-49a5-acef-4cd84e66e083"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse + Keyboard"",
                    ""action"": ""RotationDeltaHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90af6e18-6f47-43cb-ae50-16d68f334883"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse + Keyboard"",
                    ""action"": ""RotationDeltaVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""659d57e8-9342-43db-a517-59ad3318a041"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse + Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse + Keyboard"",
            ""bindingGroup"": ""Mouse + Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerInput
        m_PlayerInput = asset.FindActionMap("PlayerInput", throwIfNotFound: true);
        m_PlayerInput_MovementHorizontal = m_PlayerInput.FindAction("MovementHorizontal", throwIfNotFound: true);
        m_PlayerInput_MovementVertical = m_PlayerInput.FindAction("MovementVertical", throwIfNotFound: true);
        m_PlayerInput_RotationDeltaHorizontal = m_PlayerInput.FindAction("RotationDeltaHorizontal", throwIfNotFound: true);
        m_PlayerInput_RotationDeltaVertical = m_PlayerInput.FindAction("RotationDeltaVertical", throwIfNotFound: true);
        m_PlayerInput_Jump = m_PlayerInput.FindAction("Jump", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerInput
    private readonly InputActionMap m_PlayerInput;
    private IPlayerInputActions m_PlayerInputActionsCallbackInterface;
    private readonly InputAction m_PlayerInput_MovementHorizontal;
    private readonly InputAction m_PlayerInput_MovementVertical;
    private readonly InputAction m_PlayerInput_RotationDeltaHorizontal;
    private readonly InputAction m_PlayerInput_RotationDeltaVertical;
    private readonly InputAction m_PlayerInput_Jump;
    public struct PlayerInputActions
    {
        private @InputMap m_Wrapper;
        public PlayerInputActions(@InputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementHorizontal => m_Wrapper.m_PlayerInput_MovementHorizontal;
        public InputAction @MovementVertical => m_Wrapper.m_PlayerInput_MovementVertical;
        public InputAction @RotationDeltaHorizontal => m_Wrapper.m_PlayerInput_RotationDeltaHorizontal;
        public InputAction @RotationDeltaVertical => m_Wrapper.m_PlayerInput_RotationDeltaVertical;
        public InputAction @Jump => m_Wrapper.m_PlayerInput_Jump;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInputActions instance)
        {
            if (m_Wrapper.m_PlayerInputActionsCallbackInterface != null)
            {
                @MovementHorizontal.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMovementHorizontal;
                @MovementHorizontal.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMovementHorizontal;
                @MovementHorizontal.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMovementHorizontal;
                @MovementVertical.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMovementVertical;
                @MovementVertical.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMovementVertical;
                @MovementVertical.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMovementVertical;
                @RotationDeltaHorizontal.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotationDeltaHorizontal;
                @RotationDeltaHorizontal.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotationDeltaHorizontal;
                @RotationDeltaHorizontal.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotationDeltaHorizontal;
                @RotationDeltaVertical.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotationDeltaVertical;
                @RotationDeltaVertical.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotationDeltaVertical;
                @RotationDeltaVertical.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotationDeltaVertical;
                @Jump.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementHorizontal.started += instance.OnMovementHorizontal;
                @MovementHorizontal.performed += instance.OnMovementHorizontal;
                @MovementHorizontal.canceled += instance.OnMovementHorizontal;
                @MovementVertical.started += instance.OnMovementVertical;
                @MovementVertical.performed += instance.OnMovementVertical;
                @MovementVertical.canceled += instance.OnMovementVertical;
                @RotationDeltaHorizontal.started += instance.OnRotationDeltaHorizontal;
                @RotationDeltaHorizontal.performed += instance.OnRotationDeltaHorizontal;
                @RotationDeltaHorizontal.canceled += instance.OnRotationDeltaHorizontal;
                @RotationDeltaVertical.started += instance.OnRotationDeltaVertical;
                @RotationDeltaVertical.performed += instance.OnRotationDeltaVertical;
                @RotationDeltaVertical.canceled += instance.OnRotationDeltaVertical;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerInputActions @PlayerInput => new PlayerInputActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse + Keyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    public interface IPlayerInputActions
    {
        void OnMovementHorizontal(InputAction.CallbackContext context);
        void OnMovementVertical(InputAction.CallbackContext context);
        void OnRotationDeltaHorizontal(InputAction.CallbackContext context);
        void OnRotationDeltaVertical(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
