using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace CustomControls
{
    public class PopupWindow : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<PopupWindow, UxmlTraits> { }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlStringAttributeDescription promptAttr = new UxmlStringAttributeDescription()
            {
                name = "prompt"
            };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                (ve as PopupWindow).Prompt = promptAttr.GetValueFromBag(bag, cc);
            }
        }

        string prompt;
        public string Prompt
        {
            get => prompt;
            set
            {
                prompt = value;
                UpdatePrompt();
            }
        }

        Label msgLabel;

        private const string styleResource = "Stylesheet_PopupPanel";
        private const string ussContainer = "popup_container";
        private const string ussPopup = "popup_window";
        private const string ussPopupMsg = "popup_msg";
        private const string ussPopupButton = "popup_button";
        private const string ussCancel = "button_cancel";
        private const string ussConfirm = "button_confirm";
        private const string ussHorContainer = "horizontal_container";

        public PopupWindow()
        {
            styleSheets.Add(Resources.Load<StyleSheet>(styleResource));
            AddToClassList(ussContainer);

            VisualElement window = new VisualElement();
            hierarchy.Add(window);
            window.AddToClassList(ussPopup);

            VisualElement horizontalContainerText = new VisualElement();
            window.Add(horizontalContainerText);
            horizontalContainerText.AddToClassList(ussHorContainer);



            msgLabel = new Label();
            horizontalContainerText.Add(msgLabel);
            msgLabel.AddToClassList(ussPopupMsg);

            VisualElement horizontalContainerButton = new VisualElement();
            window.Add(horizontalContainerButton);
            horizontalContainerButton.AddToClassList(ussHorContainer);

            Button confirmButton = new Button() { text = "CONFIRM" };
            Button cancelButton = new Button() { text = "CANCEL" };
            horizontalContainerButton.Add(confirmButton);
            horizontalContainerButton.Add(cancelButton);

            confirmButton.AddToClassList(ussPopupButton);
            confirmButton.AddToClassList(ussConfirm);

            cancelButton.AddToClassList(ussPopupButton);
            cancelButton.AddToClassList(ussCancel);

            msgLabel.text = "Do you really want to quit?";

            confirmButton.clicked += OnConfirm;
            cancelButton.clicked += OnCancel;


        }

        public event Action confirmed;
        public event Action cancelled;

        void OnConfirm()
        {
            confirmed?.Invoke();
        }

        void OnCancel()
        {
            cancelled?.Invoke();
        }

        void UpdatePrompt()
        {
            msgLabel.text = prompt;
        }
    }
}