using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace UserControlExample.Behavior
{
    public class TextAcceptBehavior : Behavior<TextBox>
    {
        public Key AcceptKey { get; set; }
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.KeyDown += this.TextBoxOnKeyDown;
        }

        private void TextBoxOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == this.AcceptKey)
                return;
            var binding = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
            binding?.UpdateSource();
            this.AssociatedObject.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }
        protected override void OnDetaching()
        {
            this.AssociatedObject.KeyDown -= this.TextBoxOnKeyDown;
            base.OnDetaching();
        }
    }
}
