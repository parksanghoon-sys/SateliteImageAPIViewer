using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UserControlExample
{
    public static class ViewFactory
    {
        private readonly static Dictionary<Type,UserControl> _viewCache= new Dictionary<Type,UserControl>();
        public static UserControl GetView(Type type)
        {
            if (_viewCache.ContainsKey(type) == false)
            {
                var userControl = Activator.CreateInstance(type) as UserControl;
                if(userControl == null)
                {
                    throw new InvalidOperationException("Couldn't crre uer Control " + type);
                }
                _viewCache.Add(type, userControl);
            }
            return _viewCache[type];
        }
    }
}
