﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MvvmApp.ViewModels
{
    public class ModalDatePickerViewModel : INotifyPropertyChanged
    {
        private ICommand _command;
        private DateTime _selectedDate;
        private ICommand _cancelCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        public ModalDatePickerViewModel()
        {
            CancelCommand = new Command(async () =>
            {
                await PopupNavigation.PopAsync();
            });
        }

        public ICommand Command
        {
            get { return _command; }
            set
            {
                _command = value;
                OnPropertyChanged();
            }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
            private set
            {
                _cancelCommand = value;
                OnPropertyChanged();
            }
        }

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}