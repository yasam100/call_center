using PresentationLayer.Models;
using PresentationLayer.Models.ContentLayerDummy;
using PresentationLayer.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModels
{
    public class LoginVM : ViewModelBase
    {
        #region | Fields |
        private IContentProvider<Employee> _contentProvider = null;
        private bool _isLoggedIn = false;
        private string _userName = null;
        private string _password = null;

        private string _errorMsg = null;

        private Nullable<int> _loggedInAgentId = null;
        private Employee _loggedInAgentModel = null;

        private ICommand _cmdLogin = null;
        private ICommand _cmdClose = null;
        #endregion | Fields |

        #region | Properties |
        public bool IsLoggedIn
        {
            get
            {
                return _isLoggedIn;
            }
            set
            {
                if(_isLoggedIn!=value)
                {
                    _isLoggedIn = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (string.Compare(_userName, value) != 0)
                {
                    LoginErrMsg = null;
                    _userName = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (string.Compare(_password, value) != 0)
                {
                    LoginErrMsg = null;
                    _password = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string LoginErrMsg
        {
            get { return _errorMsg; }
            set
            {
                if (string.Compare(_errorMsg, value) != 0)
                {
                    _errorMsg = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Nullable<int> LoggedInAgentId
        {
            get
            {
                return _loggedInAgentId;
            }
            set
            {
                if(!Nullable<int>.Equals(_loggedInAgentId, value))
                {
                    _loggedInAgentId = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Employee LoggedInAgentModel
        {
            get
            {
                return _loggedInAgentModel;
            }
        }

        public ICommand CmdLogin
        {
            get
            {
                return _cmdLogin ?? (_cmdLogin = new RelayCommand(ExecCmdLogin, CanExecCmdLogin));
            }
        }

        public ICommand CmdClose
        {
            get
            {
                return _cmdClose ?? (_cmdClose = new RelayCommand(ExecCmdClose));
            }
        }
        #endregion | Properties |

        #region | Constructors |
        public LoginVM(IContentProvider<Employee> contentProvider)
        {
            _contentProvider = contentProvider;
        }
        #endregion | Constructors |

        #region | Methods |
        private void ExecCmdLogin(object param)
        {
            if (_contentProvider != null)
            {
                var agent = _contentProvider.Query()
                    .Where(e => e.UserName.CompareTo(UserName) == 0 && e.Password.CompareTo(Password) == 0).FirstOrDefault();
               
                if(agent!=null)
                {
                    _loggedInAgentModel = agent;
                    LoggedInAgentId = _loggedInAgentModel.Id;
                    IsLoggedIn = true;
                }

                UserName = null;

                if (agent == null)
                    LoginErrMsg = "Wrong username or password.\nTry again!";
            }            
        }

        private bool CanExecCmdLogin(object param)
        {
            bool canExecute = false;
            if (!String.IsNullOrEmpty(UserName)
                && !String.IsNullOrEmpty(Password))
                canExecute = true;
            return canExecute;
        }

        private void ExecCmdClose(object param)
        {
            App.Current.Shutdown();
        }
        #endregion | Methods |
    }
}
