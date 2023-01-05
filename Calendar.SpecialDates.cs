using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPersianCalendar
{
    public partial class Calendar : ContentView
    {

        #region SpecialDates

        public static readonly BindableProperty SpecialDatesProperty =
            BindableProperty.Create(nameof(SpecialDates), typeof(IEnumerable<SpecialDate>), typeof(Calendar), null,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    if (oldValue != null)
                    {
                        var observableCollection = oldValue as INotifyCollectionChanged;

                        if (observableCollection != null)
                        {
                            observableCollection.CollectionChanged -= (s, e) =>
                            {
                                var newItems = e.NewItems;
                                if (newItems != null)
                                {
                                    foreach (SpecialDate sd in newItems)
                                    {
                                        var buttons = (bindable as Calendar).buttons;
                                        var button = buttons.FirstOrDefault(d => d.Date.Value.Date == sd.Date.Date);
                                        (bindable as Calendar).SetButtonSpecial(button, sd);
                                    }
                                }

                                var oldItems = e.OldItems;
                                if (oldItems != null)
                                {
                                    foreach (SpecialDate sd in newItems)
                                    {
                                        (bindable as Calendar).ResetButton((bindable as Calendar).buttons.FirstOrDefault(d => d.Date.Value == sd.Date));
                                    }
                                }
                            };
                        }
                    }
                    if (newValue != null)
                    {
                        var observableCollection = newValue as INotifyCollectionChanged;

                        if (observableCollection != null)
                        {
                            observableCollection.CollectionChanged += (s, e) =>
                            {
                                var newItems = e.NewItems;
                                if (newItems != null)
                                {
                                    foreach (SpecialDate sd in newItems)
                                    {
                                        var buttons = (bindable as Calendar).buttons;
                                        var button = buttons.Where(d => d.Date.HasValue).FirstOrDefault(d => d.Date.Value.Date == sd.Date.Date);
                                        (bindable as Calendar).SetButtonSpecial(button, sd);
                                    }
                                }

                                var oldItems = e.OldItems;
                                if (oldItems != null)
                                {
                                    foreach (SpecialDate sd in oldItems)
                                    {
                                        (bindable as Calendar).ResetButton((bindable as Calendar).buttons.FirstOrDefault(d => d.Date.Value == sd.Date));
                                    }
                                }
                            };
                        }
                    }
                });


        public IEnumerable<SpecialDate> SpecialDates
        {
            get { return (IEnumerable<SpecialDate>)GetValue(SpecialDatesProperty); }
            set { SetValue(SpecialDatesProperty, value); }
        }

        #endregion

        public void RaiseSpecialDatesChanged()
        {
            ChangeCalendar(CalandarChanges.MaxMin);
        }

        protected void SetButtonSpecial(CalendarButton button, SpecialDate special)
        {
            if (button != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    button.BackgroundPattern = special.BackgroundPattern;
                    button.BackgroundImage = special.BackgroundImage;
                    button.FontSize = special.FontSize ?? button.FontSize;
                    button.BorderWidth = special.BorderWidth ?? button.BorderWidth;
                    button.BorderColor = special.BorderColor ?? button.BorderColor;
                    button.BackgroundColor = special.BackgroundColor ?? button.BackgroundColor;
                    button.TextColor = special.TextColor ?? button.TextColor;
                    button.FontAttributes = special.FontAttributes ?? button.FontAttributes;
                    button.FontFamily = special.FontFamily ?? button.FontFamily;
                    button.IsEnabled = special.Selectable;
                });
            }
        }
    }
}
