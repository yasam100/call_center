using PresentationLayer.Models;
using PresentationLayer.Models.ContentLayerDummy;
using PresentationLayer.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class ServiceCallsVM : QiudVMBase<ServiceCall>
    {
        #region | Fields |
        private IContentProvider<ServiceCall> _contentProvider;
        private ObservableCollection<ServiceCallVM> _dataCollection;
        private ServiceCallVM _selected;
        private int _selectedItemIndex;
        #endregion | Fields |

        #region | Properties |
        protected override IContentProvider<ServiceCall> ContentProvider
        {
            get
            {
                return _contentProvider;
            }
        }

        public ObservableCollection<ServiceCallVM> DataCollection
        {
            get
            {
                return _dataCollection;
            }
            private set
            {
                _dataCollection = value;
                RaisePropertyChanged();
            }
        }

        public ServiceCallVM Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                if (!ServiceCallVM.Equals(_selected, value))
                {
                    _selected = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int SelectedItemIndex
        {
            get
            {
                return _selectedItemIndex;
            }
            set
            {
                if(_selectedItemIndex!=value)
                {
                    _selectedItemIndex = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion | Properties |

        #region | Constructor |
        public ServiceCallsVM(IContentProvider<ServiceCall> contentProvider)
        {
            _contentProvider = contentProvider;
            GetData();
        }
        #endregion | Constructor |

        #region | Methods |
        protected override void GetData()
        {
            //ThrobberVisible = Visibility.Visible;
            var serviceCalls = ContentProvider.Query()
                .OrderByDescending(sc => sc.OpenDate)
                .Select(sc => new ServiceCallVM { Model = sc })
                .ToList();
            //  await Task.Delay(9000);
            if (serviceCalls.Count > 0)
            {
                DataCollection = new ObservableCollection<ServiceCallVM>(serviceCalls);
            }
            //ThrobberVisible = Visibility.Collapsed;
        }

        #endregion | Methods |
    }
}
