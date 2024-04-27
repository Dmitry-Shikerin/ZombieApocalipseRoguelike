using System;
using System.Collections.Generic;
using System.Linq;

namespace Sources.Frameworks.MVVM.Presentation.Exceptions
{
    public class NotFoundBindableViewException : Exception
    {
        public NotFoundBindableViewException(Type view, Type bindableView)
            : base($"Not found {bindableView.Name} in {view.Name}")
        {
        }

        public NotFoundBindableViewException(Type view, IEnumerable<Type> bindableViews)
            : base($"Not found {string.Join(", ", bindableViews.Select(type => type.Name))} " +
                   $"in {view.Name}")
        {
        }

    }
}