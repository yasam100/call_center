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
    public class MainVM : ViewModelBase
    {
        #region | Event |

        #endregion | Events |

        #region | Fields |
   
        private ContentDummy.EmployeeContentProviderDummy _staffContentProvider = new ContentDummy.EmployeeContentProviderDummy();
        private ContentDummy.CustomerContentProviderDummy _customersContentProvider = new ContentDummy.CustomerContentProviderDummy();
        private ContentDummy.ServiceCallContentProviderDummy _serviceCallsContentProvider = new ContentDummy.ServiceCallContentProviderDummy();
        
        private Nullable<int> _loggedAgentId = null;
        private Employee _loggedAgentModel = null;

        private LoginVM _loginViewModel = null;
        private ServiceCallsVM _masterViewModel = null;
        private DetailVM _detailViewModel = null;
        private string _statusBarMessage = null;

        private ICommand _cmdToggelOrder = null;
        private ICommand _cmdFilter = null;

        private ICommand _cmdServiceCallCreate = null;
        private ICommand _cmdServiceCallUpdate = null;
        private ICommand _cmdServiceCallDelete = null;
        private ICommand _cmdLogout = null;
        #endregion | Fields |

        #region | Properties |
        public Employee LoggedAgentModel
        {
            get
            {
                return _loggedAgentModel;
            }
        }

        public LoginVM LoginViewModel
        {
            get
            {
                if (_loginViewModel == null)
                {
                    _loginViewModel = new LoginVM(_staffContentProvider) { IsLoggedIn = false };
                    _loginViewModel.PropertyChanged += (s, a) =>
                    {
                        if (a.PropertyName != null && "LoggedInAgentId".CompareTo(a.PropertyName) == 0)
                        {
                            _loggedAgentId = ((LoginVM)s).LoggedInAgentId;
                            _loggedAgentModel = ((LoginVM)s).LoggedInAgentModel;
                            RaisePropertyChanged("LoggedAgentModel");
                        }
                    };
                }
                return _loginViewModel;
            }
        }

        public ServiceCallsVM MasterViewModel
        {
            get
            {
                if(_masterViewModel == null)
                {
                    _masterViewModel = new ServiceCallsVM(_serviceCallsContentProvider) { SelectedItemIndex = 0 };
                    _masterViewModel.PropertyChanged += (s, e) =>
                    {
                        if (e.PropertyName != null && "Selected".CompareTo(e.PropertyName) == 0)
                        {
                            DetailViewModel.Model = ((ServiceCallsVM)s).Selected.Model;
                        }
                    };
                }
                return _masterViewModel;
            }

        }

        public DetailVM DetailViewModel
        {
            get
            {
                if (_detailViewModel == null)
                {
                    _detailViewModel = new DetailVM(_customersContentProvider, _staffContentProvider);
                    _detailViewModel.Model.OpenByAgentId = _loggedAgentId;
                    _detailViewModel.Model.OpenByAgent = _loggedAgentModel;
                }
                return _detailViewModel;
            }
        }

        public string StatusBarMessage
        {
            get
            {
                return _statusBarMessage;
            }
            set
            {
                if(string.Compare(_statusBarMessage, value)!=0)
                {
                    _statusBarMessage = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand CmdToggleOrder
        {
            get
            {
                return _cmdToggelOrder ?? (_cmdToggelOrder = new RelayCommand(ExecCmdToggleOrder, CanExecCmdToggleOrder));
            }
        }
        public ICommand CmdFilter
        {
            get
            {
                return _cmdFilter ?? (_cmdFilter = new RelayCommand(ExecCmdFilter, CanExecCmdToggleOrder));
            }
        }

        public ICommand CmdServiceCallCreate
        {
            get
            {
                return _cmdServiceCallCreate ?? (_cmdServiceCallCreate = new RelayCommand(ExecCmdServiceCallCreate, CanExecCmdServiceCallCreate));
            }
        }

        public ICommand CmdServiceCallUpdate
        {
            get
            {
                return _cmdServiceCallUpdate ?? (_cmdServiceCallUpdate = new RelayCommand(ExecCmdServiceCallUpdate, CanExecCmdServiceCallUpdate));
            }
        }

        public ICommand CmdServiceCallDelete
        {
            get
            {
                return _cmdServiceCallDelete ?? (_cmdServiceCallDelete = new RelayCommand(ExecCmdServiceCallDelete, CanExecCmdServiceCallDelete));
            }
        }

        public ICommand CmdLogout
        {
            get
            {
                return _cmdLogout ?? (_cmdLogout = new RelayCommand(ExecCmdLogout, CanExecCmdLogout));
            }
        }
        #endregion | Properties |

        #region | Methods |
        private void ExecCmdToggleOrder(object param)
        {

        }

        private bool CanExecCmdToggleOrder(object param)
        {
            bool canExecute = false;
            if (MasterViewModel != null
                && MasterViewModel.DataCollection != null
                && MasterViewModel.DataCollection.Count > 0)
                canExecute = true;
            return canExecute;
        }

        private void ExecCmdFilter(object param)
        {
            string filterKey = null;
            if (param != null)
                filterKey = param.ToString().ToUpperInvariant();

            switch(filterKey)
            {
                case "OPENED":
                    break;
                case "CLOSED":
                    break;
            }
        }

        private void ExecCmdServiceCallCreate(object p)
        {

        }
        private bool CanExecCmdServiceCallCreate(object p)
        {
            bool canExecute = false;
            if (DetailViewModel != null)
                canExecute = true;
            return canExecute;
        }

        private void ExecCmdServiceCallUpdate(object p)
        {

        }
        private bool CanExecCmdServiceCallUpdate(object p)
        {
            bool canExecute = false;
            if (DetailViewModel != null && DetailViewModel.IsDirty)
                canExecute = true;
            return canExecute;
        }
        private void ExecCmdServiceCallDelete(object p)
        {

        }
        private bool CanExecCmdServiceCallDelete(object p)
        {
            bool canExecute = false;
            if (DetailViewModel != null
                && DetailViewModel.Model != null
                && DetailViewModel.Model.Id > 0)
                canExecute = true;
            return canExecute;
        }

        private void ExecCmdLogout(object p)
        {
            if (LoginViewModel != null)
                LoginViewModel.IsLoggedIn = false;
        }
        private bool CanExecCmdLogout(object p)
        {
            bool canExecute = false;
            if (LoginViewModel!= null && LoginViewModel.IsLoggedIn)
                canExecute = true;
            return canExecute;
        }
        #endregion | Metods |
    }
}
