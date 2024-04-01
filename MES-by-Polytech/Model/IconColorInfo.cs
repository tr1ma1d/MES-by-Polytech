using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MES_by_Polytech.ViewModel
{
    internal class IconColorInfo : BindableBase
    {
        private Brush _color;
        public Brush Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }
    }
}
