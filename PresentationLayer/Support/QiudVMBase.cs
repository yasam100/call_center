using PresentationLayer.Models.ContentLayerDummy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Support
{

    public abstract class QiudVMBase<T> : ViewModelBase
    {
        #region | Fields |
        //protected SalesContext db = new SalesContext();
        private IContentProvider<T> _contentProvider = null;
        private string errorMessage;

        private bool throbberVisible = false;
        protected bool isCurrentView = false;

        #endregion | Fields |

        #region | Properties |
        protected abstract IContentProvider<T> ContentProvider { get; }

        public bool ThrobberVisible
        {
            get { return throbberVisible; }
            set
            {
                throbberVisible = value;
                RaisePropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                RaisePropertyChanged();
            }
        }

        #endregion | Properties |

        #region | Constructors |
        protected QiudVMBase()
        {
            if(ContentProvider!=null)
                GetData();
        }
        #endregion | Constructors |

        #region | Methods |
        //protected abstract void CommitUpdates();

        //protected abstract void DeleteCurrent();

        protected virtual void RefreshData()
        {
            GetData();
        }
        protected abstract void GetData();

        #endregion | Methods |
    }
}