using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Login_UC.xaml
    /// </summary>
    public partial class Login_UC : UserControl
    {
        LoginVM _vwModel = null;

        public Login_UC()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (_vwModel == null)
            {
                _vwModel = (LoginVM)DataContext;
                if (_vwModel != null)
                    _vwModel.PropertyChanged += (s, a) =>
                      {
                          if (a != null
                          && string.Compare("UserName", a.PropertyName) == 0
                          && string.IsNullOrEmpty(_vwModel.UserName))
                              ((PasswordBox)sender).Clear();
                      };
            }

            if(_vwModel!=null)
            {
                _vwModel.Password = ((PasswordBox)e.OriginalSource).Password;
            }
        }
    }
}
