using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace UserControlExample
{
    public class ViewCache : UserControl
    {

        public ViewCache() 
        {
            this.Unloaded += this.ViewCache_Unload;
        }
        void ViewCache_Unload(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= this.ViewCache_Unload;
            this.Content = null;
        }
        private Type _contentType;
        public Type ContentType
        {
            get { return _contentType; }
            set
            {
                if (this._contentType == value)
                {
                    return;
                }
                this._contentType = value;
                this.Content = ViewFactory.GetView(this._contentType);
            }
        }
    }
}
