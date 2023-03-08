using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame이용한_팝업처리
{
    public interface IView
    {
        
    }
    public interface IMainView : IView
    {
        public bool? ShowPopupWindow();
    }
}
