using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.ViewModels
{
    public class SpeakPageViewModel : BindableBase
    {
        private string _textToSay = "Hello Prism";

        public string TextToSay
        {
            get => _textToSay;
            set => SetProperty(ref _textToSay, value);
        }

        public DelegateCommand SpeakCommand { get; }

        public SpeakPageViewModel()
        {
            SpeakCommand = new DelegateCommand(Speak);
        }

        private void Speak()
        {
            // TODO: call service
        }
    }
}
