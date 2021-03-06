﻿using GalaSoft.MvvmLight.CommandWpf;
using RegistrationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RegistrationSystem.Common.UnitOfWork;

namespace RegistrationSystem.WPFUI.ViewModel
{
    public class RegistrationViewModel
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        private ICommand _backcCommand;
        private ICommand _registCommand;

        public Action CloseAction { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string PassWord { get; set; }

        public ICommand BackToLoginCommand
        {
            get
            {
                return _backcCommand ?? (_backcCommand = new RelayCommand((() =>
                {
                    var logVindow = new LoginWindow();
                    logVindow.Show();
                    CloseAction();

                })));
            }
            set { _backcCommand = value; }
        }

        public ICommand RegistrationCommand
        {
            get
            {
                return _registCommand ?? (_registCommand = new RelayCommand((() =>
                {
                    if (IsValidLogin(Login))
                    {
                        _unitOfWork.AddUser(new User()
                        {
                            FirstName = Name,
                            LastName = LastName,
                            Login = Login,
                            Password = Encrypt.GenerateHash(PassWord, Login)
                        });
                        MessageBox.Show("New user created!");
                        var logVindow = new LoginWindow();
                        logVindow.Show();
                        CloseAction();
                    }
                    else
                    {
                        MessageBox.Show("Try to create another login!");
                    }
                })));
            }
            set { _backcCommand = value; }
        }

        public bool IsValidLogin(string login)
        {
            return _unitOfWork.IsAvailableLogin(login);
        }
    }
}