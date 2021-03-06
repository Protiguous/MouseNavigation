﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

namespace Tvl.VisualStudio.MouseNavigation
{
    using System.ComponentModel.Composition;
    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.Utilities;

    using SVsServiceProvider = Microsoft.VisualStudio.Shell.SVsServiceProvider;
    using UIElement = System.Windows.UIElement;

    [Export(typeof(IMouseProcessorProvider))]
    [Order]
    [ContentType("text")]
    [Name("MouseNavigation")]
    [TextViewRole(PredefinedTextViewRoles.Interactive)]
    internal class MouseNavigationProvider : IMouseProcessorProvider
    {
        [Import]
        public SVsServiceProvider ServiceProvider
        {
            get;
            private set;
        }

        public IMouseProcessor GetAssociatedProcessor(IWpfTextView wpfTextView)
        {
            if (!(wpfTextView is UIElement))
                return null;

            return new MouseNavigationProcessor(wpfTextView, ServiceProvider);
        }
    }
}
