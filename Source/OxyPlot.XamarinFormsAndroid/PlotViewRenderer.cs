﻿using OxyPlot.XamarinForms;
using OxyPlot.XamarinFormsAndroid;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

// Exports the renderer.
[assembly: ExportRenderer(typeof(PlotView), typeof(PlotViewRenderer))]

namespace OxyPlot.XamarinFormsAndroid
{
    using System.ComponentModel;

    using OxyPlot.XamarinAndroid;

    /// <summary>
    /// Provides a custom <see cref="OxyPlot.XamarinForms.PlotView" /> renderer for Xamarin.Android. 
    /// </summary>
    public class PlotViewRenderer : ViewRenderer<XamarinForms.PlotView, PlotView>
    {
        /// <summary>
        /// Raises the element changed event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<XamarinForms.PlotView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null)
            {
                return;
            }

            var plotView = new PlotView(this.Context)
            {
                Model = this.Element.Model,
                Controller = this.Element.Controller
            };

            if (this.Element.Model.Background.IsVisible())
            {
                plotView.Background = new Android.Graphics.Drawables.ColorDrawable(this.Element.Model.Background.ToColor());
            }

            this.SetNativeControl(plotView);
        }

        /// <summary>
        /// Raises the element property changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (this.Element == null || this.Control == null)
            {
                return;
            }

            if (e.PropertyName == XamarinForms.PlotView.ModelProperty.PropertyName)
            {
                this.Control.Model = Element.Model;
            }

            if (e.PropertyName == XamarinForms.PlotView.ControllerProperty.PropertyName)
            {
                this.Control.Controller = Element.Controller;
            }
        }
    }
}
